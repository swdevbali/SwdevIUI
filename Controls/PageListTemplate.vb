Imports System.Windows.Forms
Imports System.Drawing

Public Class PageListTemplate
    Inherits PageTemplate

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

    Property showCetakButton As Boolean = True

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
        FormEntry.PageList = Me
        FormEntry.prepareForAddition()
        popUp.Text = Application.ProductName
        popUp.Size = newsize

        popUp.ShowDialog()
        If FormEntry.result = DialogResult.OK Then
            'after call
            refreshDataGrid()
            'TODO : how to select all the newly added row?? :)
            dgvList.Rows(lastrow).Selected = True

        End If
        popUp.Hide()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        'case if using popup
        Dim FormEntry As PageEntryTemplate = Pages.Item(FORM_ENTRY_NAME)
        Dim popUp As PopupWindow = New PopupWindow
        popUp.pnlUtama.Controls.Clear()
        popUp.pnlUtama.Controls.Add(FormEntry)
        Dim newsize As Size = Drawing.Size.Add(FormEntry.Size, New Size(12, 20))
        If newsize.Width < 500 Then newsize.Width = 520
        FormEntry.FormMode = PageEntryTemplate.FormModeEnum.EDIT
        FormEntry.Dock = DockStyle.Fill
        FormEntry.PageList = Me
        FormEntry.PROCEDURE_MASTER = PROCEDURE_MASTER
        Dim kode As String = dgvList.CurrentRow.Cells(0).Value
        Dim lastrow As Integer = dgvList.CurrentRow.Cells(0).RowIndex
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
    End Sub


    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim lastrow As Integer = dgvList.CurrentRow.Cells(0).RowIndex
        Dim kode As String = dgvList.CurrentRow.Cells(0).Value.ToString
        Dim nama As String = dgvList.CurrentRow.Cells(1).Value.ToString
        Dim retval As Integer = MessageBox.Show("Apakah anda yakin akan menghapus " & kode & " - " & nama & " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If retval = DialogResult.Yes Then
            prepareDeleteParameter(kode)
            If Utils.exec_SP(PROCEDURE_MASTER, DELETE_PARAMETER) Then
                'MessageBox.Show("Data berhasil dihapus.")
                Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|delete", kode, Session.vusername})
                refreshDataGrid()
                lastrow = lastrow - 1
                If lastrow < 0 Then lastrow = 0
                dgvList.Rows(lastrow).Selected = True
            Else
                MessageBox.Show("Data gagal dihapus.")
            End If

        End If


    End Sub
    'TOFIX. Now let convert Master dokter into this
    'after that, another master
    Private Sub btnCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCetak.Click
        Dim strReportPath As String
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim errmsg As String = ""

        strReportPath = Application.StartupPath & "\Reports\" & REPORT_NAME
        Try
            If Utils.executeSP(PROCEDURE_MASTER, New Object() {"select", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", Now.ToString("yyyy-MM-dd"), "0", "0"}, dt) Then
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
        If lastrow >= 0 Then dgvList.Rows(lastrow).Selected = True
    End Sub
    Public Overrides Sub refreshDataGrid()
        MyBase.refreshDataGrid()
        Dim dt As New DataTable
        If SELECT_PARAMETER IsNot Nothing Then
            If Utils.executeSP(PROCEDURE_MASTER, SELECT_PARAMETER, dt) Then
                If dt IsNot Nothing Then
                    dgvList.DataSource = dt
                    dgvList.Columns(dgvList.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If
        End If
    End Sub

    Private Sub PageListTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAdd.Visible = showAddButton
        btnEdit.Visible = showEditButton
        btnDel.Visible = showDeleteButton
        btnCetak.Visible = showCetakButton
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
End Class
