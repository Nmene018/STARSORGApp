Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmEventReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private EventReport As CEvent
    Private Sub frmEventReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvEventReport.RefreshReport()
    End Sub
    Public Sub Display()
        EventReport = New CEvent
        rpvEventReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptEvents.rdlc"
        ds = New DataSet
        da = EventReport.GetReportData()
        da.Fill(ds)
        rpvEventReport.LocalReport.DataSources.Add(New ReportDataSource("dsEvents", ds.Tables(0)))
        rpvEventReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvEventReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class