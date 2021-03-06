﻿Imports System.Windows.Forms
Imports System.Drawing
Imports SwdevIUICore

Public Class PageListTemplate
    Inherits PageTemplate
    Protected hashCheckedRowIndex As New Hashtable

    Property showAddButton As Boolean = True
    Property showEditButton As Boolean = True
    Property showDeleteButton As Boolean = True


    Property FORM_ENTRY_NAME As String

    Property PROCEDURE_MASTER As String

    Property REPORT_NAME As String

    Property SELECT_PARAMETER As Object()

    Property DELETE_PARAMETER As Object()
    Dim WithEvents clsView As clsReportPreview
    Public Event EnterReportPage As System.EventHandler

    Property showCetakButton As Boolean = False

    Property HideFirstColumn As Boolean = True

    Property isEntryEmbedded As Boolean

    Public Property UseExtendedPanel As Boolean = False

    Public Property ExtendedPanelContent As UserControl

#Region "Pencarian Data"
    Property PROCEDURE_SEARCH As String
    Property SEARCH_PARAMETER As Object()

    Sub defaultAllColumn(ByVal tabel As String)
        Dim dt As New DataTable
        If Utils.executeSP("proc_showallcolumn", New Object() {tabel}, dt) Then
            ComCariBy.Items.Clear()
            ComCariBy.Items.Add("--Pilih kolom pencarian--")
            For Each row As DataRow In dt.Rows
                ComCariBy.Items.Add(row(0))
            Next
        End If


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        timerCari = timerCari + 1
        If ComCariBy.SelectedIndex = 0 Then
            Timer2.Enabled = False
            refreshDataGrid()
            Return
        End If
        If timerCari >= 1 Then
            Timer2.Enabled = False
            pagePart = 0
            doPencarianData()
        End If
    End Sub

    Overridable Sub prepareSearchParameter(ByVal namakolom As String, ByVal katakunci As String)
        'default to this (old Cosmedic)
        SEARCH_PARAMETER = New Object() {"search", namakolom, katakunci, getPageStart(), pageLength}
    End Sub

    Protected Overridable Sub prepareCountPencarianParameter(ByVal namakolom As String, ByVal katakunci As String)
        COUNT_PARAMETER = New Object() {"count", namakolom, katakunci, Nothing, Nothing}
    End Sub
    Public Sub RefreshDataGridPencarian(ByVal namakolom As String, ByVal katakunci As String)
        Dim dt As New DataTable
        'Dim dsrole As New DataSet
        prepareSearchParameter(namakolom, katakunci)

        If Utils.executeSP(PROCEDURE_SEARCH, SEARCH_PARAMETER, dt) Then


            prepareCountPencarianParameter(namakolom, katakunci)
            If COUNT_PARAMETER IsNot Nothing Then
                Dim dtCount As New DataTable
                Utils.executeSP(PROCEDURE_SEARCH, COUNT_PARAMETER, dtCount)
                If dtCount.Rows.Count > 0 Then dataCount = dtCount.Rows(0).Item(0) Else dataCount = "~"
            End If
            lblPagination.Text = getPageStart() + 1 & "/" & dataCount


            If dt IsNot Nothing Then
                dgvList.DataSource = dt
            End If
        End If
    End Sub

    Private Sub doPencarianData()
        Me.Cursor = Cursors.WaitCursor
        RefreshDataGridPencarian(ComCariBy.Text, TextKataKunci.Text)
        Me.Cursor = Cursors.Default
    End Sub


#End Region

