Public Class diagInfo

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub diagInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDisplay.Text = _
"Port: " & TextMgr.Port & vbCrLf & "Manufacturer: " & TextMgr.Manufacturer & vbCrLf & "Model: " & TextMgr.Model
        txtDisplay.Text &= vbCrLf & "Firmware: " & TextMgr.Firmware
        txtDisplay.Text &= vbCrLf & "IMEI: " & TextMgr.IMEI
        txtDisplay.Text &= vbCrLf & "SIM IMSI: " & TextMgr.SIMIMSI
    End Sub
End Class