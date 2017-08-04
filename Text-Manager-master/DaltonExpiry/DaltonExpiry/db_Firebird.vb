Imports System.Data.Odbc

Module db_Firebird
    Public con As OdbcConnection

    Friend dbName As String = "Database.FDB"
    Friend fbUser As String = "SYSDBA"
    Friend fbPass As String = "masterkey"
    Friend fbDataSet As New DataSet

    Private language() As String = _
        {"Connection error failed."}
    Private conStr As String = String.Empty

    Public Sub dbOpen()
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"

        con = New OdbcConnection(conStr)
        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub dbClose()
        con.Close()
    End Sub

    ''' <summary>
    ''' Get the Expired Ticket
    ''' FillData: Expiries
    ''' </summary>
    ''' <param name="st">Start Time</param>
    ''' <param name="et">End Time</param>
    ''' <remarks>Range</remarks>
    Friend Sub dbGetExpiredRange(ByVal st As String, ByVal et As String)
        Try
            Dim startTime As String = st
            Dim endTime As String = et

            If startTime = Nothing Or endTime = Nothing Then
                Exit Sub
            End If

            dbOpen()
            Dim da As OdbcDataAdapter
            Dim fillData As String = "Expiries"
            Dim sql As String = "SELECT * FROM T_PS_TICKET WHERE EXPI_DATE BETWEEN '" & startTime & "' AND '" & endTime & "'"
            sql &= " AND PHONE_NO <> '' AND CHAR_LENGTH(PHONE_NO) = 11 AND STATUS = 'A'"
            Dim ds As New DataSet

            ds.Clear()
            da = New OdbcDataAdapter(sql, con)
            da.Fill(ds, fillData)

            fbDataSet.Clear()
            da.Fill(fbDataSet, fillData)

            Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count
            MaxRow = fbDataSet.Tables(fillData).Rows.Count
            Console.WriteLine("Result is: =======================")
            Console.WriteLine(MaxRow)

            dbClose()
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message.ToString)
            dbClose()
        End Try
    End Sub

    Public Function getTables(ByVal tblName As String) As List(Of String)
        Try
            Dim restrictions As String() = New String() {Nothing, Nothing, tblName, Nothing}

            dbOpen()
            Dim dtbl As DataTable = con.GetSchema("Columns", restrictions)
            dbClose()

            Dim tmpStr As New List(Of String)
            For Each dataRow As DataRow In dtbl.Rows
                tmpStr.Add(dataRow("Column_name"))
            Next

            Return tmpStr
        Catch ex As Exception
            dbClose()
            MsgBox("Error in retrieving tables", MsgBoxStyle.Critical)
            Return Nothing
        End Try
    End Function
End Module
