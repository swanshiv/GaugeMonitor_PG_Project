Imports System.IO
Imports System
'Imports System.Globalization
'Imports System.Security.Permissions
'Imports System.Threading
'Imports System.Text
'Imports System.Text.RegularExpressions

Public Class MeasureOctaGage

    Dim isFileSelected As Boolean
    Dim isPartChanged As Boolean
    Dim mFactor As Double
    Dim partUoM As String = "mm"
    Dim Number_ofResultsSelected As Integer = 0

    Private Sub MeasureOctaGage_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        IsOctaGage = False
        Main.MenuStrip1.Enabled = True
    End Sub

    Private Sub MeasureOctaGage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Main.SerialPort1.IsOpen Then
            If MsgBox("This will STOP data capture. Do you want to continue?", MsgBoxStyle.YesNo, "Confirm close") = MsgBoxResult.Yes Then
                Main.SerialPort1.Close()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub MeasureOctaGage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IsOctaGage = True


        'TODO: This line of code loads data into the 'VersaGageMonitorDataSet.CustomerOctaGage' table. You can move, or remove it, as needed.
        Me.CustomerOctaGageTableAdapter.Connection.ConnectionString = value
        Me.CustomerOctaGageTableAdapter.Fill(Me.VersaGageMonitorDataSet.CustomerOctaGage)
        'Me.PartdetailsTableAdapter.Fill(Me.VersaGageMonitorDataSet.partdetails)

        'btnStart.BackColor = Color.LimeGreen
        'isFileSelected = False
        'DataGridView1.Rows.Clear()
        'triColorRunChart.RunChartCurrentSampleCount = 0
        'cmbPart.SelectedIndex = -1

        Main.MenuStrip1.Enabled = False
        RunChart1.RunChartCurrentSampleCount = 0
        RunChart2.RunChartCurrentSampleCount = 0
        RunChart3.RunChartCurrentSampleCount = 0
        RunChart4.RunChartCurrentSampleCount = 0

        RunChart9.RunChartCurrentSampleCount = 0
        RunChart10.RunChartCurrentSampleCount = 0
        RunChart11.RunChartCurrentSampleCount = 0
        RunChart12.RunChartCurrentSampleCount = 0

        cmbPart.SelectedIndex = -1
        Number_ofResultsSelected = 0
        Clear_ResultsVisibility()

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        '010001;C011+999.999 +VBCR = For V1, C1, C2
        '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected
        '123456;C901T/D;18:01:12;05/09/13;C011;+010.006   +VBCR = For V8 with 1 result selected

        Try
            If Data_Ready Then

                If Not (Mid(In_String, Len(In_String), 1) = vbCr) Then

                    Timer2.Enabled = False
                    'Dim file1 As System.IO.StreamWriter = Nothing
                    Dim Partfilepath As String = Mid(lblFileSel.Text, Len("Data Being Captured to: ") + 1)
                    If File.Exists(Partfilepath) Then
                        Try

                            lblCounter.Text = (Val(lblCounter.Text) + 1).ToString

                            In_String = ProvideLanguageCorrectedDecimalPoint(In_String)
                            In_String = ProvideLanguageCorrectedListSeperator(In_String)

                            Update_Results(Number_ofResultsSelected, In_String)
                            Add_Reading_To_OctaGage_Report_Template_File_Version1(Partfilepath, Format(System.DateTime.Now, "d/M/yyyy"), Format(System.DateTime.Now, "h:m:s tt"), Label7.Text, In_String)

                            lblReadingSaved.Visible = True
                            Timer3.Enabled = True

                        Catch ex1 As NotFiniteNumberException
                            MsgBox("Improper Data Received on serial port" & vbCr & " please check if number of parameters defined for this part" & vbCr & "are same as number of results displayed on the OctaGage!" & vbCr & "Please also Stop the reception of data and Start again and try! ", MsgBoxStyle.OkOnly, "Improper data received at serial port!")
                        Catch ex2 As Exception
                            MsgBox("Unable to write data to selected file!" & vbCr & "Please check if the file is open or deleted or write protected!", MsgBoxStyle.OkOnly, "File data storage error!")
                            'Finally
                            '    If Not file1 Is Nothing Then file1.Dispose()
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
                    MsgBox("Improper Data Received on serial port" & vbCr & " please check if number of parameters defined for this part" & vbCr & "are same as number of results displayed on the OctaGage!" & vbCr & "Please also Stop the reception of data and Start again and try! ", MsgBoxStyle.OkOnly, "Improper data received at serial port!")
                End If

            Else
            End If
        Catch ex As Exception
            MsgBox("Improper Data Received on serial port" & vbCr & " please check if number of parameters defined for this part" & vbCr & "are same as number of results displayed on the OctaGage!" & vbCr & "Please also Stop the reception of data and Start again and try! ", MsgBoxStyle.OkOnly, "Improper data received at serial port!")
        End Try
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        lblReadingSaved.Visible = False
    End Sub

    Private Sub Initiasile_TabPages(ByVal Ch As Integer, ByRef Data_Row As DataRow())

        If (DataGridView1.Columns.Contains("Column1")) Then
            DataGridView1.Columns.Remove("Column1")
        End If

        If (DataGridView1.Columns.Contains("Column2")) Then
            DataGridView1.Columns.Remove("Column2")
        End If
        If (DataGridView1.Columns.Contains("Column3")) Then
            DataGridView1.Columns.Remove("Column3")
        End If
        If (DataGridView1.Columns.Contains("Column4")) Then
            DataGridView1.Columns.Remove("Column4")
        End If
        If (DataGridView1.Columns.Contains("Column5")) Then
            DataGridView1.Columns.Remove("Column5")
        End If
        If (DataGridView1.Columns.Contains("Column6")) Then
            DataGridView1.Columns.Remove("Column6")
        End If
        If (DataGridView1.Columns.Contains("Column7")) Then
            DataGridView1.Columns.Remove("Column7")
        End If
        If (DataGridView1.Columns.Contains("Column8")) Then
            DataGridView1.Columns.Remove("Column8")
        End If
        If (DataGridView1.Columns.Contains("Column9")) Then
            DataGridView1.Columns.Remove("Column9")
        End If
        If (DataGridView1.Columns.Contains("Column10")) Then
            DataGridView1.Columns.Remove("Column10")
        End If


        If (DataGridView1.Columns.Count = 0) Then
            DataGridView1.Columns.Add("Column1", "Date")
            DataGridView1.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns.Add("Column2", "Time")
            DataGridView1.Columns("Column2").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End If
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()

        If (Ch > 0) Then


            'DRO TabPage1
            Panel5.Visible = True 'Result 1
            Label5.Text = Data_Row(0).Item("ParameterName1")

            DataGridView1.Columns.Add("Column3", Label5.Text)
            DataGridView1.Columns("Column3").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label1.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label1.BackColor = Color.LightGray

            'Run Chart 1-4 TabPage4
            Panel17.Visible = True 'Result 1
            Label105.Text = Data_Row(0).Item("ParameterName1")
            RunChart1.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart1.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart1.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart1.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart1.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label114.Text = formatNumber(Data_Row(0).Item("USL1"), 5).ToString().Trim()
            Label115.Text = formatNumber(Data_Row(0).Item("UCL1"), 5).ToString().Trim()
            Label120.Text = formatNumber(Data_Row(0).Item("NOM1"), 5).ToString().Trim()
            Label121.Text = formatNumber(Data_Row(0).Item("LCL1"), 5).ToString().Trim()
            Label124.Text = formatNumber(Data_Row(0).Item("LSL1"), 5).ToString().Trim()
            'Replace( ,",",".")
            RunChart1.RunChartUSL = Val(Replace(Label114.Text, Local_Decimal_Place, "."))
            RunChart1.RunChartUCL = Val(Replace(Label115.Text, Local_Decimal_Place, "."))
            RunChart1.RunChartNominal = Val(Replace(Label120.Text, Local_Decimal_Place, "."))
            RunChart1.RunChartLCL = Val(Replace(Label121.Text, Local_Decimal_Place, "."))
            RunChart1.RunChartLSL = Val(Replace(Label124.Text, Local_Decimal_Place, "."))

            Label119.Text = ProvideLanguageCorrectedDecimalPoint(Label1.Text)
            Label119.BackColor = Color.LightGray
            'Run Chart 5-8 TabPage5
        Else
            Panel5.Visible = False 'Result 1
            Panel17.Visible = False 'Result 1
        End If
        If (Ch > 1) Then
            'DRO TabPage1
            Panel4.Visible = True 'Result 2
            Label31.Text = Data_Row(0).Item("ParameterName2")

            DataGridView1.Columns.Add("Column4", Label31.Text)
            DataGridView1.Columns("Column4").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label35.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label35.BackColor = Color.LightGray
            'Run Chart 1-4 TabPage4
            Panel18.Visible = True 'Result 2
            Label138.Text = Data_Row(0).Item("ParameterName2")
            RunChart2.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart2.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart2.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart2.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart2.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())


            Label132.Text = formatNumber(Data_Row(0).Item("USL2"), 5).ToString().Trim()
            Label133.Text = formatNumber(Data_Row(0).Item("UCL2"), 5).ToString().Trim()
            Label128.Text = formatNumber(Data_Row(0).Item("NOM2"), 5).ToString().Trim()
            Label129.Text = formatNumber(Data_Row(0).Item("LCL2"), 5).ToString().Trim()
            Label126.Text = formatNumber(Data_Row(0).Item("LSL2"), 5).ToString().Trim()



            RunChart2.RunChartUSL = Val(Replace(Label132.Text, Local_Decimal_Place, "."))
            RunChart2.RunChartUCL = Val(Replace(Label133.Text, Local_Decimal_Place, "."))
            RunChart2.RunChartNominal = Val(Replace(Label128.Text, Local_Decimal_Place, "."))
            RunChart2.RunChartLCL = Val(Replace(Label129.Text, Local_Decimal_Place, "."))
            RunChart2.RunChartLSL = Val(Replace(Label126.Text, Local_Decimal_Place, "."))

            Label137.Text = ProvideLanguageCorrectedDecimalPoint(Label35.Text)
            Label137.BackColor = Color.LightGray
            'Run Chart 5-8 TabPage5
        Else
            Panel4.Visible = False 'Result 2
            Panel18.Visible = False 'Result 2
        End If

        If (Ch > 2) Then
            'DRO TabPage1
            Panel2.Visible = True 'Result 3
            Label17.Text = Data_Row(0).Item("ParameterName3")

            DataGridView1.Columns.Add("Column5", Label17.Text)
            DataGridView1.Columns("Column5").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label21.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label21.BackColor = Color.LightGray

            'Run Chart 1-4 TabPage4
            Panel19.Visible = True 'Result 3
            Label151.Text = Data_Row(0).Item("ParameterName3")
            RunChart3.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart3.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart3.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart3.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart3.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label145.Text = formatNumber(Data_Row(0).Item("USL3"), 5).ToString().Trim()
            Label146.Text = formatNumber(Data_Row(0).Item("UCL3"), 5).ToString().Trim()
            Label141.Text = formatNumber(Data_Row(0).Item("NOM3"), 5).ToString().Trim()
            Label142.Text = formatNumber(Data_Row(0).Item("LCL3"), 5).ToString().Trim()
            Label139.Text = formatNumber(Data_Row(0).Item("LSL3"), 5).ToString().Trim()


            RunChart3.RunChartUSL = Val(Replace(Label145.Text, Local_Decimal_Place, "."))
            RunChart3.RunChartUCL = Val(Replace(Label146.Text, Local_Decimal_Place, "."))
            RunChart3.RunChartNominal = Val(Replace(Label141.Text, Local_Decimal_Place, "."))
            RunChart3.RunChartLCL = Val(Replace(Label142.Text, Local_Decimal_Place, "."))
            RunChart3.RunChartLSL = Val(Replace(Label139.Text, Local_Decimal_Place, "."))

            Label150.Text = ProvideLanguageCorrectedDecimalPoint(Label21.Text)
            Label150.BackColor = Color.LightGray
            'Run Chart 5-8 TabPage5
        Else
            Panel2.Visible = False 'Result 3
            Panel19.Visible = False 'Result 3
        End If

        If (Ch > 3) Then
            'DRO TabPage1
            Panel8.Visible = True 'Result 4
            Label52.Text = Data_Row(0).Item("ParameterName4")

            DataGridView1.Columns.Add("Column6", Label52.Text)
            DataGridView1.Columns("Column6").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label56.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label56.BackColor = Color.LightGray
            'Run Chart 1-4 TabPage4
            Panel20.Visible = True 'Result 4
            Label164.Text = Data_Row(0).Item("ParameterName4")
            RunChart4.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart4.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart4.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart4.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart4.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label158.Text = formatNumber(Data_Row(0).Item("USL4"), 5).ToString().Trim()
            Label159.Text = formatNumber(Data_Row(0).Item("UCL4"), 5).ToString().Trim()
            Label154.Text = formatNumber(Data_Row(0).Item("NOM4"), 5).ToString().Trim()
            Label155.Text = formatNumber(Data_Row(0).Item("LCL4"), 5).ToString().Trim()
            Label152.Text = formatNumber(Data_Row(0).Item("LSL4"), 5).ToString().Trim()

            RunChart4.RunChartUSL = Val(Replace(Label158.Text, Local_Decimal_Place, "."))
            RunChart4.RunChartUCL = Val(Replace(Label159.Text, Local_Decimal_Place, "."))
            RunChart4.RunChartNominal = Val(Replace(Label154.Text, Local_Decimal_Place, "."))
            RunChart4.RunChartLCL = Val(Replace(Label155.Text, Local_Decimal_Place, "."))
            RunChart4.RunChartLSL = Val(Replace(Label152.Text, Local_Decimal_Place, "."))

            Label163.Text = ProvideLanguageCorrectedDecimalPoint(Label56.Text)
            Label163.BackColor = Color.LightGray
            'Run Chart 5-8 TabPage5
        Else
            Panel8.Visible = False 'Result 4
            Panel20.Visible = False 'Result 4
        End If

        If (Ch > 4) Then
            'DRO TabPage1
            Panel1.Visible = True 'Result 5
            Label10.Text = Data_Row(0).Item("ParameterName5")

            DataGridView1.Columns.Add("Column7", Label10.Text)
            DataGridView1.Columns("Column7").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label14.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label14.BackColor = Color.LightGray

            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Panel28.Visible = True 'Result 5
            Label268.Text = Data_Row(0).Item("ParameterName5")
            RunChart12.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart12.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart12.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart12.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart12.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label262.Text = formatNumber(Data_Row(0).Item("USL5"), 5).ToString().Trim()
            Label263.Text = formatNumber(Data_Row(0).Item("UCL5"), 5).ToString().Trim()
            Label258.Text = formatNumber(Data_Row(0).Item("NOM5"), 5).ToString().Trim()
            Label259.Text = formatNumber(Data_Row(0).Item("LCL5"), 5).ToString().Trim()
            Label256.Text = formatNumber(Data_Row(0).Item("LSL5"), 5).ToString().Trim()


            RunChart12.RunChartUSL = Val(Replace(Label262.Text, Local_Decimal_Place, "."))
            RunChart12.RunChartUCL = Val(Replace(Label263.Text, Local_Decimal_Place, "."))
            RunChart12.RunChartNominal = Val(Replace(Label258.Text, Local_Decimal_Place, "."))
            RunChart12.RunChartLCL = Val(Replace(Label259.Text, Local_Decimal_Place, "."))
            RunChart12.RunChartLSL = Val(Replace(Label256.Text, Local_Decimal_Place, "."))

            Label267.Text = ProvideLanguageCorrectedDecimalPoint(Label14.Text)
            Label267.BackColor = Color.LightGray
        Else
            Panel1.Visible = False 'Result 5
            Panel28.Visible = False 'Result 5
        End If

        If (Ch > 5) Then
            'DRO TabPage1
            Panel3.Visible = True 'Result 6
            Label24.Text = Data_Row(0).Item("ParameterName6")

            DataGridView1.Columns.Add("Column8", Label24.Text)
            DataGridView1.Columns("Column8").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label28.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label28.BackColor = Color.LightGray
            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Panel27.Visible = True 'Result 6
            Label255.Text = Data_Row(0).Item("ParameterName6")
            RunChart11.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart11.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart11.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart11.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart11.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label249.Text = formatNumber(Data_Row(0).Item("USL6"), 5).ToString().Trim()
            Label250.Text = formatNumber(Data_Row(0).Item("UCL6"), 5).ToString().Trim()
            Label245.Text = formatNumber(Data_Row(0).Item("NOM6"), 5).ToString().Trim()
            Label246.Text = formatNumber(Data_Row(0).Item("LCL6"), 5).ToString().Trim()
            Label243.Text = formatNumber(Data_Row(0).Item("LSL6"), 5).ToString().Trim()



            RunChart11.RunChartUSL = Val(Replace(Label249.Text, Local_Decimal_Place, "."))
            RunChart11.RunChartUCL = Val(Replace(Label250.Text, Local_Decimal_Place, "."))
            RunChart11.RunChartNominal = Val(Replace(Label245.Text, Local_Decimal_Place, "."))
            RunChart11.RunChartLCL = Val(Replace(Label246.Text, Local_Decimal_Place, "."))
            RunChart11.RunChartLSL = Val(Replace(Label243.Text, Local_Decimal_Place, "."))

            Label254.Text = ProvideLanguageCorrectedDecimalPoint(Label28.Text)
            Label254.BackColor = Color.LightGray
        Else
            Panel3.Visible = False 'Result 6
            Panel27.Visible = False 'Result 6
        End If

        If (Ch > 6) Then
            'DRO TabPage1
            Panel6.Visible = True 'Result 7
            Label38.Text = Data_Row(0).Item("ParameterName7")

            DataGridView1.Columns.Add("Column9", Label38.Text)
            DataGridView1.Columns("Column9").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label42.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label42.BackColor = Color.LightGray
            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Panel26.Visible = True 'Result 7
            Label242.Text = Data_Row(0).Item("ParameterName7")
            RunChart10.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart10.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart10.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart10.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart10.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label236.Text = formatNumber(Data_Row(0).Item("USL7"), 5).ToString().Trim()
            Label237.Text = formatNumber(Data_Row(0).Item("UCL7"), 5).ToString().Trim()
            Label232.Text = formatNumber(Data_Row(0).Item("NOM7"), 5).ToString().Trim()
            Label233.Text = formatNumber(Data_Row(0).Item("LCL7"), 5).ToString().Trim()
            Label230.Text = formatNumber(Data_Row(0).Item("LSL7"), 5).ToString().Trim()


            RunChart10.RunChartUSL = Val(Replace(Label236.Text, Local_Decimal_Place, "."))
            RunChart10.RunChartUCL = Val(Replace(Label237.Text, Local_Decimal_Place, "."))
            RunChart10.RunChartNominal = Val(Replace(Label232.Text, Local_Decimal_Place, "."))
            RunChart10.RunChartLCL = Val(Replace(Label233.Text, Local_Decimal_Place, "."))
            RunChart10.RunChartLSL = Val(Replace(Label230.Text, Local_Decimal_Place, "."))


            Label241.Text = ProvideLanguageCorrectedDecimalPoint(Label42.Text)
            Label241.BackColor = Color.LightGray
        Else
            Panel6.Visible = False 'Result 7
            Panel26.Visible = False 'Result 7
        End If

        If (Ch > 7) Then
            'DRO TabPage1
            Panel7.Visible = True 'Result 8
            Label45.Text = Data_Row(0).Item("ParameterName8")

            DataGridView1.Columns.Add("Column10", Label45.Text)
            DataGridView1.Columns("Column10").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Label49.Text = ProvideLanguageCorrectedDecimalPoint("+000.0000")
            Label49.BackColor = Color.LightGray
            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Panel25.Visible = True 'Result 8
            Label229.Text = Data_Row(0).Item("ParameterName8")
            RunChart9.RunChartUSLColor = Color.FromArgb(Data_Row(0).Item("uslcolor").ToString())
            RunChart9.RunChartUCLColor = Color.FromArgb(Data_Row(0).Item("uclcolor").ToString())
            RunChart9.RunChartNominalColor = Color.FromArgb(Data_Row(0).Item("nvcolor").ToString())
            RunChart9.RunChartLCLColor = Color.FromArgb(Data_Row(0).Item("lclcolor").ToString())
            RunChart9.RunChartLSLColor = Color.FromArgb(Data_Row(0).Item("lslcolor").ToString())

            Label223.Text = formatNumber(Data_Row(0).Item("USL8"), 5).ToString().Trim()
            Label224.Text = formatNumber(Data_Row(0).Item("UCL8"), 5).ToString().Trim()
            Label219.Text = formatNumber(Data_Row(0).Item("NOM8"), 5).ToString().Trim()
            Label220.Text = formatNumber(Data_Row(0).Item("LCL8"), 5).ToString().Trim()
            Label217.Text = formatNumber(Data_Row(0).Item("LSL8"), 5).ToString().Trim()


            RunChart9.RunChartUSL = Val(Replace(Label223.Text, Local_Decimal_Place, "."))
            RunChart9.RunChartUCL = Val(Replace(Label224.Text, Local_Decimal_Place, "."))
            RunChart9.RunChartNominal = Val(Replace(Label219.Text, Local_Decimal_Place, "."))
            RunChart9.RunChartLCL = Val(Replace(Label220.Text, Local_Decimal_Place, "."))
            RunChart9.RunChartLSL = Val(Replace(Label217.Text, Local_Decimal_Place, "."))

            Label228.Text = ProvideLanguageCorrectedDecimalPoint(Label49.Text)
            Label228.BackColor = Color.LightGray
        Else
            Panel7.Visible = False 'Result 8
            Panel25.Visible = False 'Result 8
        End If

        RunChart1.RunChartCurrentSampleCount = 0
        RunChart2.RunChartCurrentSampleCount = 0
        RunChart3.RunChartCurrentSampleCount = 0
        RunChart4.RunChartCurrentSampleCount = 0

        RunChart9.RunChartCurrentSampleCount = 0
        RunChart10.RunChartCurrentSampleCount = 0
        RunChart11.RunChartCurrentSampleCount = 0
        RunChart12.RunChartCurrentSampleCount = 0

        DataGridView1.Visible = True

    End Sub

    Private Sub Clear_ResultsVisibility()
        'DRO TabPage1
        Panel5.Visible = False 'Result 1
        Panel4.Visible = False 'Result 2
        Panel2.Visible = False 'Result 3
        Panel8.Visible = False 'Result 4
        Panel1.Visible = False 'Result 5
        Panel3.Visible = False 'Result 6
        Panel6.Visible = False 'Result 7
        Panel7.Visible = False 'Result 8



        'Run Chart 1-4 TabPage4
        Panel17.Visible = False 'Result 1
        Panel18.Visible = False 'Result 2
        Panel19.Visible = False 'Result 3
        Panel20.Visible = False 'Result 4


        'Run Chart 5-8 TabPage5
        Panel28.Visible = False 'Result 5
        Panel27.Visible = False 'Result 6
        Panel26.Visible = False 'Result 7
        Panel25.Visible = False 'Result 8

        'TabControl1.TabPages.Item("TabPage1").Visible = False
        'TabControl1.TabPages.Item("TabPage2").Visible = False
        'TabControl1.TabPages.Item("TabPage3").Visible = False
        'TabControl1.TabPages.Item("TabPage4").Visible = False
        'TabControl1.TabPages.Item("TabPage5").Visible = False

    End Sub

    Private Sub Set_ResultSettings(ByVal Ch As Integer)

    End Sub

    Private Sub Update_Results(ByVal Ch As Integer, ByVal Result_String As String)

        Dim Ch_String(8) As String

        Dim ch_length As Integer = 0

        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()

        Result_String = Mid(Result_String, 34, Result_String.Length - 1)

        For Current_Channel = 1 To Ch
            Result_String = Mid(Result_String, 6, Result_String.Length - 1)
            If Not (Current_Channel = Ch) Then
                If IsNumeric(Mid(Result_String, 1, Result_String.IndexOf(mylistseparator))) Then

                    Ch_String(Current_Channel) = Mid(Result_String, 1, Result_String.IndexOf(mylistseparator))
                    Result_String = Mid(Result_String, Ch_String(Current_Channel).Length + 2, Result_String.Length - 1)
                Else
                    Throw New NotFiniteNumberException()
                End If
            Else
                If IsNumeric(Mid(Result_String, 1, Result_String.Length)) Then
                    Ch_String(Current_Channel) = Mid(Result_String, 1, Result_String.Length)
                Else
                    Throw New NotFiniteNumberException()
                End If

            End If

        Next Current_Channel

        DataGridView1.Rows.Add()
        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column1").Value = Format(System.DateTime.Now, "d/M/yyyy")
        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column2").Value = Format(System.DateTime.Now, "h:m:s tt")


        If (Ch > 0) Then
            'DRO TabPage1

            Label1.Text = Ch_String(1) 'Result 1
            Label1.BackColor = GetColorOFReading(Double.Parse(Label1.Text), "1", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(1) = Label1.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column3").Value = Label1.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column3").Style.BackColor = Label1.BackColor

            'Run Chart 1-4 TabPage4
            Label119.Text = Label1.Text  'Result 1
            Label119.BackColor = Label1.BackColor
            RunChart1.RunChartSamplesValue = Val(Replace(Label119.Text, Local_Decimal_Place, "."))
            'Run Chart 5-8 TabPage5
        End If
        If (Ch > 1) Then
            'DRO TabPage1
            Label35.Text = Ch_String(2) 'Result 2
            Label35.BackColor = GetColorOFReading(Double.Parse(Label35.Text), "2", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(2) = Label35.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column4").Value = Label35.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column4").Style.BackColor = Label35.BackColor

            'Run Chart 1-4 TabPage4
            Label137.Text = Label35.Text 'Result 2
            Label137.BackColor = Label35.BackColor
            RunChart2.RunChartSamplesValue = Val(Replace(Label137.Text, Local_Decimal_Place, "."))
            'Run Chart 5-8 TabPage5
        End If

        If (Ch > 2) Then
            'DRO TabPage1
            Label21.Text = Ch_String(3) 'Result 3
            Label21.BackColor = GetColorOFReading(Double.Parse(Label21.Text), "3", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(3) = Label21.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column5").Value = Label21.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column5").Style.BackColor = Label21.BackColor

            'Run Chart 1-4 TabPage4
            Label150.Text = Label21.Text 'Result 3
            Label150.BackColor = Label21.BackColor
            RunChart3.RunChartSamplesValue = Val(Replace(Label150.Text, Local_Decimal_Place, "."))
            'Run Chart 5-8 TabPage5
        End If

        If (Ch > 3) Then
            'DRO TabPage1
            Label56.Text = Ch_String(4) 'Result 4
            Label56.BackColor = GetColorOFReading(Double.Parse(Label56.Text), "4", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(4) = Label56.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column6").Value = Label56.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column6").Style.BackColor = Label56.BackColor

            'Run Chart 1-4 TabPage4
            Label163.Text = Label56.Text 'Result 4
            Label163.BackColor = Label56.BackColor
            RunChart4.RunChartSamplesValue = Val(Replace(Label163.Text, Local_Decimal_Place, "."))
            'Run Chart 5-8 TabPage5
        End If

        If (Ch > 4) Then
            'DRO TabPage1
            Label14.Text = Ch_String(5) 'Result 5
            Label14.BackColor = GetColorOFReading(Double.Parse(Label14.Text), "5", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(5) = Label14.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column7").Value = Label14.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column7").Style.BackColor = Label14.BackColor

            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Label267.Text = Label14.Text 'Result 5
            Label267.BackColor = Label14.BackColor
            RunChart12.RunChartSamplesValue = Val(Replace(Label267.Text, Local_Decimal_Place, "."))
        End If

        If (Ch > 5) Then
            'DRO TabPage1
            Label28.Text = Ch_String(6) 'Result 6
            Label28.BackColor = GetColorOFReading(Double.Parse(Label28.Text), "6", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(6) = Label28.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column8").Value = Label28.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column8").Style.BackColor = Label28.BackColor

            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Label254.Text = Label28.Text 'Result 6
            Label254.BackColor = Label28.BackColor
            RunChart11.RunChartSamplesValue = Val(Replace(Label254.Text, Local_Decimal_Place, "."))
        End If

        If (Ch > 6) Then
            'DRO TabPage1
            Label42.Text = Ch_String(7) 'Result 7
            Label42.BackColor = GetColorOFReading(Double.Parse(Label42.Text), "7", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(7) = Label42.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column9").Value = Label42.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column9").Style.BackColor = Label42.BackColor

            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Label241.Text = Label42.Text 'Result 7
            Label241.BackColor = Label42.BackColor
            RunChart10.RunChartSamplesValue = Val(Replace(Label241.Text, Local_Decimal_Place, "."))
        End If

        If (Ch > 7) Then
            'DRO TabPage1
            Label49.Text = Ch_String(8) 'Result 8
            Label49.BackColor = GetColorOFReading(Double.Parse(Label49.Text), "8", VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue))
            OctaGage_Reading_Color(8) = Label49.BackColor

            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column10").Value = Label49.Text
            DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("Column10").Style.BackColor = Label49.BackColor

            'Run Chart 1-4 TabPage4
            'Run Chart 5-8 TabPage5
            Label228.Text = Label49.Text 'Result 8
            Label228.BackColor = Label49.BackColor
            RunChart9.RunChartSamplesValue = Val(Replace(Label228.Text, Local_Decimal_Place, "."))
        End If
    End Sub

    Private Function GetColorOFReading(ByRef mValue As Double, ByRef ResultNumber As String, ByRef data_row() As DataRow) As Color
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
        If mValue > Val(Replace(data_row(0).Item("USL" & ResultNumber), Local_Decimal_Place, ".")) Then
            GetColorOFReading = Color.FromArgb(data_row(0).Item("uslcolor").ToString())
        ElseIf mValue < Val(Replace(data_row(0).Item("LSL" & ResultNumber), Local_Decimal_Place, ".")) Then
            GetColorOFReading = Color.FromArgb(data_row(0).Item("lslcolor").ToString())
        ElseIf mValue > Val(Replace(data_row(0).Item("UCL" & ResultNumber), Local_Decimal_Place, ".")) AndAlso mValue <= Val(Replace(data_row(0).Item("USL" & ResultNumber), Local_Decimal_Place, ".")) Then
            GetColorOFReading = Color.FromArgb(data_row(0).Item("uclcolor").ToString())
        ElseIf mValue < Val(Replace(data_row(0).Item("LCL" & ResultNumber), Local_Decimal_Place, ".")) AndAlso mValue >= Val(Replace(data_row(0).Item("LSL" & ResultNumber), Local_Decimal_Place, ".")) Then
            GetColorOFReading = Color.FromArgb(data_row(0).Item("lclcolor").ToString())
        ElseIf mValue <= Val(Replace(data_row(0).Item("UCL" & ResultNumber), Local_Decimal_Place, ".")) AndAlso mValue >= Val(Replace(data_row(0).Item("LCL" & ResultNumber), Local_Decimal_Place, ".")) Then
            GetColorOFReading = Color.FromArgb(data_row(0).Item("nvcolor").ToString())
        End If
    End Function

    Private Function Calculated_Dial_Limit(ByRef privateUSL As Single, ByRef privateLSL As Single) As Single
        If (privateUSL - privateLSL) <= 0.0001 Then
            Calculated_Dial_Limit = 0.00012
        ElseIf (privateUSL - privateLSL) <= 0.001 Then
            Calculated_Dial_Limit = 0.00125
        ElseIf (privateUSL - privateLSL) <= 0.002 Then
            Calculated_Dial_Limit = 0.0025
        ElseIf (privateUSL - privateLSL) <= 0.005 Then
            Calculated_Dial_Limit = 0.006
        ElseIf (privateUSL - privateLSL) <= 0.001 Then
            Calculated_Dial_Limit = 0.0012
        ElseIf (privateUSL - privateLSL) <= 0.01 Then
            Calculated_Dial_Limit = 0.0125
        ElseIf (privateUSL - privateLSL) <= 0.02 Then
            Calculated_Dial_Limit = 0.025
        ElseIf (privateUSL - privateLSL) <= 0.05 Then
            Calculated_Dial_Limit = 0.06
        ElseIf (privateUSL - privateLSL) <= 0.1 Then
            Calculated_Dial_Limit = 0.125
        ElseIf (privateUSL - privateLSL) <= 0.2 Then
            Calculated_Dial_Limit = 0.25
        ElseIf (privateUSL - privateLSL) <= 0.5 Then
            Calculated_Dial_Limit = 0.625
        ElseIf (privateUSL - privateLSL) <= 1.0 Then
            Calculated_Dial_Limit = 1.25
        ElseIf (privateUSL - privateLSL) <= 2.0 Then
            Calculated_Dial_Limit = 2.5
        ElseIf (privateUSL - privateLSL) <= 4.0 Then
            Calculated_Dial_Limit = 3.0
        ElseIf (privateUSL - privateLSL) <= 5.0 Then
            Calculated_Dial_Limit = 6.0
        ElseIf (privateUSL - privateLSL) <= 10.0 Then
            Calculated_Dial_Limit = 15.5
        End If

    End Function

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
                    dr = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue)(0)
                    Create_OctaGage_Report_Template_File_Version1(SaveFileDialog1.FileName, dr)
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
                    dr = Nothing

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
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
        If isFileSelected AndAlso isPartChanged Then
            If MessageBox.Show("Data for selected part will be saved in same data file. Press OK to select new file or Cancel to continue", "Data File", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                isFileSelected = False
                lblFileSel.Text = ""
                btnSelectFile_Click(sender, e)
            End If
        End If
        isPartChanged = False

        If isFileSelected Then
            'If cmbPart.SelectedIndex > -1 Then
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
                        'DataGridView1.Rows.Clear()
                        'triColorRunChart.RunChartCurrentSampleCount = 0
                        Main.toolStripStatus.Text = "Waiting for data..."
                        Data_Ready = False
                        Timer2.Enabled = True
                        Clear_ResultsVisibility()
                        Dim dr As DataRow() = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue)
                        If Not dr Is Nothing Then
                            Initiasile_TabPages(CInt(Val(Replace(Label7.Text, Local_Decimal_Place, "."))), dr)
                        End If
                        Number_ofResultsSelected = CInt(Val(Replace(Label7.Text, Local_Decimal_Place, ".")))

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
            'Else
            '    MessageBox.Show("Please select a part to measure", "Select part", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnStart.Text = "START"
            '    btnStart.BackColor = Color.LimeGreen
            '    Main.toolStripStatus.Text = ""
            '    Data_Ready = False
            '    Timer2.Enabled = False
            'End If
        Else
            MessageBox.Show("Please select data file to store readings", "Select Data File", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnStart.Text = "START"
            btnStart.BackColor = Color.LimeGreen
            Main.toolStripStatus.Text = ""
            Data_Ready = False
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPart.SelectedIndexChanged

        isFileSelected = False
        isPartChanged = False
        Dim Local_Decimal_Place As String = ProvideLanguageDecimalPoint()
        If isFileSelected Then
            isPartChanged = True
        End If
        If Not VersaGageMonitorDataSet.Tables("CustomerOctaGage") Is Nothing AndAlso VersaGageMonitorDataSet.Tables("CustomerOctaGage").Rows.Count <= 0 Then
            CustomerOctaGageTableAdapter.Fill(VersaGageMonitorDataSet.CustomerOctaGage)
        End If
        If cmbPart.SelectedIndex > -1 Then
            Dim dr As DataRow() = VersaGageMonitorDataSet.Tables("CustomerOctaGage").Select(" PartID=" & cmbPart.SelectedValue)
            If Not dr Is Nothing Then

                DataGridView1.Visible = False
                Label7.Text = dr(0).Item("numberofparameters").ToString()
                Label6.Text = dr(0).Item("Organisation").ToString()
                Initiasile_TabPages(Val(Label7.Text), dr)
            End If
        Else
            Clear_ResultsVisibility()
            'resetControls()
        End If

    End Sub

    Private Sub btnResetCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCounter.Click
        lblCounter.Text = "0"
    End Sub

End Class