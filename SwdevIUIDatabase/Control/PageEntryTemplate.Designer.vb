Imports SwdevIUICore

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageEntryTemplate
    Inherits PageTemplate

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
        Me.components = New System.ComponentModel.Container()
        Dim CBlendItems2 As gLabel.cBlendItems = New gLabel.cBlendItems()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New gLabel.gLabel()
        Me.picTitle = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveAndAdd = New System.Windows.Forms.Button()
        Me.btnSaveAndClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.picTitle)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSaveAndAdd)
        Me.Panel1.Controls.Add(Me.btnSaveAndClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1023, 58)
        Me.Panel1.TabIndex = 35
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.BorderWidth = 1.0!
        Me.lblTitle.FillType = gLabel.gLabel.eFillType.Solid
        Me.lblTitle.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.lblTitle.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems2.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.lblTitle.ForeColorBlend = CBlendItems2
        Me.lblTitle.Glow = 12
        Me.lblTitle.GlowColor = System.Drawing.Color.DarkGreen
        Me.lblTitle.GlowState = False
        Me.lblTitle.Location = New System.Drawing.Point(53, 4)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.MouseOver = False
        Me.lblTitle.MouseOverColor = System.Drawing.Color.Gray
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.PulseSpeed = 100
        Me.lblTitle.ShadowOffset = New System.Drawing.Point(3, 3)
        Me.lblTitle.Size = New System.Drawing.Size(318, 50)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.TabStop = True
        Me.lblTitle.Text = "<Changed to Title>"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picTitle
        '
        Me.picTitle.Location = New System.Drawing.Point(5, 7)
        Me.picTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.picTitle.Name = "picTitle"
        Me.picTitle.Size = New System.Drawing.Size(40, 45)
        Me.picTitle.TabIndex = 3
        Me.picTitle.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = Global.SwdevIUIDatabase.My.Resources.Resources._4tutup
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(919, 7)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 45)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveAndAdd
        '
        Me.btnSaveAndAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndAdd.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSaveAndAdd.FlatAppearance.BorderSize = 0
        Me.btnSaveAndAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnSaveAndAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnSaveAndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndAdd.Image = Global.SwdevIUIDatabase.My.Resources.Resources._1tambah
        Me.btnSaveAndAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndAdd.Location = New System.Drawing.Point(597, 9)
        Me.btnSaveAndAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveAndAdd.Name = "btnSaveAndAdd"
        Me.btnSaveAndAdd.Size = New System.Drawing.Size(152, 45)
        Me.btnSaveAndAdd.TabIndex = 1
        Me.btnSaveAndAdd.Text = "Save and &Add"
        Me.btnSaveAndAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAndAdd.UseVisualStyleBackColor = True
        Me.btnSaveAndAdd.Visible = False
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSaveAndClose.FlatAppearance.BorderSize = 0
        Me.btnSaveAndClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnSaveAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndClose.Image = Global.SwdevIUIDatabase.My.Resources.Resources.accept_item
        Me.btnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndClose.Location = New System.Drawing.Point(757, 9)
        Me.btnSaveAndClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(153, 45)
        Me.btnSaveAndClose.TabIndex = 0
        Me.btnSaveAndClose.Text = "&Save and Close"
        Me.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAndClose.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PageEntryTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PageEntryTemplate"
        Me.Size = New System.Drawing.Size(1023, 719)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSaveAndClose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSaveAndAdd As System.Windows.Forms.Button
    Friend WithEvents picTitle As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As gLabel.gLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
