Imports System.Windows.Forms
Imports System.Drawing
Imports SwdevIUICore

Public Class PageListTemplate
    Inherits PageTemplate


    Protected hashCheckedRowIndex As New Hashtable
    Property showAddButton As Boolean = True
    Property showEditButton As Boolean = True
    Property showDeleteButton As Boolean = True

    Property PROCEDURE_SEARCH As String

    Property FORM_ENTRY_NAME As String

    Property PROCEDURE_MASTER As String

    Property REPORT_NAME As String

    Property SELECT_PARAMETER As Object()

    Property DELETE_PARAMETER As Object()

    Property SEARCH_PARAMETER As Object()
    Dim WithEvents clsView As clsReportPreview
    Public Event EnterReportPage As System.EventHandler

    Property showCetakButton As Boolean = False

    Property HideFirstColumn As Boolean = True

    Property isEntryEmbedded As Boolean

    Public Property UseExtendedPanel As Boolean = False

    Public Property ExtendedPanelContent As UserControl

    Public Sub RefreshTablePencarian(ByVal namakolom As String, ByVal katakunci As String)
        Dim dt As New DataTable
        'Dim dsrole As New DataSet
        prepareSearchParameter(namakolom, katakunci)

        If Utils.executeSP(PROCEDURE_SEARCH, SEARCH_PARAMETER, dt) Then
            If dt IsNot Nothing Then
                dgvList.DataSource = dt
            End If
        End If
    End Sub
    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshTablePencarian(ComCariBy.Text, TextKataKunci.Text)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If Not isEntryEmbedded Then


            'case if using popup
            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            Dim popUp As PopupWindow = New PopupWindow
            popUp.pnlUtama.Controls.Clear()
            popUp.pnlUtama.Controls.Add(FormEntry)
            Dim lastrow As Integer = -1
            If dgvList.CurrentRow IsNot Nothing Then
                lastrow = dgvList.CurrentRow.Cells(0).RowIndex
            End If
            Dim newsize As Size = Drawing.Size.Add(FormEntry.Size, New Size(12, 20))
            If newsize.Width < 500 Then newsize.Width = 520
            FormEntry.PROCEDURE_MASTER = PROCEDURE_MASTER
            FormEntry.Dock = DockStyle.Fill
            FormEntry.FormMode = PageEntryTemplate.FormModeEnum.ADD
            FormEntry.InstancePageTemplate = Me
            FormEntry.prepareForAddition()
            popUp.Text = Application.ProductName
            popUp.Size = newsize

            popUp.ShowDialog()
            If FormEntry.result = DialogResult.OK Then
                'after call
                refreshDataGrid()
                'TODO : how to select all the newly added row?? :)
                If lastrow < 0 Then lastrow = dgvList.Rows.Count - 1
                dgvList.Rows(lastrow).Selected = True

            End If
            popUp.Hide()
        Else

            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            FormEntry.FormMode = PageEntryTemplate.FormModeEnum.ADD
            FormEntry.prepareForAddition()
            FormEntry.prepareEnabled(True)
            FormEntry.prepareFirstFocus()
            pnlKonfirmasi.Visible = True
            pnlKonfirmasi.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not isEntryEmbedded Then
            'case if using popup
            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            Dim popUp As PopupWindow = New PopupWindow
            popUp.pnlUtama.Controls.Clear()
            popUp.pnlUtama.Controls.Add(FormEntry)
            Dim newsize As Size = Drawing.Size.Add(FormEntry.Size, New Size(12, 20))
            If newsize.Width < 500 Then newsize.Width = 520
            FormEntry.FormMode = PageEntryTemplate.FormModeEnum.EDIT
            FormEntry.Dock = DockStyle.Fill
            FormEntry.InstancePageTemplate = Me
            FormEntry.PROCEDURE_MASTER = PROCEDURE_MASTER
            Dim kode As String = dgvList.CurrentRow.Cells(1).Value
            Dim lastrow As Integer = dgvList.CurrentRow.Cells(1).RowIndex
            FormEntry.prepareForEdit(kode)
            popUp.Text = Application.ProductName
            popUp.Size = newsize
            popUp.ShowDialog()
            If FormEntry.result = DialogResult.OK Then
                'after call

                refreshDataGrid()
                dgvList.Rows(lastrow).Selected = True
            End If
            popUp.Hide()
        Else
            If dgvList.CurrentRow Is Nothing Then
                MessageBox.Show("Pilih salah satu berkas permohonan terlebih dahulu")
                Return
            End If

            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            Dim kode As String = dgvList.CurrentRow.Cells(1).Value
            Dim lastrow As Integer = dgvList.CurrentRow.Cells(1).RowIndex
            pnlKonfirmasi.Visible = True
            pnlKonfirmasi.BringToFront()
            FormEntry.FormMode = PageEntryTemplate.FormModeEnum.EDIT
            FormEntry.prepareForEdit(kode)
            FormEntry.prepareEnabled(True)
            FormEntry.prepareFirstFocus()

        End If
    End Sub


    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        'MsgBox(hashCheckedRowIndex.Count)
        If hashCheckedRowIndex.Count = 0 Then 'dgvList.CurrentRow Is Nothing 
            MessageBox.Show("Centang baris data yang akan dihapus terlebih dahulu sebelum menghapus", "PassBandara", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim lastrow As Integer = dgvList.CurrentRow.Cells(0).RowIndex
        Dim kode As String = dgvList.CurrentRow.Cells(1).Value.ToString
        Dim nama As String = dgvList.CurrentRow.Cells(2).Value.ToString
        Dim retval As Integer = MessageBox.Show("Apakah anda yakin akan menghapus " & hashCheckedRowIndex.Count & " data ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If retval = DialogResult.Yes Then
            For Each r As DataGridViewRow In hashCheckedRowIndex.Values
                kode = r.Cells(1).Value
                nama = r.Cells(2).ToString
                prepareDeleteParameter(kode)
                If Utils.exec_SP(PROCEDURE_MASTER, DELETE_PARAMETER) Then
                    'MessageBox.Show("Data berhasil dihapus.")
                    Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|delete", kode, Session.vusername})
                    'refreshDataGrid()
                    lastrow = lastrow - 1
                    If lastrow < 0 Then lastrow = 0
                    If dgvList.Rows.Count > 0 Then dgvList.Rows(lastrow).Selected = True
                Else
                    MessageBox.Show("Data gagal dihapus " & nama)
                End If
            Next
        End If
        If isEntryEmbedded Then
            refreshDataGrid()
        End If

    End Sub
    'TOFIX. Now let convert Master dokter into this
    'after that, another master
    Public Sub btnCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCetak.Click
        Dim strReportPath As String
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim errmsg As String = ""

        strReportPath = Application.StartupPath & "\Reports\" & REPORT_NAME
        Try
            If Utils.executeSP(PROCEDURE_MASTER, New Object() {"select", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", Now.ToString("yyyy-MM-dd"), "0", "0", 0, 0, 0, 0, 0}, dt) Then
                If dt IsNot Nothing Then

                    'Dim clsView As New clsReportPreview(dt, strReportPath)
                    clsView = New clsReportPreview(dt, strReportPath)
                    prepareReport(clsView)
                    clsView.ShowReport()
                    ds.Dispose()
                End If
            End If


            Me.Cursor = Cursors.Default
            If errmsg <> "" Then
                MsgBox(errmsg)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Overrides Sub Refresh()
        MyBase.Refresh()
        Dim lastrow As Integer = -1
        If dgvList.CurrentRow IsNot Nothing Then
            lastrow = dgvList.CurrentRow.Cells(0).RowIndex
        End If
        refreshDataGrid()
        'todo : still refreshing the 2nd item will make it on top
        If dgvList.Rows.Count > 0 And lastrow >= 0 Then dgvList.Rows(lastrow).Selected = True
    End Sub
    Public Overrides Sub refreshDataGrid()
        MyBase.refreshDataGrid()
        Dim dt As New DataTable
        If SELECT_PARAMETER IsNot Nothing Then
            If Utils.executeSP(PROCEDURE_MASTER, SELECT_PARAMETER, dt) Then

                hashCheckedRowIndex.clear()
                If dt.Rows.Count > 0 Then
                    dgvList.Columns.Clear()
                    dgvList.DataSource = dt
                    dgvList.Columns(dgvList.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    dgvList.Columns(0).Visible = Not HideFirstColumn

                    'checkbox columns http://www.codeproject.com/KB/grid/CheckBoxHeaderCell.aspx
                    Dim colCB As New DataGridViewCheckBoxColumn 'colCB = new DataGridViewCheckBoxColumn();
                    Dim cbHeader As New DataGridViewColumnHeaderCheckBoxCell  'cbHeader = new DatagridViewCheckBoxHeaderCell();

                    colCB.HeaderCell = cbHeader
                    dgvList.Columns.Insert(0, colCB)
                    dgvList.Columns(0).ReadOnly = False
                    dgvList.ReadOnly = False
                Else
                    dgvList.Columns.Clear()
                    dgvList.DataSource = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub PageListTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAdd.Visible = showAddButton
        btnEdit.Visible = showEditButton
        btnDel.Visible = showDeleteButton
        btnCetak.Visible = showCetakButton
        prepareDisplay()
        refreshDataGrid()

    End Sub

    Overridable Sub prepareDeleteParameter(ByVal kode As String)

    End Sub

    Overridable Sub prepareSearchParameter(ByVal namakolom As String, ByVal katakunci As String)
        'default to this (old Cosmedic)
        SEARCH_PARAMETER = New Object() {namakolom, katakunci}
    End Sub



    Private Sub TextKataKunci_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextKataKunci.TextChanged
        btnCari_Click(Nothing, Nothing)
    End Sub

    Private Sub TextKataKunci_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextKataKunci.KeyDown
        If e.KeyCode = Keys.Escape Then
            TextKataKunci.Text = ""
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'default to list all column

    End Sub
    Sub defaultAllColumn(ByVal tabel As String)
        Dim dt As New DataTable
        If Utils.executeSP("proc_showallcolumn", New Object() {tabel}, dt) Then
            ComCariBy.Items.Clear()
            For Each row As DataRow In dt.Rows
                ComCariBy.Items.Add(row(0))
            Next
        End If


    End Sub

    Overridable Sub prepareReport(ByVal clsView As clsReportPreview)

    End Sub


    Private Sub clsView_EnterReportPage(ByVal sender As Object, ByVal e As System.EventArgs) Handles clsView.EnterReportPage
        'EventBroadcaster.doEnterReportPage(report)
        Dim report As PageTemplate = sender
        RaiseEvent EnterReportPage(report, New EventArgs())
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        dgvList.Focus()
    End Sub

    Public Sub prepareDisplay()
        If isEntryEmbedded Then
            pnlForm.Visible = True
            Dim entryForm As PageTemplate = Pages.Item(FORM_ENTRY_NAME)
            entryForm.Dock = DockStyle.Fill
            pnlForm.Size = entryForm.Size
            entryForm.prepareEnabled(False) '.Enabled = False 'start with disable state
            entryForm.Refresh()
            pnlForm.Controls.Add(entryForm)
        Else
            pnlForm.Visible = False
        End If

        If UseExtendedPanel Then
            pnlExtended.Visible = True
            ExtendedPanelContent.Dock = DockStyle.Fill
            pnlExtended.Controls.Add(ExtendedPanelContent)
        Else
            pnlExtended.Visible = False
        End If
    End Sub

    Private Sub dgvList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellClick
        dgvList_SelectionChanged(sender, Nothing)
    End Sub


    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If dgvList.CurrentRow IsNot Nothing AndAlso isEntryEmbedded Then
            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            Dim kode As String
            Dim lastrow As Integer

            'this if else is handing the addition of checkbox column
            If IsNumeric(dgvList.CurrentRow.Cells(0).Value) Then
                kode = dgvList.CurrentRow.Cells(0).Value
                lastrow = dgvList.CurrentRow.Cells(0).RowIndex
            Else
                kode = dgvList.CurrentRow.Cells(1).Value
                lastrow = dgvList.CurrentRow.Cells(1).RowIndex
            End If
             
            FormEntry.PROCEDURE_MASTER = PROCEDURE_MASTER
            FormEntry.prepareForEdit(kode)
        End If
    End Sub

    Sub selectGrid()
        dgvList_SelectionChanged(dgvList, Nothing)
    End Sub

    Private Sub btnSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click
        'make sure isembed
        If isEntryEmbedded Then
            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            FormEntry.btnSaveAndClose_Click(Nothing, Nothing)
            pnlKonfirmasi.Visible = False
            pnlKonfirmasi.SendToBack()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'make sure isembed
        If isEntryEmbedded Then
            Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
            FormEntry.btnCancel_Click_1(Nothing, Nothing)
            pnlKonfirmasi.Visible = False
            pnlKonfirmasi.SendToBack()
        End If
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If (e.ColumnIndex = 0) Then
            dgvList.Rows(e.RowIndex).Cells(0).Value = Not dgvList.Rows(e.RowIndex).Cells(0).Value
            hashCheckedRowIndex.Remove(e.RowIndex)

            If dgvList.Rows(e.RowIndex).Cells(0).Value Then
                hashCheckedRowIndex.Add(e.RowIndex, dgvList.Rows(e.RowIndex))

            End If
        End If
    End Sub
End Class
