'Imports System.IO
'Imports Microsoft.Office.Interop.Excel
'Imports System.Windows.Forms
'Module XlsInterface
'    Public Const xlWorkSheet = -4167
'    Public Const xl3DPie = -4102
'    Public Const xlRows = 1
'    Public OctaGage_Reading_Color(8) As Color
'    Public Sub Create_TricolorColumn_Report_Template_File_Version1(ByRef FileName As String, ByRef CustomerName As String, ByRef PartName As String, ByRef MachineNumber As String, ByRef OperatorName As String, ByRef ParameterName As String, ByRef USL As String, ByRef UCL As String, ByRef NOM As String, ByRef LCL As String, ByRef LSL As String, ByRef Uom As String)

'        Dim application As New Microsoft.Office.Interop.Excel.Application
'        application.Visible = False

'        Dim workbook As Microsoft.Office.Interop.Excel.Workbook
'        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet


'        'set the application caption
'        application.Caption = "Test Report"

'        workbook = application.Workbooks.Add(Template:=xlWorkSheet)

'        worksheet = workbook.Worksheets(1)

'        'set the name of the worksheet
'        worksheet.Name = "REPORT- " & Format(System.DateTime.Today, "ddMMyy") & ", " & Format(System.DateTime.Now, "hhmmss tt")

'        'Set font colour
'        workbook.ActiveSheet.Range("A1 : C1").Font.ColorIndex = 25
'        'Set font style
'        workbook.ActiveSheet.Range("A1 : C1").Font.Bold = True
'        'set font name
'        workbook.ActiveSheet.Range("A1 : C1").Font.Name = "Times New Roman"
'        'set font size
'        workbook.ActiveSheet.Range("A1 : C1").Font.Size = 12
'        'Merge cells
'        workbook.ActiveSheet.Range("A1 : C1").MergeCells = True
'        'Write text to the merged cells
'        workbook.ActiveSheet.Range("A1").Value = "Test Report"

'        'Set font colour
'        workbook.ActiveSheet.Range("A3 : C3").Font.ColorIndex = 25

'        'Set font colour
'        workbook.ActiveSheet.Range("A3 : C3").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(3, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(3, 1).Value = "Measurements Taken:"
'        workbook.ActiveSheet.Cells(3, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(3, 2).Value = "0"

'        'Set font colour
'        workbook.ActiveSheet.Range("A5 : C5").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(5, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(5, 1).Value = "Part ID:"
'        workbook.ActiveSheet.Cells(5, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(5, 2).Value = PartName

'        'Set font colour
'        workbook.ActiveSheet.Range("A6 : C6").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(6, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(6, 1).Value = "Customer Name:"
'        workbook.ActiveSheet.Cells(6, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(6, 2).Value = CustomerName

'        'Set font colour
'        workbook.ActiveSheet.Range("A7 : C7").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(7, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(7, 1).Value = "Operator Name:"
'        workbook.ActiveSheet.Cells(7, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(7, 2).Value = OperatorName


'        'Set font colour
'        workbook.ActiveSheet.Range("A8 : C8").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(8, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(8, 1).Value = "Machine ID:"
'        workbook.ActiveSheet.Cells(8, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(8, 2).Value = MachineNumber


'        'Set font colour
'        workbook.ActiveSheet.Range("A9 : C9").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(9, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(9, 1).Value = "Unit of Measure:"
'        workbook.ActiveSheet.Cells(9, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(9, 2).Value = Uom


'        workbook.ActiveSheet.Range("A3 : C9").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic)

'        'Set font colour
'        workbook.ActiveSheet.Range("A11 : B11").MergeCells = True
'        workbook.ActiveSheet.Range("A11 : B11").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A11 : B11").Font.Bold = True
'        workbook.ActiveSheet.Cells(11, 1).Value = "Tolerances"
'        workbook.ActiveSheet.Range("A11").HorizontalAlignment = XlHAlign.xlHAlignCenter


