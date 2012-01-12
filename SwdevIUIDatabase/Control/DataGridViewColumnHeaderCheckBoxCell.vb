#Region "Imports"

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports System.ComponentModel

#End Region

Public Class DataGridViewColumnHeaderCheckBoxCell
    Inherits DataGridViewColumnHeaderCell

#Region "Fields"

    Private _Checked As Boolean
    Private _CheckBoxSize As Size
    Private _CheckBoxLocation As Point
    Private _CheckBoxBounds As Rectangle
    Private _CellLocation As New Point()
    Private _CheckBoxAlignment As HorizontalAlignment = HorizontalAlignment.Center

#End Region

#Region "Events"

    Public Event CheckBoxCheckedChanged As DataGridViewCheckBoxHeaderCellEvenHandler

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region "Properties"

    Event BeginToCheckColumnHeader()

    Event CheckBoxCellChangeValue(ByVal dataGridViewCellEventArgs As DataGridViewCellEventArgs)

    
    Public Property CheckBoxAlignment() As HorizontalAlignment
        Get
            Return _CheckBoxAlignment
        End Get
        Set(ByVal value As HorizontalAlignment)
            If Not [Enum].IsDefined(GetType(HorizontalAlignment), value) Then

                Throw New InvalidEnumArgumentException("value", CInt(value), GetType(HorizontalAlignment))
            End If
            If _CheckBoxAlignment <> value Then
                _CheckBoxAlignment = value
                If Me.DataGridView IsNot Nothing Then
                    Me.DataGridView.InvalidateCell(Me)
                End If
            End If
        End Set
    End Property

    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            If _Checked <> value Then
                _Checked = value
                If Me.DataGridView IsNot Nothing Then
                    'raise event
                    RaiseCheckBoxCheckedChanged()

                    Me.DataGridView.InvalidateCell(Me)
                End If
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Protected Overridable Sub OnCheckBoxCheckedChanged(ByVal e As DataGridViewCheckBoxHeaderCellEventArgs)
        RaiseEvent CheckBoxCheckedChanged(Me, e)
    End Sub

#End Region

#Region "Override"

    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As DataGridViewElementStates, ByVal value As Object, _
            ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        'checkbox bounds
        Dim state As CheckBoxState = Me.CheckBoxState
        _CellLocation = cellBounds.Location
        _CheckBoxSize = CheckBoxRenderer.GetGlyphSize(graphics, state)
        Dim p As New Point()
        p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (_CheckBoxSize.Height / 2)
        Select Case _CheckBoxAlignment
            Case HorizontalAlignment.Center
                p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (_CheckBoxSize.Width / 2) - 1
                Exit Select
            Case HorizontalAlignment.Left
                p.X = cellBounds.Location.X + 2
                Exit Select
            Case HorizontalAlignment.Right
                p.X = cellBounds.Right - _CheckBoxSize.Width - 4
                Exit Select
        End Select
        _CheckBoxLocation = p
        _CheckBoxBounds = New Rectangle(_CheckBoxLocation, _CheckBoxSize)

        'paint background
        paintParts = paintParts And Not DataGridViewPaintParts.ContentForeground
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, _
         formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        'paint foreground
        Select Case _CheckBoxAlignment
            Case HorizontalAlignment.Center
                cellBounds.Width = _CheckBoxLocation.X - cellBounds.X - 2
                Exit Select
            Case HorizontalAlignment.Left
                cellBounds.X += _CheckBoxSize.Width + 2
                cellBounds.Width -= _CheckBoxSize.Width + 2
                Exit Select
            Case HorizontalAlignment.Right
                cellBounds.Width -= _CheckBoxSize.Width + 4
                Exit Select
        End Select
        paintParts = DataGridViewPaintParts.ContentForeground
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, _
         formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        'paint check box           
        CheckBoxRenderer.DrawCheckBox(graphics, _CheckBoxLocation, state)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If Not Me.OwningColumn.ReadOnly Then
                'click on check box ?

                Dim p As New Point(_CellLocation.X + e.X, _CellLocation.Y + e.Y)
                If _CheckBoxBounds.Contains(p) Then
                    'raise event
                    'RaiseEvent 
                    RaiseCheckBoxCheckedChanged()
                End If
            End If
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs, ByVal rowIndex As Integer)
        If e.KeyCode = Keys.Space Then
            If Not Me.OwningColumn.ReadOnly Then
                'raise event
                RaiseCheckBoxCheckedChanged()
            End If
        End If
        MyBase.OnKeyDown(e, rowIndex)
    End Sub

    Public Overrides Function Clone() As Object
        Dim cell As DataGridViewColumnHeaderCheckBoxCell = TryCast(MyBase.Clone(), DataGridViewColumnHeaderCheckBoxCell)
        If cell IsNot Nothing Then
            cell.Checked = Me.Checked
        End If
        Return cell
    End Function

