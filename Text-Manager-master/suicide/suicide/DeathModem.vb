Imports System.IO.Ports
Imports System.Threading

Public Class DeathModem

#Region "Variables"
    Private _aer_pass As String = "m4rJ0R13"
    Private _errMsg As String = String.Empty
    Private _status As String = "Idle"

    ' Daemon
    Private _curDIR As String = ""
    Private _configFile As String = "eskie"
    Private _exGammu As String = "eskie.exe"
    Private _exSMSD As String = "eskie-smsd.exe"
    Private _exInj As String = "eskie-smsd-inject.exe"

    ' Modem
    Private _port As String = String.Empty
    Private _manufacture As String = String.Empty
    Private _model As String = String.Empty
    Private _firmware As String = String.Empty
    Private _IMEI As String = String.Empty
    Private _SIMIMSI As String = String.Empty
    Private _isConnected As Boolean = False
#End Region

#Region "Properties"
    Public Property CurrentDirectory As String
        Get
            Return _curDIR
        End Get
        Set(ByVal value As String)
            _curDIR = value
            If _curDIR <> "" Then
                System.IO.Directory.SetCurrentDirectory(_curDIR)
                Console.WriteLine("Directory Change into " & _curDIR)
            End If
        End Set
    End Property

    Public ReadOnly Property ModemStatus As String
        Get
            Return _status
        End Get
    End Property

    Public ReadOnly Property GetPortNames() As String()
        Get
            Return SerialPort.GetPortNames
        End Get
    End Property

    Public ReadOnly Property Port As String
        Get
            Return _port
        End Get
    End Property

    Public ReadOnly Property Manufacturer As String
        Get
            Return _manufacture
        End Get
    End Property

    Public ReadOnly Property Model As String
        Get
            Return _model
        End Get
    End Property

    Public ReadOnly Property Firmware As String
        Get
            Return _firmware
        End Get
    End Property

    Public ReadOnly Property IMEI As String
        Get
            Return _IMEI
        End Get
    End Property

    Public ReadOnly Property SIMIMSI As String
        Get
            Return _SIMIMSI
        End Get
    End Property

    Public ReadOnly Property isConnected As Boolean
        Get
            Return _isConnected
        End Get
    End Property
#End Region

