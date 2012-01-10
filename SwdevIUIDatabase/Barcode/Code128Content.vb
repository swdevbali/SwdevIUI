Imports System
Imports System.Text
Namespace GenCode128
    Public Enum CodeSet
        CodeA
        CodeB
        ' ,CodeC   // not supported
    End Enum
    Public Class Code128Content
        Private mCodeList As Integer()

        ''' <summary>
        ''' Create content based on a string of ASCII data
        ''' </summary>
        ''' <param name="AsciiData">the string that should be represented</param>
        Public Sub New(ByVal AsciiData As String)
            mCodeList = StringToCode128(AsciiData)
        End Sub

        ''' <summary>
        ''' Provides the Code128 code values representing the object's string
        ''' </summary>
        Public ReadOnly Property Codes() As Integer()
            Get
                Return mCodeList
            End Get
        End Property

        ''' <summary>
        ''' Transform the string into integers representing the Code128 codes
        ''' necessary to represent it
        ''' </summary>
        ''' <param name="AsciiData">String to be encoded</param>
        ''' <returns>Code128 representation</returns>
        Private Function StringToCode128(ByVal AsciiData As String) As Integer()
            ' turn the string into ascii byte data
            Dim asciiBytes As Byte() = Encoding.ASCII.GetBytes(AsciiData)

            ' decide which codeset to start with
            Dim csa1 As Code128Code.CodeSetAllowed = If(asciiBytes.Length > 0, Code128Code.CodesetAllowedForChar(asciiBytes(0)), Code128Code.CodeSetAllowed.CodeAorB)
            Dim csa2 As Code128Code.CodeSetAllowed = If(asciiBytes.Length > 0, Code128Code.CodesetAllowedForChar(asciiBytes(1)), Code128Code.CodeSetAllowed.CodeAorB)
            Dim currcs As CodeSet = GetBestStartSet(csa1, csa2)

            ' set up the beginning of the barcode
            Dim codes As New System.Collections.ArrayList(asciiBytes.Length + 3)
            ' assume no codeset changes, account for start, checksum, and stop
            codes.Add(Code128Code.StartCodeForCodeSet(currcs))

            ' add the codes for each character in the string
            For i As Integer = 0 To asciiBytes.Length - 1
                Dim thischar As Integer = asciiBytes(i)
                Dim nextchar As Integer = If(asciiBytes.Length > (i + 1), asciiBytes(i + 1), -1)

                codes.AddRange(Code128Code.CodesForChar(thischar, nextchar, currcs))
            Next

            ' calculate the check digit
            Dim checksum As Integer = CInt(codes(0))
            For i As Integer = 1 To codes.Count - 1
                checksum += i * CInt(codes(i))
            Next
            codes.Add(checksum Mod 103)

            codes.Add(Code128Code.StopCode())

            Dim result As Integer() = TryCast(codes.ToArray(GetType(Integer)), Integer())
            Return result
        End Function

        ''' <summary>
        ''' Determines the best starting code set based on the the first two 
        ''' characters of the string to be encoded
        ''' </summary>
        ''' <param name="csa1">First character of input string</param>
        ''' <param name="csa2">Second character of input string</param>
        ''' <returns>The codeset determined to be best to start with</returns>
        Private Function GetBestStartSet(ByVal csa1 As Code128Code.CodeSetAllowed, ByVal csa2 As Code128Code.CodeSetAllowed) As CodeSet
            Dim vote As Integer = 0

            vote += If((csa1 = Code128Code.CodeSetAllowed.CodeA), 1, 0)
            vote += If((csa1 = Code128Code.CodeSetAllowed.CodeB), -1, 0)
            vote += If((csa2 = Code128Code.CodeSetAllowed.CodeA), 1, 0)
            vote += If((csa2 = Code128Code.CodeSetAllowed.CodeB), -1, 0)

            Return If((vote > 0), CodeSet.CodeA, CodeSet.CodeB)
            ' ties go to codeB due to my own prejudices
        End Function



    End Class

    Public NotInheritable Class Code128Code
        Private Sub New()
        End Sub
#Region "Constants"

        Private Const cSHIFT As Integer = 98
        Private Const cCODEA As Integer = 101
        Private Const cCODEB As Integer = 100

        Private Const cSTARTA As Integer = 103
        Private Const cSTARTB As Integer = 104
        Private Const cSTOP As Integer = 106

