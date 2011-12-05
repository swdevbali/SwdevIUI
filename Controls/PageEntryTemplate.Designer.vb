<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageEntryTemplate
    Inherits SwdevIUI.PageTemplate

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
        Dim CBlendItems1 As gLabel.cBlendItems = New gLabel.cBlendItems()
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
        Me.Panel1.BackColor = System.Drawing.Color.Beige
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.picTitle)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSaveAndAdd)
        Me.Panel1.Controls.Add(Me.btnSaveAndClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 40)
        Me.Panel1.TabIndex = 35
        '
        'lblTitle
        '
        Me.lblTitle.BorderWidth = 1.0!
        Me.lblTitle.FillType = gLabel.gLabel.eFillType.Solid
        Me.lblTitle.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.lblTitle.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.lblTitle.ForeColorBlend = CBlendItems1
        Me.lblTitle.Glow = 12
        Me.lblTitle.GlowColor = System.Drawing.Color.DarkGreen
        Me.lblTitle.Location = New System.Drawing.Point(40, 3)
        Me.lblTitle.MouseOver = False
        Me.lblTitle.MouseOverColor = System.Drawing.Color.Gray
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.PulseSpeed = 100
        Me.lblTitle.ShadowOffset = New System.Drawing.Point(3, 3)
        Me.lblTitle.Size = New System.Drawing.Size(145, 34)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.TabStop = True
        Me.lblTitle.Text = "<Changed to Title>"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picTitle
        '
        Me.picTitle.Location = New System.Drawing.Point(4, 5)
        Me.picTitle.Name = "picTitle"
        Me.picTitle.Size = New System.Drawing.Size(30, 31)
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
        Me.btnCancel.Image = Global.SwdevIUI.My.Resources.Resources._4tutup
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(689, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
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
        Me.btnSaveAndAdd.Image = Global.SwdevIUI.My.Resources.Resources._1tambah
        Me.btnSaveAndAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndAdd.Location = New System.Drawing.Point(569, 5)
        Me.btnSaveAndAdd.Name = "btnSaveAndAdd"
        Me.btnSaveAndAdd.Size = New System.Drawing.Size(114, 31)
        Me.btnSaveAndAdd.TabIndex = 1
        Me.btnSaveAndAdd.Text = "Save and &Add"
        Me.btnSaveAndAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAndAdd.UseVisualStyleBackColor = True
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSaveAndClose.FlatAppearance.BorderSize = 0
        Me.btnSaveAndClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnSaveAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndClose.Image = Global.SwdevIUI.My.Resources.Resources.accept_item
        Me.btnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndClose.Location = New System.Drawing.Point(448, 5)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(115, 31)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PageEntryTemplate"
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
