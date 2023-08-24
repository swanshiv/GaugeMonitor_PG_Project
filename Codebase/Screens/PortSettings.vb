Imports System.IO
Imports System.IO.Ports

Public Class PortSettings

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'SetSerialPortProperties(Main.SerialPort1, ListBox2.Text, CInt(ListBox1.Text), ListBox3.Text, CUShort(ListBox4.Text), CUShort(ListBox5.Text), ListBox6.Text)

        If (Main.SerialPort1.IsOpen = False) And Not (ListBox1.SelectedItem = Nothing) Then

            'Port_Name
            'Port_Baud_Rate
            'Port_Data_Bits
            'Port_Port_Parity
            'Port_Stop_Bits
            'Port_Handshake

            Main.SerialPort1.PortName = ListBox1.Text

            Main.SerialPort1.BaudRate = CInt(ListBox2.Text) 'Integer value

            If ListBox3.Text = "8" Then
                Main.SerialPort1.DataBits = 8
            ElseIf ListBox3.Text = "9" Then
                Main.SerialPort1.DataBits = 9
            End If

            If ListBox4.Text = "Even" Then
                Main.SerialPort1.Parity = Parity.Even
            ElseIf ListBox4.Text = "Odd" Then
                Main.SerialPort1.Parity = Parity.Odd
            ElseIf ListBox4.Text = "Space" Then
                Main.SerialPort1.Parity = Parity.Space
            ElseIf ListBox4.Text = "Mark" Then
                Main.SerialPort1.Parity = Parity.Mark
            ElseIf ListBox4.Text = "None" Then
                Main.SerialPort1.Parity = Parity.None
            End If

            If ListBox5.Text = "One" Then
                Main.SerialPort1.StopBits = StopBits.One
            ElseIf ListBox5.Text = "Two" Then
                Main.SerialPort1.StopBits = StopBits.Two
            ElseIf ListBox5.Text = "OnePointFive" Then
                Main.SerialPort1.StopBits = StopBits.OnePointFive
            ElseIf ListBox5.Text = "None" Then
                Main.SerialPort1.StopBits = StopBits.One
            End If

            If ListBox6.Text = "None" Then
                Main.SerialPort1.Handshake = Handshake.None
            ElseIf ListBox6.Text = "XOnXOff" Then
                Main.SerialPort1.Handshake = Handshake.XOnXOff
            ElseIf ListBox6.Text = "RequestToSend" Then
                Main.SerialPort1.Handshake = Handshake.RequestToSend
            ElseIf ListBox6.Text = "RequestToSendXOnXOff" Then
                Main.SerialPort1.Handshake = Handshake.RequestToSendXOnXOff
            End If

            'Save to DB
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Port") = ListBox1.SelectedItem.ToString()
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Baud_Rate") = ListBox2.SelectedItem.ToString()
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Data_Bits") = ListBox3.SelectedItem.ToString()
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Parity") = ListBox4.SelectedItem.ToString()
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Stop_Bit") = ListBox5.SelectedItem.ToString()
            VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Flow_Control") = ListBox6.SelectedItem.ToString()
            CommunicationPortTableAdapter.UpdateQuery(ListBox1.SelectedItem.ToString(), ListBox2.SelectedItem.ToString(), ListBox3.SelectedItem.ToString(), ListBox4.SelectedItem.ToString(), ListBox5.SelectedItem.ToString(), ListBox6.SelectedItem.ToString())
        Else
            MsgBox("First 'Stop Data Capture' and then try changing port settings!", MsgBoxStyle.OkOnly, "Serial port settings change error")
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PortSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ListBox1.Items.Clear()
        If COMPorts.Length > 0 Then
            For itm = 0 To (COMPorts.Length - 1)
                ListBox1.Items.Add(CStr(COMPorts(itm)))
            Next itm
            ListBox1.SelectedIndex = 0
            ListBox1.Text = ListBox1.SelectedItem.ToString
        Else
            MsgBox("No COM port available!", MsgBoxStyle.OkOnly, "Error!")
        End If

        'If Not (A_user = "") And Not (A_user = "Factory User") And Not (A_user = "Admin") Then
        '    GroupBox2.Enabled = False

        'Else
        populateDropdowns()
        'End If
        'ListBox2.SelectedIndex = -1
        'ListBox2.Text = ListBox1.SelectedItem.ToString

        'ListBox3.SelectedIndex = -1
        'ListBox3.Text = ListBox1.SelectedItem.ToString

        'ListBox4.SelectedIndex = -1
        'ListBox4.Text = ListBox1.SelectedItem.ToString

        'ListBox5.SelectedIndex = -1
        'ListBox5.Text = ListBox1.SelectedItem.ToString

        'ListBox6.SelectedIndex = -1
        'ListBox6.Text = ListBox1.SelectedItem.ToString

        'Load from DB
        CommunicationPortTableAdapter.Fill(VersaGageMonitorDataSet.Tables("CommunicationPort"))
        If Not VersaGageMonitorDataSet.Tables("CommunicationPort") Is Nothing Then
            If VersaGageMonitorDataSet.Tables("CommunicationPort").Rows.Count > 0 Then
                ListBox1.SelectedIndex = ListBox1.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Port").ToString())
                ListBox2.SelectedIndex = ListBox2.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Baud_Rate").ToString())
                ListBox3.SelectedIndex = ListBox3.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Data_Bits").ToString())
                ListBox4.SelectedIndex = ListBox4.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Parity").ToString())
                ListBox5.SelectedIndex = ListBox5.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Stop_Bit").ToString())
                ListBox6.SelectedIndex = ListBox6.FindStringExact(VersaGageMonitorDataSet.Tables("CommunicationPort").Rows(0).Item("Flow_Control").ToString())
            End If
        End If
    End Sub

    Private Sub populateDropdowns()
        ListBox2.DataSource = New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"}
        ListBox3.DataSource = New Object() {"8", "9"}
        ListBox4.DataSource = New Object() {"None", "Even", "Odd", "Space", "Mark"}
        ListBox5.DataSource = New Object() {"One", "Two", "One Point Five", "None"}
        ListBox6.DataSource = New Object() {"None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff"}
    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.CommunicationPortTableAdapter.Connection.ConnectionString = value
            Me.CommunicationPortTableAdapter.Fill(Me.VersaGageMonitorDataSet.CommunicationPort)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class