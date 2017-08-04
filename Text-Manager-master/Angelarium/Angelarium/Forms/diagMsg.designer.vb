<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagMsg
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
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReply = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(12, 32)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(279, 104)
        Me.txtMsg.TabIndex = 3
        '
        'txtNum
        '
        Me.txtNum.BackColor = System.Drawing.SystemColors.Info
        Me.txtNum.Location = New System.Drawing.Point(77, 6)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.ReadOnly = True
        Me.txtNum.Size = New System.Drawing.Size(214, 20)
        Me.txtNum.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sender"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(217, 142)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReply
        '
        Me.btnReply.Location = New System.Drawing.Point(136, 142)
        Me.btnReply.Name = "btnReply"
        Me.btnReply.Size = New System.Drawing.Size(75, 23)
        Me.btnReply.TabIndex = 5
        Me.btnReply.Text = "&Reply"
        Me.btnReply.UseVisualStyleBackColor = True
        '
        'diagMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 174)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnReply)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagMsg"
        Me.Text = "Sender"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReply As System.Windows.Forms.Button
End Class
