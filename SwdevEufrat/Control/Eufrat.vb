Imports System.IO
Imports System.Security.Cryptography
Imports SwdevIUICore
Imports System.Net

'It is .. Early User Feedback Response Auto Transcript
Public Class Eufrat
    Enum ApplicationPhase
        Phase0_Development
        Phase1_DevelopmentAndTesting
        Phase2_Deploy
        Phase3_Maintenance
    End Enum

    Public Shared MasterMachineIP As String
    'Public Shared MasterMachinePath As String
    'Public Shared AutoUpdateFilename As String
    Shared wc As New WebClient
    Shared localFile As String
    Shared remoteFile As String
    Public Shared Function isApplicationNewest()
        'MsgBox("Pinging..")
        Dim hasilPing As Boolean
        Try
            hasilPing = My.Computer.Network.Ping(MasterMachineIP)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        If hasilPing Then
            'MsgBox(MasterMachineIP & " is on, checking whether the file is the latest one")
            localFile = Session.StartupPath & "\AutoUpdate\PassBandaraUpdate.zip"
            remoteFile = "\\" & MasterMachineIP & "\AutoUpdate\PassBandaraUpdate.zip"
            If CompareFiles(localFile, remoteFile) Then
                'MsgBox("File identical, no need to update")
                Return True
            End If
        End If
        'MsgBox("There is new update available, comenching update...")
        Return False
    End Function

    Shared Sub doAutoUpdate()
        'AddHandler wc.DownloadFileCompleted, AddressOf downloadComplete
        Process.Start(Session.StartupPath & "\DoUpdateApplication.exe", remoteFile & " " & """" & localFile & """")
        'wc.DownloadFileAsync(New Uri(remoteFile), localFile)
        EventBroadcaster.doCloseApplication()
    End Sub
    Shared Sub downloadComplete(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
  
        ' Process.Start(Session.StartupPath & "\DoUpdateApplication.exe")
        'EventBroadcaster.doCloseApplication()
    End Sub
    Shared Sub extract()
        Dim cmd As String = """" & Session.StartupPath & "\Tools\unzip.exe"""
        Dim arg As String = "-o """ & localFile & """"
        Dim psi1 As New ProcessStartInfo(cmd, arg)
        psi1.CreateNoWindow = True
        Process.Start(psi1)
        MsgBox("Update process completed, please restart the application")
        EventBroadcaster.doCloseApplication()
    End Sub
    'http://www.freevbcode.com/ShowCode.asp?ID=5393
    Public Shared Function CompareFiles(ByVal FileFullPath1 As String, _
    ByVal FileFullPath2 As String) As Boolean

        'returns true if two files passed to is are identical, false
        'otherwise

        'does byte comparison; works for both text and binary files

        'Throws exception on errors; you can change to just return 
        'false if you prefer


        Dim objMD5 As New MD5CryptoServiceProvider()
        Dim objEncoding As New System.Text.ASCIIEncoding()

        Dim aFile1() As Byte, aFile2() As Byte
        Dim strContents1, strContents2 As String
        Dim objReader As StreamReader
        Dim objFS As FileStream
        Dim bAns As Boolean
        If Not File.Exists(FileFullPath1) Then _
            Throw New Exception(FileFullPath1 & " doesn't exist")
        If Not File.Exists(FileFullPath2) Then _
         Throw New Exception(FileFullPath2 & " doesn't exist")

        Try

            objFS = New FileStream(FileFullPath1, FileMode.Open)
            objReader = New StreamReader(objFS)
            aFile1 = objEncoding.GetBytes(objReader.ReadToEnd)
            strContents1 = _
              objEncoding.GetString(objMD5.ComputeHash(aFile1))
            objReader.Close()
            objFS.Close()


            objFS = New FileStream(FileFullPath2, FileMode.Open)
            objReader = New StreamReader(objFS)
            aFile2 = objEncoding.GetBytes(objReader.ReadToEnd)
            strContents2 = _
             objEncoding.GetString(objMD5.ComputeHash(aFile2))

            bAns = strContents1 = strContents2
            objReader.Close()
            objFS.Close()
            aFile1 = Nothing
            aFile2 = Nothing

        Catch ex As Exception
            Throw ex

        End Try

        Return bAns
    End Function
End Class
