Module HardLock

    'Public HWLockExtensionNum As String = " 6" ' Inflatable BEL Installation 1
    'Public HWLockExtensionNum As String = " 5" ' Inflatable DASS Hitachi Installation 1
    Public HWLockExtensionNum As String = " 11" ' Inflatable DASS Hitachi Installation 2
    Public rbuff(12) As UInt16
    Public signature(12) As UInt16

    '***********************************************************************************************
    'key6251.txt
    'Sentry Hardware Lock
    'Key for Batch Number:6251
    'ASCII:MZ7MJH-M5JPQ7-J6ZM5K
    'HEX:
    '   0x5a4d
    '   0x4d37
    '   0x484a
    '   0x4d2d
    '   0x4a35
    '   0x5150
    '   0x2d37
    '   0x364a
    '   0x4d5a
    '   0x4b35
    '   0x2020
    '   0x2020
    'PASSWORD:VCCP
    'ASCII "VCCP"
    'HEX: 0x56,0x43,0x43,0x50
    '***********************************************************************************************
    '***********************************************************************************************
    'Hardware Lock Serial Number -6251-0002
    '
    '***********************************************************************************************

    'HardLockTime
    '#Const net = True

    'GetExtension
#If net Then
    Public Declare Auto Function init_client Lib "sentrynet.dll" Alias "init_client" (ByRef rbuff As UInt16) As Int32
    Public Declare Auto Function net_get_extn_nt95 Lib "sentrynet.dll" Alias "net_get_extn_nt95" (ByRef rbuff As UInt16) As Int32
    Public Declare Auto Function exit_client Lib "sentrynet.dll" Alias "exit_client" () As Int32
#Else
    Public Declare Auto Function win_get_extn_nt95 Lib "sentrydll5.dll" Alias "win_get_extn_nt95" (ByRef rbuff As UInt16) As Int32
#End If

    'Xread
#If net Then
    Public Declare Auto Function init_client Lib "Sentrynet.dll" Alias "init_client" (ByRef rbuff As UInt16) As Int32
    Public Declare Auto Function net_xread_nt95 Lib "Sentrynet.dll" Alias "net_xread_nt95" (ByRef rbuff As UInt16, ByRef pass As Byte) As Int32
    Public Declare Auto Function exit_client Lib "Sentrynet.dll" Alias "exit_client" () As Int32
#Else
    Public Declare Auto Function win_xread_nt95 Lib "SentryDLL5.dll" Alias "win_xread_nt95" (ByRef rbuff As UInt16, ByRef pass As Byte) As Int32
#End If

    'GetVal
#If net Then
        Public Declare Auto Function init_client Lib "Sentrynet.dll" Alias "init_client" (ByRef rbuff As UInt16) As Int32
        Public Declare Auto Function net_read_val_nt95 Lib "Sentrynet.dll" Alias "net_read_val_nt95" (ByRef rbuff As UInt16, ByVal value1 As Int16) As Int32
        Public Declare Auto Function exit_client Lib "Sentrynet.dll" Alias "exit_client" () As Int32
#Else

    Public Declare Auto Function win_read_val_nt95 Lib "SentryDLL5.dll" Alias "win_read_val_nt95" (ByRef rbuff As UInt16, ByVal value1 As Int16) As Int32
#End If
    Public Function Check_HardwareLock() As Boolean
        Dim ExtensionNumber As String = GetExtension()


        If (HWLockExtensionNum = ExtensionNumber) Then
            If (Xread()) Then
                Return True
            Else

                Return False
            End If
        Else
            Return False
        End If
        'Return True 'Enabled only for debugging
    End Function

    Public Sub Set_rbuff_Key_Signature() 'Here to set Key and Signature of the Hardware Lock for each Setup Distribution
        rbuff(0) = Convert.ToUInt16(&H5A4D)
        rbuff(1) = Convert.ToUInt16(&H4D37)
        rbuff(2) = Convert.ToUInt16(&H484A)
        rbuff(3) = Convert.ToUInt16(&H4D2D)
        rbuff(4) = Convert.ToUInt16(&H4A35)
        rbuff(5) = Convert.ToUInt16(&H5150)
        rbuff(6) = Convert.ToUInt16(&H2D37)
        rbuff(7) = Convert.ToUInt16(&H364A)
        rbuff(8) = Convert.ToUInt16(&H4D5A)
        rbuff(9) = Convert.ToUInt16(&H4B35)
        rbuff(10) = Convert.ToUInt16(&H2020)
        rbuff(11) = Convert.ToUInt16(&H2020)

        signature(0) = Convert.ToUInt16(&H1234)
        signature(1) = Convert.ToUInt16(&H2345)
        signature(2) = Convert.ToUInt16(&H3456)
        signature(3) = Convert.ToUInt16(&H4567)
        signature(4) = Convert.ToUInt16(&H5678)
        signature(5) = Convert.ToUInt16(&H6789)
        signature(6) = Convert.ToUInt16(&H789A)
        signature(7) = Convert.ToUInt16(&H89AB)
        signature(8) = Convert.ToUInt16(&H9ABC)
        signature(9) = Convert.ToUInt16(&HABCD)
        signature(10) = Convert.ToUInt16(&HBCDE)
        signature(11) = Convert.ToUInt16(&HCDEF)
    End Sub

    'Gets Extension Number Of the Hardware Lock
    Public Function GetExtension() As String 'Gets Extension Number Of the Hardware Lock

        Dim pass(4) As Byte
        Dim stat As Int32
        'Dim stat1 As Int32
        'Dim i As Integer
        'Dim index As Long
        ' Dim value As Long

        Set_rbuff_Key_Signature()

