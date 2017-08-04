Imports suicide
Imports System.Threading

Module modem

    Public ModemPort As String
    Public NoticeNumber As String
    Public ModemConfig As String = "eskie"
    Public Core As New DeathModem

    Private onPause As Boolean = False

    Public Sub Initialize()
        Core.CurrentDirectory = "binary/"
    End Sub

    Public Function Ports() As String()
        Return Core.GetPortNames
    End Function

    Public Sub GetModemInfo()
        Core.GetModemInformation()
    End Sub

#Region "Notifier"
    Public Sub SendingNotice()
        Console.WriteLine("SendingNotice Sub ===========================")
        Dim timeMin As Integer = LoadOption("TimeoutMin")
        Dim timeMax As Integer = LoadOption("TimeoutMax")
        Dim batchLimit As Integer = LoadOption("BatchLimit")
        Dim failedAttempt As Integer = 0

sending:
        'Sending
        Dim notiMsg As String = String.Empty, resendCnt As Integer = 0
        Dim customMessage As String, MaxRow As Integer = ForNotice.Count

        customMessage = LoadOption("CustomMessage")
        Console.WriteLine("Msg: " & customMessage)
        Dim batchCnt As Integer = CType(Math.Ceiling(MaxRow / batchLimit), Integer)
        Dim custRow As Integer = 0
        If batchCnt = 0 And MaxRow > 0 Then batchCnt = 1 'Error Handler
        frmFileLoader.DefineProgress(ForNotice.Count)

        For cnt = 0 To batchCnt - 1 'main Loop
            Application.DoEvents()

            For perBatch As Integer = 0 To batchLimit - 1
                With ForNotice
                    If ForNotice.Count - 1 >= custRow Then
                        SendNotice(.Item(custRow).PhoneNumber, subShortCodes(customMessage, .Item(custRow)))
                        AddContacts(.Item(custRow))
                    End If

                    Thread.Sleep(500) 'Queuing Delay
                    If custRow < ForNotice.Count Then
                        If isResend(.Item(custRow).PhoneNumber) And custRow < ForNotice.Count Then
                            resendCnt += 1
                            Console.WriteLine("Sending Failed")
                        Else
                            If ForNotice.Count - 1 >= custRow Then
                                AddReport(.Item(custRow))
                                database.RemoveExpiry(.Item(custRow).TicketNumber)
                            End If
                        End If
                    End If
                    Application.DoEvents()
                End With

                custRow += 1
                frmFileLoader.AddProgress()
            Next

            'Sending Waiting
            While Not database.NoQueue
                Thread.Sleep(100)
                Application.DoEvents()
            End While

            'Timeout Settings
            If cnt < batchCnt - 1 Then
                Dim avgTimeout As Integer = GetRandom(timeMin, timeMax)
                notiMsg = String.Format("[{2}] Timeout! Resending after {0} minutes as exactly {1}", avgTimeout, Now.AddMinutes(avgTimeout), Now())
                SendNotice(NoticeNumber, notiMsg)
                frmFileLoader.formUpdate(notiMsg)
                Application.DoEvents()

                Dim delaySleep As Integer = (avgTimeout * 1000) * 60

                'Threading with Parameter
                Dim th As Thread
                th = New Thread(AddressOf WaitingThread)
                th.Start(delaySleep)

                Thread.Sleep(2000) 'System Delay
                While onPause
                    Application.DoEvents()
                End While

                If cnt < batchCnt Then
                    SendNotice(NoticeNumber, "Texting Resume")
                    Console.WriteLine("Resume=================================================")
                End If
            End If
        Next 'main Loop
        Dim mainNum As Integer = ForNotice.Count

        If resendCnt > 0 Then
            database.FillCollection()
            If NoticeNumber = "" Then frmOptions.LoadMainOptions()
            SendNotice(NoticeNumber, "Resending Failed " & ForNotice.Count & " Expiry!")
            GoTo sending
        End If

        frmFileLoader.formUpdate("Sending Notice Completed | Sent: " & mainNum)
        SendNotice(NoticeNumber, "Sending Notice Completed!")
        If resendCnt > 0 Then LogEntry("Failed - " & resendCnt, MessageLevel.Warning)
        LogEntry("Notice Sent was " & mainNum, MessageLevel.System)

        Dim hasFailed As DataSet = LoadSQL("SELECT * FROM expiry")
        If hasFailed.Tables(0).Rows.Count > 0 Then
            If failedAttempt >= 3 Then
                frmFileLoader.FormFrozen(False)
                MsgBox("Resending Attepmt reaches 3" & vbCrLf & "Notifier Stop", MsgBoxStyle.Critical)
                Exit Sub
            End If
            failedAttempt += 1
            frmFileLoader.formUpdate("Resending Failed expiry please wait for 5 seconds...")
            Thread.Sleep("5000")
            GoTo sending
        End If

        frmFileLoader.FormFrozen(False)
        MsgBox("Sending Completed", MsgBoxStyle.Information)
    End Sub

    Private Sub WaitingThread(ByVal ds As Integer)
        Console.WriteLine("WaitingThread for " & ds)
        onPause = True
        Thread.Sleep(ds)
        onPause = False
        Console.WriteLine("Resume!===================================")
    End Sub

    ''' <summary>
    ''' Sending Notification
    ''' </summary>
    ''' <param name="num"></param>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Private Sub SendNotice(ByVal num As String, ByVal msg As String)
        Console.WriteLine(String.Format("{0}|:- {1}", num, msg))
        modem.Core.SendMessage(num, msg)
    End Sub

    ''' <summary>
    ''' Add ShortCodes
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="cust"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function subShortCodes(ByVal str As String, ByVal cust As Expiry) As String
        Dim legend As String() = {"[%p]", "[%t]", "[%auc]", "[%expr]"}

        If str.Contains(legend(0)) Then
            str = str.Replace(legend(0), cust.PawnerName)
        End If
        If str.Contains(legend(1)) Then
            str = str.Replace(legend(1), cust.TicketNumber)
        End If
        If str.Contains(legend(2)) Then
            str = str.Replace(legend(2), cust.AuctionDate)
        End If
        If str.Contains(legend(3)) Then
            str = str.Replace(legend(3), cust.ExpiryDate)
        End If

        Return str
    End Function

    Private Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
#End Region
End Module
