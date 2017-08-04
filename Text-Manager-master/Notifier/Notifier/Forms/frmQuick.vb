Public Class frmQuick

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmQuick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ChangeMode(ByVal typ As FormMode)
        If typ = 0 Then
            txtNumber.Text = ""
            txtMsg.Text = ""
            btnSend.Text = "&Send"

            txtNumber.ReadOnly = False
            txtMsg.ReadOnly = False
            txtMsg.Focus()
        Else
            txtNumber.ReadOnly = True
            txtMsg.ReadOnly = True
            btnSend.Text = "&Reply"
        End If
    End Sub

    Enum FormMode
        Text = 0
        View = 1
    End Enum

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'modem.Core.QuickText(txtNumber.Text, txtMsg.Text)
        If btnSend.Text = "&Send" Then
            If Not modem.Core.isConnected Then Exit Sub
            modem.Core.SendMessage(txtNumber.Text, txtMsg.Text)
            MsgBox("Message Sent!", MsgBoxStyle.Information)
            Me.Close()
        Else
            Dim num As String = txtNumber.Text
            ChangeMode(FormMode.Text)
            txtNumber.Text = num
        End If
        
    End Sub
End Class