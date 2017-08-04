Public Class frmMain

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        TextMgr.Disconnect()
        End
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next 'Added in 1.0.0.2

        If devMode Then MsgBox("Developer MODE", MsgBoxStyle.Information)

        Me.LayoutMdi(MdiLayout.Cascade)

        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                'Set properties of ctl here, e.g.
                ctl.BackgroundImage = My.Resources.background
                ctl.BackgroundImageLayout = ImageLayout.Center
                Exit For
            End If
        Next ctl

        If Not LoadConfiguration() Then
            frmOptions.StartPosition = FormStartPosition.CenterParent
            LoadChild(frmOptions)
        Else
            UpdateStatus("Checking modem compatibility...")
            If Not devMode Then TextMgr.GetModemInformation()
            tmrModem.Enabled = True
        End If
    End Sub


    Private Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        btnExit.PerformClick()
    End Sub

    Private Sub InboxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InboxToolStripMenuItem.Click
        LoadChild(frmInbox)
    End Sub

    Private Sub ModemInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModemInformationToolStripMenuItem.Click
        diagInfo.Show()
    End Sub

    Private Sub tmrModem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrModem.Tick
        'Added in 1.0.0.1
        If TextMgr.Model <> "loading..." Then
            tsStatus.Text = "Modem ready"
            tmrModem.Enabled = False
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If TextMgr.isConnected Then
            TextMgr.Disconnect()
            Exit Sub
        End If

        If TextMgr.Model = "loading..." Then
            MsgBox("Check modem compatibility...", MsgBoxStyle.Information, "Please wait...")
            Exit Sub
        End If

        TextMgr.Connect()
        tsStatus.Text = TextMgr.ModemStatus
    End Sub

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click
        LoadChild(frmContacts)
    End Sub

    Private Sub btnMassText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMassText.Click
        LoadChild(frmSMS)
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        LoadChild(frmOptions)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error Resume Next

        TextMgr.Disconnect()
        End
    End Sub
End Class
