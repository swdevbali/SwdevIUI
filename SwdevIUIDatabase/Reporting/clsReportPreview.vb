﻿Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports SwdevIUICore

Public Class clsReportPreview
    Dim rep As New ReportDocument
    Dim sRptLocation As String
    Dim params As ParameterFieldDefinitions

    Public Event EnterReportPage As System.EventHandler

    Public Sub New(ByVal dsPrinting As DataTable, ByVal sReportPath As String)
        If Not IO.File.Exists(sReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & sReportPath))
        End If

        rep.Load(sReportPath)
        rep.SetDataSource(dsPrinting)
        sRptLocation = sReportPath
    End Sub
    Public Sub New(ByVal sReportPath As String)
        If Not IO.File.Exists(sReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & sReportPath))
        End If
        rep.Load(sReportPath)
        sRptLocation = sReportPath
    End Sub

    Event PopulateReport(ByRef rep As ReportDocument)

    Public Sub ShowReport()

        Dim report As ReportViewerPage = Pages.Item("reportPage")

        report.rptLocation = sRptLocation
        RaiseEvent PopulateReport(rep)
        report.CrystalReportViewer1.ReportSource = rep
        EventBroadcaster.doEnterReportPage(report)
        'RaiseEvent EnterReportPage(report, New EventArgs()) 'EventBroadcaster.doEnterReportPage(report)
    End Sub

    Public Sub SetParameter(ByVal sParameterName As String, ByVal sValue As String)
        Dim value As ParameterDiscreteValue
        Dim crParameterField As ParameterField

        value = New ParameterDiscreteValue()
        value.Value = sValue
        crParameterField = New ParameterField()
        crParameterField.ParameterFieldName = sParameterName
        crParameterField.CurrentValues.Add(value)

        rep.DataDefinition.ParameterFields(sParameterName).ApplyCurrentValues(crParameterField.CurrentValues)

    End Sub
    Public Sub DirectPrint()
        rep.PrintToPrinter(1, False, 0, 0)
    End Sub

End Class
