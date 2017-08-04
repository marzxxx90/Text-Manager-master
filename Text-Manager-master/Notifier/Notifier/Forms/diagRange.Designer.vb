<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagRange
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
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.btnGen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(9, 9)
        Me.monCal.MaxSelectionCount = 399
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 0
        '
        'btnGen
        '
        Me.btnGen.Location = New System.Drawing.Point(220, 12)
        Me.btnGen.Name = "btnGen"
        Me.btnGen.Size = New System.Drawing.Size(75, 23)
        Me.btnGen.TabIndex = 1
        Me.btnGen.Text = "&Generate"
        Me.btnGen.UseVisualStyleBackColor = True
        '
        'diagRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 186)
        Me.Controls.Add(Me.btnGen)
        Me.Controls.Add(Me.monCal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagRange"
        Me.Text = "Date Range"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGen As System.Windows.Forms.Button
End Class
