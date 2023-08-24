Imports System
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Threading
Imports System.Text
Imports System.Text.RegularExpressions

Public Class PartSettings
    Dim docMode As String
    Dim docMode_OctaGage As String
    Dim custId As Int16 = 0
    Const minNumber As Integer = -999.999
    Const maxNumber As Integer = 999.999
    Dim ParameterName(8) As String
    Dim USL(8) As String
    Dim UCL(8) As String
    Dim NOM(8) As String
    Dim LCL(8) As String
    Dim LSL(8) As String
    Dim Current_Parameter_Pointer As Integer = 0

    Private Sub PartSettings_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Main.MenuStrip1.Enabled = True
    End Sub

    Private Sub PartSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VersaGageMonitorDataSet.CustomerOctaGage' table. You can move, or remove it, as needed.
        'Me.CustomerOctaGageTableAdapter.Fill(Me.VersaGageMonitorDataSet.CustomerOctaGage)
        resetFields()
        resetFieldsOctaGage()
        controlFields(True)
        controlFieldsOctaGage(True)
        resetButtons()
        resetButtonsOctaGage()
        fetchParts()
        'fetchCustomers()'Not Required
        populateUoM()
        lstParts.SelectedIndex = -1
        ListBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        Current_Parameter_Pointer = -1
        Button10.Text = ""
        btnApply.Text = ""
        Main.MenuStrip1.Enabled = False

        Dim foo_I As Integer
        For foo_I = 0 To 8
            ParameterName(foo_I) = ("Parameter" & foo_I.ToString)
            USL(foo_I) = 0.05
            UCL(foo_I) = 0.025
            NOM(foo_I) = 0.0
            LCL(foo_I) = -0.025
            LSL(foo_I) = -0.05
        Next foo_I
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub resetFields()
        docMode = ""
        txtPartName.Text = ""
        txtCustomer.Text = ""
        txtparam.Text = ""
        txtoperator.Text = ""
        txtmachine.Text = ""
        txtusl.Text = 0
        txtucl.Text = 0
        txtnv.Text = 0
        txtlcl.Text = 0
        txtlsl.Text = 0


    End Sub

    Private Sub controlFields(ByVal lock As Boolean)
        txtPartName.Enabled = Not lock
        txtCustomer.Enabled = Not lock
        txtusl.Enabled = Not lock
        txtucl.Enabled = Not lock
        txtnv.Enabled = Not lock
        txtlcl.Enabled = Not lock
        txtlsl.Enabled = Not lock
        txtparam.Enabled = Not lock
        txtoperator.Enabled = Not lock
        txtmachine.Enabled = Not lock

        btnusl.Enabled = Not lock
        btnlsl.Enabled = Not lock
        btnucl.Enabled = Not lock
        btnlcl.Enabled = Not lock
        btnnv.Enabled = Not lock

        If lock Then
            btnucl.BackColor = Color.Yellow
            btnlcl.BackColor = Color.Yellow
            btnnv.BackColor = Color.Green
            btnusl.BackColor = Color.Red
            btnlsl.BackColor = Color.Red
        End If
    End Sub

    Private Sub resetButtons()
        btnApply.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnAdd.Enabled = True

        controlFields(True)
    End Sub

    Private Sub fetchParts()
        Try
            Me.PartdetailsTableAdapter.Fill(Me.VersaGageMonitorDataSet.partdetails)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Try
            Me.CustomerOctaGageTableAdapter.Fill(Me.VersaGageMonitorDataSet.CustomerOctaGage)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub fetchCustomers()
    '    Me.CustomerTriColorColumnTableAdapter.Fill(Me.VersaGageMonitorDataSet.CustomerTriColorColumn)
    'End Sub

    Private Sub populateUoM()
        ComboBox2.DataSource = New Object() {"1", "2", "3", "4", "5", "6", "7", "8"}

    End Sub

    Private Function getColor(ByVal oriColor As Color) As Color
        If (ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Return ColorDialog1.Color
        Else
            Return oriColor
        End If
    End Function

    Private Sub btnucl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnucl.Click
        btnucl.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub btnlcl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlcl.Click
        btnlcl.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub btnlsl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlsl.Click
        btnlsl.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub btnusl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnusl.Click
        btnusl.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub btnnv_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnv.Click
        btnnv.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        btnApply.Enabled = True
        resetButtons()
        resetFields()
        controlFields(False)
        lstParts.SelectedIndex = -1
        docMode = "ADD"
        If (docMode = "ADD") Then

            txtparam.Text = ("Parameter")
            txtusl.Text = 0.05
            txtucl.Text = 0.025
            txtnv.Text = 0.0
            txtlcl.Text = -0.025
            txtlsl.Text = -0.05

        Else

        End If
        btnApply.Text = "Add Part"
        btnApply.Enabled = True
        txtPartName.Focus()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lstParts.SelectedIndex > -1 Then
            populateFields()
            docMode = "EDIT"
            btnApply.Text = "Apply Changes"
            btnApply.Enabled = True
            controlFields(False)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lstParts.SelectedIndex > -1 Then
            populateFields()
            docMode = "DELETE"
            btnApplyChanges_Click(sender, e)
            controlFields(True)
            resetFields()
            resetButtons()
            lstParts.SelectedIndex = -1
        End If
    End Sub

    Private Sub lstParts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstParts.Click
        If lstParts.SelectedIndex > -1 Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
        If lstParts.SelectedIndex > -1 Then
            populateFields()
            docMode = "EDIT"
            btnApply.Text = "Apply Changes"
            btnApply.Enabled = True
            controlFields(False)
        End If
    End Sub

    Private Sub populateFields()
        txtPartName.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("partname").ToString()
        txtCustomer.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("customername").ToString()
        txtoperator.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("operatorname").ToString()
        txtparam.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("paramname").ToString()
        txtmachine.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("machinenum").ToString()

        txtucl.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("ucl").ToString()
        txtlcl.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("lcl").ToString()
        txtnv.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("nv").ToString()
        txtusl.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("usl").ToString()
        txtlsl.Text = VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("lsl").ToString()


        Try
            btnucl.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("uclcolor"))
            btnlcl.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("lclcolor"))
            btnnv.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("nvcolor"))
            btnusl.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("uslcolor"))
            btnlsl.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("partdetails").Rows(lstParts.SelectedIndex).Item("lslcolor"))
        Catch ex As Exception
            'error in loading color
            btnucl.BackColor = Nothing
            btnlcl.BackColor = Nothing
            btnnv.BackColor = Nothing
            btnusl.BackColor = Nothing
            btnlsl.BackColor = Nothing
        End Try

    End Sub

    Private Sub btnApplyChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If (Tolerance_Validated() = True) Then
            Try
                Dim validated As Boolean = False
                Select Case docMode
                    Case "ADD"
                        custId = -1
                        validated = validateForm()
                        If validated Then
                            Dim rw As DataRow
                            Dim mCode As Int16 = 0
                            rw = VersaGageMonitorDataSet.Tables("partdetails").NewRow
                            For Each dr As DataRow In VersaGageMonitorDataSet.Tables("partdetails").Rows
                                If (mCode < dr.Item("partId")) Then
                                    mCode = dr.Item("partId")
                                End If
                            Next
                            rw.Item("partId") = mCode + 1
                            rw.Item("partname") = txtPartName.Text
                            rw.Item("customername") = txtCustomer.Text
                            rw.Item("paramname") = txtparam.Text
                            rw.Item("operatorname") = txtoperator.Text
                            rw.Item("machinenum") = txtmachine.Text
                            rw.Item("ucl") = txtucl.Text
                            rw.Item("lcl") = txtlcl.Text
                            rw.Item("nv") = txtnv.Text
                            rw.Item("usl") = txtusl.Text
                            rw.Item("lsl") = txtlsl.Text
                            rw.Item("uclcolor") = btnucl.BackColor.ToArgb()
                            rw.Item("lclcolor") = btnlcl.BackColor.ToArgb()
                            rw.Item("nvcolor") = btnnv.BackColor.ToArgb()
                            rw.Item("uslcolor") = btnusl.BackColor.ToArgb()
                            rw.Item("lslcolor") = btnlsl.BackColor.ToArgb()

                            VersaGageMonitorDataSet.Tables("partdetails").Rows.Add(rw)

                            PartdetailsTableAdapter.Update(VersaGageMonitorDataSet.Tables("partdetails"))

                            MessageBox.Show("Part details added successfully")
                        End If
                    Case "EDIT"
                        custId = lstParts.SelectedValue
                        validated = validateForm()
                        If validated Then
                            fetchParts()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("usl") = txtusl.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("lsl") = txtlsl.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("nv") = txtnv.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("ucl") = txtucl.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("lcl") = txtlcl.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("uslcolor") = btnusl.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("lslcolor") = btnlsl.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("nvcolor") = btnnv.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("uclcolor") = btnucl.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("lclcolor") = btnlcl.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("partname") = txtPartName.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("customername") = txtCustomer.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("operatorname") = txtoperator.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("paramname") = txtparam.Text
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partId = " & custId & "")(0).Item("machinenum") = txtmachine.Text
                            PartdetailsTableAdapter.Update(VersaGageMonitorDataSet.Tables("partdetails"))

                            MessageBox.Show("Part details updated successfully")
                        End If
                    Case "DELETE"
                        If MessageBox.Show("Do you really want to delete the selected part?", "Delete Part", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            validated = True
                            VersaGageMonitorDataSet.Tables("partdetails").Select("partid = " & lstParts.SelectedValue & "")(0).Delete()
                            PartdetailsTableAdapter.Update(VersaGageMonitorDataSet.Tables("partdetails"))

                            MessageBox.Show("Part details deleted successfully")
                        End If
                End Select
                If validated Then
                    btnApply.Enabled = False
                    fetchParts()
                    lstParts.SelectedIndex = -1
                    docMode = ""
                    resetFields()
                    resetButtons()
                    controlFields(True)
                    docMode = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MsgBox("Please check tolerence value entered" & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If

    End Sub

    Private Function Tolerance_Validated() As Boolean
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
        If (IsNumeric(txtusl.Text) AndAlso IsNumeric(txtucl.Text) AndAlso IsNumeric(txtnv.Text) AndAlso IsNumeric(txtlcl.Text) AndAlso IsNumeric(txtlsl.Text)) Then
            If (Val(Replace(txtusl.Text, Local_Decimal_Place, ".")) >= Val(Replace(txtucl.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(txtucl.Text, Local_Decimal_Place, ".")) >= Val(Replace(txtnv.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(txtnv.Text, Local_Decimal_Place, ".")) >= Val(Replace(txtlcl.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(txtlcl.Text, Local_Decimal_Place, ".")) >= Val(Replace(txtlsl.Text, Local_Decimal_Place, "."))) Then
                Tolerance_Validated = True
            Else
                Tolerance_Validated = False
            End If
        Else
            Tolerance_Validated = False
        End If



    End Function

    Private Function Tolerance_Validated_OctaGage() As Boolean
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
        If (IsNumeric(TextBox6.Text) AndAlso IsNumeric(TextBox7.Text) AndAlso IsNumeric(TextBox5.Text) AndAlso IsNumeric(TextBox9.Text) AndAlso IsNumeric(TextBox8.Text)) Then
            If (Val(Replace(TextBox6.Text, Local_Decimal_Place, ".")) >= Val(Replace(TextBox7.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(TextBox7.Text, Local_Decimal_Place, ".")) >= Val(Replace(TextBox5.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(TextBox5.Text, Local_Decimal_Place, ".")) >= Val(Replace(TextBox9.Text, Local_Decimal_Place, "."))) AndAlso (Val(Replace(TextBox9.Text, Local_Decimal_Place, ".")) >= Val(Replace(TextBox8.Text, Local_Decimal_Place, "."))) Then

                Tolerance_Validated_OctaGage = True

            Else
                Tolerance_Validated_OctaGage = False
            End If
        Else
            Tolerance_Validated_OctaGage = False
        End If



    End Function

    Private Function validateForm() As Boolean
        If String.IsNullOrEmpty(txtPartName.Text.Trim()) Then
            MessageBox.Show("Please enter Part Number or Name")
            txtPartName.Focus()
            Exit Function
        Else
            Dim isDuplicate As Boolean = False
            If custId = -1 Then
                isDuplicate = VersaGageMonitorDataSet.Tables("partdetails").Select("partname = '" & txtPartName.Text.Trim() & "'").Length > 0
            Else
                isDuplicate = VersaGageMonitorDataSet.Tables("partdetails").Select("partname = '" & txtPartName.Text.Trim() & "' and partid <> " & custId).Length > 0
            End If
            If isDuplicate Then
                MessageBox.Show("Another part with same Number or Name already exists, please change to continue", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPartName.Focus()
                Exit Function
            End If
        End If

        If Not validateRangeNumber(txtusl.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtusl.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(txtucl.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtucl.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(txtnv.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtnv.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(txtlcl.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtlcl.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(txtlsl.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtlsl.Focus()
            Exit Function
        End If
        validateForm = True
    End Function

    Private Function validateForm_OctaGage() As Boolean
        If String.IsNullOrEmpty(TextBox10.Text.Trim()) Then
            MessageBox.Show("Please enter Part Number or Name")
            TextBox10.Focus()
            Exit Function
        Else
            Dim isDuplicate As Boolean = False
            If custId = -1 Then
                isDuplicate = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartName = '" & TextBox10.Text.Trim() & "'").Length > 0
            Else
                isDuplicate = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartName = '" & TextBox10.Text.Trim() & "' and partid <> " & custId).Length > 0
            End If
            If isDuplicate Then
                MessageBox.Show("Part with same Part ID already exists", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TextBox10.Focus()
                Exit Function
            End If
        End If

        If Not validateRangeNumber(TextBox6.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox6.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(TextBox7.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox7.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(TextBox5.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox5.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(TextBox9.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox9.Focus()
            Exit Function
        End If
        If Not validateRangeNumber(TextBox8.Text) Then
            MessageBox.Show("Please make a valid number entry, Please check your tolerances!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBox8.Focus()
            Exit Function
        End If
        validateForm_OctaGage = True
    End Function

    Private Function validateNumber(ByVal input As Object) As Boolean
        If Not String.IsNullOrEmpty(input) Then
            'Need to take care of regional language settings
            'Dim mydecimalseparator As String = My.Computer.Info.InstalledUICulture.NumberFormat.NumberDecimalSeparator
            Dim mydecimalseparator As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim regex As Regex = New Regex("^[+\-]?\d*\" + mydecimalseparator + "?\d*$") 'Indian style . for decimal places and , for list separator
            'Dim regex As Regex = New Regex("^[+\-]?\d*\,?\d*$") 'European style , for decimal places and ; for list separator
            Dim match As Match = regex.Match(input.ToString())

            validateNumber = match.Success
        End If
    End Function

    Private Function validateRangeNumber(ByVal input As Object) As Boolean
        If Not String.IsNullOrEmpty(input) Then
            If validateNumber(input) Then
                If input >= minNumber AndAlso input <= maxNumber Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Update_Result_GroupBox(Val(ComboBox2.Text))
        If RadioButton1.Enabled = True Then
            RadioButton1.Checked = True
            Read_Tolarences_Octagage(1)
        Else

        End If
    End Sub

    Private Sub Update_Result_GroupBox(ByRef Results As Integer)
        If Results = 1 Then
            RadioButton1.Enabled = True

        Else
            RadioButton1.Enabled = False

        End If
        If Results > 1 Then
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
        Else
            'RadioButton1.Enabled = False
            RadioButton2.Enabled = False
        End If
        If Results > 2 Then
            RadioButton3.Enabled = True
        Else
            RadioButton3.Enabled = False
        End If
        If Results > 3 Then
            RadioButton4.Enabled = True
        Else
            RadioButton4.Enabled = False
        End If
        If Results > 4 Then
            RadioButton5.Enabled = True
        Else
            RadioButton5.Enabled = False
        End If
        If Results > 5 Then
            RadioButton6.Enabled = True
        Else
            RadioButton6.Enabled = False
        End If
        If Results > 6 Then
            RadioButton7.Enabled = True
        Else
            RadioButton7.Enabled = False
        End If
        If Results > 7 Then
            RadioButton8.Enabled = True
        Else
            RadioButton8.Enabled = False
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button10.Enabled = True
        resetButtonsOctaGage()
        resetFieldsOctaGage()
        controlFieldsOctaGage(False)
        ListBox1.SelectedIndex = -1
        docMode_OctaGage = "ADD"

        If (docMode_OctaGage = "ADD") Then
            Dim foo_I As Integer
            For foo_I = 0 To 8
                ParameterName(foo_I) = ("Parameter" & foo_I.ToString)
                USL(foo_I) = 0.05
                UCL(foo_I) = 0.025
                NOM(foo_I) = 0.0
                LCL(foo_I) = -0.025
                LSL(foo_I) = -0.05
            Next foo_I
        Else

        End If

        Button10.Text = "Add Part"
        Button10.Enabled = True
        TextBox10.Focus()

        ListBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = 7

        If RadioButton1.Enabled = True Then
            RadioButton1.Checked = True
            Read_Tolarences_Octagage(1)
            Current_Parameter_Pointer = 1
        Else
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex > -1 Then
            populateFieldsOctaGage()
            docMode_OctaGage = "EDIT"
            Button10.Text = "Apply Changes"
            Button10.Enabled = True
            controlFieldsOctaGage(False)

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListBox1.SelectedIndex > -1 Then
            populateFieldsOctaGage()
            docMode_OctaGage = "DELETE"
            Button10_Click(sender, e)
            controlFieldsOctaGage(True)
            resetFieldsOctaGage()
            resetButtonsOctaGage()
            ListBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1

        End If
    End Sub

    Private Sub resetButtonsOctaGage()
        Button10.Enabled = False
        Button4.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False

        controlFieldsOctaGage(True)
    End Sub

    Private Sub resetFieldsOctaGage()
        docMode_OctaGage = ""
        TextBox10.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = 0
        TextBox7.Text = 0
        TextBox5.Text = 0
        TextBox9.Text = 0
        TextBox8.Text = 0
    End Sub

    Private Sub controlFieldsOctaGage(ByVal lock As Boolean)
        TextBox10.Enabled = Not lock
        TextBox4.Enabled = Not lock
        TextBox6.Enabled = Not lock
        TextBox7.Enabled = Not lock
        TextBox5.Enabled = Not lock
        TextBox9.Enabled = Not lock
        TextBox8.Enabled = Not lock
        TextBox3.Enabled = Not lock
        TextBox2.Enabled = Not lock
        TextBox1.Enabled = Not lock
        ComboBox2.Enabled = Not lock


        Button9.Enabled = Not lock
        Button8.Enabled = Not lock
        Button5.Enabled = Not lock
        Button7.Enabled = Not lock
        Button6.Enabled = Not lock

        If lock Then
            Button8.BackColor = Color.Yellow
            Button7.BackColor = Color.Yellow
            Button5.BackColor = Color.Green
            Button9.BackColor = Color.Red
            Button6.BackColor = Color.Red
        End If
    End Sub

    Private Sub populateFieldsOctaGage()
        TextBox10.Text = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("PartName").ToString()
        TextBox4.Text = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("Organisation").ToString()
        TextBox2.Text = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("operatorname").ToString()

        TextBox1.Text = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("machinenum").ToString()
        populateUoM()
        ComboBox2.SelectedIndex = ComboBox2.FindStringExact(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("numberofparameters").ToString())
        If Not (ComboBox2.SelectedValue = "Nothing") Then
            Dim foo_i As Integer
            For foo_i = 1 To Val(ComboBox2.SelectedValue)
                ParameterName(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("ParameterName" & foo_i.ToString)
                USL(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("USL" & foo_i.ToString)
                UCL(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("UCL" & foo_i.ToString)
                NOM(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("NOM" & foo_i.ToString)
                LCL(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("LCL" & foo_i.ToString)
                LSL(foo_i) = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("LSL" & foo_i.ToString)
            Next foo_i
        End If

        Update_Result_GroupBox(Val(ComboBox2.Text))

        Try
            Button9.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("uslcolor"))
            Button8.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("uclcolor"))
            Button5.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("nvcolor"))
            Button7.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("lclcolor"))
            Button6.BackColor = Color.FromArgb(VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows(ListBox1.SelectedIndex).Item("lslcolor"))
        Catch ex As Exception
            'error in loading color
            Button9.BackColor = Nothing
            Button8.BackColor = Nothing
            Button5.BackColor = Nothing
            Button7.BackColor = Nothing
            Button6.BackColor = Nothing
        End Try
        If RadioButton1.Enabled = True Then
            RadioButton1.Checked = True
            Read_Tolarences_Octagage(1)
            Current_Parameter_Pointer = 1
        Else

        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click


        If (Tolerance_Validated_OctaGage() = True) Then
            Try
                If (Current_Parameter_Pointer > -1) Then
                    USL(Current_Parameter_Pointer) = TextBox6.Text
                    UCL(Current_Parameter_Pointer) = TextBox7.Text
                    NOM(Current_Parameter_Pointer) = TextBox5.Text
                    LCL(Current_Parameter_Pointer) = TextBox9.Text
                    LSL(Current_Parameter_Pointer) = TextBox8.Text
                Else
                    'MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
                End If

                Dim validated As Boolean = False
                Dim foo_i As Integer
                Select Case docMode_OctaGage
                    Case "ADD"
                        custId = -1
                        validated = validateForm_OctaGage()
                        If validated Then
                            Dim rw As DataRow
                            Dim mCode As Int16 = 0
                            rw = VersaGageMonitorDataSet.Tables("CustomerOctaGage").NewRow
                            For Each dr As DataRow In VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows
                                If (mCode < dr.Item("PartID")) Then
                                    mCode = dr.Item("PartID")
                                End If
                            Next
                            rw.Item("PartID") = mCode + 1
                            rw.Item("PartName") = TextBox10.Text
                            rw.Item("Organisation") = TextBox4.Text

                            rw.Item("operatorname") = TextBox2.Text
                            rw.Item("machinenum") = TextBox1.Text


                            rw.Item("uslcolor") = Button9.BackColor.ToArgb()
                            rw.Item("uclcolor") = Button8.BackColor.ToArgb()
                            rw.Item("nvcolor") = Button5.BackColor.ToArgb()
                            rw.Item("lclcolor") = Button7.BackColor.ToArgb()
                            rw.Item("lslcolor") = Button6.BackColor.ToArgb()
                            rw.Item("numberofparameters") = ComboBox2.SelectedValue.ToString()


                            If Not (ComboBox2.SelectedValue = "Nothing") Then
                                For foo_i = 1 To Val(ComboBox2.SelectedValue)

                                    rw.Item("ParameterName" & foo_i.ToString) = ParameterName(foo_i).ToString
                                    rw.Item("USL" & foo_i.ToString) = USL(foo_i).ToString
                                    rw.Item("UCL" & foo_i.ToString) = UCL(foo_i).ToString
                                    rw.Item("NOM" & foo_i.ToString) = NOM(foo_i).ToString
                                    rw.Item("LCL" & foo_i.ToString) = LCL(foo_i).ToString
                                    rw.Item("LSL" & foo_i.ToString) = LSL(foo_i).ToString
                                Next foo_i
                            End If
                            'rw.Item("paramname") = txtparam.Text 'To be validated and stored separatly for each parameter
                            'rw.Item("USL") = txtucl.Text
                            'rw.Item("UCL") = txtlcl.Text
                            'rw.Item("NOM") = txtnv.Text
                            'rw.Item("LCL") = txtusl.Text
                            'rw.Item("LSL") = txtlsl.Text

                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows.Add(rw)

                            CustomerOctaGageTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerOctaGage"))

                            MessageBox.Show("Part details added successfully")
                        End If
                    Case "EDIT"
                        custId = ListBox1.SelectedValue
                        validated = validateForm_OctaGage()
                        If validated Then
                            fetchParts()

                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("uslcolor") = Button9.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("lslcolor") = Button6.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("nvcolor") = Button5.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("uclcolor") = Button8.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("lclcolor") = Button7.BackColor.ToArgb()
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("PartName") = TextBox10.Text
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("Organisation") = TextBox4.Text
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("operatorname") = TextBox2.Text
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("machinenum") = TextBox1.Text
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("numberofparameters") = ComboBox2.SelectedValue.ToString()

                            If Not (ComboBox2.SelectedValue = "Nothing") Then
                                For foo_i = 1 To Val(ComboBox2.SelectedValue)

                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("ParameterName" & foo_i.ToString) = ParameterName(foo_i)
                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("USL" & foo_i.ToString) = USL(foo_i)
                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("UCL" & foo_i.ToString) = UCL(foo_i)
                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("NOM" & foo_i.ToString) = NOM(foo_i)
                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("LCL" & foo_i.ToString) = LCL(foo_i)
                                    VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & custId & "")(0).Item("LSL" & foo_i.ToString) = LSL(foo_i)
                                Next foo_i
                            End If


                            CustomerOctaGageTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerOctaGage"))

                            MessageBox.Show("Part details updated successfully")
                        End If
                    Case "DELETE"
                        If MessageBox.Show("Do you really want to delete the selected part?", "Delete Part", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            validated = True
                            VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select("PartID = " & ListBox1.SelectedValue & "")(0).Delete()
                            CustomerOctaGageTableAdapter.Update(VersaGageMonitorDataSet.Tables("CustomerOctaGage"))

                            MessageBox.Show("Part details deleted successfully")
                        End If
                End Select
                If validated Then
                    Button10.Enabled = False
                    fetchParts()
                    ListBox1.SelectedIndex = -1
                    ComboBox2.SelectedIndex = -1
                    docMode_OctaGage = ""
                    resetFieldsOctaGage()
                    resetButtonsOctaGage()
                    controlFieldsOctaGage(True)
                    docMode_OctaGage = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedIndex > -1 Then
            Button2.Enabled = True 'Edit Button
            Button3.Enabled = True 'Delete Button
        End If
        If ListBox1.SelectedIndex > -1 Then
            populateFieldsOctaGage()
            docMode_OctaGage = "EDIT"
            Button10.Text = "Apply Changes"
            Button10.Enabled = True
            controlFieldsOctaGage(False)

        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Button9.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Button8.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button5.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Button7.BackColor = getColor(sender.BackColor)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button6.BackColor = getColor(sender.BackColor)
    End Sub
    
    Private Sub Read_Tolarences_Octagage(ByRef tolIndex As Integer)
        TextBox3.Text = ParameterName(tolIndex)
        TextBox6.Text = USL(tolIndex)
        TextBox7.Text = UCL(tolIndex)
        TextBox5.Text = NOM(tolIndex)
        TextBox9.Text = LCL(tolIndex)
        TextBox8.Text = LSL(tolIndex)
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 1
            Read_Tolarences_Octagage(1)

        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 2
            Read_Tolarences_Octagage(2)
            'Save_Parameter_Name_Octagage(2)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 3
            Read_Tolarences_Octagage(3)
            'Save_Parameter_Name_Octagage(3)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 4
            Read_Tolarences_Octagage(4)
            'Save_Parameter_Name_Octagage(4)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 5
            Read_Tolarences_Octagage(5)
            'Save_Parameter_Name_Octagage(5)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 6
            Read_Tolarences_Octagage(6)
            'Save_Parameter_Name_Octagage(6)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton7.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 7
            Read_Tolarences_Octagage(7)
            'Save_Parameter_Name_Octagage(7)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If


    End Sub

    Private Sub RadioButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton8.Click
        If (Tolerance_Validated_OctaGage() = True) AndAlso (Current_Parameter_Pointer > -1) Then
            USL(Current_Parameter_Pointer) = TextBox6.Text
            UCL(Current_Parameter_Pointer) = TextBox7.Text
            NOM(Current_Parameter_Pointer) = TextBox5.Text
            LCL(Current_Parameter_Pointer) = TextBox9.Text
            LSL(Current_Parameter_Pointer) = TextBox8.Text
            Current_Parameter_Pointer = 8
            Read_Tolarences_Octagage(8)
            'Save_Parameter_Name_Octagage(8)
        Else
            Set_Current_Radiobutton_Selection(Current_Parameter_Pointer)
            Read_Tolarences_Octagage(Current_Parameter_Pointer)
            MsgBox("Please check tolerence value entered for Parameter number- " & Current_Parameter_Pointer.ToString & vbCrLf & "Upper Set Limit should be > or = Upper Control Limit" & vbCrLf & "Upper Control Limit should be > or = Nominal Value" & vbCrLf & "Nominal Value should be > or = Lower Control Limit" & vbCrLf & "Lower Control Limit should be > or = Lower Set Limit", MsgBoxStyle.OkOnly, "Tolerence value entry error!")
        End If

    End Sub

    Private Sub Set_Current_Radiobutton_Selection(ByRef Radio_Pointer As Integer)
        If (Radio_Pointer = 1) Then
            RadioButton1.Checked = True
        ElseIf (Radio_Pointer = 2) Then
            RadioButton2.Checked = True
        ElseIf (Radio_Pointer = 3) Then
            RadioButton3.Checked = True
        ElseIf (Radio_Pointer = 4) Then
            RadioButton4.Checked = True
        ElseIf (Radio_Pointer = 5) Then
            RadioButton5.Checked = True
        ElseIf (Radio_Pointer = 6) Then
            RadioButton6.Checked = True
        ElseIf (Radio_Pointer = 7) Then
            RadioButton7.Checked = True
        ElseIf (Radio_Pointer = 8) Then
            RadioButton8.Checked = True
        Else
            RadioButton1.Checked = True

        End If
    End Sub

    Private Function Tolerance_Index_Octagage() As Integer
        If RadioButton1.Checked = True Then
            Tolerance_Index_Octagage = 1
        ElseIf RadioButton2.Checked = True Then
            Tolerance_Index_Octagage = 2
        ElseIf RadioButton3.Checked = True Then
            Tolerance_Index_Octagage = 3
        ElseIf RadioButton4.Checked = True Then
            Tolerance_Index_Octagage = 4
        ElseIf RadioButton5.Checked = True Then
            Tolerance_Index_Octagage = 5
        ElseIf RadioButton6.Checked = True Then
            Tolerance_Index_Octagage = 6
        ElseIf RadioButton7.Checked = True Then
            Tolerance_Index_Octagage = 7
        ElseIf RadioButton8.Checked = True Then
            Tolerance_Index_Octagage = 8
        End If
    End Function

    Private Sub Save_Parameter_Name_Octagage(ByRef tolIndex As Integer)
        ParameterName(tolIndex) = TextBox3.Text
    End Sub

    Private Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        If Not (docMode_OctaGage = "") Then
            Save_Parameter_Name_Octagage(Tolerance_Index_Octagage())
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress

        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtusl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusl.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtucl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtucl.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtnv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnv.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtlcl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlcl.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtlsl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlsl.KeyPress
        Dim Local_Decimal_Place As String = LanguageCulture.ProvideLanguageDecimalPoint()

        If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar)) AndAlso Not e.KeyChar = CChar(Local_Decimal_Place) AndAlso Not e.KeyChar = "-" Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Local_Decimal_Place) AndAlso TryCast(sender, TextBox).Text.IndexOf(Convert.ToChar(Local_Decimal_Place)) > -1 Then
            e.Handled = True
        ElseIf e.KeyChar = "-"c AndAlso TryCast(sender, TextBox).Text.IndexOf("-"c) > -1 Then
            e.Handled = True
        End If

    End Sub

End Class