Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.IO.Ports
Module CommunicationPortSettings
    Public PublicPort As Boolean = False 'Set if the port is open and available for communication
    Public In_String As String = ""
    Public Port_Read_Busy As Boolean = False 'No any other threads / application should read the port or Chanel_Count array when it is being updated
    Public COMPorts As Array
    Public Data_Ready As Boolean = False
    
    Public Function GetPortNames(ByRef SerialPort As SerialPort) As String()
        Dim returnValue As String()

        returnValue = SerialPort.GetPortNames()
        Return returnValue


    End Function
    Public Sub SetSerialPortProperties(ByVal Sport As SerialPort, ByRef PortName As String, ByRef BaudRate As Integer, ByRef Parity As String, ByRef DataBits As UShort, ByRef StopBits As UShort, ByRef Handshake As String)
        If Sport.IsOpen = False Then
            Sport.PortName = PortName
            Sport.BaudRate = BaudRate
            Sport.DataBits = DataBits
            Sport.Parity = Parity
            Sport.StopBits = StopBits
            Sport.Handshake = Handshake
        Else
            MsgBox("Port already open or being used by another application", MsgBoxStyle.OkOnly, "Serial Port Open Error")
        End If
    End Sub
    Public Sub SetSerialPortReceivedBytesThreshold(ByVal Sport As SerialPort, ByRef RThreshold As Integer)
        Sport.ReceivedBytesThreshold = RThreshold
    End Sub
    Public Sub SetSerialPortReadBufferSize(ByVal Sport As SerialPort, ByRef ReadBufferSize As Integer)
        Sport.ReadBufferSize = ReadBufferSize
    End Sub

    Public Sub TogglePort(ByVal SPort As SerialPort)
        Try
            If Not SPort.IsOpen Then
                SPort.Open()
                PublicPort = True
            ElseIf SPort.IsOpen Then
                SPort.Close()
                PublicPort = False
                'MsgBox("Port already open or being used by another application", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            End If

            'Exception                          (Condition)
            'InvalidOperationException          The specified port is open. 
        Catch ex1 As InvalidOperationException
            MsgBox("The specified port is open.", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            Exit Try

            'Exception                          (Condition)
            'ArgumentOutOfRangeException        One or more of the properties for this instance are invalid. For example, the Parity, DataBits, or Handshake properties are not valid values; the BaudRate is less than or equal to zero; the ReadTimeout or WriteTimeout property is less than zero and is not InfiniteTimeout. 
        Catch ex2 As ArgumentOutOfRangeException
            MsgBox("One or more of the properties for this instance are invalid.", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            Exit Try

            'Exception                          (Condition)
            'ArgumentException                  The port name does not begin with "COM". 
            '                                   - or -
            '                                   The file type of the port is not supported.
        Catch ex3 As ArgumentException
            MsgBox("The port name does not begin with 'COM'. ", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            Exit Try

            'Exception                          (Condition)
            'IOException                        The port is in an invalid state. 
            '                                   - or - 
            '                                   An attempt to set the state of the underlying port failed. For example, the parameters passed from this SerialPort object were invalid.
        Catch ex4 As IOException
            MsgBox("An attempt to set the state of the underlying port failed.", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            Exit Try

            'Exception                          (Condition)
            'UnauthorizedAccessException        Access is denied to the port. 
        Catch ex5 As UnauthorizedAccessException
            MsgBox("Access is denied to the port.", MsgBoxStyle.OkOnly, "Serial Port Open Error")
            Exit Try

        End Try



    End Sub

End Module
