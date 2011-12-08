Imports System.Windows.Forms

Public Class Validation
    Public Shared ErrorProvider1 As ErrorProvider
    Shared Function required(ByVal sender As Object, ByVal e As System.EventArgs) As Boolean
        Dim e2 As System.ComponentModel.CancelEventArgs = e
        If sender.Text = "" Then
            ErrorProvider1.SetError(sender, "Nilai wajib diisi")
            e2.Cancel = True
        Else
            ErrorProvider1.SetError(sender, "")
            e2.Cancel = False
        End If
        Return True
    End Function
End Class