'        'Set font colour
'        workbook.ActiveSheet.Range("A12 : B12").MergeCells = True
'        workbook.ActiveSheet.Range("A12 : B12").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A12 : B12").Font.Bold = True
'        workbook.ActiveSheet.Cells(12, 1).Value = "USL"
'        workbook.ActiveSheet.Cells(12, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A13 : B13").MergeCells = True
'        workbook.ActiveSheet.Range("A13 : B13").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A13 : B13").Font.Bold = True
'        workbook.ActiveSheet.Cells(13, 1).Value = "UCL"
'        workbook.ActiveSheet.Cells(13, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A14 : B14").MergeCells = True
'        workbook.ActiveSheet.Range("A14 : B14").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A14 : B14").Font.Bold = True
'        workbook.ActiveSheet.Cells(14, 1).Value = "Nominal Value"
'        workbook.ActiveSheet.Cells(14, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A15 : B15").MergeCells = True
'        workbook.ActiveSheet.Range("A15 : B15").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A15 : B15").Font.Bold = True
'        workbook.ActiveSheet.Cells(15, 1).Value = "LCL"
'        workbook.ActiveSheet.Cells(15, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A16 : B16").MergeCells = True
'        workbook.ActiveSheet.Range("A16 : B16").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A16 : B16").Font.Bold = True
'        workbook.ActiveSheet.Cells(16, 1).Value = "LSL"
'        workbook.ActiveSheet.Cells(16, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter


'        workbook.ActiveSheet.Cells(12, 3).Font.Bold = True
'        workbook.ActiveSheet.Cells(12, 3).Value = USL
'        workbook.ActiveSheet.Cells(13, 3).Font.Bold = True
'        workbook.ActiveSheet.Cells(13, 3).Value = UCL
'        workbook.ActiveSheet.Cells(14, 3).Font.Bold = True
'        workbook.ActiveSheet.Cells(14, 3).Value = NOM
'        workbook.ActiveSheet.Cells(15, 3).Font.Bold = True
'        workbook.ActiveSheet.Cells(15, 3).Value = LCL
'        workbook.ActiveSheet.Cells(16, 3).Font.Bold = True
'        workbook.ActiveSheet.Cells(16, 3).Value = LSL

'        workbook.ActiveSheet.Range("A11 : C16").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic)

'        'Set font colour
'        workbook.ActiveSheet.Range("A18 : C18").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(18, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(18, 1).Value = "Date"
'        workbook.ActiveSheet.Cells(18, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(18, 2).Value = "Time"

'        workbook.ActiveSheet.Cells(18, 3).Font.Bold = True
'        If Not (ParameterName = "") Then
'            workbook.ActiveSheet.Cells(18, 3).Value = ParameterName
'        Else
'            workbook.ActiveSheet.Cells(18, 3).Value = "Parameter Name"
'        End If
'        'set columns autofit to contents
'        workbook.ActiveSheet.Columns("A:C").AutoFit()

'        workbook.ActiveSheet.Range("A18 : C18").Borders(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlDouble
'        ' Excel sheet row and column numbers for channel
'        'Sheet_Row = 19
'        'Sheet_Column = 1
'        'Channel_Row_Max = 19
'        'Chanel_Row_Min = 19
'        'Channel1_Row = 19
'        'Channel1_Column = 19

'        'To save file to EXCEL 2003 format i.e. .xls
'        'workbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)

'        'To save file to EXCEL 2007 format i.e. .xlsx
'        workbook.SaveAs(FileName)

'        workbook.Close(False)
'        application.Quit()

'    End Sub

'    Public Sub Create_OctaGage_Report_Template_File_Version1(ByRef FileName As String, ByRef Data_Row As DataRow)

'        Dim application As New Microsoft.Office.Interop.Excel.Application
'        application.Visible = False

'        Dim workbook As Microsoft.Office.Interop.Excel.Workbook
'        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet


'        'set the application caption
'        application.Caption = "Test Report"

'        workbook = application.Workbooks.Add(Template:=xlWorkSheet)

'        worksheet = workbook.Worksheets(1)

'        'set the name of the worksheet
'        worksheet.Name = "REPORT- " & Format(System.DateTime.Today, "ddMMyy") & ", " & Format(System.DateTime.Now, "hhmmss tt")

