Imports System.Threading

Public Class frmFileLoader
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim result As DialogResult = ofdExcel.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then

            For Each fileName In ofdExcel.FileNames
                Console.WriteLine(fileName)
                lstFile.Items.Add(fileName)
            Next
        Else
            Console.WriteLine("Canceled")
        End If
    End Sub

    Private Function getFilename(ByVal str As String) As String
        Dim pos As Integer = str.LastIndexOf("\")
        Return str.Substring(pos + 1)
    End Function

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Frozen(1)

        If lvForNotice.Items.Count > 0 Then
            Dim ans As MsgBoxResult = MsgBox("Do you want to reload the list?", MsgBoxStyle.YesNo)
            If Not ans = MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        formUpdate("Loading files...")
        lvForNotice.Items.Clear() 'Remove ListView
        ForNotice.Clear() 'Remove Collection
        ImportToCollection()
        ForNotice.ClearAllAuctionedItem()

        Frozen(0)
    End Sub

    Private Sub Frozen(ByVal st As Boolean)
        Dim x As Boolean = Not st

        btnBrowse.Enabled = x
        lstFile.Enabled = x
        btnLoad.Enabled = x
        lvForNotice.Enabled = x
        btnNotice.Enabled = x
        btnSend.Enabled = x
    End Sub

    Private Sub ImportToCollection()
        Dim arr(lstFile.Items.Count - 1) As String
        For cnt As Integer = 0 To lstFile.Items.Count - 1
            arr(cnt) = lstFile.Items(cnt)
        Next
        importExcel.LoadFile(arr)

        For cnt As Integer = 0 To ForNotice.Count - 1
            Dim lv As ListViewItem = lvForNotice.Items.Add(ForNotice.Item(cnt).BranchCode)
            lv.SubItems.Add(ForNotice.Item(cnt).TicketNumber)
            lv.SubItems.Add(ForNotice.Item(cnt).PawnerName)
            lv.SubItems.Add(ForNotice.Item(cnt).ExpiryDate)
            lv.SubItems.Add(ForNotice.Item(cnt).AuctionDate)

            Application.DoEvents()
        Next

        lblStatus.Text = String.Format("Loaded {0} entries", ForNotice.Count)
    End Sub

    Private Sub frmFileLoader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formUpdate("IDLE")

        ' Load pending numbers
        formUpdate("Loading pending...")
        hasPending()

        If modem.Core.isConnected Then
            formUpdate("Ready")
        Else
            formUpdate("Not connected")
        End If
    End Sub

    Friend Sub formUpdate(ByVal str As String)
        lblStatus.Text = str
    End Sub

    Private Sub hasPending()
        Dim pen As DataSet = LoadSQL("SELECT * FROM expiry")

        If pen.Tables(0).Rows.Count > 0 And modem.Core.isConnected Then
            DefineProgress(pen.Tables(0).Rows.Count)
            FormFrozen(1)

            ForNotice.Clear()
            For cnt As Integer = 0 To pen.Tables(0).Rows.Count - 1
                With pen.Tables(0).Rows(cnt)
                    Dim notice As New Expiry
                    notice.PawnerName = .Item("NAME")
                    notice.TicketNumber = .Item("TICKET_NO")
                    notice.ItemType = .Item("ITEMTYPE")
                    notice.PhoneNumber = .Item("PHONE_NO")
                    notice.ExpiryDate = .Item("EXPI_DATE")
                    notice.AuctionDate = .Item("AUCT_DATE")
                    notice.BranchCode = .Item("branchCode")

                    ForNotice.Add(notice)
                End With
            Next

            Dim sending As New Thread(AddressOf StartNotifing)
            sending.Start()
        End If
        If Not modem.Core.isConnected Then lblStatus.Text = "Please connect to Modem. Pending Found"
    End Sub

    Private Sub lstFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFile.KeyDown
        If e.KeyCode = Keys.Delete Then
            Console.WriteLine("Delete!")
            If lstFile.SelectedItems.Count > 0 Then
                lstFile.Items.RemoveAt(lstFile.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub btnNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotice.Click
        frmNotice.Show()
    End Sub

    Public Sub FormFrozen(ByVal st As Boolean)
        Dim tm As Boolean = Not st
        pbSending.Visible = st

        btnBrowse.Enabled = tm
        lstFile.Enabled = tm

        btnLoad.Enabled = tm
        btnNotice.Enabled = tm
        btnSend.Enabled = tm
        lvForNotice.Enabled = tm
    End Sub

    Friend Sub DefineProgress(ByVal barMax As Integer)
        pbSending.Value = 0
        pbSending.Maximum = barMax
    End Sub

    Private Delegate Sub AddProgress_dele()
    Friend Sub AddProgress()
        If pbSending.InvokeRequired Then
            pbSending.Invoke(New AddProgress_dele(AddressOf AddProgress))
        Else
            If pbSending.Value < pbSending.Maximum Then
                pbSending.Value += 1
            End If
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Not modem.Core.isConnected Then
            MsgBox("Please connect to a modem", MsgBoxStyle.Information)
            Exit Sub
        End If

        If ForNotice.Count < 1 Then
            MsgBox("Please load Customers", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim ans As MsgBoxResult = MsgBox("Sending Notification Ready" & vbCr & "Please click YES", MsgBoxStyle.YesNo, "WARNING")
        If ans = MsgBoxResult.No Then
            Exit Sub
        End If
        FormFrozen(True)

        'onQueue Expiry
        For Each cust As Expiry In ForNotice
            onQueueExpiry(cust)
        Next
        Console.WriteLine("On Queue Ready")

        'Start Notifying
        StartNotifing()
    End Sub

End Class