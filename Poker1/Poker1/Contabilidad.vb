'Clase donde esta todo lo relacionado con la contabilidad, cuanto se paga si se gana segun las combinaciones ganadoras.
Public Class Contabilidad
    'Declaro las variables
    Public Creditos As Double = 0
    Public ApuestaIncremento As ApuestaIncremento1
    Public CreditosLabel As Label
    Sub New(ByVal CreditosLabel As Label)
        Me.CreditosLabel = CreditosLabel
    End Sub

    'Estas variables son fundamentales , seran los valores predeterminados de pago e incremento de dinero en la cuenta
    Enum ApuestaIncremento1
        Cien
        Cincuenta
        Veinte
        Diez
        Cinco
        Uno
    End Enum

    'Metodo para calcular el dinero ganado segun las combinaciones al final de cada ronda
    Sub PagarVictorias(ByVal ApuestaIncremento As ApuestaIncremento1, ByVal Apuesta As Double, ByVal GanarTipo As CartaJuego.GanarTipo)
        'El multiplicador de dinero segun victoria
        Dim Multiplicador As Double = 0
        Select Case GanarTipo
            Case CartaJuego.GanarTipo.Pareja : Multiplicador = 2
            Case CartaJuego.GanarTipo.DoblePareja : Multiplicador = 5
            Case CartaJuego.GanarTipo.Trio : Multiplicador = 15
            Case CartaJuego.GanarTipo.Escalera : Multiplicador = 20
            Case CartaJuego.GanarTipo.Color : Multiplicador = 25
            Case CartaJuego.GanarTipo.FullHouse : Multiplicador = 30
            Case CartaJuego.GanarTipo.Poker : Multiplicador = 35
            Case CartaJuego.GanarTipo.EscaleraColor : Multiplicador = 50
            Case CartaJuego.GanarTipo.EscaleraReal : Multiplicador = 250
            Case CartaJuego.GanarTipo.None
        End Select
        'Calculo para sacar el dinero resultante
        Dim CreditosGanados As Double = Apuesta * Multiplicador
        Dim DineroGanado As Double
        Select Case ApuestaIncremento
            Case ApuestaIncremento1.Cien
                DineroGanado = CreditosGanados * 100
            Case ApuestaIncremento1.Cincuenta
                DineroGanado = CreditosGanados * 50
            Case ApuestaIncremento1.Veinte
                DineroGanado = CreditosGanados * 20
            Case ApuestaIncremento1.Diez
                DineroGanado = CreditosGanados * 10
            Case ApuestaIncremento1.Cinco
                DineroGanado = CreditosGanados * 5
            Case ApuestaIncremento1.Uno
                DineroGanado = CreditosGanados * 1
        End Select
        'Saco en pantalla el dinero resultante de lo ganado mas lo que tenias
        Creditos = Creditos + DineroGanado
        CreditosLabel.Text = "€" & Creditos.ToString("##0.00")
    End Sub

    'El dinero que se le quitara a la cuenta segun lo que apostemos
    Function PagarMaquina(ByVal Incremento As ApuestaIncremento1, ByVal Apuesta As Double) As Boolean
        Dim PagarCantidad As Double
        Select Case Incremento
            Case ApuestaIncremento1.Cien : PagarCantidad = Apuesta * 100
            Case ApuestaIncremento1.Cincuenta : PagarCantidad = Apuesta * 50
            Case ApuestaIncremento1.Veinte : PagarCantidad = Apuesta * 20
            Case ApuestaIncremento1.Diez : PagarCantidad = Apuesta * 10
            Case ApuestaIncremento1.Cinco : PagarCantidad = Apuesta * 5
            Case Contabilidad.ApuestaIncremento1.Uno : PagarCantidad = Apuesta * 1
            Case Else
                Return False
        End Select
        'Saco en pantalla el dinero resultante de lo que tienes menos la apuesta
        Select Case (Creditos - PagarCantidad) >= 0
            Case True
                Creditos = Creditos - PagarCantidad
                CreditosLabel.Text = "€" & Creditos.ToString("##0.00")
                Return True
            Case False
                Return False
        End Select
        Return False
    End Function

    'Metodo para insertar dinero en la cuenta
    Sub InsertarDinero(ByVal Incremento As ApuestaIncremento1)
        Select Case Incremento
            Case ApuestaIncremento1.Cien
                Creditos = Creditos + 100
            Case ApuestaIncremento1.Cincuenta
                Creditos = Creditos + 50
            Case ApuestaIncremento1.Veinte
                Creditos = Creditos + 20
            Case ApuestaIncremento1.Diez
                Creditos = Creditos + 10
            Case ApuestaIncremento1.Cinco
                Creditos = Creditos + 5
        End Select
        CreditosLabel.Text = "€" & Creditos.ToString("##0.00")
        My.Computer.Audio.Play(My.Resources.ChaChing, AudioPlayMode.Background)
    End Sub
End Class
