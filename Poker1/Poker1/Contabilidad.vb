Public Class Contabilidad
    Public Credits As Double = 0
    Public BetIncrement As BetIncrement1
    Public CreditsLabel As Label
    Sub New(ByVal CreditsLabel As Label)
        Me.CreditsLabel = CreditsLabel
    End Sub
    Sub PayWinnings(ByVal BetIncrement As BetIncrement1, ByVal Bet As Double, ByVal WinType As CartaJuego.GanarTipo)
        Dim Multiplier As Double = 0
        Select Case WinType
            Case CartaJuego.GanarTipo.Pareja : Multiplier = 2
            Case CartaJuego.GanarTipo.DoblePareja : Multiplier = 5
            Case CartaJuego.GanarTipo.Trio : Multiplier = 15
            Case CartaJuego.GanarTipo.Escalera : Multiplier = 20
            Case CartaJuego.GanarTipo.Color : Multiplier = 25
            Case CartaJuego.GanarTipo.FullHouse : Multiplier = 30
            Case CartaJuego.GanarTipo.Poker : Multiplier = 35
            Case CartaJuego.GanarTipo.EscaleraColor : Multiplier = 50
            Case CartaJuego.GanarTipo.EscaleraReal : Multiplier = 250
            Case CartaJuego.GanarTipo.None
        End Select
        Dim CreditsWon As Double = Bet * Multiplier
        Dim MoneyWon As Double
        Select Case BetIncrement
            Case BetIncrement1.Cien
                MoneyWon = CreditsWon * 100
            Case BetIncrement1.Cincuenta
                MoneyWon = CreditsWon * 50
            Case BetIncrement1.Veinte
                MoneyWon = CreditsWon * 20
            Case BetIncrement1.Diez
                MoneyWon = CreditsWon * 10
            Case BetIncrement1.Cinco
                MoneyWon = CreditsWon * 5
            Case BetIncrement1.Uno
                MoneyWon = CreditsWon * 1
        End Select
        Credits = Credits + MoneyWon
        CreditsLabel.Text = "€" & Credits.ToString("##0.00")
    End Sub
    Function PayMachine(ByVal Increment As BetIncrement1, ByVal Bet As Double) As Boolean
        Dim PayAmount As Double
        Select Case Increment
            Case BetIncrement1.Cien : PayAmount = Bet * 100
            Case BetIncrement1.Cincuenta : PayAmount = Bet * 50
            Case BetIncrement1.Veinte : PayAmount = Bet * 20
            Case BetIncrement1.Diez : PayAmount = Bet * 10
            Case BetIncrement1.Cinco : PayAmount = Bet * 5
            Case Contabilidad.BetIncrement1.Uno : PayAmount = Bet * 1
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
    Sub InsertMoney(ByVal Increment As BetIncrement1)
        Select Case Increment
            Case BetIncrement1.Cien
                Credits = Credits + 100
            Case BetIncrement1.Cincuenta
                Credits = Credits + 50
            Case BetIncrement1.Veinte
                Credits = Credits + 20
            Case BetIncrement1.Diez
                Credits = Credits + 10
            Case BetIncrement1.Cinco
                Credits = Credits + 5
        End Select
        CreditsLabel.Text = "€" & Credits.ToString("##0.00")
        My.Computer.Audio.Play(My.Resources.ChaChing, AudioPlayMode.Background)
    End Sub
    Enum BetIncrement1
        Inicial
        Cien
        Cincuenta
        Veinte
        Diez
        Cinco
        Uno
    End Enum
End Class
