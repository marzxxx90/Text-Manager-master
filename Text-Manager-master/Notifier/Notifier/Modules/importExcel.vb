Imports Microsoft.Office.Interop

Module importExcel

    Public ForNotice As New ExpiryCollection
    Dim fillData As String = "Expiries"

    Public Sub LoadFile(ByVal filePath() As String)
        Dim ExcelTable As DataTable = New DataTable(fillData)

        For Each fileUrl In filePath
            If validateFile(fileUrl) Then
                'Excel
                Dim oXL As New Excel.Application
                Dim oWB As Excel.Workbook
                Dim oSheet As Excel.Worksheet

                oWB = oXL.Workbooks.Open(fileUrl)
                oSheet = oWB.Worksheets(fillData)

                Dim xHeader() As String, branchCode As String = getBranch(fileUrl)
                Dim MaxColumn As Integer = 0
                With oSheet
                    MaxColumn = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).column
                End With
                Dim MaxEntries As Long = 0
                With oSheet
                    MaxEntries = .Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
                End With
                xHeader = {"TICKET_NO", "NAME", "ITEMTYPE", "DESC1", "DESC2", "DESC3", "DESC4", "PHONE_NO", "EXPI_DATE", "AUCT_DATE", "TRANSDATE", "SEX"}

                Dim hashTable As New Hashtable
                For headIdx As Integer = 1 To MaxColumn
                    If xHeader.Contains(oSheet.Cells(1, headIdx).value) Then
                        hashTable.Add(oSheet.Cells(1, headIdx).value, headIdx)
                    End If
                Next

                ' Entries Loop
                For rowIdx As Integer = 2 To MaxEntries
                    'xHeader = {"TICKET_NO", "NAME",  "ITEMTYPE", "DESC1", "DESC2", "DESC3", "DESC4", "PHONE_NO", "EXPI_DATE", "AUCT_DATE"}
                    Dim newExpr As New Expiry
                    newExpr.TicketNumber = oSheet.Cells(rowIdx, hashTable(xHeader(0))).value
                    newExpr.PawnerName = oSheet.Cells(rowIdx, hashTable(xHeader(1))).value
                    newExpr.ItemType = oSheet.Cells(rowIdx, hashTable(xHeader(2))).value
                    newExpr.Description = {oSheet.Cells(rowIdx, hashTable(xHeader(3))).value, oSheet.Cells(rowIdx, hashTable(xHeader(4))).value, oSheet.Cells(rowIdx, hashTable(xHeader(5))).value, oSheet.Cells(rowIdx, hashTable(xHeader(6))).value}
                    newExpr.PhoneNumber = oSheet.Cells(rowIdx, hashTable(xHeader(7))).value
                    newExpr.ExpiryDate = oSheet.Cells(rowIdx, hashTable(xHeader(8))).value
                    newExpr.AuctionDate = oSheet.Cells(rowIdx, hashTable(xHeader(9))).value
                    newExpr.LoanDate = oSheet.Cells(rowIdx, hashTable(xHeader(10))).value
                    Select Case oSheet.Cells(rowIdx, hashTable(xHeader(11))).value
                        Case "M"
                            newExpr.Gender = Expiry.Sex.Male
                        Case "F"
                            newExpr.Gender=Expiry.Sex.Female 
                    End Select
                    newExpr.BranchCode = branchCode

                    'HashCheck
                    Dim hashCollection As String = String.Empty
                    For hashIdx As Integer = 1 To MaxColumn - 1 'Exclude Checksum
                        With oSheet.Cells(rowIdx, hashIdx)
                            hashCollection &= If(hashIdx = hashTable.Contains("PHONE_NO"), .value.ToString.Substring(1), .value)
                        End With
                    Next

                    If hashMe(hashCollection) = oSheet.Cells(rowIdx, MaxColumn).value Then
                        newExpr.isTampered = False
                    Else
                        newExpr.isTampered = True
                    End If

                    If newExpr.AuctionDate > Now.Date Then
                        Console.WriteLine(newExpr.PawnerName & " added.")
                        ForNotice.Add(newExpr)
                    Else
                        Console.WriteLine(String.Format("PT#{0} not added", newExpr.TicketNumber))
                    End If
                    Application.DoEvents() 'No HANG
                Next

                'Memory Unload
                oSheet = Nothing
                oWB = Nothing
                oXL.Quit()
                oXL = Nothing
            Else
                Dim err As String = "Invalid file " & fileUrl
                frmFileLoader.lblStatus.Text = err
                LogEntry(err, MessageLevel.System)
            End If
        Next
    End Sub

    Private Function validateFile(ByVal url As String) As Boolean
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        Dim allowedHeader() As String = _
            {"ID", "TICKET_NO", "TRANSDATE", "NAME", "ADDRESS1", "ADDRESS2", "ADDRESS3", "ZIP_CODE", "ITEMTYPE", "GRAMS", "NOPCS", "DESC1", "DESC2", "DESC3", "DESC4", "NOMONTH", "MATU_DATE", "EXPI_DATE", "AUCT_DATE", "INT_RATE", "APPRAISAL", "PRINCIPAL", "INT_AMOUNT", "SRV_CHARGE", "VAT_AMOUNT", "DOC_STAMP", "NET_AMOUNT", "USERNAME", "STATUS", "NEW_NO", "OLD_NO", "RCT_NO", "CLOSE_DATE", "TRANSFER_DATE", "DATE_CREATED", "CANCEL_BY", "DATE_CANCEL", "ISBEGBAL", "PHONE_NO", "BIRTH_DATE", "SEX", "KARAT", "KARAT1", "GRAMS1", "APPRAISAL1", "APPRAISEDBY1", "DATE_REAPPRAISAL1", "ITEMDESC"}

        Try
            oWB = oXL.Workbooks.Open(url)
            oSheet = oWB.Worksheets(fillData)

            Dim MaxColumn As Integer = 0
            With oSheet
                MaxColumn = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).column
            End With

            For cnt As Integer = 0 To MaxColumn - 2
                With oSheet
                    If .Cells(1, cnt + 1).value.ToString.Trim <> allowedHeader(cnt).Trim Then
                        Return False
                    End If
                End With
            Next

            Return True
        Catch ex As Exception
            'Memory Unload
            oSheet = Nothing
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            Return False
        End Try
    End Function

    Private Function getBranch(ByVal path As String) As String
        Dim tmpPos As Integer = path.LastIndexOf("\")
        Return path.Substring(tmpPos + 1, 3)
    End Function
End Module
