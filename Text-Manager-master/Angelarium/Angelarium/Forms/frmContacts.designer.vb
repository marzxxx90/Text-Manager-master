<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContacts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContacts))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.lvContacts = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbUser = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboCat = New System.Windows.Forms.ComboBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.cboFilterCat = New System.Windows.Forms.ComboBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.gbUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filter"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(60, 6)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(353, 20)
        Me.txtFilter.TabIndex = 0
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(338, 29)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 2
        Me.btnFilter.Text = "&Search"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'lvContacts
        '
        Me.lvContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvContacts.FullRowSelect = True
        Me.lvContacts.Location = New System.Drawing.Point(12, 58)
        Me.lvContacts.MultiSelect = False
        Me.lvContacts.Name = "lvContacts"
        Me.lvContacts.Size = New System.Drawing.Size(401, 359)
        Me.lvContacts.TabIndex = 3
        Me.lvContacts.UseCompatibleStateImageBehavior = False
        Me.lvContacts.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 35
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 206
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Number"
        Me.ColumnHeader3.Width = 99
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Category"
        Me.ColumnHeader4.Width = 80
        '
        'gbUser
        '
        Me.gbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbUser.Controls.Add(Me.btnAdd)
        Me.gbUser.Controls.Add(Me.cboCat)
        Me.gbUser.Controls.Add(Me.txtNumber)
        Me.gbUser.Controls.Add(Me.txtName)
        Me.gbUser.Controls.Add(Me.Label4)
        Me.gbUser.Controls.Add(Me.Label3)
        Me.gbUser.Controls.Add(Me.Label2)
        Me.gbUser.Location = New System.Drawing.Point(419, 58)
        Me.gbUser.Name = "gbUser"
        Me.gbUser.Size = New System.Drawing.Size(284, 143)
        Me.gbUser.TabIndex = 4
        Me.gbUser.TabStop = False
        Me.gbUser.Text = "User"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(203, 107)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboCat
        '
        Me.cboCat.FormattingEnabled = True
        Me.cboCat.Location = New System.Drawing.Point(92, 80)
        Me.cboCat.Name = "cboCat"
        Me.cboCat.Size = New System.Drawing.Size(186, 21)
        Me.cboCat.TabIndex = 6
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(92, 51)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtNumber.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(92, 23)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(186, 20)
        Me.txtName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Location = New System.Drawing.Point(418, 207)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(76, 23)
        Me.btnSelect.TabIndex = 8
        Me.btnSelect.Text = "&Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        Me.btnSelect.Visible = False
        '
        'cboFilterCat
        '
        Me.cboFilterCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterCat.FormattingEnabled = True
        Me.cboFilterCat.Items.AddRange(New Object() {"ALL"})
        Me.cboFilterCat.Location = New System.Drawing.Point(60, 32)
        Me.cboFilterCat.Name = "cboFilterCat"
        Me.cboFilterCat.Size = New System.Drawing.Size(217, 21)
        Me.cboFilterCat.TabIndex = 1
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.Location = New System.Drawing.Point(627, 207)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(76, 23)
        Me.btnDel.TabIndex = 9
        Me.btnDel.Text = "&Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(545, 207)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(76, 23)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'frmContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 426)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.cboFilterCat)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.gbUser)
        Me.Controls.Add(Me.lvContacts)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmContacts"
        Me.Text = "Contacts"
        Me.gbUser.ResumeLayout(False)
        Me.gbUser.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents lvContacts As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbUser As System.Windows.Forms.GroupBox
    Friend WithEvents cboCat As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents cboFilterCat As System.Windows.Forms.ComboBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
End Class
