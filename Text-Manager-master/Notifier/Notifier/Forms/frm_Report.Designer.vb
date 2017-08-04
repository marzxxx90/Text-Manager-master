<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dsReportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dsReportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptViewer
        '
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "listReport"
        ReportDataSource1.Value = Me.dsReportBindingSource
        Me.rptViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptViewer.LocalReport.ReportEmbeddedResource = "Notifier.rpt_SentReports.rdlc"
        Me.rptViewer.Location = New System.Drawing.Point(0, 0)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(695, 397)
        Me.rptViewer.TabIndex = 0
        '
        'dsReportBindingSource
        '
        Me.dsReportBindingSource.DataMember = "sentreports"
        Me.dsReportBindingSource.DataSource = GetType(Notifier.dsReport)
        '
        'frm_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 397)
        Me.Controls.Add(Me.rptViewer)
        Me.Name = "frm_Report"
        Me.Text = "Report Viewer"
        CType(Me.dsReportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsReportBindingSource As System.Windows.Forms.BindingSource
End Class
