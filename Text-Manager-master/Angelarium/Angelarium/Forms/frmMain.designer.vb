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
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnContacts = New System.Windows.Forms.ToolStripButton()
        Me.btnMassText = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModemInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stripStatus = New System.Windows.Forms.StatusStrip()
        Me.tsStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrModem = New System.Windows.Forms.Timer(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.stripStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConnect, Me.ToolStripSeparator3, Me.btnContacts, Me.btnMassText, Me.ToolStripSeparator4, Me.btnSettings, Me.btnExit})
        Me.tsMenu.Location = New System.Drawing.Point(0, 24)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(69, 521)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnConnect
        '
        Me.btnConnect.Image = Global.Angelarium.My.Resources.Resources.disconnect_64x
        Me.btnConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(66, 81)
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(66, 6)
        '
        'btnContacts
        '
        Me.btnContacts.Image = Global.Angelarium.My.Resources.Resources.addressbook_64x
        Me.btnContacts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnContacts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(66, 81)
        Me.btnContacts.Text = "Contacts"
        Me.btnContacts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnMassText
        '
        Me.btnMassText.Image = Global.Angelarium.My.Resources.Resources.sms_64x
        Me.btnMassText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMassText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMassText.Name = "btnMassText"
        Me.btnMassText.Size = New System.Drawing.Size(66, 81)
        Me.btnMassText.Text = "Mass Text"
        Me.btnMassText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(66, 6)
        '
        'btnSettings
        '
        Me.btnSettings.Image = Global.Angelarium.My.Resources.Resources.settings_64x
        Me.btnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(66, 81)
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnExit
        '
        Me.btnExit.Image = Global.Angelarium.My.Resources.Resources.exit_64x
        Me.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 81)
        Me.btnExit.Text = "E&xit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(725, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModemInformationToolStripMenuItem, Me.InboxToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ModemInformationToolStripMenuItem
        '
        Me.ModemInformationToolStripMenuItem.Name = "ModemInformationToolStripMenuItem"
        Me.ModemInformationToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ModemInformationToolStripMenuItem.Text = "&Modem Information"
        '
        'InboxToolStripMenuItem
        '
        Me.InboxToolStripMenuItem.Name = "InboxToolStripMenuItem"
        Me.InboxToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.InboxToolStripMenuItem.Text = "&Messages"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TutorialToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'TutorialToolStripMenuItem
        '
        Me.TutorialToolStripMenuItem.Name = "TutorialToolStripMenuItem"
        Me.TutorialToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.TutorialToolStripMenuItem.Text = "&Tutorial"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.AboutUsToolStripMenuItem.Text = "&About Us"
        '
        'stripStatus
        '
        Me.stripStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStatus})
        Me.stripStatus.Location = New System.Drawing.Point(69, 523)
        Me.stripStatus.Name = "stripStatus"
        Me.stripStatus.Size = New System.Drawing.Size(656, 22)
        Me.stripStatus.TabIndex = 5
        Me.stripStatus.Text = "Idle"
        '
        'tsStatus
        '
        Me.tsStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(25, 17)
        Me.tsStatus.Text = "Idle"
        '
        'tmrModem
        '
        Me.tmrModem.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(725, 545)
        Me.Controls.Add(Me.stripStatus)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Program | Perfecto Group of Companies"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.stripStatus.ResumeLayout(False)
        Me.stripStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TutorialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stripStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tsStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InboxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModemInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrModem As System.Windows.Forms.Timer
    Friend WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnContacts As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMassText As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton

End Class
