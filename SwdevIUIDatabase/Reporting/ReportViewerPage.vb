Imports System.Windows.Forms
Imports SwdevIUI

Public Class ReportViewerPage
    Inherits PageTemplate
    Public rptLocation As String
    Public Sub New(ByVal sRptLocation As String)
        Me.InitializeComponent()
        rptLocation = sRptLocation
    End Sub

    Public Sub New()
        Me.InitializeComponent()
        rptLocation = "Belum terdefinisi !"
    End Sub


    Private Sub frmReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            MsgBox("Lokasi file :" & rptLocation, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CrystalReportViewer1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CrystalReportViewer1.KeyDown
        If e.KeyCode = Keys.F11 Then
            MsgBox("Lokasi file :" & rptLocation, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CrystalReportViewer1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CrystalReportViewer1.MouseDoubleClick
        MsgBox("Lokasi file :" & rptLocation, MsgBoxStyle.Information)
    End Sub
End Class