'        'Set font colour
'        workbook.ActiveSheet.Range("A1 : J1").Font.ColorIndex = 25
'        'Set font style
'        workbook.ActiveSheet.Range("A1 : J1").Font.Bold = True
'        'set font name
'        workbook.ActiveSheet.Range("A1 : J1").Font.Name = "Times New Roman"
'        'set font size
'        workbook.ActiveSheet.Range("A1 : J1").Font.Size = 12
'        'Merge cells
'        workbook.ActiveSheet.Range("A1 : J1").MergeCells = True
'        'Write text to the merged cells
'        workbook.ActiveSheet.Range("A1").Value = "Test Report"
'        workbook.ActiveSheet.Cells(1, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter
'        ''Set font colour
'        'workbook.ActiveSheet.Range("A3 : J3").Font.ColorIndex = 25
'        ''Set sheet date
'        'workbook.ActiveSheet.Cells(3, 1).Font.Bold = True
'        'workbook.ActiveSheet.Cells(3, 1).Value = "Test Report Created ON:"
'        'workbook.ActiveSheet.Cells(3, 2).Font.Bold = True
'        'workbook.ActiveSheet.Cells(3, 2).Value = System.DateTime.Today + ", " & Format(System.DateTime.Now, "hh:mm:ss tt")


'        'Set font colour
'        workbook.ActiveSheet.Range("A3 : J3").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(3, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(3, 1).Value = "Measurements Taken:"
'        workbook.ActiveSheet.Cells(3, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(3, 2).Value = "0"

'        'Set font colour
'        workbook.ActiveSheet.Range("A5 : J5").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(5, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(5, 1).Value = "Part ID:"
'        workbook.ActiveSheet.Cells(5, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(5, 2).Value = Data_Row.Item("PartName").ToString()

'        'Set font colour
'        workbook.ActiveSheet.Range("A6 : J6").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(6, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(6, 1).Value = "Customer Name:"
'        workbook.ActiveSheet.Cells(6, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(6, 2).Value = Data_Row.Item("Organisation").ToString()

'        'Set font colour
'        workbook.ActiveSheet.Range("A7 : J7").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(7, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(7, 1).Value = "Operator Name:"
'        workbook.ActiveSheet.Cells(7, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(7, 2).Value = Data_Row.Item("operatorname").ToString()


'        'Set font colour
'        workbook.ActiveSheet.Range("A8 : J8").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(8, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(8, 1).Value = "Machine ID:"
'        workbook.ActiveSheet.Cells(8, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(8, 2).Value = Data_Row.Item("machinenum").ToString()


'        'Set font colour
'        workbook.ActiveSheet.Range("A9 : J9").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(9, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(9, 1).Value = "Unit of Measure:"
'        workbook.ActiveSheet.Cells(9, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(9, 2).Value = Data_Row.Item("uom").ToString()

'        workbook.ActiveSheet.Range("A3 : J9").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic)

'        'Set font colour
'        workbook.ActiveSheet.Range("A11 : B11").MergeCells = True
'        workbook.ActiveSheet.Range("A11 : J11").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A11 : J11").Font.Bold = True
'        workbook.ActiveSheet.Cells(11, 1).Value = "Tolerances"
'        workbook.ActiveSheet.Range("A11").HorizontalAlignment = XlHAlign.xlHAlignCenter

'        Dim Ch_Defined As Integer = CInt(Val(Data_Row.Item("numberofparameters")))
'        Dim ii As Integer = 1
'        If (Ch_Defined > 0) Then
'            For ii = 1 To Ch_Defined
'                workbook.ActiveSheet.Cells(11, 2 + ii).Font.Bold = True
'                workbook.ActiveSheet.Cells(11, 2 + ii).HorizontalAlignment = XlHAlign.xlHAlignCenter
'                If Not ((Data_Row.Item("ParameterName" & ii).ToString()) = "") Then
'                    workbook.ActiveSheet.Cells(11, 2 + ii).Value = Data_Row.Item("ParameterName" & ii).ToString()
'                Else
'                    workbook.ActiveSheet.Cells(11, 2 + ii).Value = "Parameter Name"
'                End If
'            Next ii
'        End If


