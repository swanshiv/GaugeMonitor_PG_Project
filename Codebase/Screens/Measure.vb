Imports System.IO

Public Class Measure
    Dim isFileSelected As Boolean
    Dim isPartChanged As Boolean
    Dim mFactor As Double

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        '010001;C011+999.999 +VBCR = For V1, C1, C2
        '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected
        '123456;C901T/D;18:01:12;05/09/13;C011;+010.006   +VBCR = For V8 with 1 result selected
        Try
            If Data_Ready Then

                In_String = ProvideLanguageCorrectedDecimalPoint(In_String)
                In_String = ProvideLanguageCorrectedListSeperator(In_String)

                If (IsNumeric(Mid(In_String, 13, In_String.Length - 12))) Then

                    Timer2.Enabled = False
                    'Dim file1 As System.IO.StreamWriter = Nothing
                    Dim Partfilepath As String = Mid(lblFileSel.Text, Len("Data Being Captured to: ") + 1)
                    Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
                    If File.Exists(Partfilepath) Then
                        Try
                            lblCounter.Text = (Val(lblCounter.Text) + 1).ToString

                            lblMeasurement.Text = Mid(In_String, 12, In_String.Length - 11)

                            applyColorToReading()

                            If (triColorRunChart.RunChartCurrentSampleCount = triColorRunChart.RunChartTotalSampleCount) Then
                                DataGridView1.Rows.RemoveAt(0)
                            End If
                            DataGridView1.Rows.Add(Format(System.DateTime.Now, "d/M/yyyy") + ";" + Format(System.DateTime.Now, "h:m:s tt"), lblMeasurement.Text)
                            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column3").Style.BackColor = lblMeasurement.BackColor
                            Add_Reading_To_TricolorColumn_Report_Template_File_Version1(Partfilepath, Format(System.DateTime.Now, "d/M/yyyy"), Format(System.DateTime.Now, "h:m:s tt"), lblMeasurement.Text)

                            triColorRunChart.RunChartSamplesValue = Val(Replace(lblMeasurement.Text, Local_Decimal_Place, ".")) * mFactor
                            lblReadingSaved.Visible = True
                            Timer3.Enabled = True
                        Catch ex As Exception
                            MsgBox("Unable to write data to selected file!" & vbCr & "Please check if the file is open or deleted or write protected!", MsgBoxStyle.OkOnly, "File data storage error!")
                        Finally
                            'If Not file1 Is Nothing Then file1.Dispose()
                        End Try
                    Else
                        MsgBox("File do not exist." & vbCr & " Please check if the file exists or has correct permission!", MsgBoxStyle.OkOnly, "File data storage error!")
                    End If
                    Main.ToolStripStatusLabel4.Text = ""
                    In_String = ""
                    Data_Ready = False
                    Timer2.Enabled = True
                Else
                    In_String = ""
                    Data_Ready = False

                    MsgBox("Improper Data Received on serial port" & vbCr & " please check if Communication Settings are correct." & vbCr & "Please also Stop the reception of data and Start again and try! ", MsgBoxStyle.OkOnly, "Improper data received at serial port!")
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Improper Data Received on Serial Port." & vbCr & "Please also Stop the reception of data and Start again and try!", "Improper data received at serial port!", MessageBoxButtons.OKCancel)
        End Try

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        lblReadingSaved.Visible = False
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        'Dim myStream As Stream = Nothing

        If cmbPart.SelectedIndex > -1 Then
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                lblFileSel.Text = ""
                'lblFileSel.Visible = False
                isFileSelected = False
                Try
                    'myStream = OpenFileDialog1.OpenFile()

                    ' Insert code to read the stream here.
                    lblFileSel.Text = "Data Being Captured to: " & OpenFileDialog1.FileName
                    'lblFileSel.Visible = True
                    isFileSelected = True
                    isPartChanged = False

                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    '' Check this again, since we need to make sure we didn't throw an exception on open.
                    'If (myStream IsNot Nothing) Then
                    '    myStream.Close()
                    'End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a part first", "Select Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateFile.Click
        'Dim myStream As Stream
        If cmbPart.SelectedIndex > -1 Then
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                'SaveFileDialog1.FileName = (SaveFileDialog1.FileName & "." & SaveFileDialog1.DefaultExt)
                SaveFileDialog1.FileName = (SaveFileDialog1.FileName)
                'myStream = SaveFileDialog1.OpenFile()
                'If (myStream IsNot Nothing) Then
                '    ' Code to write the stream goes here.
                '    myStream.Close()
                'End If

                Dim Partfilepath As String = SaveFileDialog1.FileName
                'If (File.Exists(Partfilepath)) Then
                Try
                    isFileSelected = False
                    'Dim file1 As System.IO.StreamWriter = New StreamWriter(Partfilepath, True)
                    'file1.WriteLine("")
                    'file1.WriteLine("")

                    'Try
                    Dim dr As DataRow
                    dr = VersaGageMonitorDataSet.Tables("partdetails").Select(" partid=" & cmbPart.SelectedValue)(0)
                    Create_TricolorColumn_Report_Template_File_Version1(SaveFileDialog1.FileName, dr.Item("customername").ToString(), dr.Item("partname").ToString(), dr.Item("machinenum").ToString(), dr.Item("operatorname").ToString(), dr.Item("paramname").ToString(), dr.Item("usl").ToString(), dr.Item("ucl").ToString(), dr.Item("nv").ToString(), dr.Item("lcl").ToString(), dr.Item("lsl").ToString())
                    'file1.WriteLine("Part Name:" & "," & dr.Item("partname").ToString())
                    'file1.WriteLine("Customer Name:" & "," & dr.Item("customername").ToString())
                    'file1.WriteLine("Parameter Name:" & "," & dr.Item("paramname").ToString())
                    'file1.WriteLine("Operator Name:" & "," & dr.Item("operatorname").ToString())
                    'file1.WriteLine("Machine No:" & "," & dr.Item("machinenum").ToString())
                    'Catch ex As Exception
                    '    MsgBox("Please check customer and part configuration", MsgBoxStyle.OkOnly, "Data error!")
                    'End Try

                    'file1.WriteLine("")
                    'file1.WriteLine("")
                    'file1.WriteLine("Component Data Log")
                    'file1.WriteLine("")
                    'file1.WriteLine("")
                    'file1.Close()
                Catch ex As Exception
                    MessageBox.Show("Unable to write data to created file", "Data Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                'Else
                '    MsgBox("Unable to write data to created file", MsgBoxStyle.OkOnly, "File data storage error!")
                'End If
                If (MsgBox("Do you want to store readings to: " & Partfilepath, MsgBoxStyle.YesNo, "Selecting file for storing data!") = MsgBoxResult.Yes) Then
                    lblFileSel.Text = "Data Being Captured to: " & Partfilepath
                    'lblFileSel.Visible = True
                    isFileSelected = True
                Else
                    lblFileSel.Text = ""
                    'lblFileSel.Visible = False
                End If
            End If
        Else
            MessageBox.Show("Please select a part first", "Select Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If isFileSelected AndAlso isPartChanged Then
            If MessageBox.Show("Data for selected part will be saved in same data file. Press OK to select new file or Cancel to continue", "Data File", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.OK Then
                isFileSelected = False
                lblFileSel.Text = ""
                btnSelectFile_Click(sender, e)
            End If
        End If
        isPartChanged = False

        If isFileSelected Then
            If cmbPart.SelectedIndex > -1 Then
                TogglePort(Main.SerialPort1)

                If btnStart.Text.Trim().ToUpper().Equals("START") Then
                    If (Main.SerialPort1.IsOpen = True) Then
                        If Not isFileSelected Then
                            MessageBox.Show("Please select data file to store readings", "Select Data File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            btnStart.Text = "START"
                            btnStart.BackColor = Color.LimeGreen
                            Main.toolStripStatus.Text = ""
                            Data_Ready = False
                            Timer2.Enabled = False
                        Else
                            cmbPart.Enabled = False
                            btnStart.Text = "STOP"
                            btnStart.BackColor = Color.Red
                            'reset counter
                            btnResetCounter_Click(sender, e)
                            'reset right sight measurement list
                            DataGridView1.Rows.Clear()
                            triColorRunChart.RunChartCurrentSampleCount = 0
                            Main.toolStripStatus.Text = "Waiting for data..."
                            Data_Ready = False
                            Timer2.Enabled = True
                            If (TriColorColumn.Visible = True) Then
                                'Main.SerialPort1.ReceivedBytesThreshold = Len("010001;C011+999.999") + 1 '+1 for VBCR ' This setting is for Single channel V1, C1, C2
                            End If
                        End If
                    Else
                        MessageBox.Show("Unable to open serial port", "Port error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnStart.Text = "START"
                        btnStart.BackColor = Color.LimeGreen
                        Main.toolStripStatus.Text = ""
                        Data_Ready = False
                        Timer2.Enabled = False
                    End If
                ElseIf (btnStart.Text.Trim().ToUpper().Equals("STOP")) Then
                    If (Main.SerialPort1.IsOpen = False) Then
                        cmbPart.Enabled = True
                        btnStart.Text = "START"
                        btnStart.BackColor = Color.LimeGreen
                        Main.toolStripStatus.Text = ""
                        Data_Ready = False
                        Timer2.Enabled = False
                    Else
                        MessageBox.Show("Unable to close serial port", "Port error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Please select a part to measure", "Select part", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnStart.Text = "START"
                btnStart.BackColor = Color.LimeGreen
                Main.toolStripStatus.Text = ""
                Data_Ready = False
                Timer2.Enabled = False
            End If
        Else
            MessageBox.Show("Please select data file to store readings", "Select Data File", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnStart.Text = "START"
            btnStart.BackColor = Color.LimeGreen
            Main.toolStripStatus.Text = ""
            Data_Ready = False
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub btnResetCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCounter.Click
        lblCounter.Text = "0"
    End Sub

    Private Sub cmbPart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPart.SelectedIndexChanged
        isFileSelected = False
        isPartChanged = False
        If isFileSelected Then
            isPartChanged = True
        End If

        If Not VersaGageMonitorDataSet.Tables("partdetails") Is Nothing AndAlso VersaGageMonitorDataSet.Tables("partdetails").Rows.Count <= 0 Then
            PartdetailsTableAdapter.Fill(VersaGageMonitorDataSet.partdetails)
        End If

        lblMeasurement.Text = ProvideLanguageCorrectedDecimalPoint(lblMeasurement.Text)

        If cmbPart.SelectedIndex > -1 Then
            Dim dr As DataRow() = VersaGageMonitorDataSet.Tables("partdetails").Select(" partid=" & cmbPart.SelectedValue)
            If Not dr Is Nothing Then
                Dim mUsl As String
                Dim mUcl As String
                Dim mLsl As String
                Dim mLcl As String
                Dim mNv As String
                Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()

                mUsl = formatNumber(dr(0).Item("usl"), 5).ToString().Trim()
                mUcl = formatNumber(dr(0).Item("ucl"), 5).ToString().Trim()
                mLsl = formatNumber(dr(0).Item("lsl"), 5).ToString().Trim()
                mLcl = formatNumber(dr(0).Item("lcl"), 5).ToString().Trim()
                mNv = formatNumber(dr(0).Item("nv"), 5).ToString().Trim()

                txtusl.Text = mUsl
                txtucl.Text = mUcl
                txtlsl.Text = mLsl
                txtlcl.Text = mLcl
                txtnv.Text = mNv
                lblCustName.Text = dr(0).Item("customername").ToString()


                lbluslColor.BackColor = Color.FromArgb(dr(0).Item("uslcolor").ToString())
                lbluclColor.BackColor = Color.FromArgb(dr(0).Item("uclcolor").ToString())
                lbllslColor.BackColor = Color.FromArgb(dr(0).Item("lslcolor").ToString())
                lbllclColor.BackColor = Color.FromArgb(dr(0).Item("lclcolor").ToString())
                lblnvColor.BackColor = Color.FromArgb(dr(0).Item("nvcolor").ToString())

                triColorRunChart.RunChartNominalColor = Color.FromArgb(dr(0).Item("nvcolor").ToString())
                triColorRunChart.RunChartUSLColor = Color.FromArgb(dr(0).Item("uslcolor").ToString())
                triColorRunChart.RunChartLSLColor = Color.FromArgb(dr(0).Item("lslcolor").ToString())
                triColorRunChart.RunChartLCLColor = Color.FromArgb(dr(0).Item("lclcolor").ToString())
                triColorRunChart.RunChartUCLColor = Color.FromArgb(dr(0).Item("uclcolor").ToString())

                Dim mDiff As Double
                mDiff = formatNumber(mUsl - mLsl, 5)
                
                mFactor = 1 'formatNumber(mDiff * 2, 5)

                Dim mUsl1 As Double = CDbl(Val(Replace(txtusl.Text, Local_Decimal_Place, ".")))
                Dim mUcl1 As Double = CDbl(Val(Replace(txtucl.Text, Local_Decimal_Place, ".")))
                Dim mLsl1 As Double = CDbl(Val(Replace(txtlsl.Text, Local_Decimal_Place, ".")))
                Dim mLcl1 As Double = CDbl(Val(Replace(txtlcl.Text, Local_Decimal_Place, ".")))
                Dim mNv1 As Double = CDbl(Val(Replace(txtnv.Text, Local_Decimal_Place, ".")))

                triColorRunChart.RunChartUSL = Val(mUsl1) * mFactor
                triColorRunChart.RunChartUCL = Val(mUcl1) * mFactor
                triColorRunChart.RunChartNominal = Val(mNv1) * mFactor
                triColorRunChart.RunChartLCL = Val(mLcl1) * mFactor
                triColorRunChart.RunChartLSL = Val(mLsl1) * mFactor
                lblMeasurement.Text = ProvideLanguageCorrectedDecimalPoint("+000.000")
                lblMeasurement.BackColor = Color.LightGray
                triColorRunChart.RunChartCurrentSampleCount = 0
                DataGridView1.Rows.Clear()



            End If
        Else
            resetControls()
        End If

    End Sub

    Private Sub resetControls()
        txtusl.Text = ""
        txtucl.Text = ""
        txtlsl.Text = ""
        txtlcl.Text = ""
        txtnv.Text = ""
        lblCustName.Text = ""

        lbluslColor.BackColor = Nothing
        lbluclColor.BackColor = Nothing
        lbllslColor.BackColor = Nothing
        lbllclColor.BackColor = Nothing
        lblnvColor.BackColor = Nothing

        triColorRunChart.RunChartNominalColor = Nothing
        triColorRunChart.RunChartUSLColor = Nothing
        triColorRunChart.RunChartLSLColor = Nothing
        triColorRunChart.RunChartLCLColor = Nothing
        triColorRunChart.RunChartUCLColor = Nothing
    End Sub

    Private Sub applyColorToReading()
        Dim mValue As Double
        Dim mColor As Color = Color.White
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()

        Dim mUsl As Double = CDbl(Val(Replace(txtusl.Text, Local_Decimal_Place, ".")))
        Dim mUcl As Double = CDbl(Val(Replace(txtucl.Text, Local_Decimal_Place, ".")))
        Dim mLsl As Double = CDbl(Val(Replace(txtlsl.Text, Local_Decimal_Place, ".")))
        Dim mLcl As Double = CDbl(Val(Replace(txtlcl.Text, Local_Decimal_Place, ".")))
        Dim mNv As Double = CDbl(Val(Replace(txtnv.Text, Local_Decimal_Place, ".")))
        mValue = CDbl(Val(Replace(lblMeasurement.Text, Local_Decimal_Place, ".")))
        If mValue > mUsl Then
            mColor = lbluslColor.BackColor
        ElseIf mValue < mLsl Then
            mColor = lbllslColor.BackColor
        ElseIf mValue > mUcl AndAlso mValue <= mUsl Then
            mColor = lbluclColor.BackColor
        ElseIf mValue < mLcl AndAlso mValue >= mLsl Then
            mColor = lbllclColor.BackColor
        ElseIf mValue <= mUcl AndAlso mValue >= mLcl Then
            mColor = lblnvColor.BackColor
        End If

        lblMeasurement.BackColor = mColor
        lblMeasurement.Refresh()
    End Sub

    Private Sub Measure_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        IsMeasure = False
        Main.MenuStrip1.Enabled = True
    End Sub

    Private Sub Measure_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Main.SerialPort1.IsOpen Then
            If MsgBox("This will STOP data capture. Do you want to continue?", MsgBoxStyle.YesNo, "Confirm close") = MsgBoxResult.Yes Then
                Main.SerialPort1.Close()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Measure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsMeasure = True
        Me.PartdetailsTableAdapter.Connection.ConnectionString = value
        Me.PartdetailsTableAdapter.Fill(Me.VersaGageMonitorDataSet.partdetails)

        lblMeasurement.Text = ProvideLanguageCorrectedDecimalPoint(lblMeasurement.Text)
        btnStart.BackColor = Color.LimeGreen
        isFileSelected = False
        DataGridView1.Rows.Clear()
        triColorRunChart.RunChartCurrentSampleCount = 0
        cmbPart.SelectedIndex = -1
        lblMeasurement.Text = ProvideLanguageCorrectedDecimalPoint(lblMeasurement.Text)
        Main.MenuStrip1.Enabled = False
    End Sub

End Class