Imports System.Windows.Forms

Public Class PopupWindow

    Private Sub PopupWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Hide()
    End Sub

    Sub clearControl()
        pnlUtama.Controls.Clear()
    End Sub

    Sub Add(ByVal FormEntry As PageEntryTemplate)
        pnlUtama.Controls.Add(FormEntry)
    End Sub

End Class