'        'Set font colour
'        workbook.ActiveSheet.Range("A12 : B12").MergeCells = True
'        workbook.ActiveSheet.Range("A12 : J12").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A12 : J12").Font.Bold = True
'        workbook.ActiveSheet.Cells(12, 1).Value = "USL"
'        workbook.ActiveSheet.Cells(12, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A13 : B13").MergeCells = True
'        workbook.ActiveSheet.Range("A13 : J13").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A13 : J13").Font.Bold = True
'        workbook.ActiveSheet.Cells(13, 1).Value = "UCL"
'        workbook.ActiveSheet.Cells(13, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A14 : B14").MergeCells = True
'        workbook.ActiveSheet.Range("A14 : J14").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A14 : J14").Font.Bold = True
'        workbook.ActiveSheet.Cells(14, 1).Value = "Nominal Value"
'        workbook.ActiveSheet.Cells(14, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A15 : B15").MergeCells = True
'        workbook.ActiveSheet.Range("A15 : J15").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A15 : J15").Font.Bold = True
'        workbook.ActiveSheet.Cells(15, 1).Value = "LCL"
'        workbook.ActiveSheet.Cells(15, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter

'        workbook.ActiveSheet.Range("A16 : B16").MergeCells = True
'        workbook.ActiveSheet.Range("A16 : J16").Font.ColorIndex = 25
'        workbook.ActiveSheet.Range("A16 : J16").Font.Bold = True
'        workbook.ActiveSheet.Cells(16, 1).Value = "LSL"
'        workbook.ActiveSheet.Cells(16, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter


'        If (Ch_Defined > 0) Then
'            For ii = 1 To Ch_Defined
'                workbook.ActiveSheet.Cells(12, ii + 2).Value = Data_Row.Item("USL" & ii).ToString()

'                workbook.ActiveSheet.Cells(13, ii + 2).Value = Data_Row.Item("UCL" & ii).ToString()

'                workbook.ActiveSheet.Cells(14, ii + 2).Value = Data_Row.Item("NOM" & ii).ToString()

'                workbook.ActiveSheet.Cells(15, ii + 2).Value = Data_Row.Item("LCL" & ii).ToString()

'                workbook.ActiveSheet.Cells(16, ii + 2).Value = Data_Row.Item("LSL" & ii).ToString()
'            Next ii
'        End If

'        workbook.ActiveSheet.Range("A11 : J16").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic)





'        'Set font colour
'        workbook.ActiveSheet.Range("A18 : J18").Font.ColorIndex = 25
'        workbook.ActiveSheet.Cells(18, 1).Font.Bold = True
'        workbook.ActiveSheet.Cells(18, 1).Value = "Date"
'        workbook.ActiveSheet.Cells(18, 2).Font.Bold = True
'        workbook.ActiveSheet.Cells(18, 2).Value = "Time"


'        If (Ch_Defined > 0) Then
'            For ii = 1 To Ch_Defined
'                workbook.ActiveSheet.Cells(18, 2 + ii).Font.Bold = True
'                workbook.ActiveSheet.Cells(18, 2 + ii).HorizontalAlignment = XlHAlign.xlHAlignCenter
'                If Not ((Data_Row.Item("ParameterName" & ii).ToString()) = "") Then
'                    workbook.ActiveSheet.Cells(18, 2 + ii).Value = Data_Row.Item("ParameterName" & ii).ToString()
'                Else
'                    workbook.ActiveSheet.Cells(18, 2 + ii).Value = "Parameter Name"
'                End If
'            Next ii
'        End If

'        workbook.ActiveSheet.Range("A18 : J18").Borders(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlDouble


'        'set columns autofit to contents
'        workbook.ActiveSheet.Columns("A:J").AutoFit()

'        ' Excel sheet row and column numbers for channel
'        'Sheet_Row = 19
'        'Sheet_Column = 1
'        'Channel_Row_Max = 19
'        'Chanel_Row_Min = 19
'        'Channel1_Row = 19
'        'Channel1_Column = 19

'        'To save file to EXCEL 2003 format i.e. .xls
'        'workbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)

'        'To save file to EXCEL 2007 format i.e. .xlsx
'        workbook.SaveAs(FileName)

'        workbook.Close(False)
'        application.Quit()

'    End Sub
'    Public Sub Add_Reading_To_TricolorColumn_Report_Template_File_Version1(ByVal filename As String, ByVal ReadingDate As String, ByRef ReadingTime As String, ByVal Reading As String, ByRef ReadingColor As Color)
'        Dim foo_int As Integer = 0
'        Dim application As New Microsoft.Office.Interop.Excel.Application
'        application.Visible = False
'        application.Workbooks.Open(filename)


'        Dim samples_available As Integer

