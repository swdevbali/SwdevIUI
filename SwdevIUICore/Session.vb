Public Class Session
    Public Shared dbhost As String = "192.168.10.1"
    Public Shared dbuser As String = "adbandara"
    Public Shared dbpassword As String = "passbandara"
    Public Shared dbname As String = "passbandara"
    Public Shared dbport As String = "3307"

    Public Shared isLoggedIn As Boolean

    Public Shared vkodeuser As String
    Public Shared username As String
    Public Shared password As String
    Public Shared vrolename As String
    Public Shared kodeRole As Integer

   

    Public Shared vusername As String
    Public Shared valamat As String
    Public Shared vtelepon As String
    Public Shared vfax As String
    Public Shared StartupPath As String
    Public Shared applicationName As String

    Public Shared Property serverberkas As String

    Shared Property activeView As PageTemplate

    Shared Sub loadDatabaseConfigurationFromRegistry()
        Session.dbhost = UtilsCore.readFromReg("Database", "dbhost", Session.dbhost)
        Session.dbuser = UtilsCore.readFromReg("Database", "dbuser", Session.dbuser)
        Session.dbpassword = UtilsCore.readFromReg("Database", "dbpassword", Session.dbpassword)
        Session.dbport = UtilsCore.readFromReg("Database", "dbport", Session.dbport)
        Session.dbname = UtilsCore.readFromReg("Database", "dbname", Session.dbname)
    End Sub

    Shared Sub saveDatabaseConfigurationToRegistry()
        UtilsCore.saveToReg("Database", "dbhost", Session.dbhost)
        UtilsCore.saveToReg("Database", "dbuser", Session.dbuser)
        UtilsCore.saveToReg("Database", "dbpassword", Session.dbpassword)
        UtilsCore.saveToReg("Database", "dbport", Session.dbport)
        UtilsCore.saveToReg("Database", "dbname", Session.dbname)
    End Sub
End Class
