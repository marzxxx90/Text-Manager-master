Imports MySql.Data.MySqlClient

Public Class frmContacts
    Dim EditID As Integer

    Private Sub frmContacts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LoadContacts()
    End Sub

    Friend Sub SelectMode()
        btnSelect.Visible = True
        lvContacts.MultiSelect = True

        btnEdit.Visible = False
        btnDel.Visible = False
    End Sub

    Private Sub ClearField()
        AddCat(cboCat, False)
        AddCat(cboFilterCat, True)

        txtFilter.Text = ""
        txtName.Text = ""
        txtNumber.Text = ""

        cboCat.SelectedIndex = -1
        cboFilterCat.SelectedIndex = 0
    End Sub

    Private Sub AddCat(ByVal cbo As ComboBox, ByVal withAll As Boolean)
        On Error Resume Next

        With cbo
            .Items.Clear()
            If withAll Then .Items.Add("All")
            .Items.AddRange(getCategories)
            .SelectedIndex = 0
        End With
    End Sub

    Friend Sub LoadContacts(Optional ByVal sql As String = "")
        Try
            dbOpen()
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String

            If sql = "" Then
                sql = "SELECT * FROM contacts ORDER BY contact_name ASC"
            End If

            'sql = InjectUserGroup(sql)
            fillData = "Contacts"
            ds.Clear()
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, fillData)
            Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count
            lvContacts.Items.Clear()

            For cnt As Integer = 0 To MaxRow - 1
                Dim lv As ListViewItem = lvContacts.Items.Add(cnt + 1)
                With ds.Tables(fillData).Rows(cnt)
                    lv.SubItems.Add(.Item("contact_name"))
                    lv.SubItems.Add(.Item("contact_number"))
                    lv.SubItems.Add(.Item("contact_category"))
                End With
            Next

            dbClose()
        Catch ex As Exception
            dbClose()
            MsgBox("Err: " & ex.Message, MsgBoxStyle.Critical, appName)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtNumber.Text = "" Then
            MsgBox("Please fill in the number", MsgBoxStyle.Information, appName)
            Exit Sub
        End If

        If btnAdd.Text = "&Add" Then
            'Add
            SaveEntry(txtName.Text, txtNumber.Text, cboCat.Text)
            ClearField()
            LoadContacts() ' Added in 1.0.0.2
            txtName.Focus()
        Else
            'Edit
            EditContact(EditID)
            LoadContacts()
            EditMode(0)
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim sql As String = _
            "SELECT * FROM contacts WHERE "

        If txtFilter.Text <> "" Then
            sql &= "(contact_name LIKE '%" & _
            Dreadful(txtFilter.Text) & "%' OR contact_number LIKE '%" & Dreadful(txtFilter.Text) & "%')"
        End If
        If cboFilterCat.Text <> "All" Then
            If txtFilter.Text <> "" Then sql &= " AND"
            sql &= " contact_category = '" & Dreadful(cboFilterCat.Text) & "'"
        End If
        If cboFilterCat.Text = "All" And txtFilter.Text = "" Then sql = ""

        Console.WriteLine("Loading SQL : " & sql)
        LoadContacts(sql)
    End Sub

    Private Function InjectUserGroup(ByVal sql As String) As String
        If sql = "" Then GoTo injDone

        If Not sql.Contains("UserGroup") Then
            Dim pos As Integer = sql.ToUpper.IndexOf("WHERE")
            If pos = -1 Then
                Dim dbPos As Integer = sql.ToUpper.IndexOf("FROM")
                Dim endDBnamePos As Integer = dbPos, cnt As Integer = 0
                Do While True
                    endDBnamePos = InStr(endDBnamePos + 2, sql, " ", CompareMethod.Text)
                    cnt += 1
                    If cnt >= 2 Then
                        Exit Do
                    End If
                Loop

                If endDBnamePos = 0 Then
                    sql &= " WHERE UserGroup = '" & mod_system._userID & "'"
                Else
                    sql = sql.Insert(endDBnamePos, " WHERE UserGroup = '" & mod_system._userID & "' ")
                End If
            Else
                sql = sql.Insert(pos + 6, "UserGroup = '" & mod_system._userID & "' AND ")
            End If
        End If