#If net Then
        stat = init_client(rbuff(0))
        stat1 = stat
        If stat = 0 Then
            stat = net_get_extn_nt95(rbuff(0))
        End If
#Else
        stat = win_get_extn_nt95(rbuff(0))
#End If
        If stat >= 0 And Not (stat = HWLockExtensionNum) Then
            'Error
            MsgBox("The Hardware Lock you installed is not bearing proper identity!!!")
        Else
            Select Case stat
                Case -1
                    'Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    MsgBox("Sentry Hardware Lock Sr. " & HWLockExtensionNum & " NOT installed OR the one installed is not bearing proper identity", vbOKOnly)
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    MsgBox("The Password you have issued is not matching with the one assigned for the Lock attached !", vbOKOnly)
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    MsgBox(" The memory location index entered is out of range (0-29)!", vbOKOnly)
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to this machine !"
                    MsgBox("The KEY passed with this function is not made for the lock attached to this machine !", vbOKOnly)
#If net Then
                Case -1
                    'Text5.Text = "Sentry Hardware Lock NOT found on Server Machine"
                    MsgBox("Hardware Lock NOT found on Server Machine", vbOKOnly)
                Case -11
                    'Text5.Text = "Network Lock NOT found on Server Machine"
                    MsgBox("Network Lock NOT found on Server Machine", vbOKOnly)
                Case -21
                    'Text5.Text = "Client already logged in! "
                    MsgBox("Client already logged in! ", vbOKOnly)
                Case -22
                    'Text5.Text = "Client limit exceeded! "
                    MsgBox("Client limit exceeded! ", vbOKOnly)
                Case -13
                    'Text5.Text = "Client Not Logged in!"
                    MsgBox("Client Not Logged in!", vbOKOnly)
                Case -14
                    'Text5.Text = " Server Not found!"
                    MsgBox(" Server Not found!", vbOKOnly)
#End If
            End Select
            'Else
            'Text5.Text = "Successfully gets the Extension number of the lock"
        End If
        'Text4.Text = Str(stat)
        Return (Str(stat))
#If net Then
        If stat1 = 0 Then
            stat1 = exit_client()
            Select Case stat1
                Case 0
                    MsgBox("Client Logged out Successfully!", vbOKOnly)
                Case -13
                    MsgBox("Client Not Logged in!", vbOKOnly)
            End Select
        End If
#End If
    End Function

    'Reads Hardware Lock Signature
    Public Function Xread() As Boolean 'Reads Hardware Lock Signature

        Dim pass(4) As Byte
        Dim stat As Int32
        'Dim stat1 As Int32
        Dim i As Integer


        Set_rbuff_Key_Signature()


        pass(0) = &H56
        pass(1) = &H43
        pass(2) = &H43
        pass(3) = &H50


#If net Then
        stat = init_client(rbuff(0))
        stat1 = stat
        If stat = 0 Then
            stat = net_xread_nt95(rbuff(0), pass(0))
        End If
#Else
        stat = win_xread_nt95(rbuff(0), pass(0))
#End If

        Select Case stat
            Case 0

                For i = 0 To 11

                    If (rbuff(i).CompareTo(signature(i)) <> 0) Then Exit For

                Next i
                If (i < 11) Then
                    'Text5.Text = "Lock Found! Data Read from the lock is NOT matching with the one assigned to Signature variable!"
                    MsgBox("Lock Found! Data Read from the lock is NOT matching with the one assigned to Signature variable!", vbOKOnly)
                    Return False
                Else
                    't1.Text = Hex(rbuff(0).ToString)
                    't2.Text = Hex(rbuff(1).ToString)
                    't3.Text = Hex(rbuff(2).ToString)
                    't4.Text = Hex(rbuff(3).ToString)
                    't5.Text = Hex(rbuff(4).ToString)
                    't6.Text = Hex(rbuff(5).ToString)
                    't7.Text = Hex(rbuff(6).ToString)
                    't8.Text = Hex(rbuff(7).ToString)
                    't9.Text = Hex(rbuff(8).ToString)
                    't10.Text = Hex(rbuff(9).ToString)
                    't11.Text = Hex(rbuff(10).ToString)
                    't12.Text = Hex(rbuff(11).ToString)

                    'Text5.Text = "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!"
                    'MsgBox("Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", vbOKOnly)
                    Return True
                End If

            Case -1
                'Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                MsgBox("Sentry Hardware Lock Sr. " & HWLockExtensionNum & " NOT installed OR the one installed is not bearing proper identity", vbOKOnly)
            Case -2
                'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                MsgBox("The Password you have issued is not matching with the one assigned for the Lock attached !", vbOKOnly)
            Case -7
                'Text5.Text = " The memory location index entered is out of range (0-29)!"
                MsgBox(" The memory location index entered is out of range (0-29)!", vbOKOnly)
            Case -10
                'Text5.Text = " The KEY passed with this function is not made for the lock attached to this machine !"
                MsgBox(" The KEY passed with this function is not made for the lock attached to this machine !", vbOKOnly)
