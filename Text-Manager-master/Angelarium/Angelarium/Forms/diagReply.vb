Public Class diagReply

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReply.Click
        TextMgr.SendMessage(txtNum.Text, txtMsg.Text)
        MsgBox("Sending...", MsgBoxStyle.Information, appName)
        Me.Close()
    End Sub
End Class