Imports System.Windows.Forms
Imports SwdevIUIDatabase
Imports SwdevIUICore

Public Class PageEntryTemplate
    Inherits PageTemplate

    Dim newItemAdded As Boolean

    Property PROCEDURE_MASTER As String 'copy from pagelistmaster
    Property CONTROL_CONTAINER As Control()
    Dim idkodelama As String

    Public Enum FormModeEnum
        ADD
        EDIT
    End Enum
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()



    End Sub

    Property InstancePageTemplate As PageTemplate
    Property InstancePageListTemplate As PageListTemplate

    Property FormMode As FormModeEnum

    Property SELECT_SINGLE_ROW_PARAMETER As Object()

    Property INSERT_PARAMETER As Object()

    Property UPDATE_PARAMETER As Object()

    Public Property result As DialogResult



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As Form = Parent.Parent
        frm.Close()
    End Sub

    Overridable Sub prepareForAddition()
        enableNewValue()
        prepareFirstFocus()
        prepareEnabled(True)
    End Sub


    Private Sub PageEntryTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ImageTitle IsNot Nothing Then picTitle.Image = ImageTitle
        lblTitle.Text = Title
        If InstancePageListTemplate IsNot Nothing AndAlso InstancePageListTemplate.isEntryEmbedded Then
            btnSaveAndClose.Visible = False
            btnCancel.Visible = False
        End If
    End Sub

    Public Sub btnSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click
        If FormMode = FormModeEnum.ADD Then
            doInsertNewData()
        Else
            doUpdateData()
            doAfterUpdateData()
        End If
        result = DialogResult.OK
        If InstancePageListTemplate.isEntryEmbedded Then
            InstancePageListTemplate.refreshDataGrid()
            InstancePageListTemplate.dgvList.Focus()
            prepareEnabled(False)
            InstancePageListTemplate.selectGrid()
        End If
        'Me.ParentForm.Hide()

    End Sub
    Overridable Sub doAfterUpdateData()

    End Sub

    Overridable Sub doInsertNewData()

        'Dim retval As Integer = MessageBox.Show("Apakah anda yakin akan menyimpan data ini ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If retval = DialogResult.Yes Then
        prepareInsertParameter()
        If Utils.exec_SP(PROCEDURE_MASTER, INSERT_PARAMETER) Then
            'MessageBox.Show("Data berhasil ditambahkan.")
            Dim kodeTransaksi As String
            'Actually I don't need this.. <==what a comment :))
            If INSERT_PARAMETER(2) IsNot Nothing Then kodeTransaksi = INSERT_PARAMETER(2) Else kodeTransaksi = INSERT_PARAMETER(1)

            Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|add", kodeTransaksi, Session.vusername, Nothing})
        Else
            MessageBox.Show("Data gagal ditambahkan.")
        End If
        'End If
    End Sub


    Private Sub btnSaveAndAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndAdd.Click
        doInsertNewData()
        FormMode = PageEntryTemplate.FormModeEnum.ADD 'switch to add mode :)
        prepareFirstFocus()
        prepareForAddition()
        newItemAdded = True
        InstancePageListTemplate.refreshDataGrid()
        doAfterInsertNewData()
    End Sub
    Overridable Sub doAfterInsertNewData()

    End Sub
    Overridable Sub prepareFirstFocus()

    End Sub

    Overridable Sub prepareForEdit(ByVal kode As String)
        idkodelama = kode
        Dim dt As New DataTable
        prepareSelectSingleRowParameter(kode)

        If Utils.executeSP(PROCEDURE_MASTER, SELECT_SINGLE_ROW_PARAMETER, dt) Then
            'enableNewValue()'FIX: this should solve the problem
            fillEditValue(dt)
        End If
    End Sub

    Protected Overridable Sub enableNewValue()
        If CONTROL_CONTAINER Is Nothing Then Return
        For Each Container As Control In CONTROL_CONTAINER
            For Each c As Control In Container.Controls
                c.Enabled = True
                If TypeOf c Is TextBox Then
                    c.Text = ""
                ElseIf TypeOf c Is ComboBox Then
                    Dim cmb As ComboBox = c
                    If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0 '                    cmb.Text = ""
                ElseIf TypeOf c Is DateTimePicker Then
                    Dim dt As DateTimePicker = c
                    'kasus harus check dulu sebelum milh date
                    If dt.ShowCheckBox Then
                        dt.Checked = False
                        dt.CustomFormat = " "
                    Else
                        dt.Value = Now
                    End If

                End If
            Next
        Next
    End Sub
    Protected Overridable Sub fillEditValue(ByVal dt As DataTable)
        If dt.Rows.Count = 0 Then
            Return
        End If
        For Each Container As Control In CONTROL_CONTAINER
            For Each c As Control In Container.Controls
                If c.Tag IsNot Nothing AndAlso c.Tag <> "" Then
                    If Not IsDBNull(dt.Rows(0).Item(c.Tag)) Then
                        If (TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox Or TypeOf (c) Is DateTimePicker) Then
                            If TypeOf (c) Is DateTimePicker Then
                                Dim tggl As DateTimePicker = c
                                Try
                                    tggl.Value = dt.Rows(0).Item(c.Tag).ToString
                                    If tggl.ShowCheckBox Then tggl.Checked = True
                                Catch ex As InvalidCastException
                                    tggl.CustomFormat = " "
                                End Try
                            ElseIf TypeOf (c) Is ComboBox Then
                                Dim cbo As ComboBox = c
                                'cbo.Text = dt.Rows(0).Item(c.Tag).ToString
                                If cbo.Items.Count > 0 AndAlso TypeOf (cbo.Items(0)) Is ValueDescriptionPair Then
                                    For Each o As ValueDescriptionPair In cbo.Items
                                        If o.Value IsNot Nothing AndAlso o.Value.ToString.Equals(dt.Rows(0).Item(c.Tag).ToString) Then
                                            cbo.SelectedItem = o
                                            Exit For
                                        End If
                                    Next
                                Else
                                    cbo.Text = dt.Rows(0).Item(c.Tag).ToString
                                End If
                            Else
                                c.Text = dt.Rows(0).Item(c.Tag)
                            End If
                        ElseIf TypeOf (c) Is CheckBox Then
                            Dim chk As CheckBox = c
                            chk.Checked = dt.Rows(0).Item(c.Tag)
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Overridable Sub doUpdateData()
        'TODO : mungkin ttg konfirmasi ini bs dibuat jd option yg bs ditoggle
        prepareUpdateParameter(idkodelama)
        'Dim retval As Integer = MessageBox.Show("Apakah anda yakin akan menyimpan data ini ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If retval = DialogResult.Yes Then
        If Utils.exec_SP(PROCEDURE_MASTER, UPDATE_PARAMETER) Then
            'MessageBox.Show("Data berhasil diupdate.")
            Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|edit", UPDATE_PARAMETER(2), Session.vusername, Nothing})
        Else
            MessageBox.Show("Data gagal diupdate.")
        End If
        'End If
    End Sub

    Public Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not newItemAdded Then
            ParentForm.DialogResult = DialogResult.Cancel
            result = DialogResult.Cancel
        Else
            ParentForm.DialogResult = DialogResult.OK
            result = DialogResult.OK
        End If
        newItemAdded = False
        If InstancePageListTemplate IsNot Nothing AndAlso Not InstancePageListTemplate.isEntryEmbedded Then
            ParentForm.Hide()
        Else
            prepareEnabled(False)
            InstancePageListTemplate.dgvList.Focus()
            InstancePageListTemplate.selectGrid()
        End If
    End Sub

    Overridable Sub prepareSelectSingleRowParameter(ByVal kode As String)

    End Sub

    Overridable Sub prepareInsertParameter()

    End Sub

    Overridable Sub prepareUpdateParameter(ByVal idkodelama As String)

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        prepareFirstFocus()
    End Sub
End Class