#If net Then
            Case -1
                'Text5.Text = "Sentry Hardware Lock NOT found on Server Machine"
                MsgBox("Sentry Hardware Lock NOT found on Server Machine", vbOKOnly)
            Case -11
                'Text5.Text = "Network Lock NOT found on Server Machine"
                MsgBox("Network Lock NOT found on Server Machine", vbOKOnly)
            Case -21
                'Text5.Text = "Client already logged in! "
                MsgBox("Client already logged in! ", vbOKOnly)
            Case -22
                'Text5.Text = "Client limit exceeded! "
                MsgBox("Client limit exceeded! ", vbOKOnly)
            Case -13
                'Text5.Text = "Client Not Logged in!"
                MsgBox("Client Not Logged in!", vbOKOnly)
            Case -14
                'Text5.Text = " Server Not found!"
                MsgBox(" Server Not found!", vbOKOnly)
#End If

        End Select
        'Text4.Text = Str(stat)

#If net Then
        If stat1 = 0 Then
            stat1 = exit_client()
            Select Case stat1
                Case 0
                    MsgBox("Client Logged out Successfully!", vbOKOnly)
                Case -13
                    MsgBox("Client Not Logged in!", vbOKOnly)
            End Select
        End If
#End If
    End Function

    'Reads Value
    Public Function GetVal() As String

        Dim pass(4) As Byte
        Dim stat As Int32
        'Dim stat1 As Int32
        'Dim i As Integer
        Dim index As Int16

        Set_rbuff_Key_Signature()


        'index = Val(Text2.Text)
        If (index < 0) Or (index > 29) Then
            'Text5.Text = "You have entered index out of range (0 - 29)"
            'MsgBox("You have entered index out of range (0 - 29)", vbOKOnly)
        End If
#If net Then
        stat = init_client(rbuff(0))
        stat1 = stat
        If stat = 0 Then
            stat = net_read_val_nt95(rbuff(0), index)
        End If
#Else
        stat = win_read_val_nt95(rbuff(0), index)
#End If
        If stat < 0 Then            'Error


            Select Case stat
                Case -1
                    'Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    MsgBox("Hardware Lock Sr. " & HWLockExtensionNum & " NOT installed OR the one installed is not bearing proper identity", vbOKOnly)
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    MsgBox("The Password you have issued is not matching with the one assigned for the Lock attached !", vbOKOnly)
                Case -3
                    'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                    MsgBox("Sentrymsp.vxd is not found in the current path  ", vbOKOnly)
                Case -5
                    'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                    MsgBox("Sentry.sys is not started or not installed on the Win NT/2000 machine!", vbOKOnly)
                Case -6
                    'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                    MsgBox(" Sentry.sys could not close its operations on the Win NT/2000 machine!", vbOKOnly)
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    MsgBox(" The memory location index entered is out of range (0-29)!", vbOKOnly)
                Case -8
                    'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                    MsgBox(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", vbOKOnly)
                Case -9
                    'Text5.Text = " Cannot work on Win3.1!"
                    MsgBox(" Cannot work on Win3.1!", vbOKOnly)
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to this machine !"
                    MsgBox(" The KEY passed with this function is not made for the lock attached to this machine !", vbOKOnly)
#If net Then
                Case -1
                    'Text5.Text = "Sentry Hardware Lock NOT found on Server Machine"
                    MsgBox("Sentry Hardware Lock NOT found on Server Machine", vbOKOnly)
                Case -11
                    'Text5.Text = "Network Lock NOT found on Server Machine"
                    MsgBox("Network Lock NOT found on Server Machine", vbOKOnly)
                Case -21
                    'Text5.Text = "Client already logged in! "
                    MsgBox("Client already logged in! ", vbOKOnly)
                Case -22
                    'Text5.Text = "Client limit exceeded! "
                    MsgBox("Client limit exceeded! ", vbOKOnly)
                Case -13
                    'Text5.Text = "Client Not Logged in!"
                    MsgBox("Client Not Logged in!", vbOKOnly)
                Case -14
                    'Text5.Text = " Server Not found!"
                    MsgBox(" Server Not found!", vbOKOnly)
#End If
            End Select
        Else
            ' Text5.Text = "Successfully reads the value"
        End If
        'Text4.Text = Str(stat)
        Return (Str(stat))
#If net Then
        If stat1 = 0 Then
            stat1 = exit_client()
            Select Case stat1
                Case 0
                    MsgBox("Client Logged out Successfully!", vbOKOnly)
                Case -13
                    MsgBox("Client Not Logged in!", vbOKOnly)
            End Select
        End If
#End If
    End Function

End Module
