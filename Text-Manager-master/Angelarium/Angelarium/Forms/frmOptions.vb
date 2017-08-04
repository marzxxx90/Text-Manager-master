Public Class frmOptions

    Private Sub frmOptions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        TextMgr.Uninstall()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        cboPorts.Items.AddRange(TextMgr.GetPortNames) 'Load Modem Ports
        txtCheckNum.Text = checkNum

        'Database
        txtHost.Text = mod_system._host
        txtDatabase.Text = mod_system._database
        txtUser.Text = mod_system._user
        txtPassword.Text = mod_system._password

        cboPorts.Text = mod_system.port
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        With configFile
            .Load(mod_system._configFile)

            ' Modem
            .AddSection("Modem").AddKey("Port").Value = cboPorts.Text
            .AddSection("Modem").AddKey("Number").Value = txtCheckNum.Text

            ' Database
            .AddSection("Database").AddKey("Host").Value = txtHost.Text
            .AddSection("Database").AddKey("Database").Value = txtDatabase.Text
            .AddSection("Database").AddKey("User").Value = txtUser.Text
            .AddSection("Database").AddKey("Password").Value = txtPassword.Text

            ' Pref
            .AddSection("Pref").AddKey("Min").Value = mod_system.minTimeout
            .AddSection("Pref").AddKey("Max").Value = mod_system.maxTimeout
            .AddSection("Pref").AddKey("Batch").Value = mod_system.batchLimit

            .Save(mod_system._configFile)
        End With

        'Added in 1.0.0.1
        Dim smsdConfig As New IniFile
        With smsdConfig
            .Load("eskie")

            .AddSection("gammu").AddKey("port").Value = cboPorts.Text & ":"
            .AddSection("smsd").AddKey("host").Value = txtHost.Text
            .AddSection("smsd").AddKey("database").Value = txtDatabase.Text
            .AddSection("smsd").AddKey("user").Value = txtUser.Text
            .AddSection("smsd").AddKey("password").Value = txtPassword.Text
            .Save("eskie")
        End With

        TextMgr.Install() ' Install Modem Services
        MsgBox("Configuration Saved", MsgBoxStyle.Information, appName)
        LoadConfiguration() 'Added in 1.0.0.1
        Me.Close()
    End Sub

    Private Sub ClearField()
        cboPorts.Text = ""
        txtCheckNum.Text = ""

        txtHost.Text = ""
        txtDatabase.Text = ""
        txtUser.Text = ""
        txtPassword.Text = ""
    End Sub
End Class