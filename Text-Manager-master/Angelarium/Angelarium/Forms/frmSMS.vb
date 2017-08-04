Imports System.Threading

Public Class frmSMS

    Dim arrNum As String()
    Dim progressCnt As Integer = 0

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'UpdateConfig() 'Close means cancel
        Me.Close()
    End Sub

    Private Sub UpdateConfig()
        With configFile
            .Load(mod_system._configFile)

            .AddSection("Pref").AddKey("Min").Value = txtTimeMin.Text
            .AddSection("Pref").AddKey("Max").Value = txtTimeMax.Text
            .AddSection("Pref").AddKey("Batch").Value = txtLimit.Text

            .Save(mod_system._configFile)
        End With
    End Sub

    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        frmContacts.Show()
        frmContacts.SelectMode()
    End Sub


    Friend Sub AddRecipient(ByVal tarName As String, ByVal tarNum As String)
        Dim lv As ListViewItem = lvRecipient.Items.Add(tarName)
        lv.SubItems.Add(tarNum)
    End Sub

    Private Sub btnM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM.Click
        For Each delItm As ListViewItem In lvRecipient.SelectedItems
            delItm.Remove()
        Next
    End Sub


    Private Delegate Sub FormState_dele(ByVal st)
    Private Sub FormState(ByVal st As Boolean)
        If pnNumbers.InvokeRequired Then
            pnNumbers.Invoke(New FormState_dele(AddressOf FormState), st)
        Else
            pnNumbers.Enabled = st
            chkRandom.Enabled = st
            txtTimeMin.Enabled = st
            txtTimeMax.Enabled = st
            txtMsg.Enabled = st
            txtLimit.Enabled = st

            btnSend.Enabled = st
            btnClose.Enabled = st
        End If
    End Sub

    Private Delegate Sub progressBar_dele(ByVal st, ByVal max)
    Private Sub progressBar(ByVal st As Boolean, Optional ByVal max As Integer = 10)
        If pbNumbers.InvokeRequired Then
            pbNumbers.Invoke(New progressBar_dele(AddressOf progressBar), st, max)
        Else
            pbNumbers.Visible = st
            pbNumbers.Maximum = max

            pbNumbers.Value = 0
        End If
    End Sub

    Private Delegate Sub NextContact_dele()
    Private Sub NextContact()
        If pbNumbers.InvokeRequired Then
            Dim d As New NextContact_dele(AddressOf NextContact)
            pbNumbers.Invoke(d)
        Else
            If pbNumbers.Value < pbNumbers.Maximum Then pbNumbers.Value += 1
        End If
    End Sub


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Not devMode Then
            If Not TextMgr.isConnected Then
                MsgBox("Please connect the Modem", MsgBoxStyle.Critical, appName)
                Exit Sub
            End If
        End If
        If Not lvRecipient.Items.Count > 0 Then Exit Sub

        UpdateConfig()

        FormState(False)

        transferNum()
        Dim th As Thread
        th = New Thread(AddressOf SendingMessage)
        th.Start()
    End Sub

    Private Sub transferNum()
        ReDim arrNum(lvRecipient.Items.Count - 1)

        For tmpCnt As Integer = 0 To lvRecipient.Items.Count - 1
            arrNum(tmpCnt) = lvRecipient.Items(tmpCnt).SubItems(1).Text
        Next
    End Sub

    Private Sub SendingMessage()
        'Initialized Mass Texting
        Dim txLmt As Integer = CInt(txtLimit.Text)
        Dim avgTimeout As Integer, batchCnt As Integer = CType(Math.Ceiling(lvRecipient.Items.Count / txLmt), Integer)
        'lvRecipient.Items.Count / txLmt
        ' CType(Math.Ceiling(ContactNumbers.Length / CInt(txtMaxNum.Text)), Integer)
        Dim txtCnt As Integer = 0, tarNum As String, notiMsg As String = ""

        Console.WriteLine("=============================")
        Console.WriteLine("Statistics")
        Console.WriteLine("Batch Count: " & batchCnt)
        Console.WriteLine("Number Count: " & lvRecipient.Items.Count)
        If batchCnt <= 0 Then batchCnt = 1 'Bug Handler

        If chkRandom.Checked Then
            RandomizeArray(arrNum)
        End If

        progressBar(True, lvRecipient.Items.Count)
        For cnt As Integer = 0 To batchCnt - 1
            Application.DoEvents()

            For perBatch As Integer = 0 To txLmt - 1
                ' Queue Text Messages
                tarNum = arrNum(txtCnt)
                If Not devMode Then TextMgr.SendMessage(tarNum, txtMsg.Text)
                Console.WriteLine(String.Format("on Queue for number {0}", tarNum))

                If txtCnt >= lvRecipient.Items.Count - 1 Then Exit For
                txtCnt += 1
            Next 'Text Loop

            Dim progTMP As Integer = onQueueCnt
            While hasOnQueue()
                Application.DoEvents()
                UpdateStatus("On queue count: " & onQueueCnt)

                If progTMP <> onQueueCnt Then
                    If pbNumbers.Value <= pbNumbers.Maximum Then NextContact()
                    progTMP = onQueueCnt
                End If
            End While

            'Timeout Settings
            If cnt < batchCnt - 1 Then
                avgTimeout = GetRandom(CInt(txtTimeMin.Text), CInt(txtTimeMax.Text))
                notiMsg = String.Format("[{2}] Timeout! Resending after {0} minutes at exactly {1}", avgTimeout, Now().AddMinutes(avgTimeout), Now())
                Console.WriteLine("Notification: " & notiMsg)

                TextMgr.SendMessage(checkNum, notiMsg)
                UpdateStatus("Timeout! " & notiMsg)
                Dim delayMin As Integer = (avgTimeout * 1000) * 60
                Application.DoEvents()
                Thread.Sleep(delayMin)

                TextMgr.SendMessage(checkNum, "Mass texting RESUME")
            End If
        Next 'Batch Loop

        TextMgr.SendMessage(checkNum, "Sending Message Completed")
        UpdateStatus("Sending finish")

        progressBar(False)
        FormState(True)
        MsgBox("Sending Message Completed", MsgBoxStyle.Information)
    End Sub

    Private Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private Sub frmSMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadConfiguration() 'Update

        txtTimeMin.Text = mod_system.minTimeout
        txtTimeMax.Text = mod_system.maxTimeout
        txtLimit.Text = mod_system.batchLimit

        If hasOnQueue() Then
            If MsgBox("There are pending messages that will be sending when you Connect the modem" + vbCr + _
                      "Do you want to clear it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EmptyOutbox()
                Exit Sub
            End If
            FormState(False)
            'progressBar(True, onQueueCnt)
            Dim progTMP As Integer = 0, maxPr As Integer = onQueueCnt
            Dim prInc As Integer = 0

            While hasOnQueue()
                UpdateStatus("On queue: " & onQueueCnt)

                Application.DoEvents()
            End While
            'progressBar(False)
            FormState(True)
            UpdateStatus("SMS Ready")
        End If
    End Sub

    Private Sub RandomizeArray(ByVal items() As String)
        Dim max_index As Integer = items.Length - 1
        Dim rnd As New Random
        For i As Integer = 0 To max_index - 1
            ' Pick an item for position i.
            Dim j As Integer = rnd.Next(i, max_index + 1)

            ' Swap them.
            Dim temp As String = items(i)
            items(i) = items(j)
            items(j) = temp
        Next i
    End Sub

End Class