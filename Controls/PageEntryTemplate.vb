Imports System.Windows.Forms
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

    Property PageList As PageTemplate


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
    End Sub


    Private Sub PageEntryTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ImageTitle IsNot Nothing Then picTitle.Image = ImageTitle
        lblTitle.Text = Title
    End Sub

    Private Sub btnSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click
        If FormMode = FormModeEnum.ADD Then
            doInsertNewData()
        Else
            doUpdateData()
        End If
        result = DialogResult.OK
        'Me.ParentForm.Hide()
    End Sub

    Overridable Sub doInsertNewData()

        'Dim retval As Integer = MessageBox.Show("Apakah anda yakin akan menyimpan data ini ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'If retval = DialogResult.Yes Then
        prepareInsertParameter()
        If Utils.exec_SP(PROCEDURE_MASTER, INSERT_PARAMETER) Then
            'MessageBox.Show("Data berhasil ditambahkan.")
            Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|add", INSERT_PARAMETER(2), Session.vusername})
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
        PageList.refreshDataGrid()
    End Sub

    Overridable Sub prepareFirstFocus()

    End Sub

    Overridable Sub prepareForEdit(ByVal kode As String)
        idkodelama = kode
        Dim dt As New DataTable
        prepareSelectSingleRowParameter(kode)

        If Utils.executeSP(PROCEDURE_MASTER, SELECT_SINGLE_ROW_PARAMETER, dt) Then
            enableNewValue()
            fillEditValue(dt)
        End If
    End Sub

    Protected Sub enableNewValue()
        If CONTROL_CONTAINER Is Nothing Then Return
        For Each Container As Control In CONTROL_CONTAINER
            For Each c As Control In Container.Controls
                c.Enabled = True
                If TypeOf c Is TextBox Then
                    c.Text = ""
                ElseIf TypeOf c Is ComboBox Then
                    Dim cmb As ComboBox = c
                    cmb.Text = ""
                ElseIf TypeOf c Is DateTimePicker Then
                    Dim dt As DateTimePicker = c
                    dt.Value = Now
                End If
            Next
        Next
    End Sub
    Protected Sub fillEditValue(ByVal dt As DataTable)
        For Each Container As Control In CONTROL_CONTAINER
            For Each c As Control In Container.Controls
                If c.Tag IsNot Nothing AndAlso c.Tag <> "" Then
                    If Not IsDBNull(dt.Rows(0).Item(c.Tag)) Then
                        If (TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox Or TypeOf (c) Is DateTimePicker) Then
                            If TypeOf (c) Is DateTimePicker Then
                                Dim tggl As DateTimePicker = c
                                tggl.Value = dt.Rows(0).Item(c.Tag).ToString
                            ElseIf TypeOf (c) Is ComboBox Then
                                Dim cbo As ComboBox = c
                                'cbo.Text = dt.Rows(0).Item(c.Tag).ToString
                                For Each o As ValueDescriptionPair In cbo.Items
                                    If o.Value.ToString.Equals(dt.Rows(0).Item(c.Tag).ToString) Then cbo.SelectedItem = o
                                Next
                            Else
                                c.Text = dt.Rows(0).Item(c.Tag)
                            End If
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
            Utils.exec_SP("proc_zloguser", New Object() {"add", PROCEDURE_MASTER & "|edit", UPDATE_PARAMETER(2), Session.vusername})
        Else
            MessageBox.Show("Data gagal diupdate.")
        End If
        'End If
    End Sub

    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Not newItemAdded Then
            ParentForm.DialogResult = DialogResult.Cancel
            result = DialogResult.Cancel
        Else
            ParentForm.DialogResult = DialogResult.OK
            result = DialogResult.OK
        End If
        newItemAdded = False
        ParentForm.Hide()
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
