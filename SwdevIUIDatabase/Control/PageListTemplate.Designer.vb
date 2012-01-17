Imports SwdevIUICore

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageListTemplate
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.TextKataKunci = New System.Windows.Forms.TextBox()
        Me.ComCariBy = New System.Windows.Forms.ComboBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonItem()
        Me.lblPagination = New DevComponents.DotNetBar.LabelItem()
        Me.btnNext = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLast = New DevComponents.DotNetBar.ButtonItem()
        Me.pnlExtended = New System.Windows.Forms.Panel()
        Me.pnlKonfirmasi = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveAndClose = New System.Windows.Forms.Button()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKonfirmasi.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        Me.dgvList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        Me.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.GridColor = System.Drawing.Color.DarkKhaki
        Me.dgvList.Location = New System.Drawing.Point(0, 273)
        Me.dgvList.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.ShowEditingIcon = False
        Me.dgvList.Size = New System.Drawing.Size(1284, 574)
        Me.dgvList.TabIndex = 34
        '
        'TextKataKunci
        '
        Me.TextKataKunci.Location = New System.Drawing.Point(414, 21)
        Me.TextKataKunci.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.TextKataKunci.Name = "TextKataKunci"
        Me.TextKataKunci.Size = New System.Drawing.Size(172, 28)
        Me.TextKataKunci.TabIndex = 24
        '
        'ComCariBy
        '
        Me.ComCariBy.FormattingEnabled = True
        Me.ComCariBy.Items.AddRange(New Object() {"-", "KODE", "NAMA", "SPESIALIS", "ALAMAT", "KOTA", "PROPINSI", "TELEPON", "EMAIL"})
        Me.ComCariBy.Location = New System.Drawing.Point(204, 21)
        Me.ComCariBy.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.ComCariBy.Name = "ComCariBy"
        Me.ComCariBy.Size = New System.Drawing.Size(196, 29)
        Me.ComCariBy.TabIndex = 23
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Transparent
        Me.pnlTop.Controls.Add(Me.Bar1)
        Me.pnlTop.Controls.Add(Me.pnlExtended)
        Me.pnlTop.Controls.Add(Me.pnlKonfirmasi)
        Me.pnlTop.Controls.Add(Me.btnCetak)
        Me.pnlTop.Controls.Add(Me.btnDel)
        Me.pnlTop.Controls.Add(Me.btnEdit)
        Me.pnlTop.Controls.Add(Me.btnAdd)
        Me.pnlTop.Controls.Add(Me.TextKataKunci)
        Me.pnlTop.Controls.Add(Me.ComCariBy)
        Me.pnlTop.Controls.Add(Me.Label12)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 161)
        Me.pnlTop.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1284, 112)
        Me.pnlTop.TabIndex = 33
        '
        'Bar1
        '
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnFirst, Me.btnPrev, Me.lblPagination, Me.btnNext, Me.btnLast})
        Me.Bar1.Location = New System.Drawing.Point(24, 77)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(206, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.Bar1.TabIndex = 32
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnFirst
        '
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.ImagePaddingHorizontal = 8
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Text = "|<"
        '
        'btnPrev
        '
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.ImagePaddingHorizontal = 8
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Text = "<"
        '
        'lblPagination
        '
        Me.lblPagination.Name = "lblPagination"
        Me.lblPagination.Text = "113/45.232"
        Me.lblPagination.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblPagination.Width = 100
        '
        'btnNext
        '
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.ImagePaddingHorizontal = 8
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Text = ">"
        '
        'btnLast
        '
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.ImagePaddingHorizontal = 8
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Text = ">|"
        '
        'pnlExtended
        '
        Me.pnlExtended.Location = New System.Drawing.Point(24, 8)
        Me.pnlExtended.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.pnlExtended.Name = "pnlExtended"
        Me.pnlExtended.Size = New System.Drawing.Size(586, 62)
        Me.pnlExtended.TabIndex = 31
        Me.pnlExtended.Visible = False
        '
        'pnlKonfirmasi
        '
        Me.pnlKonfirmasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKonfirmasi.Controls.Add(Me.btnCancel)
        Me.pnlKonfirmasi.Controls.Add(Me.btnSaveAndClose)
        Me.pnlKonfirmasi.Location = New System.Drawing.Point(795, 10)
        Me.pnlKonfirmasi.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.pnlKonfirmasi.Name = "pnlKonfirmasi"
        Me.pnlKonfirmasi.Size = New System.Drawing.Size(480, 62)
        Me.pnlKonfirmasi.TabIndex = 30
        Me.pnlKonfirmasi.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = Global.SwdevIUIDatabase.My.Resources.Resources._4tutup
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(192, 7)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 50)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSaveAndClose.FlatAppearance.BorderSize = 0
        Me.btnSaveAndClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow
        Me.btnSaveAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen
        Me.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndClose.Image = Global.SwdevIUIDatabase.My.Resources.Resources.accept_item
        Me.btnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndClose.Location = New System.Drawing.Point(9, 4)
        Me.btnSaveAndClose.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(172, 50)
        Me.btnSaveAndClose.TabIndex = 7
        Me.btnSaveAndClose.Text = "&Save and Close"
        Me.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAndClose.UseVisualStyleBackColor = True
        '
        'btnCetak
        '
        Me.btnCetak.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCetak.BackColor = System.Drawing.Color.White
        Me.btnCetak.FlatAppearance.BorderColor = System.Drawing.Color.Beige
        Me.btnCetak.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki
        Me.btnCetak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige
        Me.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCetak.Image = Global.SwdevIUIDatabase.My.Resources.Resources._6print
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(1164, 11)
        Me.btnCetak.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(114, 52)
        Me.btnCetak.TabIndex = 29
        Me.btnCetak.Text = "Cetak"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCetak.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.Beige
        Me.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki
        Me.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Image = Global.SwdevIUIDatabase.My.Resources.Resources._3hapus
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.Location = New System.Drawing.Point(1041, 11)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(114, 52)
        Me.btnDel.TabIndex = 28
        Me.btnDel.Text = "Delete"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Beige
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Image = Global.SwdevIUIDatabase.My.Resources.Resources._2edit
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(918, 11)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(114, 52)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Beige
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = Global.SwdevIUIDatabase.My.Resources.Resources._1tambah
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(795, 11)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(114, 52)
        Me.btnAdd.TabIndex = 26
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 28)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 21)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Pencarian berdasarkan"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 800
        '
        'pnlForm
        '
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlForm.Location = New System.Drawing.Point(0, 0)
        Me.pnlForm.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(1284, 161)
        Me.pnlForm.TabIndex = 35
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'PageListTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlForm)
        Me.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Name = "PageListTemplate"
        Me.Size = New System.Drawing.Size(1284, 847)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKonfirmasi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCetak As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Public WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TextKataKunci As System.Windows.Forms.TextBox
    Friend WithEvents ComCariBy As System.Windows.Forms.ComboBox
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlKonfirmasi As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSaveAndClose As System.Windows.Forms.Button
    Friend WithEvents pnlExtended As System.Windows.Forms.Panel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblPagination As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

End Class
