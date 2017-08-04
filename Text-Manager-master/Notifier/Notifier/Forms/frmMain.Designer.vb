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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnConnect = New System.Windows.Forms.ToolStripButton()
        Me.btnNotice = New System.Windows.Forms.ToolStripButton()
        Me.btnIncoming = New System.Windows.Forms.ToolStripButton()
        Me.btnQuick = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ssNotice = New System.Windows.Forms.StatusStrip()
        Me.tsStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrChecking = New System.Windows.Forms.Timer(Me.components)
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenu.SuspendLayout()
        Me.ssNotice.SuspendLayout()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConnect, Me.btnNotice, Me.btnIncoming, Me.btnQuick, Me.ToolStripSeparator1, Me.btnSettings, Me.btnExit})
        Me.tsMenu.Location = New System.Drawing.Point(0, 24)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(733, 84)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "MainMenu"
        '
        'btnConnect
        '
        Me.btnConnect.Image = Global.Notifier.My.Resources.Resources.World_Connect_64
        Me.btnConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(68, 81)
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnNotice
        '
        Me.btnNotice.Image = Global.Notifier.My.Resources.Resources.notifier_64
        Me.btnNotice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNotice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNotice.Name = "btnNotice"
        Me.btnNotice.Size = New System.Drawing.Size(68, 81)
        Me.btnNotice.Text = "Notify"
        Me.btnNotice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnIncoming
        '
        Me.btnIncoming.Image = Global.Notifier.My.Resources.Resources.inbox_icon_64
        Me.btnIncoming.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnIncoming.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIncoming.Name = "btnIncoming"
        Me.btnIncoming.Size = New System.Drawing.Size(68, 81)
        Me.btnIncoming.Text = "Incoming"
        Me.btnIncoming.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnQuick
        '
        Me.btnQuick.Image = Global.Notifier.My.Resources.Resources.Text_Edit_icon_64
        Me.btnQuick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnQuick.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuick.Name = "btnQuick"
        Me.btnQuick.Size = New System.Drawing.Size(68, 81)
        Me.btnQuick.Text = "Quick Text"
        Me.btnQuick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 84)
        '
        'btnSettings
        '
        Me.btnSettings.Image = Global.Notifier.My.Resources.Resources.settings_64x
        Me.btnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(68, 81)
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnExit
        '
        Me.btnExit.Image = Global.Notifier.My.Resources.Resources.cross_icon_64
        Me.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 81)
        Me.btnExit.Text = "E&xit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ssNotice
        '
        Me.ssNotice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStatus})
        Me.ssNotice.Location = New System.Drawing.Point(0, 403)
        Me.ssNotice.Name = "ssNotice"
        Me.ssNotice.Size = New System.Drawing.Size(733, 22)
        Me.ssNotice.TabIndex = 3
        Me.ssNotice.Text = "ss"
        '
        'tsStatus
        '
        Me.tsStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(29, 17)
        Me.tsStatus.Text = "IDLE"
        '
        'tmrChecking
        '
        Me.tmrChecking.Enabled = True
        Me.tmrChecking.Interval = 1000
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(733, 24)
        Me.mainMenu.TabIndex = 5
        Me.mainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ReportToolStripMenuItem.Text = "&Report"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManualToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        Me.ManualToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ManualToolStripMenuItem.Text = "&Manual"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.AboutUsToolStripMenuItem.Text = "&About Us"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 425)
        Me.Controls.Add(Me.ssNotice)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.mainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dalton Rematado|Notifier"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ssNotice.ResumeLayout(False)
        Me.ssNotice.PerformLayout()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNotice As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnIncoming As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuick As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssNotice As System.Windows.Forms.StatusStrip
    Friend WithEvents tsStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrChecking As System.Windows.Forms.Timer
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
