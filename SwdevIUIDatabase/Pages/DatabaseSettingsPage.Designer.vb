Imports SwdevIUICore


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseSettingsPage
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
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnTestKoneksi = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.tabSettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabSettings
        '
        Me.tabSettings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabSettings.Controls.Add(Me.TabPage1)
        Me.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSettings.Location = New System.Drawing.Point(0, 0)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(851, 418)
        Me.tabSettings.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabSettings.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.btnTestKoneksi)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(843, 389)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Database"
        '
        'btnTestKoneksi
        '
        Me.btnTestKoneksi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki
        Me.btnTestKoneksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnTestKoneksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestKoneksi.Location = New System.Drawing.Point(128, 125)
        Me.btnTestKoneksi.Name = "btnTestKoneksi"
        Me.btnTestKoneksi.Size = New System.Drawing.Size(89, 23)
        Me.btnTestKoneksi.TabIndex = 0
        Me.btnTestKoneksi.Text = "Test Koneksi"
        Me.btnTestKoneksi.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtDatabase, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPassword, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUser, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPort, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHost, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(17, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 104)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(113, 87)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(84, 20)
        Me.txtDatabase.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(113, 66)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(84, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(113, 45)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(84, 20)
        Me.txtUser.TabIndex = 2
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(113, 24)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(84, 20)
        Me.txtPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "User"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Database"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Password"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(113, 3)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(84, 20)
        Me.txtHost.TabIndex = 0
        '
        'DatabaseSettingsPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tabSettings)
        Me.ImageTitle = Global.SwdevIUIDatabase.My.Resources.Resources.database_server
        Me.Name = "DatabaseSettingsPage"
        Me.Size = New System.Drawing.Size(851, 418)
        Me.Title = "Settings"
        Me.tabSettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnTestKoneksi As System.Windows.Forms.Button
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox

End Class
