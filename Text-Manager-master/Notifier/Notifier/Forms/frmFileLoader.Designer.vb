<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileLoader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileLoader))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstFile = New System.Windows.Forms.ListBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnNotice = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lvForNotice = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ofdExcel = New System.Windows.Forms.OpenFileDialog()
        Me.pbSending = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lstFile)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 405)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File List"
        '
        'lstFile
        '
        Me.lstFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstFile.FormattingEnabled = True
        Me.lstFile.Location = New System.Drawing.Point(6, 48)
        Me.lstFile.Name = "lstFile"
        Me.lstFile.Size = New System.Drawing.Size(204, 342)
        Me.lstFile.TabIndex = 3
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(6, 19)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnSend)
        Me.GroupBox2.Controls.Add(Me.btnNotice)
        Me.GroupBox2.Controls.Add(Me.lblStatus)
        Me.GroupBox2.Controls.Add(Me.btnLoad)
        Me.GroupBox2.Controls.Add(Me.lvForNotice)
        Me.GroupBox2.Location = New System.Drawing.Point(236, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 405)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Viewer"
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(549, 19)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(126, 23)
        Me.btnSend.TabIndex = 7
        Me.btnSend.Text = "&Send Notice"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnNotice
        '
        Me.btnNotice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotice.Location = New System.Drawing.Point(417, 19)
        Me.btnNotice.Name = "btnNotice"
        Me.btnNotice.Size = New System.Drawing.Size(126, 23)
        Me.btnNotice.TabIndex = 6
        Me.btnNotice.Text = "&Prepare Notice"
        Me.btnNotice.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(6, 383)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(669, 15)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = resources.GetString("lblStatus.Text")
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(6, 19)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load List"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lvForNotice
        '
        Me.lvForNotice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvForNotice.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvForNotice.FullRowSelect = True
        Me.lvForNotice.GridLines = True
        Me.lvForNotice.Location = New System.Drawing.Point(6, 48)
        Me.lvForNotice.Name = "lvForNotice"
        Me.lvForNotice.Size = New System.Drawing.Size(669, 332)
        Me.lvForNotice.TabIndex = 5
        Me.lvForNotice.UseCompatibleStateImageBehavior = False
        Me.lvForNotice.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Branch"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "TICKET"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "NAME"
        Me.ColumnHeader3.Width = 328
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "EXPIRY"
        Me.ColumnHeader4.Width = 135
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "AUCTION"
        Me.ColumnHeader5.Width = 129
        '
        'ofdExcel
        '
        Me.ofdExcel.Filter = "2007 Excel Format|*.xlsx|2003 Excel Format|*.xls"
        Me.ofdExcel.Multiselect = True
        '
        'pbSending
        '
        Me.pbSending.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbSending.Location = New System.Drawing.Point(0, 413)
        Me.pbSending.Name = "pbSending"
        Me.pbSending.Size = New System.Drawing.Size(929, 13)
        Me.pbSending.TabIndex = 10
        Me.pbSending.Visible = False
        '
        'frmFileLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 426)
        Me.Controls.Add(Me.pbSending)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFileLoader"
        Me.Text = "File Loader"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstFile As System.Windows.Forms.ListBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lvForNotice As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ofdExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNotice As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents pbSending As System.Windows.Forms.ProgressBar
End Class
