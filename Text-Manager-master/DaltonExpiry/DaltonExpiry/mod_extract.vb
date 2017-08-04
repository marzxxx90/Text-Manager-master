Imports Microsoft.Office.Interop

Module mod_extract
    Enum SaveFileFormat
        Excel = 1
        CSV = 0
    End Enum

    'Excel
    Dim oXL As Excel.Application
    Dim oWB As Excel.Workbook
    Dim oSheet As Excel.Worksheet

    ''' <summary>
    ''' Extract the Dataset to Excel
    ''' </summary>
    ''' <param name="ds">Dataset</param>
    ''' <param name="fillData">fillData</param>
    ''' <param name="url">SaveAs url</param>
    ''' <remarks></remarks>
    Public Sub ExtractToExcel(ByVal ds As DataSet, ByVal fillData As String, ByVal url As String, Optional ByVal fileFormat As SaveFileFormat = SaveFileFormat.Excel)
        Try
            Dim listHeader As List(Of String)
            Dim PhoneIdx As Integer = 0
            listHeader = getTables("T_PS_TICKET")
            listHeader.Add("Eskie")

            oXL = CreateObject("Excel.Application")
            oXL.Visible = False

            oWB = oXL.Workbooks.Add
            oSheet = oWB.ActiveSheet
            oSheet.Name = "Expiries"

            'Headers
            For Each head In listHeader
                oSheet.Cells(1, listHeader.IndexOf(head) + 1).value = head
            Next
            If fileFormat = SaveFileFormat.Excel Then oSheet.Cells.Range("A1", "AV1").Font.Bold = True
            'oSheet.Cells.Range("A1", "AV1").Font.Bold = True
            PhoneIdx = listHeader.IndexOf("PHONE_NO")

            Dim hashList As String = String.Empty
            For cnt = 0 To ds.Tables(fillData).Rows.Count - 1 ' Entries found
                hashList = Nothing
                With ds.Tables(fillData).Rows(cnt)
                    For x As Integer = 0 To listHeader.Count - 2 'less index 0 and column starts at 1, not 0
                        oSheet.Cells(cnt + 2, x + 1).value = If(x = PhoneIdx, "'", "") & .Item(x).ToString
                        hashList &= .Item(x).ToString
                    Next
                    oSheet.Cells(cnt + 2, listHeader.Count).value = hashMe(hashList.Trim)
                End With
                Application.DoEvents()
            Next

            'Save
            If fileFormat = SaveFileFormat.Excel Then
                url &= ".xlsx"
                oWB.SaveAs(url)
            End If
            If fileFormat = SaveFileFormat.CSV Then
                url &= ".csv"
                oWB.SaveAs(url, Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV)
            End If

            MemoryUnload()
            Console.WriteLine("Extracted at " & url)
        Catch ex As Exception
            MemoryUnload()
            MsgBox("Error " & vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "Extracting...")
        End Try
    End Sub

    Private Sub MemoryUnload()
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing
    End Sub
End Module
