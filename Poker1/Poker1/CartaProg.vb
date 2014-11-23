Public Class CartaProg
    Public Suit As CartaSuit
    Public RawValue As CartaValue
    Enum CartaSuit
        Treboles = 1
        Diamantes = 2
        Corazones = 3
        Picas = 4
    End Enum
    Enum CartaValue
        As1 = 1
        Dos = 2
        Tres = 3
        Cuatro = 4
        Cinco = 5
        Seis = 6
        Siete = 7
        Ocho = 8
        Nueve = 9
        Diez = 10
        Sota = 11
        Reina = 12
        Rey = 13
    End Enum
    Sub New(ByVal CartaValue As CartaValue, ByVal Suit As CartaSuit)
        Me.Suit = Suit
        Select Case CartaValue
            Case 1
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 1
                    Case CartaSuit.Diamantes : Me.RawValue = 14
                    Case CartaSuit.Corazones : Me.RawValue = 27
                    Case CartaSuit.Picas : Me.RawValue = 40
                End Select
            Case (2)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 2
                    Case CartaSuit.Diamantes : Me.RawValue = 15
                    Case CartaSuit.Corazones : Me.RawValue = 28
                    Case CartaSuit.Picas : Me.RawValue = 41
                End Select
            Case (3)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 3
                    Case CartaSuit.Diamantes : Me.RawValue = 16
                    Case CartaSuit.Corazones : Me.RawValue = 29
                    Case CartaSuit.Picas : Me.RawValue = 42
                End Select
            Case (4)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 4
                    Case CartaSuit.Diamantes : Me.RawValue = 17
                    Case CartaSuit.Corazones : Me.RawValue = 30
                    Case CartaSuit.Picas : Me.RawValue = 43
                End Select
            Case (5)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 5
                    Case CartaSuit.Diamantes : Me.RawValue = 18
                    Case CartaSuit.Corazones : Me.RawValue = 31
                    Case CartaSuit.Picas : Me.RawValue = 44
                End Select
            Case (6)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 6
                    Case CartaSuit.Diamantes : Me.RawValue = 19
                    Case CartaSuit.Corazones : Me.RawValue = 32
                    Case CartaSuit.Picas : Me.RawValue = 45
                End Select
            Case (7)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 7
                    Case CartaSuit.Diamantes : Me.RawValue = 20
                    Case CartaSuit.Corazones : Me.RawValue = 33
                    Case CartaSuit.Picas : Me.RawValue = 46
                End Select
            Case (8)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 8
                    Case CartaSuit.Diamantes : Me.RawValue = 21
                    Case CartaSuit.Corazones : Me.RawValue = 34
                    Case CartaSuit.Picas : Me.RawValue = 47
                End Select
            Case (9)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 9
                    Case CartaSuit.Diamantes : Me.RawValue = 22
                    Case CartaSuit.Corazones : Me.RawValue = 35
                    Case CartaSuit.Picas : Me.RawValue = 48
                End Select
            Case (10)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 10
                    Case CartaSuit.Diamantes : Me.RawValue = 23
                    Case CartaSuit.Corazones : Me.RawValue = 36
                    Case CartaSuit.Picas : Me.RawValue = 49
                End Select
            Case (11)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 11
                    Case CartaSuit.Diamantes : Me.RawValue = 24
                    Case CartaSuit.Corazones : Me.RawValue = 37
                    Case CartaSuit.Picas : Me.RawValue = 50
                End Select
            Case (12)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 12
                    Case CartaSuit.Diamantes : Me.RawValue = 25
                    Case CartaSuit.Corazones : Me.RawValue = 38
                    Case CartaSuit.Picas : Me.RawValue = 51
                End Select
            Case (13)
                Select Case Me.Suit
                    Case CartaSuit.Treboles : Me.RawValue = 13
                    Case CartaSuit.Diamantes : Me.RawValue = 26
                    Case CartaSuit.Corazones : Me.RawValue = 39
                    Case CartaSuit.Picas : Me.RawValue = 52
                End Select
        End Select
    End Sub
End Class
