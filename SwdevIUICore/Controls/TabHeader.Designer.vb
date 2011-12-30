<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabHeader
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tablePage = New System.Windows.Forms.TableLayoutPanel()
        Me.SuspendLayout()
        '
        'tablePage
        '
        Me.tablePage.ColumnCount = 2
        Me.tablePage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tablePage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tablePage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablePage.Location = New System.Drawing.Point(0, 0)
        Me.tablePage.Name = "tablePage"
        Me.tablePage.RowCount = 1
        Me.tablePage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablePage.Size = New System.Drawing.Size(808, 31)
        Me.tablePage.TabIndex = 0
        '
        'TabHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.tablePage)
        Me.Name = "TabHeader"
        Me.Size = New System.Drawing.Size(808, 31)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tablePage As System.Windows.Forms.TableLayoutPanel

End Class