#Region "CRUD"
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
                kode = r.Cells(1).Value.ToString
                nama = r.Cells(2).Value.ToString  'ToString
                prepareDeleteParameter(kode)
                If Utils.exec_SP(PROCEDURE_MASTER, DELETE_PARAMETER) Then
                    'MessageBox.Show("Data berhasil dihapus.")
                    Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|delete", nama, Session.vusername, -1})
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
#End Region
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
        prepareSelectParamater()
        If SELECT_PARAMETER IsNot Nothing Then
            If Utils.executeSP(PROCEDURE_MASTER, SELECT_PARAMETER, dt) Then

                prepareCountParameter()
                If COUNT_PARAMETER IsNot Nothing Then
                    Dim dtCount As New DataTable
                    Utils.executeSP(PROCEDURE_MASTER, COUNT_PARAMETER, dtCount)
                    If dtCount.Rows.Count > 0 Then dataCount = dtCount.Rows(0).Item(0) Else dataCount = "~"
                Else
                    dataCount = -1
                End If
                Dim sDataCount As String = dataCount
                If sDataCount = "-1" Then sDataCount = "~"
                lblPagination.Text = getPageStart() + 1 & "/" & sDataCount

                hashCheckedRowIndex.Clear()
                If dt.Rows.Count > 0 Then
                    dgvList.Columns.Clear()
                    dgvList.DataSource = dt
                    dgvList.Columns(dgvList.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    dgvList.Columns(0).Visible = Not HideFirstColumn

                    'checkbox columns http://www.codeproject.com/KB/grid/CheckBoxHeaderCell.aspx
                    Dim colCB As New DataGridViewCheckBoxColumn 'colCB = new DataGridViewCheckBoxColumn();
                    Dim cbHeader As New DataGridViewColumnHeaderCheckBoxCell  'cbHeader = new DatagridViewCheckBoxHeaderCell();
                    AddHandler cbHeader.BeginToCheckColumnHeader, AddressOf DoBeginToCheckColumnHeader
                    AddHandler cbHeader.CheckBoxCellChangeValue, AddressOf DoCheckBoxCellChangeValue
                    colCB.HeaderCell = cbHeader
                    dgvList.Columns.Insert(0, colCB)
                    dgvList.Columns(0).ReadOnly = False
                    dgvList.ReadOnly = False
                Else
                    dgvList.Columns.Clear()
                    dgvList.DataSource = Nothing
                End If
            Else

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



    Dim timerCari As Integer
    Private Sub TextKataKunci_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextKataKunci.TextChanged
        If ComCariBy.SelectedIndex <= 0 Then Return
        Timer2.Enabled = False
        timerCari = 0
        Timer2.Enabled = True

    End Sub

    Private Sub TextKataKunci_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextKataKunci.KeyDown
        If e.KeyCode = Keys.Escape Then
            ComCariBy.SelectedIndex = 0
            TextKataKunci.Text = ""
            refreshDataGrid()
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'default to list all column

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

        If FORM_ENTRY_NAME IsNot Nothing AndAlso isEntryEmbedded Then 'case of ZLogUser : didn't had panl form
            Dim entryForm As PageTemplate = Pages.Item(FORM_ENTRY_NAME)
            If entryForm IsNot Nothing Then
                pnlForm.Visible = True
                entryForm.Dock = DockStyle.Fill
                pnlForm.Size = entryForm.Size
                entryForm.prepareEnabled(False) '.Enabled = False 'start with disable state
                entryForm.Refresh()
                pnlForm.Controls.Add(entryForm)
            End If
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

            If FormEntry IsNot Nothing Then 'trap for kasus log yg ga pnya form entry
                FormEntry.PROCEDURE_MASTER = PROCEDURE_MASTER
                FormEntry.prepareForEdit(kode)
            End If
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

#Region "CheckBox Column Header"
    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If (e.ColumnIndex = 0) Then
            dgvList.Rows(e.RowIndex).Cells(0).Value = Not dgvList.Rows(e.RowIndex).Cells(0).Value
            hashCheckedRowIndex.Remove(e.RowIndex)

            If dgvList.Rows(e.RowIndex).Cells(0).Value Then
                hashCheckedRowIndex.Add(e.RowIndex, dgvList.Rows(e.RowIndex))

            End If
        End If
    End Sub

    Private Sub DoBeginToCheckColumnHeader()
        'Throw New NotImplementedException
        hashCheckedRowIndex.Clear()
    End Sub

    Private Sub DoCheckBoxCellChangeValue(ByVal e As DataGridViewCellEventArgs)

        If dgvList.Rows(e.RowIndex).Cells(0).Value Then
            hashCheckedRowIndex.Add(e.RowIndex, dgvList.Rows(e.RowIndex))
        Else
            hashCheckedRowIndex.Remove(e.RowIndex)
        End If
    End Sub
#End Region

#Region "Pagination"
    Protected dataCount As Integer
    Protected pageLength As Integer = 20
    Protected pagePart As Integer = 0
    Protected COUNT_PARAMETER As Object()
    Public Overrides Sub OnEnterView()
        MyBase.OnEnterView()
        ComCariBy.SelectedIndex = -1
        TextKataKunci.Text = ""
    End Sub
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        If pagePart > 0 Then pagePart = pagePart - 1
        If ComCariBy.SelectedIndex <= 0 Then refreshDataGrid() Else doPencarianData()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim max As Integer = (dataCount / pageLength) - 1

        pagePart = pagePart + 1
        If pagePart > max Then pagePart = max
        If ComCariBy.SelectedIndex <= 0 Then refreshDataGrid() Else doPencarianData()

    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        pagePart = 0
        If ComCariBy.SelectedIndex <= 0 Then refreshDataGrid() Else doPencarianData()
    End Sub

    Protected Function getPageStart() As Integer
        Return pagePart * pageLength
    End Function

    Protected Overridable Sub prepareCountParameter()
    End Sub

    Protected Overridable Sub prepareSelectParamater()

    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        pagePart = (dataCount / pageLength) - 1
        If ComCariBy.SelectedIndex <= 0 Then refreshDataGrid() Else doPencarianData()
    End Sub

#End Region


End Class
