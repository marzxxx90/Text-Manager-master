<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMS))
        Me.pnNumbers = New System.Windows.Forms.Panel()
        Me.btnM = New System.Windows.Forms.Button()
        Me.btnPlus = New System.Windows.Forms.Button()
        Me.lvRecipient = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkRandom = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimeMin = New System.Windows.Forms.TextBox()
        Me.txtTimeMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtLimit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbNumbers = New System.Windows.Forms.ProgressBar()
        Me.pnNumbers.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnNumbers
        '
        Me.pnNumbers.Controls.Add(Me.btnM)
        Me.pnNumbers.Controls.Add(Me.btnPlus)
        Me.pnNumbers.Controls.Add(Me.lvRecipient)
        Me.pnNumbers.Location = New System.Drawing.Point(12, 12)
        Me.pnNumbers.Name = "pnNumbers"
        Me.pnNumbers.Size = New System.Drawing.Size(239, 236)
        Me.pnNumbers.TabIndex = 0
        '
        'btnM
        '
        Me.btnM.Location = New System.Drawing.Point(197, 45)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(39, 36)
        Me.btnM.TabIndex = 14
        Me.btnM.Text = "-"
        Me.btnM.UseVisualStyleBackColor = True
        '
        'btnPlus
        '
        Me.btnPlus.Location = New System.Drawing.Point(197, 3)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(39, 36)
        Me.btnPlus.TabIndex = 13
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = True
        '
        'lvRecipient
        '
        Me.lvRecipient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvRecipient.FullRowSelect = True
        Me.lvRecipient.Location = New System.Drawing.Point(0, 3)
        Me.lvRecipient.Name = "lvRecipient"
        Me.lvRecipient.Size = New System.Drawing.Size(191, 230)
        Me.lvRecipient.TabIndex = 12
        Me.lvRecipient.UseCompatibleStateImageBehavior = False
        Me.lvRecipient.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 67
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Number"
        Me.ColumnHeader2.Width = 105
        '
        'chkRandom
        '
        Me.chkRandom.AutoSize = True
        Me.chkRandom.Checked = True
        Me.chkRandom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRandom.Location = New System.Drawing.Point(257, 12)
        Me.chkRandom.Name = "chkRandom"
        Me.chkRandom.Size = New System.Drawing.Size(79, 17)
        Me.chkRandom.TabIndex = 1
        Me.chkRandom.Text = "Randomize"
        Me.chkRandom.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(359, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Timeout"
        '
        'txtTimeMin
        '
        Me.txtTimeMin.Location = New System.Drawing.Point(410, 9)
        Me.txtTimeMin.Name = "txtTimeMin"
        Me.txtTimeMin.Size = New System.Drawing.Size(42, 20)
        Me.txtTimeMin.TabIndex = 3
        Me.txtTimeMin.Text = "5"
        '
        'txtTimeMax
        '
        Me.txtTimeMax.Location = New System.Drawing.Point(474, 10)
        Me.txtTimeMax.Name = "txtTimeMax"
        Me.txtTimeMax.Size = New System.Drawing.Size(42, 20)
        Me.txtTimeMax.TabIndex = 4
        Me.txtTimeMax.Text = "15"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(458, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(522, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "min"
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(257, 35)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(546, 171)
        Me.txtMsg.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "0/0"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(260, 225)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 9
        Me.btnSend.Text = "&SEND"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(341, 225)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtLimit
        '
        Me.txtLimit.Location = New System.Drawing.Point(639, 7)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.Size = New System.Drawing.Size(42, 20)
        Me.txtLimit.TabIndex = 12
        Me.txtLimit.Text = "100"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(574, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Batch Limit"
        '
        'pbNumbers
        '
        Me.pbNumbers.Location = New System.Drawing.Point(-1, 119)
        Me.pbNumbers.Name = "pbNumbers"
        Me.pbNumbers.Size = New System.Drawing.Size(816, 23)
        Me.pbNumbers.TabIndex = 14
        Me.pbNumbers.Visible = False
        '
        'frmSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 261)
        Me.Controls.Add(Me.pbNumbers)
        Me.Controls.Add(Me.txtLimit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTimeMax)
        Me.Controls.Add(Me.txtTimeMin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkRandom)
        Me.Controls.Add(Me.pnNumbers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSMS"
        Me.Text = "Texting"
        Me.pnNumbers.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnNumbers As System.Windows.Forms.Panel
    Friend WithEvents chkRandom As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTimeMin As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeMax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvRecipient As System.Windows.Forms.ListView
    Friend WithEvents btnM As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbNumbers As System.Windows.Forms.ProgressBar
End Class
