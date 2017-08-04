Public Class diagMsg

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReply.Click
        diagReply.txtNum.Text = txtNum.Text
        diagReply.Show()
        Me.Close()
    End Sub
End Class