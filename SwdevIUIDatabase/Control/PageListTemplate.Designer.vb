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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.TextKataKunci = New System.Windows.Forms.TextBox()
        Me.ComCariBy = New System.Windows.Forms.ComboBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
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
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.pnlKonfirmasi.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        Me.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.GridColor = System.Drawing.Color.DarkKhaki
        Me.dgvList.Location = New System.Drawing.Point(0, 215)
        Me.dgvList.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.ShowEditingIcon = False
        Me.dgvList.Size = New System.Drawing.Size(1141, 551)
        Me.dgvList.TabIndex = 34
        '
        'TextKataKunci
        '
        Me.TextKataKunci.Location = New System.Drawing.Point(368, 19)
        Me.TextKataKunci.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextKataKunci.Name = "TextKataKunci"
        Me.TextKataKunci.Size = New System.Drawing.Size(153, 27)
        Me.TextKataKunci.TabIndex = 24
        '
        'ComCariBy
        '
        Me.ComCariBy.FormattingEnabled = True
        Me.ComCariBy.Items.AddRange(New Object() {"-", "KODE", "NAMA", "SPESIALIS", "ALAMAT", "KOTA", "PROPINSI", "TELEPON", "EMAIL"})
        Me.ComCariBy.Location = New System.Drawing.Point(181, 19)
        Me.ComCariBy.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComCariBy.Name = "ComCariBy"
        Me.ComCariBy.Size = New System.Drawing.Size(175, 27)
        Me.ComCariBy.TabIndex = 23
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
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
        Me.pnlTop.Location = New System.Drawing.Point(0, 146)
        Me.pnlTop.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1141, 69)
        Me.pnlTop.TabIndex = 33
        '
        'pnlExtended
        '
        Me.pnlExtended.Location = New System.Drawing.Point(21, 9)
        Me.pnlExtended.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pnlExtended.Name = "pnlExtended"
        Me.pnlExtended.Size = New System.Drawing.Size(521, 56)
        Me.pnlExtended.TabIndex = 31
        Me.pnlExtended.Visible = False
        '
        'pnlKonfirmasi
        '
        Me.pnlKonfirmasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKonfirmasi.Controls.Add(Me.btnCancel)
        Me.pnlKonfirmasi.Controls.Add(Me.btnSaveAndClose)
        Me.pnlKonfirmasi.Location = New System.Drawing.Point(707, 9)
        Me.pnlKonfirmasi.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pnlKonfirmasi.Name = "pnlKonfirmasi"
        Me.pnlKonfirmasi.Size = New System.Drawing.Size(427, 56)
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
        Me.btnCancel.Location = New System.Drawing.Point(171, 6)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 45)
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
        Me.btnSaveAndClose.Location = New System.Drawing.Point(8, 4)
        Me.btnSaveAndClose.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(153, 45)
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
        Me.btnCetak.Location = New System.Drawing.Point(1035, 10)
        Me.btnCetak.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(101, 47)
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
        Me.btnDel.Location = New System.Drawing.Point(925, 10)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(101, 47)
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
        Me.btnEdit.Location = New System.Drawing.Point(816, 10)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(101, 47)
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
        Me.btnAdd.Location = New System.Drawing.Point(707, 10)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(101, 47)
        Me.btnAdd.TabIndex = 26
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 25)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(157, 19)
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
        Me.pnlForm.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(1141, 146)
        Me.pnlForm.TabIndex = 35
        '
        'PageListTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlForm)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "PageListTemplate"
        Me.Size = New System.Drawing.Size(1141, 766)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
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

End Class
