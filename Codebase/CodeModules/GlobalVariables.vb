Module GlobalVariables
    Public StartupDone As Boolean = False
    Public A_user As String = ""
    Public A_Password As String = ""
    Public value As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DataBase\VersaGageMonitor.mdb;Persist Security Info=True;Jet OLEDB:Database Password= admin410507"
    Public IsOctaGage As Boolean = False
    Public IsMeasure As Boolean = False
    Public mylistseparator As String

    '' This subroutine writes a message to the txtStatus TextBox.
    'Public Sub WriteMessage(ByRef Messagebox As TextBox, ByVal message As String, ByVal line_feed As Boolean, ByVal Clear_Text_Box As Boolean)
    '    If (line_feed = True) And (Clear_Text_Box = False) Then
    '        Messagebox.Text += message + vbCrLf
    '    ElseIf (line_feed = False) And (Clear_Text_Box = False) Then
    '        Messagebox.Text += message
    '    ElseIf (line_feed = True) And (Clear_Text_Box = True) Then
    '        Messagebox.Text = message + vbCrLf
    '    ElseIf (line_feed = False) And (Clear_Text_Box = True) Then
    '        Messagebox.Text = message
    '    End If
    'End Sub
End Module
