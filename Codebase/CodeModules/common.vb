Public Module common
    Public datacaptureFile As String = ""

    Public Function formatNumber(ByVal val As Object, ByVal digits As Int16) As String
        Dim format As String = ""
        For i = 1 To digits
            format = format + "0"
        Next
        formatNumber = String.Format("{0:#,0." & format & "}", val).ToString().Trim()
    End Function

End Module
