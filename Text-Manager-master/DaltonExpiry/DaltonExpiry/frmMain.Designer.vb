<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.wbAds = New System.Windows.Forms.WebBrowser()
        Me.pb_it = New System.Windows.Forms.PictureBox()
        Me.lblSite = New System.Windows.Forms.Label()
        Me.lblManual = New System.Windows.Forms.Label()
        CType(Me.pb_it, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExtract
        '
        Me.btnExtract.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnExtract.Location = New System.Drawing.Point(664, 10)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(81, 38)
        Me.btnExtract.TabIndex = 0
        Me.btnExtract.Text = "&Extract"
        Me.btnExtract.UseVisualStyleBackColor = False
        '
        'lvList
        '
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.Location = New System.Drawing.Point(12, 54)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(733, 245)
        Me.lvList.TabIndex = 1
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "TICKET"
        Me.ColumnHeader1.Width = 74
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "NAME"
        Me.ColumnHeader2.Width = 228
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "CELLPHONE"
        Me.ColumnHeader3.Width = 123
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "EXPIRY DATE"
        Me.ColumnHeader4.Width = 136
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "AUCTION DATE"
        Me.ColumnHeader5.Width = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(334, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(62, 19)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 6
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(365, 19)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpTo.TabIndex = 7
        '
        'wbAds
        '
        Me.wbAds.Location = New System.Drawing.Point(12, 305)
        Me.wbAds.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbAds.Name = "wbAds"
        Me.wbAds.Size = New System.Drawing.Size(733, 96)
        Me.wbAds.TabIndex = 10
        '
        'pb_it
        '
        Me.pb_it.Image = Global.DaltonExpiry.My.Resources.Resources.itd_728x90
        Me.pb_it.Location = New System.Drawing.Point(12, 305)
        Me.pb_it.Name = "pb_it"
        Me.pb_it.Size = New System.Drawing.Size(733, 96)
        Me.pb_it.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_it.TabIndex = 9
        Me.pb_it.TabStop = False
        '
        'lblSite
        '
        Me.lblSite.AutoSize = True
        Me.lblSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSite.ForeColor = System.Drawing.Color.White
        Me.lblSite.Location = New System.Drawing.Point(7, 405)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(215, 16)
        Me.lblSite.TabIndex = 11
        Me.lblSite.Text = "Visit us at http://pgc-itdept.org"
        '
        'lblManual
        '
        Me.lblManual.AutoSize = True
        Me.lblManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManual.ForeColor = System.Drawing.Color.White
        Me.lblManual.Location = New System.Drawing.Point(707, 405)
        Me.lblManual.Name = "lblManual"
        Me.lblManual.Size = New System.Drawing.Size(41, 16)
        Me.lblManual.TabIndex = 12
        Me.lblManual.Text = "Help"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(760, 424)
        Me.Controls.Add(Me.lblManual)
        Me.Controls.Add(Me.lblSite)
        Me.Controls.Add(Me.pb_it)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.wbAds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "DALTON | Expiry Listing with Cellphone"
        CType(Me.pb_it, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pb_it As System.Windows.Forms.PictureBox
    Friend WithEvents wbAds As System.Windows.Forms.WebBrowser
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents lblManual As System.Windows.Forms.Label

End Class
