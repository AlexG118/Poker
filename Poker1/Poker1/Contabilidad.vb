Public Class Contabilidad
    Public Credits As Double = 0
        Public BetIncrement As BetIncrememt
        Public CreditsLabel As Label
        Sub New(ByVal CreditsLabel As Label)
            Me.CreditsLabel = CreditsLabel
        End Sub
    Sub PayWinnings(ByVal BetIncrement As BetIncrememt, ByVal Bet As Double, ByVal WinType As CartaJuego.GanarTipo)
        Dim Multiplier As Double = 0
        Select Case WinType
            Case CartaJuego.GanarTipo.Pareja : Multiplier = 5
            Case CartaJuego.GanarTipo.DoblePareja : Multiplier = 10
            Case CartaJuego.GanarTipo.Trio : Multiplier = 15
            Case CartaJuego.GanarTipo.Escalera : Multiplier = 20
            Case CartaJuego.GanarTipo.Color : Multiplier = 25
            Case CartaJuego.GanarTipo.FullHouse : Multiplier = 30
            Case CartaJuego.GanarTipo.Poker : Multiplier = 35
            Case CartaJuego.GanarTipo.EscaleraColor : Multiplier = 50
            Case CartaJuego.GanarTipo.EscaleraReal
                Select Case Bet
                    Case 5
                        Multiplier = 800
                    Case Else
                        Multiplier = 250
                End Select
            Case CartaJuego.GanarTipo.None
        End Select
        Dim CreditsWon As Double = Bet * Multiplier
        Dim MoneyWon As Double
        Select Case BetIncrement
            Case BetIncrememt.Hundred
                MoneyWon = CreditsWon * 100
            Case BetIncrememt.Fifty
                MoneyWon = CreditsWon * 50
            Case BetIncrememt.Twenty
                MoneyWon = CreditsWon * 20
            Case BetIncrememt.Ten
                MoneyWon = CreditsWon * 10
            Case BetIncrememt.Five
                MoneyWon = CreditsWon * 5
            Case BetIncrememt.Two
                MoneyWon = CreditsWon * 2
            Case BetIncrememt.One
                MoneyWon = CreditsWon * 1
        End Select
        Credits = Credits + MoneyWon
        CreditsLabel.Text = "€" & Credits.ToString("##0.00")
    End Sub
        Function PayMachine(ByVal Increment As BetIncrememt, ByVal Bet As Double) As Boolean
            Dim PayAmount As Double
            Select Case Increment
                Case BetIncrememt.Hundred : PayAmount = Bet * 100
                Case BetIncrememt.Fifty : PayAmount = Bet * 50
                Case BetIncrememt.Twenty : PayAmount = Bet * 20
                Case BetIncrememt.Ten : PayAmount = Bet * 10
                Case BetIncrememt.Five : PayAmount = Bet * 5
                Case BetIncrememt.Two : PayAmount = Bet * 2
                Case BetIncrememt.One : PayAmount = Bet * 1
                Case Else
                    Return False
            End Select
            Select Case (Credits - PayAmount) >= 0
                Case True
                    Credits = Credits - PayAmount
                CreditsLabel.Text = "€" & Credits.ToString("##0.00")
                    Return True
                Case False
                    Return False
            End Select
            Return False
        End Function
        Sub InsertMoney(ByVal Increment As BetIncrememt)
            Select Case Increment
                Case BetIncrememt.Hundred
                    Credits = Credits + 100
                Case BetIncrememt.Fifty
                    Credits = Credits + 50
                Case BetIncrememt.Twenty
                    Credits = Credits + 20
                Case BetIncrememt.Ten
                    Credits = Credits + 10
                Case BetIncrememt.Five
                    Credits = Credits + 5
                Case BetIncrememt.Two
                    Credits = Credits + 2
                Case BetIncrememt.One
                    Credits = Credits + 1
            End Select
        CreditsLabel.Text = "€" & Credits.ToString("##0.00")
        My.Computer.Audio.Play(My.Resources.ChaChing, AudioPlayMode.Background)
        End Sub
        Enum BetIncrememt
            Hundred
            Fifty
            Twenty
            Ten
            Five
            Two
            One
        End Enum
    End Class
