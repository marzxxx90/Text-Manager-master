Imports MySql.Data.MySqlClient

Public Class frmInbox

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmInbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tpInbox_Click(sender, e)
    End Sub

    Private Sub LoadBox(ByVal sqlTbl As String, ByVal lvBox As ListView)
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
        "SELECT Name, Number, DateTime, Message FROM " & sqlTbl
        mySql &= vbCrLf & "LIMIT 0,100"

        fillData = sqlTbl
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
        ds.Tables(fillData).Rows.Count

        lvBox.Items.Clear()
        If ds.Tables(fillData).Rows.Count = 0 Then
            dbClose()
            Exit Sub
        End If
        For cnt As Integer = 0 To MaxRow - 1
            With ds.Tables(fillData).Rows(cnt)
                Dim lv As ListViewItem = lvBox.Items.Add(String.Format("{0}({1})", .Item("Name"), .Item("Number")))
                lv.SubItems.Add(.Item("DateTime"))
                lv.SubItems.Add(.Item("Message"))
            End With
        Next

        dbClose()
    End Sub

    Private Sub tpInbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpInbox.Click
        LoadBox("userinbox", lvInbox)
    End Sub

    Private Sub tpOutbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpOutbox.Click
        LoadBox("useroutbox", lvOut)
    End Sub

    Private Sub tpSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpSent.Click
        LoadBox("usersentitems", lvSent)
    End Sub

    Private Sub tcMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMessage.Click
        Console.WriteLine("Clicked " & tcMessage.SelectedIndex)
        Select Case tcMessage.SelectedIndex
            Case 0
                tpInbox_Click(sender, e)
            Case 1
                tpOutbox_Click(sender, e)
            Case 2
                tpSent_Click(sender, e)
        End Select
    End Sub

    Private Sub lvInbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvInbox.Click
        'MsgBox(lvInbox.FocusedItem.SubItems(0).Text & lvInbox.FocusedItem.SubItems(2).Text)
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim selLv As ListView = Nothing

        Select Case tcMessage.SelectedIndex
            Case 0
                selLv = lvInbox
            Case 1
                selLv = lvOut
            Case 2
                selLv = lvSent
        End Select

        displayMsg(selLv)
    End Sub
    Private Sub displayMsg(ByVal lvv As ListView)
        Dim tmp As String = lvv.FocusedItem.SubItems(0).Text
        Dim name As String, num As String

        num = tmp.Substring(tmp.IndexOf("(") + 1)
        num = num.Substring(0, num.Length - 1)

        name = IIf(tmp.IndexOf("(") <= 0, num, tmp.Substring(0, tmp.IndexOf("(")))

        diagMsg.Text = name
        diagMsg.txtNum.Text = num
        diagMsg.txtMsg.Text = lvv.FocusedItem.SubItems(2).Text
        diagMsg.Show()
    End Sub

    Private Sub lvInbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvInbox.DoubleClick
        btnView_Click(sender, e)
    End Sub

    Private Sub lvOut_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOut.DoubleClick
        btnView_Click(sender, e)
    End Sub

    Private Sub lvSent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSent.DoubleClick
        btnView_Click(sender, e)
    End Sub
End Class