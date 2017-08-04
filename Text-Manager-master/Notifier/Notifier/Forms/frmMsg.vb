Public Class frmMsg

    Private Sub frmMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInbox()
        lblStatus.Text = ""
    End Sub

    Private Sub LoadInbox()
        Dim ds As DataSet
        ds = LoadMessages()
        
        For cnt As Integer = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(cnt)
                Dim num As String = .Item("SenderNumber").ToString
                Dim name As String = getName(num)
                Dim fromBranch As String = getBranch(num)
                Dim lv As ListViewItem = lvInbox.Items.Add(name)

                lv.SubItems.Add(num)
                lv.SubItems.Add(.Item("ReceivingDateTime").ToString)
                lv.SubItems.Add(.Item("TextDecoded").ToString)
            End With
        Next
    End Sub

    Private Sub lvInbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvInbox.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvInbox.SelectedItems.Count > 0 Then
            frmQuick.Show()
            frmQuick.ChangeMode(frmQuick.FormMode.View)
            frmQuick.Text = IIf(lvInbox.FocusedItem.Text <> "", lvInbox.FocusedItem.Text, "Unnamed")
            frmQuick.txtNumber.Text = lvInbox.FocusedItem.SubItems(1).Text
            frmQuick.txtMsg.Text = lvInbox.FocusedItem.SubItems(3).Text
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lvInbox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvInbox.MouseMove
        Dim thisItem As ListViewItem = lvInbox.GetItemAt(e.X, e.Y)

        If thisItem Is Nothing Then
            lblStatus.Text = ""
        Else
            Dim num As String = thisItem.SubItems(1).Text
            Dim name As String = getName(num)
            Dim fromBranch As String = getBranch(num)
            Dim note As String = String.Format("Name: {0}|Number: {1}|From: {2}", name, num, fromBranch)

            lblStatus.Text = note
        End If
    End Sub

    Private Sub lvInbox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvInbox.SelectedIndexChanged

    End Sub
End Class