'        Dim workshee1 As Worksheet
'        workshee1 = application.ActiveSheet
'        If (workshee1.Range("A1").Value = "Test Report") Then
'            If (workshee1.Cells(3, 1).Value = "Measurements Taken:") Then
'                samples_available = CInt(Val(workshee1.Cells(3, 2).Value))
'                If samples_available < 100000 Then
'                    workshee1.Cells(3, 2).Value = samples_available + 1
'                    workshee1.Cells(samples_available + 19, 1).Value = ReadingDate
'                    workshee1.Cells(samples_available + 19, 2).Value = ReadingTime
'                    workshee1.Cells(samples_available + 19, 3).Value = Reading

'                    Try
'                        'Change Back Color of the Cell
'                        With workshee1.Cells(samples_available + 19, 3)
'                            .Interior.Color = RGB(ReadingColor.R, ReadingColor.G, ReadingColor.B) '<~~ Cell Back Color Black
'                            'With .Font

'                            '    .ColorIndex = 2 '<~~ Font Color White
'                            '    .Size = 8
'                            '    .Name = "Tahoma"
'                            '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                            '    .Bold = True
'                            'End With
'                        End With

'                        'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                    Catch ex As Exception

'                    End Try


'                Else


'                End If


'            Else
'                MsgBox("Report file corrupted or unable to read", MsgBoxStyle.OkOnly, "Report file read error")
'            End If


'        Else
'            MsgBox("Report file corrupted or unable to read", MsgBoxStyle.OkOnly, "Report file read error")
'        End If

'        application.Workbooks(1).Save()
'        application.Workbooks(1).Close(False)
'        application.Quit()


'    End Sub
'    Public Sub Add_Reading_To_OctaGage_Report_Template_File_Version1(ByVal filename As String, ByVal ReadingDate As String, ByRef ReadingTime As String, ByVal No_of_Channels As String, ByVal Result_String As String, ByRef Uni_t As String)
'        Dim foo_int As Integer = 0

'        Dim ch1_start As Integer = 0
'        Dim ch2_start As Integer = 0
'        Dim ch3_start As Integer = 0
'        Dim ch4_start As Integer = 0

'        Dim ch5_start As Integer = 0
'        Dim ch6_start As Integer = 0
'        Dim ch7_start As Integer = 0
'        Dim ch8_start As Integer = 0

'        Dim ch_length As Integer = 0


'        If ((Uni_t = "MM") Or (Uni_t = "mm") Or (Uni_t = "Mm") Or (Uni_t = "mM")) Then
'            '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected
'            ch1_start = 39
'            ch2_start = ch1_start + 14
'            ch3_start = ch2_start + 14
'            ch4_start = ch3_start + 14

'            ch5_start = ch4_start + 14
'            ch6_start = ch5_start + 14
'            ch7_start = ch6_start + 14
'            ch8_start = ch7_start + 14

'            ch_length = 8
'        Else
'            '123456;C901T/D;16:09:09;20/11/13;C011;-0.000005;C021;+0.000000;C031;-0.000005;C041;+0.000000;C051;-0.000015;C061;+0.000000;C071;+0.000005;C081;-0.000005  +VBCR = For V8 with 8 results selected
'            ch1_start = 39
'            ch2_start = ch1_start + 15
'            ch3_start = ch2_start + 15
'            ch4_start = ch3_start + 15

'            ch5_start = ch4_start + 15
'            ch6_start = ch5_start + 15
'            ch7_start = ch6_start + 15
'            ch8_start = ch7_start + 15

'            ch_length = 9
'        End If
'        Dim application As New Microsoft.Office.Interop.Excel.Application
'        application.Visible = False
'        application.Workbooks.Open(filename)


'        Dim samples_available As Integer
'        Dim reading_value As String
'        Dim reading_color As Color

'        Dim workshee1 As Worksheet
'        workshee1 = application.ActiveSheet
'        If (workshee1.Range("A1").Value = "Test Report") Then
'            If (workshee1.Cells(3, 1).Value = "Measurements Taken:") Then
'                samples_available = CInt(Val(workshee1.Cells(3, 2).Value))
'                If samples_available < 100000 Then
'                    workshee1.Cells(3, 2).Value = samples_available + 1
'                    workshee1.Cells(samples_available + 19, 1).Value = ReadingDate
'                    workshee1.Cells(samples_available + 19, 2).Value = ReadingTime

