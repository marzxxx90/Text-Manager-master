Imports Microsoft.Reporting.WinForms 'For Report Parameter

Public Class frm_Report

    Private Sub rpt_Viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.rptViewer.RefreshReport()
    End Sub

    Friend Sub InitReport(ByVal fillData As String, ByVal mySql As String, ByVal reportUrl As String, ByVal lstDate As List(Of Date))
        Dim ds As New DataSet

        rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        rptViewer.LocalReport.ReportPath = reportUrl
        rptViewer.LocalReport.DataSources.Clear()

        Console.WriteLine(mySql)
        ds = LoadSQL(mySql, fillData) 'FillData Must be same at the winDataSet

        Dim rptDataSource As Microsoft.Reporting.WinForms.ReportDataSource = _
            New Microsoft.Reporting.WinForms.ReportDataSource
        rptDataSource.Name = fillData
        rptDataSource.Value = ds.Tables(fillData)

        Console.WriteLine("Output Count: " & ds.Tables(0).Rows.Count)
        Console.WriteLine(mySql)
        Console.WriteLine("=============================================================================================")

        'Add Parameter
        Dim myPara As New ReportParameter
        myPara.Name = "txtRangeDate"
        myPara.Values.Add(String.Format(">> This report is dated {0} - {1}", lstDate(0).ToString("MMMM dd"), lstDate(1).ToString("MMMM dd, yyyy")))
        rptViewer.LocalReport.SetParameters(New ReportParameter() {myPara})

        rptViewer.LocalReport.DataSources.Add(rptDataSource)
        rptViewer.DocumentMapCollapsed = True
    End Sub
End Class