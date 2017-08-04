Imports System.Threading
Imports System.Reflection

Public Class frmMain
    Public devMode As Boolean = False
    Public configFile As String = "Aerauxel.ini"
    Public config As New IniFile

    Public hashEskie As String = String.Empty 'File Integrity
    Public fbDBPath As String = String.Empty 'Database Path
    Public branchCode As String = String.Empty 'Branch Code
    Public dbExport As String = String.Empty 'Excel File
    Public fileType As String = "Excel"

    Private language() As String = _
        {"Initialization Failed"}
    Private isDone As Boolean = False

    Private Sub frmMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        frmOptions.Show()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialization()
        Dim version As String = Assembly.GetExecutingAssembly().GetName().Version.ToString

        Me.Text &= " | Version " & version
    End Sub

    Private Sub Initialization()
        On Error Resume Next

        If devMode Then MsgBox("Developer Mode Activated", MsgBoxStyle.Information)

        If Not System.IO.File.Exists(configFile) Then
            'Create Configuration File
            System.IO.File.Create(configFile).Dispose()

            With config
                .Load(configFile)
                .AddSection("Extract").AddKey("Hash").Value = "Eskie"
                .AddSection("Extract").AddKey("Path").Value = defaultDBpath("ROX")
                .AddSection("Extract").AddKey("Code").Value = "ROX"
                .AddSection("Extract").AddKey("Export").Value = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .AddSection("Extracct").AddKey("Type").Value = "Excel"
                .Save(configFile)
            End With
        End If

        With config
            .Load(configFile)

            hashEskie = .GetSection("Extract").GetKey("Hash").Value
            fbDBPath = .GetSection("Extract").GetKey("Path").Value
            branchCode = .GetSection("Extract").GetKey("Code").Value
            dbExport = .GetSection("Extract").GetKey("Export").Value
            fileType = .GetSection("Extract").GetKey("Type").Value
        End With
        db_Firebird.dbName = fbDBPath

        viewAds()
    End Sub

    Private Sub viewAds()
        wbAds.Navigate("http://adf.ly/7104086/banner/google.com")
    End Sub

    Public Function defaultDBpath(ByVal code As String) As String
        Dim path As String = String.Format("D:\Remantec\Dalton\{0}\Data\AIS_JUL2010a.FDB", code)
        Return path
    End Function

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If Not System.IO.File.Exists(db_Firebird.dbName) Then
            MsgBox("DB Location not found", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim st As String = dtpFrom.Value.ToString("M/d/yyyy")
        Dim et As String = dtpTo.Value.ToString("M/d/yyyy")
        If devMode Then
            st = "12/1/2014"
            et = "12/31/2014"
        End If

        isDone = False

        dbGetExpiredRange(st, et)
        Frozen(1)
        Dim th As New Thread(AddressOf mainProcedure)
        th.Start()

        While Not isDone
            Application.DoEvents()
        End While

        Frozen(0)
    End Sub

    Private Sub mainProcedure()
        LoadExpiry()
        If lvList.Items.Count > 0 Then
            Extract(fbDataSet, "Expiries")
        Else
            isDone = True
            MsgBox("No result found", MsgBoxStyle.Information)
            Frozen(False)
        End If
    End Sub

    Private Delegate Sub dele_LoadExpiry()
    Private Sub LoadExpiry()
        If lvList.InvokeRequired Then
            Dim d As New dele_LoadExpiry(AddressOf LoadExpiry)
            lvList.Invoke(d)
        Else
            Dim fillData As String = "Expiries"
            Dim MaxResult As Integer = fbDataSet.Tables(fillData).Rows.Count

            For cnt As Integer = 0 To MaxResult - 1
                With fbDataSet.Tables(fillData).Rows(cnt)
                    Dim lv As ListViewItem = lvList.Items.Add(.Item("TICKET_NO").ToString)
                    lv.SubItems.Add(.Item("NAME").ToString)
                    lv.SubItems.Add(.Item("PHONE_NO").ToString)
                    Dim xd As Date
                    xd = Convert.ToDateTime(.Item("EXPI_DATE").ToString)
                    lv.SubItems.Add(xd.ToString("D"))
                    xd = Convert.ToDateTime(.Item("AUCT_DATE").ToString)
                    lv.SubItems.Add(xd.ToString("D"))
                End With
                Application.DoEvents()
            Next
        End If
    End Sub

    Private Sub Frozen(ByVal st As Boolean)
        btnExtract.Enabled = Not st
        lvList.Enabled = Not st
        dtpFrom.Enabled = Not st
        dtpTo.Enabled = Not st
    End Sub

    Private Function generateFilename() As String
        Dim tmpFilename As String
        tmpFilename = branchCode & Now.ToString("MMddyyyy")
        Return tmpFilename
    End Function

    Private Sub Extract(ByVal ds As DataSet, ByVal tbl As String)
        Dim fileName As String = dbExport & "\" & generateFilename()
        Select Case fileType
            Case "Excel"
                mod_extract.ExtractToExcel(ds, tbl, fileName, SaveFileFormat.Excel)
            Case "CSV"
                mod_extract.ExtractToExcel(ds, tbl, fileName, SaveFileFormat.CSV)
        End Select

        MsgBox("Exported " & ds.Tables(tbl).Rows.Count & " entries" & vbCr & "URL: " & fileName, vbInformation)

        isDone = True
    End Sub

    Private Sub lblSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSite.Click
        Process.Start("http://adf.ly/1OHMIb")
    End Sub

    Private Sub lblManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblManual.Click
        Process.Start("manual.docx")
    End Sub

    Private Sub wbAds_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbAds.DocumentCompleted
        pb_it.Visible = False
    End Sub
End Class
