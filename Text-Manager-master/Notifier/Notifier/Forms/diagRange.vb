Public Class diagRange

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen.Click
        Dim startDate As String = monCal.SelectionRange.Start.ToString("yyyy-M-d")
        Dim endDate As String = monCal.SelectionRange.End.ToString("yyyy-M-d")

        Dim sql As String
        sql = String.Format("SELECT * FROM expiryreports WHERE sentdate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", startDate, endDate)
        Dim tmpLst As New List(Of Date)
        tmpLst.Add(startDate)
        tmpLst.Add(endDate)
        frm_Report.InitReport("sentreports", sql, "..\Reports\rpt_SentReports.rdlc", tmpLst)
        frm_Report.Show()
    End Sub
End Class