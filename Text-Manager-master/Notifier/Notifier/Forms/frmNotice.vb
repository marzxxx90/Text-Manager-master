Public Class frmNotice

    Private Sub frmNotice_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Console.WriteLine(txtMsg.Text)
    End Sub

    Private Sub frmNotice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialization()
    End Sub

    Private Sub Initialization()
        Try
            ' Load Custom Message
            Dim dsOption As DataSet = database.LoadSQL("SELECT * FROM options ORDER BY opt_id ASC")

            With dsOption.Tables(0)
                txtMsg.Text = .Rows(0).Item("opt_value").ToString
                txtMin.Text = .Rows(1).Item("opt_value").ToString
                txtMax.Text = .Rows(2).Item("opt_value").ToString
                txtBatch.Text = .Rows(3).Item("opt_value").ToString
            End With
        Catch ex As Exception
            LogEntry("Not yet Initialized", MessageLevel.System)
        End Try
    End Sub

    Private Sub lblLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLegend.Click
        diagLegend.Show()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOption("CustomMessage", txtMsg.Text)
        SaveOption("TimeoutMin", txtMin.Text)
        SaveOption("TimeoutMax", txtMax.Text)
        SaveOption("BatchLimit", txtBatch.Text)

        MsgBox("Notice Preparation Updated", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class