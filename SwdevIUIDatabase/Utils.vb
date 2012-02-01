Imports NetToolMysql_v12
Imports System.Windows.Forms
Imports SwdevIUIDatabase
Imports SwdevIUICore
Imports SwdevIUIDatabase.GenCode128
Imports System.Drawing

Public Class Utils
#Region "barcode"
    Private Shared ReadOnly cPatterns As Integer(,) = {{2, 1, 2, 2, 2, 2, _
      0, 0}, {2, 2, 2, 1, 2, 2, _
      0, 0}, {2, 2, 2, 2, 2, 1, _
      0, 0}, {1, 2, 1, 2, 2, 3, _
      0, 0}, {1, 2, 1, 3, 2, 2, _
      0, 0}, {1, 3, 1, 2, 2, 2, _
      0, 0}, _
      {1, 2, 2, 2, 1, 3, _
      0, 0}, {1, 2, 2, 3, 1, 2, _
      0, 0}, {1, 3, 2, 2, 1, 2, _
      0, 0}, {2, 2, 1, 2, 1, 3, _
      0, 0}, {2, 2, 1, 3, 1, 2, _
      0, 0}, {2, 3, 1, 2, 1, 2, _
      0, 0}, _
      {1, 1, 2, 2, 3, 2, _
      0, 0}, {1, 2, 2, 1, 3, 2, _
      0, 0}, {1, 2, 2, 2, 3, 1, _
      0, 0}, {1, 1, 3, 2, 2, 2, _
      0, 0}, {1, 2, 3, 1, 2, 2, _
      0, 0}, {1, 2, 3, 2, 2, 1, _
      0, 0}, _
      {2, 2, 3, 2, 1, 1, _
      0, 0}, {2, 2, 1, 1, 3, 2, _
      0, 0}, {2, 2, 1, 2, 3, 1, _
      0, 0}, {2, 1, 3, 2, 1, 2, _
      0, 0}, {2, 2, 3, 1, 1, 2, _
      0, 0}, {3, 1, 2, 1, 3, 1, _
      0, 0}, _
      {3, 1, 1, 2, 2, 2, _
      0, 0}, {3, 2, 1, 1, 2, 2, _
      0, 0}, {3, 2, 1, 2, 2, 1, _
      0, 0}, {3, 1, 2, 2, 1, 2, _
      0, 0}, {3, 2, 2, 1, 1, 2, _
      0, 0}, {3, 2, 2, 2, 1, 1, _
      0, 0}, _
      {2, 1, 2, 1, 2, 3, _
      0, 0}, {2, 1, 2, 3, 2, 1, _
      0, 0}, {2, 3, 2, 1, 2, 1, _
      0, 0}, {1, 1, 1, 3, 2, 3, _
      0, 0}, {1, 3, 1, 1, 2, 3, _
      0, 0}, {1, 3, 1, 3, 2, 1, _
      0, 0}, _
      {1, 1, 2, 3, 1, 3, _
      0, 0}, {1, 3, 2, 1, 1, 3, _
      0, 0}, {1, 3, 2, 3, 1, 1, _
      0, 0}, {2, 1, 1, 3, 1, 3, _
      0, 0}, {2, 3, 1, 1, 1, 3, _
      0, 0}, {2, 3, 1, 3, 1, 1, _
      0, 0}, _
      {1, 1, 2, 1, 3, 3, _
      0, 0}, {1, 1, 2, 3, 3, 1, _
      0, 0}, {1, 3, 2, 1, 3, 1, _
      0, 0}, {1, 1, 3, 1, 2, 3, _
      0, 0}, {1, 1, 3, 3, 2, 1, _
      0, 0}, {1, 3, 3, 1, 2, 1, _
      0, 0}, _
      {3, 1, 3, 1, 2, 1, _
      0, 0}, {2, 1, 1, 3, 3, 1, _
      0, 0}, {2, 3, 1, 1, 3, 1, _
      0, 0}, {2, 1, 3, 1, 1, 3, _
      0, 0}, {2, 1, 3, 3, 1, 1, _
      0, 0}, {2, 1, 3, 1, 3, 1, _
      0, 0}, _
      {3, 1, 1, 1, 2, 3, _
      0, 0}, {3, 1, 1, 3, 2, 1, _
      0, 0}, {3, 3, 1, 1, 2, 1, _
      0, 0}, {3, 1, 2, 1, 1, 3, _
      0, 0}, {3, 1, 2, 3, 1, 1, _
      0, 0}, {3, 3, 2, 1, 1, 1, _
      0, 0}, _
      {3, 1, 4, 1, 1, 1, _
      0, 0}, {2, 2, 1, 4, 1, 1, _
      0, 0}, {4, 3, 1, 1, 1, 1, _
      0, 0}, {1, 1, 1, 2, 2, 4, _
      0, 0}, {1, 1, 1, 4, 2, 2, _
      0, 0}, {1, 2, 1, 1, 2, 4, _
      0, 0}, _
      {1, 2, 1, 4, 2, 1, _
      0, 0}, {1, 4, 1, 1, 2, 2, _
      0, 0}, {1, 4, 1, 2, 2, 1, _
      0, 0}, {1, 1, 2, 2, 1, 4, _
      0, 0}, {1, 1, 2, 4, 1, 2, _
      0, 0}, {1, 2, 2, 1, 1, 4, _
      0, 0}, _
      {1, 2, 2, 4, 1, 1, _
      0, 0}, {1, 4, 2, 1, 1, 2, _
      0, 0}, {1, 4, 2, 2, 1, 1, _
      0, 0}, {2, 4, 1, 2, 1, 1, _
      0, 0}, {2, 2, 1, 1, 1, 4, _
      0, 0}, {4, 1, 3, 1, 1, 1, _
      0, 0}, _
      {2, 4, 1, 1, 1, 2, _
      0, 0}, {1, 3, 4, 1, 1, 1, _
      0, 0}, {1, 1, 1, 2, 4, 2, _
      0, 0}, {1, 2, 1, 1, 4, 2, _
      0, 0}, {1, 2, 1, 2, 4, 1, _
      0, 0}, {1, 1, 4, 2, 1, 2, _
      0, 0}, _
      {1, 2, 4, 1, 1, 2, _
      0, 0}, {1, 2, 4, 2, 1, 1, _
      0, 0}, {4, 1, 1, 2, 1, 2, _
      0, 0}, {4, 2, 1, 1, 1, 2, _
      0, 0}, {4, 2, 1, 2, 1, 1, _
      0, 0}, {2, 1, 2, 1, 4, 1, _
      0, 0}, _
      {2, 1, 4, 1, 2, 1, _
      0, 0}, {4, 1, 2, 1, 2, 1, _
      0, 0}, {1, 1, 1, 1, 4, 3, _
      0, 0}, {1, 1, 1, 3, 4, 1, _
      0, 0}, {1, 3, 1, 1, 4, 1, _
      0, 0}, {1, 1, 4, 1, 1, 3, _
      0, 0}, _
      {1, 1, 4, 3, 1, 1, _
      0, 0}, {4, 1, 1, 1, 1, 3, _
      0, 0}, {4, 1, 1, 3, 1, 1, _
      0, 0}, {1, 1, 3, 1, 4, 1, _
      0, 0}, {1, 1, 4, 1, 3, 1, _
      0, 0}, {3, 1, 1, 1, 4, 1, _
      0, 0}, _
      {4, 1, 1, 1, 3, 1, _
      0, 0}, {2, 1, 1, 4, 1, 2, _
      0, 0}, {2, 1, 1, 2, 1, 4, _
      0, 0}, {2, 1, 1, 2, 3, 2, _
      0, 0}, {2, 3, 3, 1, 1, 1, _
      2, 0}}
