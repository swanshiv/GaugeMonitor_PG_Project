Imports System.IO
Imports System
'Imports System.Globalization
'Imports System.Security.Permissions
'Imports System.Threading
'Imports System.Text
'Imports System.Text.RegularExpressions

Public Class CapturetoFile

    Private Sub CapturetoFile_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Main.MenuStrip1.Enabled = True
    End Sub

    Private Sub CapturetoFile_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.SerialPort1.ReceivedBytesThreshold = 1
    End Sub

    Private Sub CapturetoFile_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Main.SerialPort1.IsOpen Then
            If MsgBox("This will STOP data capture. Do you want to continue?", MsgBoxStyle.YesNo, "Confirm close") = MsgBoxResult.Yes Then
                'Main.SerialPort1.Close()
                Dim Partfilepath As String = Mid(lblFileSel.Text, Len("Data Being Captured to: "))
                If (Main.SerialPort1.IsOpen) And File.Exists(Partfilepath) Then
                    If (Main.SerialPort1.BytesToRead > 0) Then
                        Try
                            'isFileSelected = False
                            Dim file1 As System.IO.StreamWriter = New StreamWriter(Partfilepath, True)
                            In_String = Main.SerialPort1.ReadExisting

                            In_String = ProvideLanguageCorrectedDecimalPoint(In_String)
                            In_String = ProvideLanguageCorrectedListSeperator(In_String)

                            file1.Write(In_String)
                            file1.Close()
                            file1.Dispose()
                            If TextBox1.Lines.Length > 500 Then
                                TextBox1.Text = ""
                            End If
                            TextBox1.Text = TextBox1.Text + In_String

                        Catch ex As Exception
                            MessageBox.Show("Unable to write date to created file", "Data Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End If
                End If
                TogglePort(Main.SerialPort1)
                If (Main.SerialPort1.IsOpen = False) Then
                    Timer2.Enabled = False
                    btnStartCapturing.Visible = True
                    btnStopCapturing.Visible = False
                Else
                    MsgBox("Unable to close serial port please try again!", MsgBoxStyle.OkOnly, "Serial Port Close Error!")
                End If
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub CapturetoFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnStopCapturing.Visible = False
        btnStartCapturing.Visible = True
        Main.MenuStrip1.Enabled = False
        '010001;C011+999.999 +VBCR = For V1, C1, C2
        '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected

        '123456;C901T/D;18:01:12;05/09/13;C011;+010.006   +VBCR = For V8 with 1 result selected
        '123456;C901T/D;22:42:06;05/09/13;C011;+010.007;C021;+009.994
        '123456;C901T/D;22:42:49;05/09/13;C011;+010.007;C021;+009.994;C031;+010.002
        '123456;C901T/D;22:43:29;05/09/13;C011;+010.007;C021;+009.994;C031;+010.002;C041;+010.002
        '123456;C901T/D;22:45:02;05/09/13;C011;+010.007;C021;+009.994;C031;+010.002;C041;+010.002;C051;+010.007
        '123456;C901T/D;22:46:10;05/09/13;C011;+010.007;C021;+009.994;C031;+010.002;C041;+010.002;C051;+010.007;C061;+010.009
        '123456;C901T/D;22:47:02;05/09/13;C011;+010.007;C021;+009.994;C031;+010.002;C041;+010.002;C051;+010.007;C061;+010.009;C071;+010.008
        '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007
        
        lblFileSel.Text = ""
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        '010001;C011+999.999 +VBCR = For V1, C1, C2
        '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected
        '123456;C901T/D;18:01:12;05/09/13;C011;+010.006   +VBCR = For V8 with 1 result selected

        If Data_Ready Then

            Timer2.Enabled = False
            Dim file1 As System.IO.StreamWriter = Nothing
            datacaptureFile = Mid(lblFileSel.Text, Len("Data Being Captured to: "))
            If File.Exists(datacaptureFile) Then
                Try
                    'lblCounter.Text = (Val(lblCounter.Text) + 1).ToString
                    'lblMeasurement.Text = (Format(Val(Mid(In_String, 12, 8)), "###0.0000#")).ToString
                    'lblMeasurement.Text = Val(Mid(In_String, 12, 8))
                    'applyColorToReading()

                    If (Len(In_String) > 0) Then
                        file1 = New StreamWriter(datacaptureFile, True)

                        In_String = ProvideLanguageCorrectedDecimalPoint(In_String)
                        In_String = ProvideLanguageCorrectedListSeperator(In_String)


                        file1.Write(In_String)
                        file1.Close()
                        file1.Dispose()
                    Else

                    End If
                    If TextBox1.Lines.Length > 500 Then
                        TextBox1.Text = ""
                    End If
                    TextBox1.Text = TextBox1.Text + In_String

                    
                Catch ex As Exception
                    MsgBox("Unable to write data to selected file!" & vbCr & "Please check if the file is open or deleted or write protected!", MsgBoxStyle.OkOnly, "File data storage error!")
                Finally
                    If Not file1 Is Nothing Then file1.Dispose()
                End Try
            Else
                MsgBox("File do not exist." & vbCr & " Please check if the file exists or has correct permission!", MsgBoxStyle.OkOnly, "File data storage error!")
            End If
            Main.ToolStripStatusLabel4.Text = ""
            In_String = ""
            Data_Ready = False

            Timer2.Enabled = True
        Else
        End If
    End Sub

    
   
    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        Dim myStream As Stream = Nothing
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            lblFileSel.Text = ""
            'lblFileSel.Visible = False
            'isFileSelected = False
            Try
                myStream = OpenFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                    lblFileSel.Text = "Data Being Captured to: " & OpenFileDialog1.FileName
                    'lblFileSel.Visible = True
                    'isFileSelected = True
                    'isPartChanged = False
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateFile.Click
        Dim myStream As Stream

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'SaveFileDialog1.FileName = (SaveFileDialog1.FileName & "." & SaveFileDialog1.DefaultExt)
            SaveFileDialog1.FileName = (SaveFileDialog1.FileName)
            myStream = SaveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                ' Code to write the stream goes here.
                myStream.Close()
            End If

            Dim Partfilepath As String = SaveFileDialog1.FileName
            If (File.Exists(Partfilepath)) Then
                Try
                    'isFileSelected = False
                    Dim file1 As System.IO.StreamWriter = New StreamWriter(Partfilepath, True)
                    file1.WriteLine("")
                    file1.WriteLine("")

                    file1.WriteLine("")
                    file1.WriteLine("")
                    file1.WriteLine("Component Data Log OctaGage")
                    file1.WriteLine("")
                    file1.WriteLine("")
                    file1.Close()
                    file1.Dispose()

                Catch ex As Exception
                    MessageBox.Show("Unable to write date to created file", "Data Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Else
                MsgBox("Unable to write date to created file", MsgBoxStyle.OkOnly, "File data storage error!")
            End If
            If (MsgBox("Do you want to store readings to: " & Partfilepath, MsgBoxStyle.YesNo, "Selecting file for storing data!") = MsgBoxResult.Yes) Then
                lblFileSel.Text = "Data Being Captured to: " & Partfilepath
                'lblFileSel.Visible = True
                'isFileSelected = True
            Else
                lblFileSel.Text = ""
                'lblFileSel.Visible = False
            End If
        End If

    End Sub

    Private Sub btnStartCapturing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartCapturing.Click
        If Not (lblFileSel.Text = "") Then
            TogglePort(Main.SerialPort1)
            '010001;C011+999.999 +VBCR = For V1, C1, C2
            '123456;C901T/D;17:59:51;05/09/13;C011;+010.005;C021;+010.004;C031;+010.001;C041;+010.001;C051;+010.006;C061;+010.007;C071;+010.007;C081;+010.007  +VBCR = For V8 with 8 results selected
            '123456;C901T/D;18:01:12;05/09/13;C011;+010.006   +VBCR = For V8 with 1 result selected
            Main.SerialPort1.ReceivedBytesThreshold = 1024
            If (Main.SerialPort1.IsOpen) Then
                Timer2.Interval = CInt(((Main.SerialPort1.ReceivedBytesThreshold) / ((Main.SerialPort1.BaudRate) / 8)) * 1000)
                Timer2.Enabled = True
                btnStartCapturing.Visible = False
                btnStopCapturing.Visible = True
                btnCreateFile.Enabled = False
                btnSelectFile.Enabled = False
                TextBox1.Text = ""
            Else
                Timer2.Enabled = False
                MsgBox("Unable to open serial port please try again!", MsgBoxStyle.OkOnly, "Serial Port Open Error!")
            End If
        Else
            MsgBox("Please select file to capture data!", MsgBoxStyle.OkOnly, "Select / Create data file!")
        End If
        

    End Sub

    Private Sub btnStopCapturing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopCapturing.Click
        btnCreateFile.Enabled = True
        btnSelectFile.Enabled = True

        Dim Partfilepath As String = Mid(lblFileSel.Text, Len("Data Being Captured to: "))
        If (Main.SerialPort1.IsOpen) And File.Exists(Partfilepath) Then
            If (Main.SerialPort1.BytesToRead > 0) Then
                Try
                    'isFileSelected = False
                    Dim file1 As System.IO.StreamWriter = New StreamWriter(Partfilepath, True)
                    In_String = Main.SerialPort1.ReadExisting

                    In_String = ProvideLanguageCorrectedDecimalPoint(In_String)
                    In_String = ProvideLanguageCorrectedListSeperator(In_String)

                    file1.Write(In_String)
                    file1.Close()
                    file1.Dispose()
                    If TextBox1.Lines.Length > 500 Then
                        TextBox1.Text = ""
                    End If

                    
                    TextBox1.Text = TextBox1.Text + In_String

                Catch ex As Exception
                    MessageBox.Show("Unable to write date to created file", "Data Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If
        TogglePort(Main.SerialPort1)
        If (Main.SerialPort1.IsOpen = False) Then
            Timer2.Enabled = False
            btnStartCapturing.Visible = True
            btnStopCapturing.Visible = False
        Else
            MsgBox("Unable to close serial port please try again!", MsgBoxStyle.OkOnly, "Serial Port Close Error!")
        End If

    End Sub
End Class