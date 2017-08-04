<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInbox))
        Me.tcMessage = New System.Windows.Forms.TabControl()
        Me.tpInbox = New System.Windows.Forms.TabPage()
        Me.lvInbox = New System.Windows.Forms.ListView()
        Me.Sender = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpOutbox = New System.Windows.Forms.TabPage()
        Me.lvOut = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpSent = New System.Windows.Forms.TabPage()
        Me.lvSent = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.tcMessage.SuspendLayout()
        Me.tpInbox.SuspendLayout()
        Me.tpOutbox.SuspendLayout()
        Me.tpSent.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMessage
        '
        Me.tcMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcMessage.Controls.Add(Me.tpInbox)
        Me.tcMessage.Controls.Add(Me.tpOutbox)
        Me.tcMessage.Controls.Add(Me.tpSent)
        Me.tcMessage.Location = New System.Drawing.Point(3, 1)
        Me.tcMessage.Name = "tcMessage"
        Me.tcMessage.SelectedIndex = 0
        Me.tcMessage.Size = New System.Drawing.Size(693, 326)
        Me.tcMessage.TabIndex = 0
        '
        'tpInbox
        '
        Me.tpInbox.Controls.Add(Me.lvInbox)
        Me.tpInbox.Location = New System.Drawing.Point(4, 22)
        Me.tpInbox.Name = "tpInbox"
        Me.tpInbox.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInbox.Size = New System.Drawing.Size(685, 300)
        Me.tpInbox.TabIndex = 0
        Me.tpInbox.Text = "Inbox"
        Me.tpInbox.UseVisualStyleBackColor = True
        '
        'lvInbox
        '
        Me.lvInbox.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Sender, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvInbox.FullRowSelect = True
        Me.lvInbox.Location = New System.Drawing.Point(6, 6)
        Me.lvInbox.Name = "lvInbox"
        Me.lvInbox.Size = New System.Drawing.Size(676, 287)
        Me.lvInbox.TabIndex = 0
        Me.lvInbox.UseCompatibleStateImageBehavior = False
        Me.lvInbox.View = System.Windows.Forms.View.Details
        '
        'Sender
        '
        Me.Sender.Text = "Sender"
        Me.Sender.Width = 101
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date/Time"
        Me.ColumnHeader1.Width = 99
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Message"
        Me.ColumnHeader2.Width = 299
        '
        'tpOutbox
        '
        Me.tpOutbox.Controls.Add(Me.lvOut)
        Me.tpOutbox.Location = New System.Drawing.Point(4, 22)
        Me.tpOutbox.Name = "tpOutbox"
        Me.tpOutbox.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOutbox.Size = New System.Drawing.Size(685, 300)
        Me.tpOutbox.TabIndex = 1
        Me.tpOutbox.Text = "Outbox"
        Me.tpOutbox.UseVisualStyleBackColor = True
        '
        'lvOut
        '
        Me.lvOut.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvOut.FullRowSelect = True
        Me.lvOut.Location = New System.Drawing.Point(4, 7)
        Me.lvOut.Name = "lvOut"
        Me.lvOut.Size = New System.Drawing.Size(676, 287)
        Me.lvOut.TabIndex = 1
        Me.lvOut.UseCompatibleStateImageBehavior = False
        Me.lvOut.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Sender"
        Me.ColumnHeader3.Width = 101
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date/Time"
        Me.ColumnHeader4.Width = 99
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Message"
        Me.ColumnHeader5.Width = 299
        '
        'tpSent
        '
        Me.tpSent.Controls.Add(Me.lvSent)
        Me.tpSent.Location = New System.Drawing.Point(4, 22)
        Me.tpSent.Name = "tpSent"
        Me.tpSent.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSent.Size = New System.Drawing.Size(685, 300)
        Me.tpSent.TabIndex = 2
        Me.tpSent.Text = "Sent Items"
        Me.tpSent.UseVisualStyleBackColor = True
        '
        'lvSent
        '
        Me.lvSent.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvSent.FullRowSelect = True
        Me.lvSent.Location = New System.Drawing.Point(4, 7)
        Me.lvSent.Name = "lvSent"
        Me.lvSent.Size = New System.Drawing.Size(676, 287)
        Me.lvSent.TabIndex = 1
        Me.lvSent.UseCompatibleStateImageBehavior = False
        Me.lvSent.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Sender"
        Me.ColumnHeader6.Width = 101
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Date/Time"
        Me.ColumnHeader7.Width = 99
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Message"
        Me.ColumnHeader8.Width = 299
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(612, 333)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(531, 333)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 1
        Me.btnView.Text = "&View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'frmInbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 363)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tcMessage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInbox"
        Me.Text = "Inbox"
        Me.tcMessage.ResumeLayout(False)
        Me.tpInbox.ResumeLayout(False)
        Me.tpOutbox.ResumeLayout(False)
        Me.tpSent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMessage As System.Windows.Forms.TabControl
    Friend WithEvents tpInbox As System.Windows.Forms.TabPage
    Friend WithEvents tpOutbox As System.Windows.Forms.TabPage
    Friend WithEvents tpSent As System.Windows.Forms.TabPage
    Friend WithEvents lvInbox As System.Windows.Forms.ListView
    Friend WithEvents Sender As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOut As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSent As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
End Class
