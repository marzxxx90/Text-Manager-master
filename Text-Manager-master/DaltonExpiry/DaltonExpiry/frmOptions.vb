Public Class frmOptions

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtExport.Text = frmMain.dbExport
        txtBranchCode.Text = frmMain.branchCode
        txtDBName.Text = frmMain.fbDBPath
        cboType.Text = frmMain.fileType
    End Sub

    Private Sub RefreshValue()
        With frmMain.config
            .Load(frmMain.configFile)

            frmMain.hashEskie = .GetSection("Extract").GetKey("Hash").Value
            frmMain.fbDBPath = .GetSection("Extract").GetKey("Path").Value
            frmMain.branchCode = .GetSection("Extract").GetKey("Code").Value
            frmMain.dbExport = .GetSection("Extract").GetKey("Export").Value
            frmMain.fileType = .GetSection("Extract").GetKey("Type").Value
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        With frmMain.config
            .Load(frmMain.configFile)

            .AddSection("Extract").AddKey("Path").Value = txtDBName.Text
            .AddSection("Extract").AddKey("Code").Value = txtBranchCode.Text
            .AddSection("Extract").AddKey("Export").Value = txtExport.Text
            .AddSection("Extract").AddKey("Type").Value = cboType.Text

            .Save(frmMain.configFile)
        End With

        RefreshValue()
        MsgBox("Saved", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub txtDBName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDBName.DoubleClick
        txtDBName.Text = frmMain.defaultDBpath(txtBranchCode.Text)
    End Sub

    Private Sub txtExport_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExport.DoubleClick
        txtExport.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub
End Class