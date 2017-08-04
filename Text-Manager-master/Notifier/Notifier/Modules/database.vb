Imports MySql.Data.MySqlClient

Module database

    Public Host As String = "localhost"
    Public DatabaseName As String = "notifier"
    Public User As String = "root"
    Public Password As String = ""
    Dim con As New MySqlConnection

    Enum MessageLevel
        System = 0
        Low = 1
        Warning = 2
        Critical = 3
    End Enum

    Public Function LoadMessages() As DataSet
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String 

        mySql = "SELECT * FROM inbox "
        mySql &= "ORDER BY ReceivingDateTime DESC"
        fillData = "Inbox"

        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
            ds.Tables(fillData).Rows.Count

        dbClose()

        Return ds
    End Function

    Public Function LoadSQL(ByVal mySql As String, Optional ByVal fillData As String = "CustomSQL") As DataSet
        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            ds.Clear()
            da = New MySqlDataAdapter(mySql, con)
            da.Fill(ds, fillData)
            Dim MaxRow As Integer = _
                ds.Tables(fillData).Rows.Count

            dbClose()

            Return ds
        Catch ex As Exception
            MsgBox("Cannot do some queries", MsgBoxStyle.Critical, "Load SQL")
            dbClose()
            Return Nothing
        End Try
    End Function

    Public Sub SaveOption(ByVal key As String, ByVal StrVal As String)
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM options WHERE opt_key = '" & key & "'"

        fillData = "SaveData"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim cb As New MySqlCommandBuilder(da)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        If MaxRow > 0 Then
            ds.Tables(fillData).Rows(0).Item("opt_value") = StrVal
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("opt_key") = key
                .Item("opt_value") = StrVal
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
        End If
        da.Update(ds, fillData)

        dbClose()
    End Sub

    Public Function getName(ByVal number As String) As String
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, SQL As String = _
            "SELECT * FROM contacts WHERE RIGHT(contactNumber,9) = RIGHT('" & number & "',9)" '09257577559

        fillData = "Contact"
        ds.Clear()
        da = New MySqlDataAdapter(SQL, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
        ds.Tables(fillData).Rows.Count

        Dim contactName As String = ""
        If MaxRow = 1 Then
            contactName = ds.Tables(fillData).Rows(0).Item("contactName").ToString
        End If

        dbClose()
        Return contactName
    End Function

    Public Function getBranch(ByVal number As String) As String
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, SQL As String = _
            "SELECT * FROM contacts WHERE RIGHT(contactNumber,9) = RIGHT('" & number & "',9)" '09257577559

        fillData = "Contact"
        ds.Clear()
        da = New MySqlDataAdapter(SQL, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = _
        ds.Tables(fillData).Rows.Count

        Dim branchCode As String = ""
        If MaxRow = 1 Then
            branchCode = ds.Tables(fillData).Rows(0).Item("latestBranch").ToString
        End If

        dbClose()
        Return branchCode
    End Function

    Public Function LoadOption(ByVal key As String) As String
        Dim ans As String = "No Value"

        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, SQL As String = _
                "SELECT * FROM options WHERE opt_key = '" & key & "'"

            fillData = "Options"
            ds.Clear()
            da = New MySqlDataAdapter(SQL, con)
            da.Fill(ds, fillData)

            ans = ds.Tables(fillData).Rows(0).Item("opt_value")
            dbClose()
        Catch ex As Exception
            dbClose()
        End Try

        Return ans
    End Function

    ''' <summary>
    ''' Record information in the database log table
    ''' </summary>
    ''' <param name="str">Information</param>
    ''' <param name="Lv">Message Priority</param>
    ''' <remarks></remarks>
    Public Sub LogEntry(ByVal str As String, ByVal Lv As MessageLevel)
        Dim user As String = "Developer"

        Select Case Lv
            Case MessageLevel.System
                str = "[System] " & str
            Case MessageLevel.Low
                str = "[Low] " & str
            Case MessageLevel.Warning
                str = "[Warning!] " & str
            Case MessageLevel.Critical
                str = "[DANGER!!!] " & str
        End Select

        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, SQL As String = _
            "SELECT * FROM logs"

        fillData = "Logs"
        ds.Clear()
        da = New MySqlDataAdapter(SQL, con)
        da.Fill(ds, fillData)

        Dim cb As New MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow

        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("log_user") = user
            .Item("log_msg") = str
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        da.Update(ds, fillData)

        dbClose()
    End Sub

    Friend Sub ClearOutbox()
        Console.WriteLine("Clearing out Outbox")

        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, SQL As String = _
            "SELECT * FROM outbox"

        fillData = "Outbox"
        ds.Clear()
        da = New MySqlDataAdapter(SQL, con)
        da.Fill(ds, fillData)

        Dim cb As New MySqlCommandBuilder(da)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count
        For cnt As Integer = 0 To MaxRow - 1
            With ds.Tables(fillData).Rows(cnt)
                .Delete()
            End With
        Next
        da.Update(ds, fillData)
        dbClose()

        dbOpen()
        SQL = "SELECT * FROM outbox_multipart"
        fillData = "MultiPart"
        ds.Clear()
        da = New MySqlDataAdapter(SQL, con)
        da.Fill(ds, fillData)

        cb = New MySqlCommandBuilder(da)
        MaxRow = ds.Tables(fillData).Rows.Count
        For cnt As Integer = 0 To MaxRow - 1
            With ds.Tables(fillData).Rows(cnt)
                .Delete()
            End With
        Next
        da.Update(ds, fillData)

        dbClose()
    End Sub

    Friend Sub AddReport(ByVal expCustomer As Expiry)
        dbOpen()
        Try
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, mySql As String

            mySql = "SELECT * FROM expiryreports"
            fillData = "Report"

            ds.Clear()
            da = New MySqlDataAdapter(mySql, con)
            da.Fill(ds, fillData)
            Dim cb As New MySqlCommandBuilder(da)
            Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("NAME") = expCustomer.PawnerName
                .Item("TICKET_NO") = expCustomer.TicketNumber
                .Item("PHONE_NO") = expCustomer.PhoneNumber
                .Item("TRANSDATE") = expCustomer.LoanDate
                .Item("EXPI_DATE") = expCustomer.ExpiryDate
                .Item("AUCT_DATE") = expCustomer.AuctionDate
                Select Case expCustomer.Gender
                    Case Expiry.Sex.Male
                        .Item("SEX") = "M"
                    Case Expiry.Sex.Female
                        .Item("SEX") = "F"
                End Select
                .Item("branchCode") = expCustomer.BranchCode
            End With

            ds.Tables(fillData).Rows.Add(dsNewRow)
            da.Update(ds, fillData)
        Catch ex As Exception
            LogEntry("Report saving failure", MessageLevel.Warning)
        End Try

        dbClose()
    End Sub

#Region "Notifier"
    Public Sub StartNotifing()
        FillCollection()
        SendingNotice()
    End Sub

    Friend Sub FillCollection()
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM expiry"

        fillData = "ExpiryForNotice"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        ' Fetch Expiry
        ForNotice.Clear()
        For cnt As Integer = 0 To MaxRow - 1
            With ds.Tables(fillData).Rows(cnt)
                Dim notice As New Expiry
                notice.PawnerName = .Item("NAME")
                notice.TicketNumber = .Item("TICKET_NO")
                notice.ItemType = .Item("ITEMTYPE")
                notice.PhoneNumber = .Item("PHONE_NO")
                notice.LoanDate = .Item("TRANSDATE")
                notice.ExpiryDate = .Item("EXPI_DATE")
                notice.AuctionDate = .Item("AUCT_DATE")
                Select Case .Item("SEX")
                    Case "M"
                        notice.Gender = Expiry.Sex.Male
                    Case "F"
                        notice.Gender = Expiry.Sex.Female
                End Select
                notice.BranchCode = .Item("branchCode")
                ForNotice.Add(notice)
            End With
        Next
        dbClose()
    End Sub

    Public Sub onQueueExpiry(ByVal customer As Expiry)
        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, mySql As String = _
                "SELECT * FROM expiry"

            fillData = "ExpiryOnQueue"
            ds.Clear()
            da = New MySqlDataAdapter(mySql, con)
            da.Fill(ds, fillData)
            Dim cb As New MySqlCommandBuilder(da)
            Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("NAME") = customer.PawnerName
                .Item("TICKET_NO") = customer.TicketNumber
                .Item("ITEMTYPE") = customer.ItemType
                .Item("PHONE_NO") = customer.PhoneNumber
                .Item("TRANSDATE") = customer.LoanDate
                .Item("EXPI_DATE") = customer.ExpiryDate
                .Item("AUCT_DATE") = customer.AuctionDate

                .Item("branchCode") = customer.BranchCode
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            da.Update(ds, fillData)

            dbClose()
        Catch ex As Exception
            dbClose()
            LogEntry(ex.Message.ToCharArray, MessageLevel.Critical)
        End Try
    End Sub

    Friend Sub AddContacts(ByVal customer As Expiry)
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM contacts WHERE RIGHT(contactNumber,9) = '" & customer.PhoneNumber.Substring(customer.PhoneNumber.Length - 9) & "'"

        fillData = "AddContacts"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim cb As New MySqlCommandBuilder(da)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        If MaxRow = 0 Then
            'Add Contacts
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("contactName") = customer.PawnerName
                .Item("contactNumber") = customer.PhoneNumber
                .Item("latestBranch") = customer.BranchCode
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
        ElseIf MaxRow = 1 Then
            'Edit Contacts
            With ds.Tables(fillData).Rows(0)
                .Item("contactName") = customer.PawnerName
                .Item("contactNumber") = customer.PhoneNumber
                .Item("latestBranch") = customer.BranchCode
            End With
        Else
            LogEntry("Unknown contact listing", MessageLevel.Critical)
        End If
        da.Update(ds, fillData)

        dbClose()
    End Sub

    Friend Function isResend(ByVal num As String) As Boolean
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM sentitems ORDER BY SendingDateTime DESC LIMIT 1"
        Dim txtStat As String = String.Empty, txtNum As String = String.Empty

        fillData = "forResend"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        If MaxRow = 1 Then
            txtStat = ds.Tables(fillData).Rows(0).Item("Status")
            txtNum = ds.Tables(fillData).Rows(0).Item("DestinationNumber")
        End If

        dbClose()

        If txtStat.Contains("SendingErr") And (txtNum.Substring(9) = num.Substring(9)) Then
            Return True
        End If

        Return False
    End Function

    Friend Sub RemoveExpiry(ByVal ticketNo As String)
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM expiry WHERE TICKET_NO = '" & ticketNo & "'"

        fillData = "RemoveExpiry"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim cb As New MySqlCommandBuilder(da)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        If MaxRow = 1 Then
            ds.Tables(fillData).Rows(0).Delete()
        Else
            LogEntry("Ticket Not Found or Multiply Value!", MessageLevel.Critical)
        End If
        da.Update(ds, fillData)
        dbClose()
    End Sub

    Friend Function NoQueue() As Boolean
        dbOpen()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, mySql As String = _
            "SELECT * FROM outbox"
        Dim txtStat As String = String.Empty

        fillData = "Pending"
        ds.Clear()
        da = New MySqlDataAdapter(mySql, con)
        da.Fill(ds, fillData)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        dbClose()

        If MaxRow > 0 Then
            frmFileLoader.formUpdate(String.Format("{0} remaining...", MaxRow))
            Return False
        Else
            Return True
        End If
    End Function
#End Region
#Region "Systems Procedures and Functions"
    Public Function TestConnection() As Boolean
        Try
            dbOpen()

            dbClose()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub dbOpen()
        Dim conStr As String
        conStr = "Server=" & Host & ";Database=" & DatabaseName & ";User Id=" & User & ";"
        If Password <> "" Then
            conStr += "Password=" & Password & ";"
        End If

        If con.State = 1 Then
            dbClose()
        End If

        con.ConnectionString = conStr

        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Public Sub dbClose()
        con.Close()
    End Sub
#End Region
End Module