#End Region

    Private Const cQuietWidth As Integer = 10
    Public Shared Function generateBarcode(ByVal InputData As String, ByVal BarWeight As Integer, ByVal AddQuietZone As Boolean) As Image
        ' get the Code128 codes to represent the message
        Dim content As New Code128Content(InputData)
        Dim codes As Integer() = content.Codes

        Dim width As Integer, height As Integer
        width = ((codes.Length - 3) * 11 + 35) * BarWeight
        'height = Convert.ToInt32(System.Math.Ceiling(Convert.ToSingle(width) * 0.15F)) 'asli
        height = Convert.ToInt32(System.Math.Ceiling(Convert.ToSingle(width) * 0.15F))

        If AddQuietZone Then
            ' on both sides
            width += 2 * cQuietWidth * BarWeight
        End If

        ' get surface to draw on
        Dim myimg As Image = New System.Drawing.Bitmap(width, height)
        Using gr As Graphics = Graphics.FromImage(myimg)

            ' set to white so we don't have to fill the spaces with white
            gr.FillRectangle(System.Drawing.Brushes.White, 0, 0, width, height)

            ' skip quiet zone
            Dim cursor As Integer = If(AddQuietZone, cQuietWidth * BarWeight, 0)

            For codeidx As Integer = 0 To codes.Length - 1
                Dim code As Integer = codes(codeidx)

                ' take the bars two at a time: a black and a white
                For bar As Integer = 0 To 7 Step 2
                    Dim barwidth As Integer = cPatterns(code, bar) * BarWeight
                    Dim spcwidth As Integer = cPatterns(code, bar + 1) * BarWeight

                    ' if width is zero, don't try to draw it
                    If barwidth > 0 Then
                        gr.FillRectangle(System.Drawing.Brushes.Black, cursor, 0, barwidth, height)
                    End If

                    ' note that we never need to draw the space, since we 
                    ' initialized the graphics to all white

                    ' advance cursor beyond this pair
                    cursor += (barwidth + spcwidth)
                Next
            Next
        End Using

        Return myimg

    End Function
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
        'If My.Computer.Network.Ping(Session.dbhost) = False Then
        '    Return Nothing
        'End If
        'AdBandara
        'Session.dbhost = "192.168.10.1" '"localhost"
        'Session.dbname = "passbandara"
        'Session.dbpassword = "passbandara" '""
        'Session.dbport = "3307" '"3306"
        'Session.dbuser = "adbandara" '"root"

        Session.dbhost = "localhost"
        Session.dbname = "passbandara"
        Session.dbpassword = ""
        Session.dbport = "3306"
        Session.dbuser = "root"

        Dim ErrMsg As String = ""
        Dim MySQL As NetMysql = Nothing
        Try
            If Session.dbname = "" Then Return Nothing
            MySQL = New NetToolMysql_v12.NetMysql(Session.dbname, Session.dbhost, Session.dbuser, Session.dbpassword, Session.dbport)
            MySQL.TesConnection(ErrMsg)


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
            If condb Is Nothing Then Return False
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

    Shared Sub fillComboBox(ByVal comboBox As ComboBox, ByVal value As Object, ByVal description As Object, ByVal table As String, ByVal firstitem As String)
        Dim dt As New DataTable
        Utils.executeSP("proc_cbofill", New Object() {value, description, table}, dt)
        If comboBox.DataSource IsNot Nothing Then
            comboBox.DataSource = Nothing
        End If
        comboBox.Items.Clear()

        Dim VDP_Array As New ArrayList
        VDP_Array.Add(New ValueDescriptionPair(Nothing, firstitem))
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

    Shared Sub selectInCombo(ByVal comboBox As ComboBox, ByVal value As String)
        For Each o As ValueDescriptionPair In comboBox.Items
            If o.Value IsNot Nothing AndAlso o.Value.ToString.Equals(value) Then
                comboBox.SelectedItem = o
                Exit For
            End If
        Next
    End Sub
    Shared Sub selectInComboDataGrid(ByVal comboBox As DataGridViewComboBoxCell, ByVal value As String)
        For Each o As ValueDescriptionPair In comboBox.Items
            If o.Value IsNot Nothing AndAlso o.Value.ToString.Equals(value) Then
                comboBox.Value = o
                Exit For
            End If
        Next
    End Sub
    Shared Sub fillComboBoxUsingSP(ByVal comboBox As ComboBox, ByVal proc_name As String, ByVal param As Object(), ByVal firstItem As String)
        Dim dt As New DataTable
        Utils.executeSP(proc_name, param, dt)
        If comboBox.DataSource IsNot Nothing Then
            comboBox.DataSource = Nothing
        End If
        comboBox.Items.Clear()

        Dim VDP_Array As New ArrayList
        VDP_Array.Add(New ValueDescriptionPair(Nothing, firstItem))
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

    Shared Sub fillComboBoxCellUsingSP(ByVal comboBox As DataGridViewComboBoxColumn, ByVal proc_name As String, ByVal param As Object(), ByVal firstitem As String)
        Dim dt As New DataTable
        Utils.executeSP(proc_name, param, dt)
        If comboBox.DataSource IsNot Nothing Then
            comboBox.DataSource = Nothing
        End If
        comboBox.Items.Clear()

        Dim VDP_Array As New ArrayList
        VDP_Array.Add(New ValueDescriptionPair(Nothing, firstitem))
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

    Shared Function execQuery(ByVal query As String) As String
        Dim con As NetMysql = getConnection()
        Dim errMsg As String = ""
        con.MySqlExecuteNonQuery(query, errMsg)

        If errMsg <> "" Then
            Return "ERROR : " & errMsg & " : " & query
        End If

        Return "OK : " & query
    End Function
    'thanks to http://www.java2s.com/Code/VB/Database-ADO.net/PopulateDatafromdatatable.htm
    Shared Function getMysqlData(ByVal query As String, ByRef dt As DataTable) As String
        Dim con As NetMysql = getConnection()
        Dim errMsg As String = ""
        Dim ds As DataSet = con.getMySqlData(query, errMsg)

        If errMsg <> "" Then

            Return "ERROR : " & errMsg & " : " & query
        End If
        dt = ds.Tables(0)
        Return "OK : " & query

    End Function

    Shared Sub fillAutocomplete(ByRef autoComplete As AutoCompleteStringCollection, ByVal proc As String, ByVal param As Object())
        Dim dt As New DataTable
        executeSP(proc, param, dt)
        autoComplete.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                autoComplete.Add(dt.Rows(i).Item(0).ToString)
            Next
        End If
        dt.Dispose()
    End Sub

  
End Class


