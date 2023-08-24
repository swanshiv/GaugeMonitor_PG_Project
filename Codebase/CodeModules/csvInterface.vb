Imports System.IO
Imports System.Windows.Forms

Module csvInterface

    Public OctaGage_Reading_Color(8) As Color
    Public Sub Create_TricolorColumn_Report_Template_File_Version1(ByRef FileName As String, ByRef CustomerName As String, ByRef PartName As String, ByRef MachineNumber As String, ByRef OperatorName As String, ByRef ParameterName As String, ByRef USL As String, ByRef UCL As String, ByRef NOM As String, ByRef LCL As String, ByRef LSL As String)

        Try
            Dim Createfile As System.IO.FileStream = File.Create(FileName)
            Createfile.Close()
            Dim filewrite As System.IO.StreamWriter = New StreamWriter(FileName)

            Dim List_Separator As Char = ProvideLanguageListSeperator()

            'filewrite.WriteLine("REPORT- " & List_Separator & Format(System.DateTime.Today, "ddMMyy") & ProviderLanguageListSeperator() & Format(System.DateTime.Now, "hhmmss tt"))
            'filewrite.WriteLine()
            filewrite.WriteLine("Test Report")
            filewrite.WriteLine()
            'filewrite.WriteLine("Measurements Taken:" & List_Separator & "0")
            'filewrite.WriteLine()
            filewrite.WriteLine("Part ID:" & List_Separator & PartName)
            filewrite.WriteLine("Customer Name:" & List_Separator & CustomerName)
            filewrite.WriteLine("Operator Name:" & List_Separator & OperatorName)
            filewrite.WriteLine("Machine ID:" & List_Separator & MachineNumber)
            filewrite.WriteLine()
            If Not (ParameterName = "") Then
                filewrite.WriteLine("Tolerances of -" & List_Separator & ParameterName)
            Else
                filewrite.WriteLine("Tolerances of -" & List_Separator & "")
            End If

            filewrite.WriteLine("USL" & List_Separator & USL)
            filewrite.WriteLine("UCL" & List_Separator & UCL)
            filewrite.WriteLine("Nominal Value" & List_Separator & NOM)
            filewrite.WriteLine("LCL" & List_Separator & LCL)
            filewrite.WriteLine("LSL" & List_Separator & LSL)

            filewrite.WriteLine()

            If Not (ParameterName = "") Then
                filewrite.WriteLine("Date" & List_Separator & "Time" & List_Separator & ParameterName)
            Else
                filewrite.WriteLine("Date" & List_Separator & "Time" & List_Separator & "")
            End If

            filewrite.Close()
            filewrite.Dispose()

        Catch ex As Exception
            MsgBox("Unable to create the file!", MsgBoxStyle.OkOnly, "Unable to create the file!")
        End Try
    End Sub

    Public Sub Create_OctaGage_Report_Template_File_Version1(ByRef FileName As String, ByRef Data_Row As DataRow)

        Try
            Dim Createfile As System.IO.FileStream = File.Create(FileName)
            Createfile.Close()
            Dim filewrite As System.IO.StreamWriter = New StreamWriter(FileName)

            Dim List_Separator As Char = ProvideLanguageListSeperator()

            'filewrite.WriteLine("REPORT- " & List_Separator & Format(System.DateTime.Today, "ddMMyy") & ProviderLanguageListSeperator() & Format(System.DateTime.Now, "hhmmss tt"))
            'filewrite.WriteLine()
            filewrite.WriteLine("Test Report")
            filewrite.WriteLine()
            'filewrite.WriteLine("Measurements Taken:" & List_Separator & "0")
            'filewrite.WriteLine()
            filewrite.WriteLine("Part ID:" & List_Separator & Data_Row.Item("PartName").ToString())
            filewrite.WriteLine("Customer Name:" & List_Separator & Data_Row.Item("Organisation").ToString())
            filewrite.WriteLine("Operator Name:" & List_Separator & Data_Row.Item("operatorname").ToString())
            filewrite.WriteLine("Machine ID:" & List_Separator & Data_Row.Item("machinenum").ToString())

            filewrite.WriteLine()

            Dim Line_Tolerances As String = "Tolerances of - " & List_Separator
            Dim Line_Values_USL As String = "USL" & List_Separator
            Dim Line_Values_UCL As String = "UCL" & List_Separator
            Dim Line_Values_NOM As String = "Nominal Value" & List_Separator
            Dim Line_Values_LCL As String = "LCL" & List_Separator
            Dim Line_Values_LSL As String = "LSL" & List_Separator

            Dim Ch_Defined As Integer = CInt(Val(Data_Row.Item("numberofparameters")))
            Dim ii As Integer = 1
            If (Ch_Defined > 0) Then
                For ii = 1 To Ch_Defined
                    If Not ((Data_Row.Item("ParameterName" & ii).ToString()) = "") Then
                        Line_Tolerances = Line_Tolerances & List_Separator & Data_Row.Item("ParameterName" & ii).ToString()
                    Else
                        Line_Tolerances = Line_Tolerances & List_Separator & ""
                    End If
                    Line_Values_USL = Line_Values_USL & List_Separator & Data_Row.Item("USL" & ii).ToString()
                    Line_Values_UCL = Line_Values_UCL & List_Separator & Data_Row.Item("UCL" & ii).ToString()
                    Line_Values_NOM = Line_Values_NOM & List_Separator & Data_Row.Item("NOM" & ii).ToString()
                    Line_Values_LCL = Line_Values_LCL & List_Separator & Data_Row.Item("LCL" & ii).ToString()
                    Line_Values_LSL = Line_Values_LSL & List_Separator & Data_Row.Item("LSL" & ii).ToString()
                Next ii
            End If
            filewrite.WriteLine(Line_Tolerances)
            filewrite.WriteLine(Line_Values_USL)
            filewrite.WriteLine(Line_Values_UCL)
            filewrite.WriteLine(Line_Values_NOM)
            filewrite.WriteLine(Line_Values_LCL)
            filewrite.WriteLine(Line_Values_LSL)

            filewrite.WriteLine()

            
            Dim Line_Date As String = "Date" & List_Separator & "Time" & List_Separator

            If (Ch_Defined > 0) Then
                For ii = 1 To Ch_Defined
                    If Not ((Data_Row.Item("ParameterName" & ii).ToString()) = "") Then
                        Line_Date = Line_Date & Data_Row.Item("ParameterName" & ii).ToString() & List_Separator

                    Else
                        Line_Date = Line_Date & "" & List_Separator
                    End If
                Next ii
            End If

            filewrite.WriteLine(Line_Date)
            filewrite.Close()
            filewrite.Dispose()

        Catch ex As Exception
            MsgBox("Unable to create the file!", MsgBoxStyle.OkOnly, "Unable to create the file!")
        End Try

    End Sub
    Public Sub Add_Reading_To_TricolorColumn_Report_Template_File_Version1(ByVal filename As String, ByVal ReadingDate As String, ByRef ReadingTime As String, ByVal Reading As String)
        Dim foo_int As Integer = 0

        Dim List_Separator As Char = ProvideLanguageListSeperator()
        If (File.Exists(filename)) Then
            Try
                Dim filewrite As System.IO.StreamWriter = New StreamWriter(filename, True)

                filewrite.WriteLine(ReadingDate & List_Separator & ReadingTime & List_Separator & Reading)

                filewrite.Close()
                filewrite.Dispose()

            Catch ex As Exception
                MsgBox("1Unable to write to the file!", MsgBoxStyle.OkOnly, "Unable to write to the file!")
            End Try
        Else
            MsgBox("File does not exists!", MsgBoxStyle.OkOnly, "File does not exists!")
        End If

    End Sub
    Public Sub Add_Reading_To_OctaGage_Report_Template_File_Version1(ByVal filename As String, ByVal ReadingDate As String, ByRef ReadingTime As String, ByVal No_of_Channels As String, ByVal Result_String As String)

        Dim Line_Reading As String
        Dim Ch_String(8) As String

        Result_String = Mid(Result_String, 34, Result_String.Length - 1)

        For Current_Channel = 1 To CInt(No_of_Channels)
            Result_String = Mid(Result_String, 6, Result_String.Length - 1)
            If Not (Current_Channel = CInt(No_of_Channels)) Then
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

        Dim List_Separator As Char = ProvideLanguageListSeperator()
        If (File.Exists(filename)) Then
            Try
                Dim filewrite As System.IO.StreamWriter = New StreamWriter(filename, True)

                Line_Reading = ReadingDate & List_Separator & ReadingTime

                If (No_of_Channels > 0) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(1) 'Result 1

                Else

                End If

                If (No_of_Channels > 1) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(2) 'Result 2

                Else

                End If

                If (No_of_Channels > 2) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(3) 'Result 3

                Else

                End If

                If (No_of_Channels > 3) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(4) 'Result 4

                Else

                End If

                If (No_of_Channels > 4) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(5) 'Result 5

                Else

                End If

                If (No_of_Channels > 5) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(6) 'Result 6

                Else

                End If

                If (No_of_Channels > 6) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(7) 'Result 7

                Else

                End If

                If (No_of_Channels > 7) Then
                    Line_Reading = Line_Reading & List_Separator & Ch_String(8) 'Result 8

                Else

                End If

                filewrite.WriteLine(Line_Reading)

                filewrite.Close()
                filewrite.Dispose()

            Catch ex As Exception
                MsgBox("Unable to write to the file!", MsgBoxStyle.OkOnly, "Unable to write to the file!")
            End Try
        Else
            MsgBox("File does not exists!", MsgBoxStyle.OkOnly, "File does not exists!")
        End If








    End Sub
    


End Module


