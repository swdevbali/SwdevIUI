Public Class EventBroadcaster
    Public Shared Event EnterReportPage As System.EventHandler
    Public Shared Event EnterDatabaseStatusChange As System.EventHandler
    Public Shared name As String

    Public Shared Event SettingsChange As System.EventHandler

    Public Shared Event CloseApplication As System.EventHandler


    Shared Sub doEnterReportPage(ByVal page As SwdevIUICore.PageTemplate)
        RaiseEvent EnterReportPage(page, Nothing) 'akan ditangani MainWindow
    End Sub

    Shared Sub doUpdateDatabaseStatus()
        RaiseEvent EnterDatabaseStatusChange(Nothing, Nothing)
    End Sub

    Shared Sub doSettingsChange()
        RaiseEvent SettingsChange(Nothing, Nothing)
    End Sub

    Shared Sub doCloseApplication()
        RaiseEvent CloseApplication(Nothing, Nothing)
    End Sub

End Class
