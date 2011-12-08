Imports NetToolMysql_v12
Imports System.Windows.Forms
Imports SwdevIUI

Public Class Utils



    Public Shared Function isConnected() As Boolean
        Dim ReturnValue As Boolean = False
        Dim ErrMsg As String = ""
        Dim MySQL As NetToolMysql_v12.NetMysql
        Try
            'I changed this into returning false if dbname is not defined
            If Session.dbname = "" Then Return False
            MySQL = New NetToolMysql_v12.NetMysql(Session.dbname, Session.dbhost, Session.dbuser, Session.dbpassword, Session.dbport)
            MySQL.TesConnection(ErrMsg)

            If ErrMsg = "" Then
                ReturnValue = True
            Else
                ReturnValue = False
            End If
        Catch ex As Exception
            ReturnValue = False
        End Try
        Return ReturnValue
    End Function

    Public Shared Function getConnection() As NetMysql

        Dim ErrMsg As String = ""
        Dim MySQL As NetMysql = Nothing
        Try
            MySQL = New NetToolMysql_v12.NetMysql(Session.dbname, Session.dbhost, Session.dbuser, Session.dbpassword, Session.dbport)
            MySQL.TesConnection(ErrMsg)

            If Session.dbname = "" Then Return Nothing
            If ErrMsg = "" Then
                Return MySQL
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return MySQL
    End Function



    Public Shared Function executeSP(ByVal spname As String, ByVal param As Object(), ByRef dt As DataTable) As Boolean
        Dim errMsg As String = ""
        Dim RetrunValue As Boolean = False

        Try

            Dim condb As NetMysql = getConnection()
            dt = condb.MySQLExecuteProcedure(False, spname, errMsg, param)
            If errMsg = "" Then
                RetrunValue = True
            Else
                getmessagesystem(0, errMsg)
                RetrunValue = False
                Exit Try
            End If
        Catch ex As Exception
            getmessagesystem(0, ex.Message.ToString)
        End Try

        'End If
        Return RetrunValue

    End Function

    Public Shared Function exec_SP(ByVal spname As String, ByVal param As Object()) As Boolean
        Dim errMsg As String = ""
        Dim RetrunValue As Boolean = False

        If isConnected() Then
            Try

                Dim condb As NetMysql = getConnection()
                condb.MySQLExecuteProcedure(True, spname, errMsg, param)
                If errMsg = "" Then
                    RetrunValue = True
                Else
                    getmessagesystem(0, errMsg)
                    RetrunValue = False
                    Exit Try
                End If
            Catch ex As Exception
                getmessagesystem(0, ex.Message.ToString)
            End Try

        End If
        Return RetrunValue

    End Function

    Public Sub getmessage(ByVal messageoption As String)
        If messageoption = "koneksi0" Then
            MessageBox.Show("Koneksi Berhasil", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf messageoption = "koneksi-1" Then
            MessageBox.Show("Koneksi Gagal", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf messageoption = "simpan0" Then
            MessageBox.Show("Data Berhasil Disimpan", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf messageoption = "simpan-1" Then
            MessageBox.Show("Data Gagal Disimpan", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Shared Sub getmessagesystem(ByVal messagekode As Integer, ByVal messageoption As String)
        If messagekode = 0 Then
            MessageBox.Show(messageoption, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub setgrid(ByVal Grid As DataGridView, Optional ByVal ds As DataSet = Nothing, Optional ByVal dt As DataTable = Nothing)
        If ds IsNot Nothing Then
            If ds.Tables.Count > 0 Then
                Grid.DataSource = ds.Tables(0)
            End If
        Else
            If dt IsNot Nothing Then
                Grid.DataSource = dt
            End If
        End If
    End Sub

    Public Sub setgridbinding(ByVal Grid As DataGridView, Optional ByVal ds As DataSet = Nothing, Optional ByVal dt As DataTable = Nothing)
        If ds IsNot Nothing Then
            If ds.Tables.Count > 0 Then
                Dim bs As New BindingSource
                bs.DataSource = ds.Tables(0)
                Grid.DataSource = bs
            End If
        Else
            If dt IsNot Nothing Then
                Dim bs As New BindingSource
                bs.DataSource = dt
                Grid.DataSource = bs
            End If
        End If
    End Sub

    Public Function modcekangka(ByVal value As String) As Boolean
        Dim ReturnValue As Boolean
        Dim i As Integer
        If value <> "" Then
            Try
                i = CInt(value)
                ReturnValue = True
            Catch ex As Exception
                ReturnValue = False
            End Try
        End If
        Return ReturnValue
    End Function






    Public Function xml_to_dt(ByVal strXMLSchema As String) As DataTable
        Dim ds As New DataSet
        Dim xRead As System.IO.StringReader
        Try
            'strData = wsSOPPOra.getnamaPP(kodepp, strXMLschema, err)
            If strXMLSchema.Trim <> "" Then
                'Dim strXMLOra1 As String = Zipper.zipper.DeCompress(strXMLSchema)
                xRead = Nothing
                xRead = New IO.StringReader(strXMLSchema)
                ds.ReadXmlSchema(xRead)

                'Dim strXMLOra As String = Zipper.zipper.DeCompress(strXMLData)
                'xRead = Nothing
                'xRead = New IO.StringReader(strXMLOra)
                'ds.ReadXml(xRead)
            End If
        Catch ex As Exception
            ds = Nothing
            ' err = ex.Message
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function testkoneksi(ByRef errmsg As String, ByVal parameterkoneksi As Object()) As Boolean
        Dim ReturnValue As Boolean = False
        Dim clsmysql As NetToolMysql_v12.NetMysql
        Try
            clsmysql = New NetToolMysql_v12.NetMysql(parameterkoneksi(0), parameterkoneksi(1), _
                                                               parameterkoneksi(2), parameterkoneksi(3), _
                                                               parameterkoneksi(4))
            ReturnValue = clsmysql.TesConnection(errmsg)
        Catch ex As Exception
            errmsg = ex.Message
            ReturnValue = False
        End Try
        Return ReturnValue
    End Function

    Shared Function HanyaAngka(ByVal kode As String) As Boolean
        If (kode >= 48 And kode <= 57) Or kode = 8 Then
            HanyaAngka = False
        Else
            HanyaAngka = True
        End If
    End Function
    Shared Function convertTgldt(ByVal dt As DataTable) As DataTable
        Dim dtpass As New DataTable
        dtpass = dt.Clone
        Dim td As String = "MySql.Data.Types.MySqlDateTime"
        For Each col As DataColumn In dtpass.Columns
            'td = col.DataType.ToString()
            If col.DataType.ToString = td Then
                col.DataType = System.Type.GetType("System.DateTime")
            End If
        Next
        Return dtpass
    End Function


    'Public Shared Sub init(ByVal dbname As String, ByVal dbhost As String, ByVal dbuser As String, ByVal dbpassword As String, ByVal dbport As String)
    '    My.Settings.dbname = dbname
    '    My.Settings.dbhost = dbhost
    '    My.Settings.dbpassword = dbpassword
    '    My.Settings.dbport = dbport
    '    My.Settings.dbuser = dbuser
    '    My.Settings.Save()
    'End Sub

    Shared Sub fillComboBox(ByVal comboBox As ComboBox, ByVal value As String, ByVal description As String, ByVal table As String, ByVal firstitem As String)
        Dim dt As New DataTable
        Utils.executeSP("proc_cbofill", New Object() {value, description, table}, dt)
        If comboBox.DataSource IsNot Nothing Then
            comboBox.DataSource = Nothing
        End If
        comboBox.Items.Clear()

        Dim VDP_Array As New ArrayList
        VDP_Array.Add(New ValueDescriptionPair("-1", firstitem))
        For Each row As DataRow In dt.Rows
            VDP_Array.Add(New ValueDescriptionPair(row(0), row(1)))
        Next
        With comboBox
            .DisplayMember = "Description"
            .ValueMember = "Value"
            .DataSource = VDP_Array
        End With
        dt.Dispose()
    End Sub

End Class


