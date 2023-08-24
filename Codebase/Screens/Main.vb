Imports System.Math
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.IO.Ports
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Drawing.Drawing2D
Imports System
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Globalization
Imports System.Security.Permissions

'<Assembly: SecurityPermission(SecurityAction.RequestMinimum, ControlThread:=True)> 

Public Class Main

    Private Sub Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not (A_user = "") And Not (A_user = "Factory User") And Not (A_user = "Admin") Then
            AddUserToolStripMenuItem.Enabled = False
            DeleteUserToolStripMenuItem.Enabled = False
            ChangePasswordToolStripMenuItem.Enabled = False

        Else
            AddUserToolStripMenuItem.Enabled = True
            DeleteUserToolStripMenuItem.Enabled = True
            ChangePasswordToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Main_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem1.Click
        COMPorts = GetPortNames(SerialPort1)
        PortSettings.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem2.Click
        Customer_Information.ShowDialog()
    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (A_user = "") And Not (A_user = "Factory User") And Not (A_user = "Admin") Then
            AddUserToolStripMenuItem.Enabled = False
            DeleteUserToolStripMenuItem.Enabled = False
            ChangePasswordToolStripMenuItem.Enabled = False
        Else
            AddUserToolStripMenuItem.Enabled = True
            DeleteUserToolStripMenuItem.Enabled = True
            ChangePasswordToolStripMenuItem.Enabled = True
        End If


        LoadCommunicatoinSettings()

    End Sub

    Private Sub TricolorColumnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TricolorColumnToolStripMenuItem.Click
        Dim measureData As New Measure
        measureData.MdiParent = Me
        measureData.Show()

        'Measure.ShowDialog()
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived


        Try
            If Not Data_Ready Then
                If Not IsOctaGage Then
                    If IsMeasure Then

                        In_String = SerialPort1.ReadTo(vbCr)
                        Data_Ready = True

                    Else
                        In_String = SerialPort1.ReadTo(vbCr)
                        Data_Ready = True
                    End If
                Else
                    In_String = SerialPort1.ReadTo(vbCr)
                    Data_Ready = True
                End If

            Else

            End If

        Catch ex As IOException
            MsgBox("Port is abruptly closed!!!" & "Please close the Communication Port and start again!!!", MsgBoxStyle.OkOnly, "")
        Catch ex As Exception
            MsgBox("Improper Data Received on serial port" & vbCr & " please check if number of parameters defined for this part" & vbCr & "are same as number of results displayed on the OctaGage!" & vbCr & "Please also Stop the reception of data and Start again and try! ", MsgBoxStyle.OkOnly, "Improper data received at serial port!")
        End Try

    End Sub

    Private Sub LoadCommunicatoinSettings()
        'Load from DB
        CommunicationPortTableAdapter.Fill(VersaGageMonitorDataSet.Tables("CommunicationPort"))
        If Not VersaGageMonitorDataSet.Tables("CommunicationPort") Is Nothing Then
            If VersaGageMonitorDataSet.Tables("CommunicationPort").Rows.Count > 0 Then
                SerialPort1.PortName = VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Port").ToString()
                SerialPort1.BaudRate = CInt(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Baud_Rate").ToString()) 'Integer value

                Select Case VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Data_Bits").ToString()
                    Case "8"
                        SerialPort1.DataBits = 8
                    Case "9"
                        SerialPort1.DataBits = 9
                End Select

                Select Case VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Parity").ToString().ToUpper()
                    Case "EVEN"
                        SerialPort1.Parity = Parity.Even
                    Case "ODD"
                        SerialPort1.Parity = Parity.Odd
                    Case "SPACE"
                        SerialPort1.Parity = Parity.Space
                    Case "MARK"
                        SerialPort1.Parity = Parity.Mark
                    Case "NONE"
                        SerialPort1.Parity = Parity.None
                    Case Else
                        SerialPort1.Parity = Parity.None
                End Select

                Select Case VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Stop_Bit").ToString().ToUpper()
                    Case "ONE"
                        SerialPort1.StopBits = StopBits.One
                    Case "TWO"
                        SerialPort1.StopBits = StopBits.Two
                    Case "ONEPOINTFIVE"
                        SerialPort1.StopBits = StopBits.OnePointFive
                    Case "NONE"
                        SerialPort1.StopBits = StopBits.One
                End Select

                Select Case VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Flow_Control").ToString().ToUpper()
                    Case "NONE"
                        SerialPort1.Handshake = Handshake.None
                    Case "XONXOFF"
                        SerialPort1.Handshake = Handshake.XOnXOff
                    Case "REQUESTTOSEND"
                        SerialPort1.Handshake = Handshake.RequestToSend
                    Case "REQUESTTOSENDXONXOFF"
                        SerialPort1.Handshake = Handshake.RequestToSendXOnXOff
                End Select
            End If
        End If
    End Sub

    Private Sub PartDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartDetailsToolStripMenuItem.Click
        Dim FormPartSettings As New PartSettings
        FormPartSettings.MdiParent = Me
        FormPartSettings.Show()
        'PartSettings.ShowDialog()
    End Sub

    Private Sub ReadToCSVFileToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadToCSVFileToolStripMenuItem1.Click
        Dim captureData As New CapturetoFile
        captureData.MdiParent = Me
        captureData.Show()
        'CapturetoFile.ShowDialog()
    End Sub

    Private Sub OctaGageToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OctaGageToolStripMenuItem1.Click
        Dim captureOctaGage As New MeasureOctaGage
        captureOctaGage.MdiParent = Me
        captureOctaGage.Show()

        'MeasureOctaGage.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If (MessageBox.Show("Do You Want to Exit?", "Exiting From Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        Help.ShowHelpIndex(Me, HelpProvider1.HelpNamespace)
    End Sub

    'Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    If (MessageBox.Show("Do You Want to Exit", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.OK) Then
    '        If SerialPort1.IsOpen Then
    '            SerialPort1.Close()
    '        End If
    '    End If
    'End Sub

End Class
