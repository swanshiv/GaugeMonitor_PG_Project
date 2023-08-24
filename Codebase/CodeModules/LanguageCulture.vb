Imports System.IO
Imports System
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Threading
Imports System.Text
Imports System.Text.RegularExpressions
Module LanguageCulture
    Public Function ProvideLanguageCorrectedDecimalPoint(ByRef InputString As String) As String
        Dim mydecimalseparator As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim CorrectedString As String = ""
        CorrectedString = Replace(InputString, ".", mydecimalseparator)
        ProvideLanguageCorrectedDecimalPoint = CorrectedString
    End Function

    Public Function ProvideLanguageCorrectedListSeperator(ByRef InputString As String) As String
        mylistseparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator
        Dim CorrectedString As String = ""
        CorrectedString = Replace(InputString, ";", mylistseparator)
        ProvideLanguageCorrectedListSeperator = CorrectedString
    End Function
    Public Function ProvideLanguageDecimalPoint() As Char
        ProvideLanguageDecimalPoint = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Function
    Public Function ProvideLanguageListSeperator() As Char
        ProvideLanguageListSeperator = CultureInfo.CurrentCulture.TextInfo.ListSeparator
    End Function
End Module
