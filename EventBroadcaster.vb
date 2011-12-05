Public Class EventBroadcaster
    Public Shared Event EnterReportPage As System.EventHandler
    Public Shared Event EnterDatabaseStatusChange As System.EventHandler
    Public Shared name As String


    Shared Sub doEnterReportPage(ByVal page As SwdevIUI.PageTemplate)
        RaiseEvent EnterReportPage(page, Nothing)
    End Sub

    Shared Sub doUpdateDatabaseStatus()
        RaiseEvent EnterDatabaseStatusChange(Nothing, Nothing)
    End Sub
End Class
