Public Class frmOptions

    Public IniConfigFile As String = "Aerauxel.ini"
    Dim config As New IniFile

    Private Sub frmOptions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        modem.Core.Uninstall()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        createIniFile()
        createModemConfig()

        LoadMainOptions()
        If database.TestConnection Then
            LoadOptionConfig()
        End If
    End Sub

    Private Sub createModemConfig()
        If Not System.IO.File.Exists(modem.ModemConfig) Then
            System.IO.File.Create(modem.ModemConfig).Dispose()

            With config
                .Load(modem.ModemConfig)
                .AddSection("gammu").AddKey("port").Value = modem.ModemPort
                .AddSection("smsd").AddKey("password").Value = database.Password
                .AddSection("smsd").AddKey("user").Value = database.User
                .AddSection("smsd").AddKey("database").Value = database.DatabaseName
                .AddSection("smsd").AddKey("host").Value = database.Host
                .Save(modem.ModemConfig)
            End With
        End If
    End Sub

    Private Sub createIniFile()
        If Not System.IO.File.Exists(IniConfigFile) Then
            System.IO.File.Create(IniConfigFile).Dispose()

            With config
                .Load(IniConfigFile)
                .AddSection("Notice").AddKey("Number").Value = modem.NoticeNumber
                .Save(IniConfigFile)
            End With
        End If
    End Sub

    Public Sub LoadMainOptions()
        'Loading M0d3m
        With config
            .Load(modem.ModemConfig)
            modem.ModemPort = .GetSection("gammu").GetKey("port").Value
            database.Host = .GetSection("smsd").GetKey("host").Value
            database.DatabaseName = .GetSection("smsd").GetKey("database").Value
            database.User = .GetSection("smsd").GetKey("user").Value
            database.Password = .GetSection("smsd").GetKey("password").Value
        End With

        'Loading Config
        With config
            .Load(IniConfigFile)
            modem.NoticeNumber = .GetSection("Notice").GetKey("Number").Value
        End With
    End Sub

    Private Sub LoadOptionConfig()
        'Loading M0d3m
        cboPorts.Items.AddRange(modem.Ports)
        With config
            .Load(modem.ModemConfig)
            cboPorts.Text = .GetSection("gammu").GetKey("port").Value
            txtHost.Text = .GetSection("smsd").GetKey("host").Value
            txtDatabase.Text = .GetSection("smsd").GetKey("database").Value
            txtUser.Text = .GetSection("smsd").GetKey("user").Value
            txtPassword.Text = .GetSection("smsd").GetKey("password").Value
        End With

        'Loading Config
        With config
            .Load(IniConfigFile)
            txtCheckNum.Text = .GetSection("Notice").GetKey("Number").Value
        End With
    End Sub

    Private Sub SaveConfig()
        'Mod3m
        With config
            .Load(modem.ModemConfig)
            .AddSection("gammu").AddKey("port").Value = cboPorts.Text
            .AddSection("smsd").AddKey("password").Value = txtPassword.Text
            .AddSection("smsd").AddKey("user").Value = txtUser.Text
            .AddSection("smsd").AddKey("database").Value = txtDatabase.Text
            .AddSection("smsd").AddKey("host").Value = txtHost.Text
            .Save(modem.ModemConfig)
        End With

        'Database
        With config
            .Load(IniConfigFile)
            .AddSection("Notice").AddKey("Number").Value = txtCheckNum.Text
            .Save(IniConfigFile)
        End With

        modem.Core.Install()
        LogEntry("New configuration Saved", MessageLevel.Low)
    End Sub

    Private Sub ClearFields()
        txtCheckNum.Text = ""
        txtDatabase.Text = ""
        txtHost.Text = ""
        txtPassword.Text = ""
        txtUser.Text = ""
        cboPorts.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveConfig()
        MsgBox("Configuration Saved!", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class