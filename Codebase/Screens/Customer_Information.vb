Public Class Customer_Information
    Dim docMode As String

    Private Sub Customer_Information_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        resetFields()
        controlFields(True)
        resetButtons()
        fetchCustomers()
        ListBox1.SelectedIndex = -1
    End Sub

    Private Sub fetchCustomers()
        'TODO: This line of code loads data into the 'VersaGageMonitorDataSet.CustomerTriColorColumn' table. You can move, or remove it, as needed.
        Me.CustomerTriColorColumnTableAdapter.Fill(Me.VersaGageMonitorDataSet.CustomerTriColorColumn)
    End Sub

    Private Sub resetFields()
        docMode = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub resetButtons()
        btnApplyChanges.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnAdd.Enabled = True
        controlFields(True)
    End Sub

    '    Nirschl Präzisionsmechanik
    'Held & Plaschke GmbH
    'Trifthofstr. 56
    '82362 Weilheim
    'Roman Held

    '    Versa Controls
    'Cell:+91-9158992072
    'S.No.432/1/2,Near Paisa Fund,
    'Talegaon Dabhade,
    'DIst. Pune, Pune -410507,
    'Maharashtra, India.
    'e-mail: rnd@versacontrols.com
    'URL: www.versacontrols.com  

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        btnApplyChanges.Enabled = True
        resetButtons()
        resetFields()
        controlFields(False)
        ListBox1.SelectedIndex = -1
        docMode = "ADD"
        btnApplyChanges.Enabled = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ListBox1.SelectedIndex > -1 Then
            populateFields()
            docMode = "EDIT"
            btnApplyChanges.Enabled = True
            controlFields(False)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            populateFields()
            docMode = "DELETE"
            btnApplyChanges.Enabled = True
            controlFields(True)
        End If
    End Sub

    Private Sub controlFields(ByVal lock As Boolean)
        TextBox1.ReadOnly = lock
        TextBox2.ReadOnly = lock
        TextBox3.ReadOnly = lock
        TextBox4.ReadOnly = lock
        TextBox5.ReadOnly = lock
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedIndex > -1 Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub populateFields()
        TextBox1.Text = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows(ListBox1.SelectedIndex).Item("Organisation")
        TextBox2.Text = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows(ListBox1.SelectedIndex).Item("AddressLine1")
        TextBox3.Text = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows(ListBox1.SelectedIndex).Item("AddressLine2")
        TextBox4.Text = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows(ListBox1.SelectedIndex).Item("AddressLine3")
        TextBox5.Text = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows(ListBox1.SelectedIndex).Item("ContactPerson")
    End Sub


    Private Sub btnApplyChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyChanges.Click
        Try
            Select Case docMode
                Case "ADD"
                    If (String.IsNullOrEmpty(TextBox1.Text.Trim()) Or String.IsNullOrEmpty(TextBox5.Text.Trim())) Then
                        MessageBox.Show("Please enter Organization Name and Contact Person")
                        Exit Sub
                    Else
                        Dim rw As DataRow
                        Dim mCode As Int16 = 0
                        rw = VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").NewRow
                        For Each dr As DataRow In VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows
                            If (mCode < dr.Item("CustomerId")) Then
                                mCode = dr.Item("CustomerId")
                            End If
                        Next
                        rw.Item("CustomerId") = mCode + 1
                        rw.Item("Organisation") = TextBox1.Text
                        rw.Item("AddressLine1") = TextBox2.Text
                        rw.Item("AddressLine2") = TextBox3.Text
                        rw.Item("AddressLine3") = TextBox4.Text
                        rw.Item("ContactPerson") = TextBox5.Text
                        VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Rows.Add(rw)

                        CustomerTriColorColumnTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerTriColorColumn"))

                        MessageBox.Show("Customer details added successfully")
                    End If
                Case "EDIT"
                    Dim custId As Int16 = ListBox1.SelectedValue
                    fetchCustomers()
                    VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & custId & "")(0).Item("Organisation") = TextBox1.Text
                    VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & custId & "")(0).Item("AddressLine1") = TextBox2.Text
                    VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & custId & "")(0).Item("AddressLine2") = TextBox3.Text
                    VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & custId & "")(0).Item("AddressLine3") = TextBox4.Text
                    VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & custId & "")(0).Item("ContactPerson") = TextBox5.Text
                    CustomerTriColorColumnTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerTriColorColumn"))

                    MessageBox.Show("Customer details updated successfully")
                Case "DELETE"
                    If MsgBox("Do you really want to delete selected customer", MsgBoxStyle.YesNo, "Delete Customer Details") = MsgBoxResult.Yes Then
                        VersaGageMonitorDataSet.Tables("CustomerTriColorColumn").Select("CustomerId = " & ListBox1.SelectedValue & "")(0).Delete()
                        CustomerTriColorColumnTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerTriColorColumn"))

                        MessageBox.Show("Customer details deleted successfully")
                    End If
            End Select
            btnApplyChanges.Enabled = False
            fetchCustomers()
            ListBox1.SelectedIndex = -1
            resetFields()
            resetButtons()
            controlFields(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class