injDone:
        Return sql
    End Function

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        For Each selList As ListViewItem In lvContacts.SelectedItems
            frmSMS.AddRecipient(selList.SubItems(1).Text, selList.SubItems(2).Text)
        Next
        Me.Close()
    End Sub

    Private Sub cboCat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCat.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cboCat.Text <> "" Then
                btnAdd_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub EditMode(ByVal st As Boolean)
        If st Then
            'Active
            btnAdd.Text = "&Save"
            btnEdit.Text = "&Cancel"
            btnDel.Enabled = False
        Else
            'Deactivate
            btnAdd.Text = "&Add"
            btnEdit.Text = "&Edit"
            btnDel.Enabled = True
            ClearField()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lvContacts.SelectedItems.Count <= 0 Then Exit Sub

        If btnEdit.Text = "&Edit" Then
            txtName.Text = lvContacts.FocusedItem.SubItems(1).Text
            txtNumber.Text = lvContacts.FocusedItem.SubItems(2).Text
            cboCat.Text = lvContacts.FocusedItem.SubItems(3).Text

            EditMode(1)

            EditID = getID(txtName.Text, txtNumber.Text)
        Else
            EditMode(0)
        End If

        'EditContact(getID(txtName.Text, txtNumber.Text))
        'LoadContacts()
    End Sub

    Private Sub EditContact(ByVal uid As Integer)
        Dim name As String = Dreadful(txtName.Text)
        Dim num As String = Dreadful(txtNumber.Text)
        Dim cat As String = Dreadful(cboCat.Text)

        dbOpen()

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Dim fillData As String, sql As String

        sql = "SELECT * FROM contacts WHERE contact_id = " & uid

        fillData = "Contacts"
        ds.Clear()
        da = New MySqlDataAdapter(sql, con)
        da.Fill(ds, fillData)
        Dim cb As New MySqlCommandBuilder(da)
        Dim MaxRow As Integer = ds.Tables(fillData).Rows.Count

        If MaxRow <> 1 Then GoTo err
        With ds.Tables(fillData).Rows(0)
            .Item("contact_name") = name
            .Item("contact_number") = num
            .Item("contact_category") = cat
        End With
        da.Update(ds, fillData)

        dbClose()
        MsgBox("Data Updated", MsgBoxStyle.Information, appName)
        Exit Sub
err:
        dbClose()
        MsgBox("Unexpected error occurred" + vbCrLf + "Data not saved", MsgBoxStyle.Critical, "Edit Error")
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        If lvContacts.SelectedItems.Count <= 0 Then Exit Sub

        If vbNo = MsgBox("Do you want to delete " & lvContacts.FocusedItem.SubItems(1).Text & "?", MsgBoxStyle.YesNo) Then
            Exit Sub
        End If

        Try
            Dim num As String = Dreadful(lvContacts.FocusedItem.SubItems(2).Text)

            dbOpen()

            Dim da As MySqlDataAdapter
            Dim ds As New DataSet
            Dim fillData As String, sql As String

            sql = "SELECT * FROM contacts WHERE RIGHT(contact_number,9) = '" & num.Substring(num.Length - 9) & "'"
            Console.WriteLine("Delete SQL: " & sql)
            fillData = "DelContact"
            ds.Clear()
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, fillData)
            Dim cb As New MySqlCommandBuilder(da)

            ds.Tables(fillData).Rows(0).Delete()
            da.Update(ds, fillData)

            dbClose()
            MsgBox("Contact deleted", MsgBoxStyle.Information, appName)
            LoadContacts()
        Catch ex As Exception
            dbClose()

            MsgBox("Unable to delete contact", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub lvContacts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvContacts.DoubleClick
        btnEdit_Click(sender, e)
    End Sub
End Class