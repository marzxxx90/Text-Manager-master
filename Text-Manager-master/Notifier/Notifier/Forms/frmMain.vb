Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modem.Initialize()
        tsStatus.Text = "Checking Modem Compatibility..."
        LoadBackground()

        If Not System.IO.File.Exists(frmOptions.IniConfigFile) Then
            LoadChild(frmOptions)
        Else
            frmOptions.LoadMainOptions()
        End If

        checkPending()
    End Sub

    Private Sub LoadBackground()
        Me.LayoutMdi(MdiLayout.Cascade)

        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackgroundImage = My.Resources.wallpaper
                ctl.BackgroundImageLayout = ImageLayout.Center
                Exit For
            End If
        Next ctl
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        modem.Core.Disconnect()
        End
    End Sub

    Private Sub btnQuick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuick.Click
        frmQuick.Show()
        frmQuick.ChangeMode(frmQuick.FormMode.Text)
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        LoadChild(frmOptions)
    End Sub

    Private Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        ClearOutbox()
        Connect()
    End Sub

    Private Sub Connect()
        If modem.Core.Manufacturer = "loading..." Then
            MsgBox("Please wait...", MsgBoxStyle.Information, "Checking Modem")
            Exit Sub
        End If
        If modem.Core.isConnected Then
            Exit Sub
        End If

        modem.Core.Connect()
        If modem.Core.isConnected Then
            tsStatus.Text = "Modem Connected!"
            checkPending()
        End If
    End Sub

    Private Sub tmrChecking_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrChecking.Tick
        If modem.Core.Model <> "loading..." Then
            tsStatus.Text = "Modem Ready!"
            tmrChecking.Enabled = False
        End If
    End Sub

    Private Sub checkPending()
        Dim ds As DataSet = LoadSQL("SELECT * FROM expiry")
        If ds Is Nothing Then
            tmrChecking.Enabled = False
            tsStatus.Text = "Cannot Connect to the database"
            Exit Sub
        End If

        Dim failSend As Integer = ds.Tables(0).Rows.Count
        If failSend > 0 Then
            tsStatus.Text = " | " & failSend & " failed send. Go to NOTIFIER to resend."
        End If
    End Sub

    Private Sub btnExit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Disposed
        btnExit.PerformClick()
    End Sub

    Private Sub btnIncoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncoming.Click
        LoadChild(frmMsg)
    End Sub

    Private Sub btnNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotice.Click
        LoadChild(frmFileLoader)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        btnExit.PerformClick()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        abtTnx.Show()
    End Sub

    Private Sub ManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem.Click
        Dim path As String = GetAppPath() & "\INSTRUCTION MANUAL.docx"
        If System.IO.File.Exists(path) Then
            Process.Start(path)
        Else
            Console.WriteLine("Help not found at " & path)
        End If
    End Sub

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        diagRange.Show()
    End Sub
End Class
