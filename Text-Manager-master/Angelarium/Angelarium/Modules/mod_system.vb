Imports MySql.Data.MySqlClient
Imports suicide

Module mod_system
    Public devMode As Boolean = 0

    Public _userID As String = "Developer"
    Public con As New MySqlConnection
    Public appName As String = "Mass Texting"
    Public TextMgr As New DeathModem

    Friend _host As String = "localhost"
    Friend _database As String = "smsd"
    Friend _user As String = "root"
    Friend _password As String = ""
    Friend configFile As New IniFile
    Friend port As String, checkNum As String
    Friend _configFile As String = "Aerauxel.ini"

    'Preferrence
    Friend minTimeout As Integer = 5
    Friend maxTimeout As Integer = 15
    Friend batchLimit As Integer = 100

    'System
    Friend onQueueCnt As Integer = 0

    ''' <summary>
    ''' To Save New Contacts to the database
    ''' </summary>
    ''' <param name="NewName">Recipient Name</param>
    ''' <param name="NewNumber">Recipient Number</param>
    ''' <param name="NewCat">Recipient Category</param>
    ''' <remarks></remarks>
    Public Sub SaveEntry(ByVal NewName As String, ByVal NewNumber As String, ByVal NewCat As String)
        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, SQL As String

            SQL = "SELECT * FROM contacts WHERE contact_number LIKE '%" & Right(NewNumber, 10) & "'"
            fillData = "Contacts"
            ds.Clear()
            da = New MySqlDataAdapter(SQL, con)
            da.Fill(ds, fillData)
            If ds.Tables(fillData).Rows.Count >= 1 Then
                MsgBox("The number " & NewNumber & " of " & NewName & " already exist!", MsgBoxStyle.Critical, "Message")
                Exit Sub
            End If

            Dim cb As New MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow

            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("contact_name") = Dreadful(NewName)
                .Item("contact_number") = Dreadful(NewNumber)
                .Item("contact_category") = Dreadful(NewCat)
                .Item("userGroup") = _userID
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            da.Update(ds, fillData)

            dbClose()
            MsgBox("New Contact Saved!", MsgBoxStyle.Information)
        Catch ex As Exception
            dbClose()
            MsgBox("Err 001: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function getCategories() As String()
        dbOpen()

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
        "SELECT DISTINCT contact_category " & _
        "FROM contacts"

        fillData = "Categories"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
        ds.Tables(fillData).Rows.Count

        Dim arr(MaxRow - 1) As String
        For cnt As Integer = 0 To MaxRow - 1
            arr(cnt) = ds.Tables(fillData).Rows(cnt).Item("contact_category")
        Next

        dbClose()

        Return arr
    End Function

    Public Sub dbOpen()
        Dim conStr As String
        conStr = "Server=" & _host & ";Database=" & _database & ";User Id=" & _user & ";"
        If _password <> "" Then
            conStr += "Password=" & _password & ";"
        End If

        Console.WriteLine("State is " & con.State)
        If con.State = 1 Then
            dbClose()
        End If

        con.ConnectionString = conStr
        Console.WriteLine("ConnectionString: " & conStr)

        Try
            con.Open()
            Console.WriteLine("Database Connected!")
        Catch ex As Exception
            con.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Sub dbClose()
        con.Close()
        Console.WriteLine("Database Closed...")
    End Sub

    Public Function Dreadful(ByVal str As String) As String
        Dim tmpStr As String = str.Replace("""", "\""")
        tmpStr = tmpStr.Replace("'", "\'")

        Return tmpStr
    End Function

    Public Function LoadConfiguration() As Boolean
        If Not System.IO.File.Exists(_configFile) Then
            System.IO.File.Create(mod_system._configFile).Dispose()
            Return False
        Else
            With configFile
                .Load(_configFile)

                'Database
                _host = .GetSection("Database").GetKey("Host").Value
                _database = .GetSection("Database").GetKey("Database").Value
                _user = .GetSection("Database").GetKey("User").Value
                _password = .GetSection("Database").GetKey("Password").Value

                'Preferrence
                minTimeout = .GetSection("Pref").GetKey("Min").Value
                maxTimeout = .GetSection("Pref").GetKey("Max").Value
                batchLimit = .GetSection("Pref").GetKey("Batch").Value

                'Aerauxel
                port = .GetSection("Modem").GetKey("Port").Value
                checkNum = .GetSection("Modem").GetKey("Number").Value
            End With

            'Added in 1.0.0.1
            Dim smsdConfig As New IniFile
            With smsdConfig
                .Load("eskie")
                'Database
                _host = .GetSection("smsd").GetKey("host").Value
                _database = .GetSection("smsd").GetKey("database").Value
                _user = .GetSection("smsd").GetKey("user").Value
                _password = .GetSection("smsd").GetKey("password").Value
            End With
        End If

        Return True
    End Function

    Public Function getID(ByVal name As String, ByVal num As String) As Integer
        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, SQL As String, uid As Integer

            SQL = String.Format("SELECT * FROM contacts WHERE contact_name = '{0}' AND contact_number = '{1}'", name, num)
            fillData = "Contacts"
            ds.Clear()
            da = New MySqlDataAdapter(SQL, con)
            da.Fill(ds, fillData)
            Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count
            If MaxRow = 1 Then
                uid = ds.Tables(fillData).Rows(0).Item("contact_id")
            Else
                uid = -1
            End If

            dbClose()
            Return uid
        Catch ex As Exception
            dbClose()

            Return -2
        End Try
    End Function

    Public Function hasOnQueue() As Boolean
        dbOpen()

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim onQueue As Boolean = False
        Dim fillData As String, mySql As String = _
        "SELECT * FROM outbox"

        fillData = "OnQueues"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
        ds.Tables(fillData).Rows.Count

        onQueueCnt = MaxRow
        If MaxRow > 0 Then
            onQueue = True
        Else
            onQueue = False
        End If

        dbClose()

        Return onQueue
    End Function

    'Added in 1.0.0.3
    Public Sub EmptyOutbox()
        dbOpen()

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim onQueue As Boolean = False
        Dim fillData As String, mySql As String = _
        "TRUNCATE TABLE outbox"

        fillData = "EmptyOutbox"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim cb As New MySqlCommandBuilder(da)

        dbClose()
    End Sub

    Public Delegate Sub UpdateStatus_dele(ByVal str)
    Public Sub UpdateStatus(ByVal str As String)
        If frmMain.InvokeRequired Then
            frmMain.Invoke(New UpdateStatus_dele(AddressOf UpdateStatus), str)
        Else
            frmMain.tsStatus.Text = str
        End If
    End Sub
End Module