#End Region

        ''' <summary>
        ''' Get the Code128 code value(s) to represent an ASCII character, with 
        ''' optional look-ahead for length optimization
        ''' </summary>
        ''' <param name="CharAscii">The ASCII value of the character to translate</param>
        ''' <param name="LookAheadAscii">The next character in sequence (or -1 if none)</param>
        ''' <param name="CurrCodeSet">The current codeset, that the returned codes need to follow;
        ''' if the returned codes change that, then this value will be changed to reflect it</param>
        ''' <returns>An array of integers representing the codes that need to be output to produce the 
        ''' given character</returns>
        Public Shared Function CodesForChar(ByVal CharAscii As Integer, ByVal LookAheadAscii As Integer, ByRef CurrCodeSet As CodeSet) As Integer()
            Dim result As Integer()
            Dim shifter As Integer = -1

            If Not CharCompatibleWithCodeset(CharAscii, CurrCodeSet) Then
                ' if we have a lookahead character AND if the next character is ALSO not compatible
                If (LookAheadAscii <> -1) AndAlso Not CharCompatibleWithCodeset(LookAheadAscii, CurrCodeSet) Then
                    ' we need to switch code sets
                    Select Case CurrCodeSet
                        Case CodeSet.CodeA
                            shifter = cCODEB
                            CurrCodeSet = CodeSet.CodeB
                            Exit Select
                        Case CodeSet.CodeB
                            shifter = cCODEA
                            CurrCodeSet = CodeSet.CodeA
                            Exit Select
                    End Select
                Else
                    ' no need to switch code sets, a temporary SHIFT will suffice
                    shifter = cSHIFT
                End If
            End If

            If shifter <> -1 Then
                result = New Integer(1) {}
                result(0) = shifter
                result(1) = CodeValueForChar(CharAscii)
            Else
                result = New Integer(0) {}
                result(0) = CodeValueForChar(CharAscii)
            End If

            Return result
        End Function

        ''' <summary>
        ''' Tells us which codesets a given character value is allowed in
        ''' </summary>
        ''' <param name="CharAscii">ASCII value of character to look at</param>
        ''' <returns>Which codeset(s) can be used to represent this character</returns>
        Public Shared Function CodesetAllowedForChar(ByVal CharAscii As Integer) As CodeSetAllowed
            If CharAscii >= 32 AndAlso CharAscii <= 95 Then
                Return CodeSetAllowed.CodeAorB
            Else
                Return If((CharAscii < 32), CodeSetAllowed.CodeA, CodeSetAllowed.CodeB)
            End If
        End Function

        ''' <summary>
        ''' Determine if a character can be represented in a given codeset
        ''' </summary>
        ''' <param name="CharAscii">character to check for</param>
        ''' <param name="currcs">codeset context to test</param>
        ''' <returns>true if the codeset contains a representation for the ASCII character</returns>
        Public Shared Function CharCompatibleWithCodeset(ByVal CharAscii As Integer, ByVal currcs As CodeSet) As Boolean
            Dim csa As CodeSetAllowed = CodesetAllowedForChar(CharAscii)
            Return csa = CodeSetAllowed.CodeAorB OrElse (csa = CodeSetAllowed.CodeA AndAlso currcs = CodeSet.CodeA) OrElse (csa = CodeSetAllowed.CodeB AndAlso currcs = CodeSet.CodeB)
        End Function

        ''' <summary>
        ''' Gets the integer code128 code value for a character (assuming the appropriate code set)
        ''' </summary>
        ''' <param name="CharAscii">character to convert</param>
        ''' <returns>code128 symbol value for the character</returns>
        Public Shared Function CodeValueForChar(ByVal CharAscii As Integer) As Integer
            Return If((CharAscii >= 32), CharAscii - 32, CharAscii + 64)
        End Function

        ''' <summary>
        ''' Return the appropriate START code depending on the codeset we want to be in
        ''' </summary>
        ''' <param name="cs">The codeset you want to start in</param>
        ''' <returns>The code128 code to start a barcode in that codeset</returns>
        Public Shared Function StartCodeForCodeSet(ByVal cs As CodeSet) As Integer
            Return If(cs = CodeSet.CodeA, cSTARTA, cSTARTB)
        End Function

        ''' <summary>
        ''' Return the Code128 stop code
        ''' </summary>
        ''' <returns>the stop code</returns>
        Public Shared Function StopCode() As Integer
            Return cSTOP
        End Function

        ''' <summary>
        ''' Indicates which code sets can represent a character -- CodeA, CodeB, or either
        ''' </summary>
        Public Enum CodeSetAllowed
            CodeA
            CodeB
            CodeAorB
        End Enum

    End Class
End Namespace

