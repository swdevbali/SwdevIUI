Public Class UtilsCore

    Shared Function readFromReg(ByVal subsection As String, ByVal key As String, ByVal defaultValue As String) As String
        Dim result As String = GetSetting(Session.applicationName, subsection, key, "<empty>")
        If result = "<empty>" Then
            SaveSetting(Session.applicationName, subsection, key, defaultValue)
            result = defaultValue
        End If
        Return result
    End Function

    Shared Sub saveToReg(ByVal subsection As String, ByVal key As String, ByVal value As String)
        SaveSetting(Session.applicationName, subsection, key, value)

    End Sub

End Class
