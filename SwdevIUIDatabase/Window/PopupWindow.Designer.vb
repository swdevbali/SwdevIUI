<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.pnlUtama = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlUtama
        '
        Me.pnlUtama.BackColor = System.Drawing.Color.Beige
        Me.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUtama.Location = New System.Drawing.Point(0, 0)
        Me.pnlUtama.Name = "pnlUtama"
        Me.pnlUtama.Size = New System.Drawing.Size(614, 417)
        Me.pnlUtama.TabIndex = 0
        '
        'PopupWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(614, 417)
        Me.Controls.Add(Me.pnlUtama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PopupWindow"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "<Changed>"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlUtama As System.Windows.Forms.Panel

End Class