'                    If (No_of_Channels > 0) Then
'                        reading_value = Mid(Result_String, ch1_start, 8) 'Result 1
'                        workshee1.Cells(samples_available + 19, 3).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(1)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 3)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 1) Then
'                        reading_value = Mid(Result_String, ch2_start, 8) 'Result 2
'                        workshee1.Cells(samples_available + 19, 4).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(2)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 4)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 2) Then
'                        reading_value = Mid(Result_String, ch3_start, 8) 'Result 3
'                        workshee1.Cells(samples_available + 19, 5).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(3)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 5)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 3) Then
'                        reading_value = Mid(Result_String, ch4_start, 8) 'Result 4
'                        workshee1.Cells(samples_available + 19, 6).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(4)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 6)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 4) Then
'                        reading_value = Mid(Result_String, ch5_start, 8) 'Result 5
'                        workshee1.Cells(samples_available + 19, 7).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(5)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 7)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 5) Then
'                        reading_value = Mid(Result_String, ch6_start, 8) 'Result 6
'                        workshee1.Cells(samples_available + 19, 8).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(6)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 8)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 6) Then
'                        reading_value = Mid(Result_String, ch7_start, 8) 'Result 7
'                        workshee1.Cells(samples_available + 19, 9).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(7)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 9)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If

'                    If (No_of_Channels > 7) Then
'                        reading_value = Mid(Result_String, ch8_start, 8) 'Result 8
'                        workshee1.Cells(samples_available + 19, 10).Value = reading_value
'                        Try
'                            reading_color = OctaGage_Reading_Color(8)
'                            'Change Back Color of the Cell
'                            With workshee1.Cells(samples_available + 19, 10)
'                                .Interior.Color = RGB(reading_color.R, reading_color.G, reading_color.B) '<~~ Cell Back Color Black
'                                'With .Font

'                                '    .ColorIndex = 2 '<~~ Font Color White
'                                '    .Size = 8
'                                '    .Name = "Tahoma"
'                                '    .Underline = workshee1.XlUnderlineStyle.xlUnderlineStyleSingle
'                                '    .Bold = True
'                                'End With
'                            End With

'                            'workshee1.Cells(samples_available + 16, 3).Interior.Color = ReadingColor
'                        Catch ex As Exception

'                        End Try
'                    Else

'                    End If
'                Else


'                End If


'            Else
'                MsgBox("Report file corrupted or unable to read", MsgBoxStyle.OkOnly, "Report file read error")
'            End If


'        Else
'            MsgBox("Report file corrupted or unable to read", MsgBoxStyle.OkOnly, "Report file read error")
'        End If

'        application.Workbooks(1).Save()
'        application.Workbooks(1).Close(False)
'        application.Quit()


'    End Sub



'    Public Function Check_Report_Template_File_Version1(ByVal filename As String) As Boolean
'        Dim foo_int As Integer = 0
'        Dim application As New Microsoft.Office.Interop.Excel.Application
'        application.Visible = False
'        application.Workbooks.Open(filename)


'        Dim samples_available As Integer

'        Dim workshee1 As Worksheet
'        workshee1 = application.ActiveSheet
'        Try
'            If (workshee1.Range("A1").Value = "Test Report") Then
'                If (workshee1.Cells(3, 1).Value = "Measurements Taken:") Then
'                    samples_available = CInt(Val(workshee1.Cells(3, 2).Value))
'                    If samples_available < 100000 Then
'                        Check_Report_Template_File_Version1 = True
'                    Else
'                        Check_Report_Template_File_Version1 = False
'                    End If
'                Else
'                    MsgBox("Report file corrupted or unable to read" & vbCrLf & "Please create new report file", MsgBoxStyle.OkOnly, "Report file read error")
'                    Check_Report_Template_File_Version1 = False
'                End If

'            Else
'                MsgBox("Report file corrupted or unable to read" & vbCrLf & "Please create new report file", MsgBoxStyle.OkOnly, "Report file read error")
'                Check_Report_Template_File_Version1 = False
'            End If

'        Catch ex As Exception

'        End Try

'        application.Workbooks(1).Save()
'        application.Workbooks(1).Close(False)
'        application.Quit()


'    End Function


'End Module
