Imports System.Windows.Forms
Imports SwdevIUICore

Public Class DatabaseSettingsPage
    Inherits PageTemplate
    'Dim WithEvents swdevIUIEvent As EventBroadcaster
    Private Sub btnTestKoneksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestKoneksi.Click


        Session.dbhost = txtHost.Text
        Session.dbport = txtPort.Text
        Session.dbuser = txtUser.Text
        Session.dbpassword = txtPassword.Text
        Session.dbname = txtDatabase.Text


        'Utils.init(My.Settings.dbname, My.Settings.dbhost, My.Settings.dbuser, My.Settings.dbpassword, My.Settings.dbport)
        If Utils.isConnected() Then
            MessageBox.Show("OK, connected to database " & Session.dbname & " at " & Session.dbhost)
        Else
            MessageBox.Show("Unable to established connection to database " & Session.dbname & " at " & Session.dbhost)
        End If
        EventBroadcaster.doUpdateDatabaseStatus()
    End Sub

    Private Sub DatabaseSettingsPage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtDatabase.Text = Session.dbname
        txtHost.Text = Session.dbhost
        txtPassword.Text = Session.dbpassword
        txtPort.Text = Session.dbport
        txtUser.Text = Session.dbuser
    End Sub
End Class