#End Region

#Region "Private"

    Private Sub RaiseCheckBoxCheckedChanged()
        'raise event
        Dim e As New DataGridViewCheckBoxHeaderCellEventArgs(Not _Checked)
        Me.OnCheckBoxCheckedChanged(e)
        If Not e.Cancel Then
            Me._Checked = e.Checked
            Me.DataGridView.InvalidateCell(Me)

            If Not e.Handled Then
                Me.SetColumnCheckBoxChecked(e.Checked)
            End If
        End If
    End Sub

    Private Sub SetColumnCheckBoxChecked(ByVal checked As Boolean)

        RaiseEvent BeginToCheckColumnHeader()
        For Each dgvr As DataGridViewRow In Me.DataGridView.Rows
            If (dgvr.IsNewRow) Then
                Continue For
            End If

            dgvr.Cells(Me.OwningColumn.Index).Value = checked
            RaiseEvent CheckBoxCellChangeValue(New DataGridViewCellEventArgs(Me.OwningColumn.Index, dgvr.Index))
        Next

        Dim currCell As DataGridViewCell = Me.DataGridView.CurrentCell
        If (currCell IsNot Nothing AndAlso currCell.ColumnIndex = Me.OwningColumn.Index) Then
            Me.DataGridView.RefreshEdit()
        End If
    End Sub

    Private ReadOnly Property CheckBoxState() As CheckBoxState
        Get
            Dim enabled As Boolean = True
            If MyBase.DataGridView IsNot Nothing AndAlso Not MyBase.DataGridView.Enabled Then
                enabled = False
            End If
            If enabled Then
                Return IIf((_Checked), CheckBoxState.CheckedNormal, CheckBoxState.UncheckedNormal)
            End If
            Return IIf((_Checked), CheckBoxState.CheckedDisabled, CheckBoxState.UncheckedDisabled)
        End Get
    End Property

#End Region

End Class

#Region "Events and Delegates"

Public Delegate Sub DataGridViewCheckBoxHeaderCellEvenHandler(ByVal sender As Object, ByVal e As DataGridViewCheckBoxHeaderCellEventArgs)

Public Class DataGridViewCheckBoxHeaderCellEventArgs
    Inherits CancelEventArgs

    Private _Checked As Boolean = False
    Private _Handled As Boolean = False

    Public Sub New(ByVal checkedValue As Boolean)
        MyBase.New()
        _Checked = checkedValue
    End Sub

    Public Sub New(ByVal checkedValue As Boolean, ByVal cancel As Boolean)
        MyBase.New(cancel)
        _Checked = checkedValue
    End Sub

    Public Sub New(ByVal checkedValue As Boolean, ByVal handled As Boolean, ByVal cancel As Boolean)
        MyBase.New(cancel)
        _Checked = checkedValue
        _Handled = handled
    End Sub

    Public ReadOnly Property Checked() As Boolean
        Get
            Return _Checked
        End Get
    End Property

    Public Property Handled() As Boolean
        Get
            Return _Handled
        End Get
        Set(ByVal value As Boolean)
            _Handled = value
        End Set
    End Property

End Class

#End Region