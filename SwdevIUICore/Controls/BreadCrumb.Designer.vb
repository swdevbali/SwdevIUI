<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BreadCrumb
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
        Me.imgHome = New System.Windows.Forms.LinkLabel()
        Me.linkHome = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'imgHome
        '
        Me.imgHome.Image = Global.SwdevIUIcore.My.Resources.Resources.home
        Me.imgHome.Location = New System.Drawing.Point(0, 3)
        Me.imgHome.Name = "imgHome"
        Me.imgHome.Size = New System.Drawing.Size(24, 24)
        Me.imgHome.TabIndex = 0
        Me.imgHome.Tag = "-1"
        Me.imgHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linkHome
        '
        Me.linkHome.AutoSize = True
        Me.linkHome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.linkHome.Location = New System.Drawing.Point(31, 9)
        Me.linkHome.Name = "linkHome"
        Me.linkHome.Size = New System.Drawing.Size(35, 13)
        Me.linkHome.TabIndex = 1
        Me.linkHome.TabStop = True
        Me.linkHome.Tag = "0"
        Me.linkHome.Text = "Home"
        '
        'BreadCumb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.linkHome)
        Me.Controls.Add(Me.imgHome)
        Me.Name = "BreadCumb"
        Me.Size = New System.Drawing.Size(428, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgHome As System.Windows.Forms.LinkLabel
    Friend WithEvents linkHome As System.Windows.Forms.LinkLabel

End Class