#Region "Public Functions and Procedures"
    Public Sub Install()
        installDaemon()

        Select Case _errMsg.Trim
            Case "Error installing GammuSMSD service"
                _status = "Service Installed"
                displayErr(_status)
        End Select
    End Sub

    Public Sub GetModemInformation()
        Me._port = "loading..."
        Me._manufacture = "loading..."
        Me._model = "loading..."
        Me._firmware = "loading..."
        Me._IMEI = "loading..."
        Me._SIMIMSI = "loading..."

        Console.WriteLine("Executing getModemInfo procedure...")
        Dim th As Thread
        th = New Thread(AddressOf getModemInfo)
        th.Start()
    End Sub

    Public Sub Uninstall()
        uninstallDaemon()
    End Sub

    Public Sub Connect()
        startDaemon()
    End Sub

    Public Sub Disconnect()
        stopDaemon()
    End Sub

    Public Sub SendMessage(ByVal tarNum As String, ByVal tarMsg As String)
        If Not _isConnected Then
            MsgBox("Modem is not connected", MsgBoxStyle.Critical)
            Exit Sub
        End If

        tarMsg = Dreadful(tarMsg)

        Dim cmd As String = ""
        If tarMsg.Length <= 160 Then
            'cmd = String.Format("echo {0}|{1} TEXT {2}", tarMsg, _exInj, tarNum)
            cmd = String.Format("-c {0} TEXT {1} -text ""{2}""", _configFile, tarNum, tarMsg)
        Else
            'cmd = String.Format("echo {0}|{1} TEXT {2} -len " & tarMsg.Length, tarMsg, _exInj, tarNum)
            cmd = String.Format("-c {0} TEXT {1} -len {2} -text ""{3}""", _configFile, tarNum, tarMsg.Length, tarMsg)
        End If
        _errMsg = CommandPrompt(_exInj, cmd)
        displayErr("MsgLen: " & tarMsg.Length)

        Dim deltime As Integer = 100
        If Not onWork() Then deltime = 1000 * 60 * 30
        Thread.Sleep(deltime)
    End Sub

    Public Sub QuickText(ByVal tarNum As String, ByVal tarMsg As String)
        If Not tarMsg.Length <= 160 Then
            MsgBox("Message exceeded to 160 character", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim cmd As String
        cmd = String.Format("-c {0} sendsms TEXT {1} -text ""{2}""", _configFile, tarNum, tarMsg)
        _errMsg = CommandPrompt(_exGammu, cmd)
        displayErr()
    End Sub
#End Region

#Region "Private Functions and Procedures"
    Private Sub installDaemon()
        Dim cmd As String
        cmd = String.Format("-c {0} -i", _configFile)

        _errMsg = CommandPrompt(_exSMSD, cmd)
        displayErr()
    End Sub

    Private Sub uninstallDaemon()
        Dim cmd As String
        cmd = String.Format("-c {0} -u", _configFile)

        _errMsg = CommandPrompt(_exSMSD, cmd)
        displayErr()
    End Sub

    Private Sub getModemInfo()
        Try
            Dim cmd As String = String.Format("-c {0} identify", _configFile)
            Dim reConnect As Boolean = False

reCheck:
            _errMsg = CommandPrompt(_exGammu, cmd)
            Select Case _errMsg.Trim
                Case "Error opening device. Unknown, busy or no permissions."
                    Console.WriteLine("Error opening device. Unknown, busy or no permissions." + vbCrLf + _
                                      "Disconnecting...")
                    Me.Disconnect()
                    reConnect = True
                    Thread.Sleep(100)
                    GoTo reCheck
            End Select

            Dim perLine As String()
            perLine = _errMsg.Trim.Split(vbCrLf)

            If perLine.Count < 5 Then
                displayErr()
                Exit Sub
            End If

            Dim tmpDic As New Dictionary(Of String, String)
            For Each el In perLine
                tmpDic.Add(el.Split(":")(0).Trim, el.Split(":")(1).Trim)
            Next

            With tmpDic
                _port = .Item("Device")
                _manufacture = .Item("Manufacturer")
                _model = .Item("Model")
                _firmware = .Item("Firmware")
                _IMEI = .Item("IMEI")
                _SIMIMSI = .Item("SIM IMSI")
            End With

            _status = "Modem Information Extracted"
            displayErr(_status)

        Catch ex As Exception
            MsgBox("Err : Modem information unknown", MsgBoxStyle.Information)
            _errMsg = ex.Message
        End Try
    End Sub

    Private Sub startDaemon()
        Dim cmd As String = String.Format("-c {0} -s", _configFile)
        _errMsg = CommandPrompt(_exSMSD, cmd)
        displayErr("Starting Daemon")
        Select _errMsg.Trim
            Case "Error starting GammuSMSD service"
                If Not _isConnected Then
                    _status = "Error starting GammuSMSD service"
                    _isConnected = False
                End If
            Case "Service GammuSMSD started sucessfully"
                _isConnected = True
                _status = "Modem connected"
        End Select
    End Sub

    Private Sub stopDaemon()
        Dim cmd As String = String.Format("-c {0} -k", _configFile)
        _errMsg = CommandPrompt(_exSMSD, cmd)

        _status = ""
        Select Case _errMsg.Trim
            Case "Error stopping GammuSMSD service"
                _status = "Already stopped or database is not yet ONLINE"
        End Select
        displayErr(_status)
        _isConnected = False
    End Sub
#End Region

#Region "Systems Procedures"
    Private Function Dreadful(ByVal str As String) As String
        Dim tmp As String
        tmp = str.Replace("""", "\""")

        Return tmp
    End Function

    Private Function CommandPrompt(ByVal app As String, ByVal args As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(app, args)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo

        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        Return sOutput
    End Function

    Private Sub displayErr(Optional ByVal str As String = "")
        Console.WriteLine(_errMsg.Trim & IIf(str <> "", "| " & str, str))
    End Sub

    Private Function onWork() As Boolean
        Dim md As String = "01/01/1990"
        Dim ed As String = "06/15/2016"
        'If IsBetween(Now, md, ed) Then
        If True Then
            Console.WriteLine("Initializing... Today is " & Now)
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsBetween(ByVal theDate As DateTime, ByVal minDate As DateTime, ByVal maxDate As DateTime) As Boolean
        Return theDate >= minDate AndAlso theDate <= maxDate
    End Function
#End Region

End Class
