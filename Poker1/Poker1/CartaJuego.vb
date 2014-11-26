Option Strict On
'Clase para definir las rondas y los tipos de ganado
Public Class CartaJuego
    'Establece la ronda actual entre 1 o 2
    Public RondaActual As Integer = 1
    'Establece una lista de las cartas
    Public CartasBaraja As New List(Of Carta)
    'Establece una lista de las cartas del la primera ronda
    Public Ronda1Cartas As New List(Of Carta)
    'Establece una lista de las cartas del la segunda ronda
    Public Ronda2Cartas As New List(Of Carta)
    'Establece una lista de las cartas activas
    Public CartasActivas As New List(Of Carta)
    'Establece la velocidad del juego como integer a 200
    Public VelocidadJuego As Integer = 200
    'Boolean para saber si el juego sigue en proceso
    Public JuegoEnProceso As Boolean = False

    'Al crear uno nuevo objeto CartaJuego tendra de rondaactual 1
    Sub New(ByVal CartaSet As CartasBaraja)
        RondaActual = 1
    End Sub

    'Metodo para cuando se pase a la siguiente accion/ronda
    Sub NextAccion(ByVal CartaSet As CartasBaraja, ByVal RoundLabel As Label, ByVal Button As Button)
        'El boton se hara invisible y tendra la imagen de Draw
        Button.Visible = False
        Button.BackgroundImage = My.Resources.Draw
        'Segun la Ronda Actual
        Select Case RondaActual
            Case 1
                'Si la ronda actual es 1 (la primera) el juego seguira en proceso, el label se vacia, inicia la ronda con el set de cartas
                ', en el label aparecera el mensaje correspondiente y por ultimo la ronda actual sera 2.
                Me.JuegoEnProceso = True
                RoundLabel.Text = ""
                Iniciar(CartaSet)
                RoundLabel.Text = "Haz Click sobre una carta para mantenerla/quitarla"
                RondaActual = 2
                'Si el metodo PuntuacionJuego dice que hay alguna combinacion , sacara un sonido de "pista" para avisarnos de que hay una combinacion.
                Select Case PuntuacionJuego()
                    Case GanarTipo.None
                    Case Else
                        My.Computer.Audio.Play(My.Resources.hint, AudioPlayMode.Background)
                End Select
                'Por cada carta el cursor sera Hand.
                For Each C As Tablero In Tableros
                    C.Cursor = Cursors.Hand
                Next
                'El boton se hara visible
                Button.Visible = True
            Case 2
                'Si la ronda actual es 2 (la segunda) el juego seguira en proceso,el label se vacia,
                Me.JuegoEnProceso = False
                RoundLabel.Text = ""
                Dim NextCuenta As Integer = 0
                'Si el metodo PuntuacionJuego dice que hay alguna combinacion , sacara un sonido de "pista" para avisarnos de que hay una combinacion.
                Select Case PuntuacionJuego()
                    Case GanarTipo.None
                    Case Else
                        My.Computer.Audio.Play(My.Resources.hint, AudioPlayMode.Background)
                End Select
                'Por cada carta , si no esta mantenida su imagen sera nada
                For Each C As Tablero In Tableros
                    If C.Mantenida = False Then
                        C.Image = Nothing
                    End If
                Next
                'Por cada carta
                For Each C As Tablero In Tableros
                    'Establece el cursor como Hand al pasar sobre ellas.
                    C.Cursor = Cursors.Arrow

                    If C.Mantenida = True Then
                    Else
                        'Cambiara las cartas que habia sin mantener
                        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
                        'Hace una pequeña pausa entre cada desvelado de cada carta
                        Wait(VelocidadJuego)
                        'Guarda las imagenes y su valor en la lista Ronda2Cartas y el numero de carta gracias a la variable NextCuenta
                        'que se ira autoincrementando en este for
                        C.Image = Ronda2Cartas(NextCuenta).Image
                        C.Carta = Ronda2Cartas(NextCuenta)
                        CartasActivas(NextCuenta) = Ronda2Cartas(NextCuenta)
                        NextCuenta = NextCuenta + 1
                    End If
                Next
                'Segun que valor nos devuelva PuntuacionJuego, sacara un mensaje con su respectivo tipo de victoria
                Dim VictoriaActual As GanarTipo = PuntuacionJuego()
                Select Case VictoriaActual
                    Case GanarTipo.Pareja
                        RoundLabel.Text = "¡Pareja!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.DoblePareja
                        RoundLabel.Text = "¡Doble Pareja!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.Trio
                        RoundLabel.Text = "¡Trío!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.Escalera
                        RoundLabel.Text = "¡Escalera!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.Color
                        RoundLabel.Text = "¡Color!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.FullHouse
                        RoundLabel.Text = "¡Full House!"
                        My.Computer.Audio.Play(My.Resources.bling, AudioPlayMode.Background)
                    Case GanarTipo.Poker
                        RoundLabel.Text = "¡Poker!"
                        My.Computer.Audio.Play(My.Resources.bigwin2, AudioPlayMode.Background)
                    Case GanarTipo.EscaleraColor
                        RoundLabel.Text = "¡Escalera de color!"
                        My.Computer.Audio.Play(My.Resources.bigwin2, AudioPlayMode.Background)
                    Case GanarTipo.EscaleraReal
                        RoundLabel.Text = "¡Escalera Real!"
                        My.Computer.Audio.Play(My.Resources.bigwin2, AudioPlayMode.Background)
                    Case Else
                        My.Computer.Audio.Play(My.Resources.lose, AudioPlayMode.Background)
                        RoundLabel.Text = ""
                End Select

                'Por cada carta , establece que el juego no esta en proceso, la posicion en Top,
                'no esta mantenida, y actualiza el string de mantenida a nada.
                For Each T As Tablero In Tableros
                    T.JuegoEnProceso = False
                    T.Top = T.EstandarTop
                    T.Mantenida = False
                    T.ActualizarString()
                Next

                'El boton es visible ahora , con la imagen Deal , de ronda 1 y espera 600 miliseg
                Button.Visible = True
                Button.BackgroundImage = My.Resources.Deal
                RondaActual = 1
                Wait(600)
                'Si el label esta vacio , poner Game Over , si no , coger lo que hay en el label y en una linea abajo poner Game Over
                Select Case RoundLabel.Text = ""
                    Case True
                        RoundLabel.Text = "¡Game Over!"
                    Case Else
                        RoundLabel.Text = RoundLabel.Text & vbCrLf & "¡Game Over!"
                End Select
                'Pagar a la cuenta los creditos correspondientes.
                MiBanco.PagarVictorias(IncrementoActual, CantidadApostada, VictoriaActual)
        End Select
    End Sub

    'Metodo para saber los diferentes tipos de victorias
    Function PuntuacionJuego() As GanarTipo
        'Las distintas variables para contar las cartas y las victorias
        Dim TrebolCuenta As Integer = 0 : Dim DiamantesCuenta As Integer = 0 : Dim CorazonesCuenta As Integer = 0
        Dim PicasCuenta As Integer = 0 : Dim UnoCuenta As Integer = 0 : Dim DosCuenta As Integer = 0
        Dim TresCuenta As Integer = 0 : Dim CuatroCuenta As Integer = 0 : Dim FiveCuenta As Integer = 0
        Dim SeisCuenta As Integer = 0 : Dim SieteCuenta As Integer = 0 : Dim OchoCuenta As Integer = 0
        Dim NueveCuenta As Integer = 0 : Dim DiezCuenta As Integer = 0 : Dim SotaCuenta As Integer = 0
        Dim ReinaCuenta As Integer = 0 : Dim ReyCuenta As Integer = 0
        Dim ParejaCuenta As Integer = 0
        Dim GanarParejaCuenta As Integer = 0
        Dim TrioCuenta As Integer = 0
        Dim PokerCuenta As Integer = 0
        Dim FullHouseCuenta As Integer = 0
        Dim Royal As Boolean = False
        Dim EscaleraCuenta As Integer = 0
        Dim ColorCuenta As Integer = 0
        Dim EscaleraRealCuenta As Integer = 0
        'Recorre todas las cartas y ira contando sus valores y almacenandolo en su respectiva variable
        For Each TC As Tablero In Tableros
            'Aqui contara los palos de las cartas
            Select Case TC.Carta.Suit
                Case Carta.CartaSuit.Treboles : TrebolCuenta = TrebolCuenta + 1
                Case Carta.CartaSuit.Diamantes : DiamantesCuenta = DiamantesCuenta + 1
                Case Carta.CartaSuit.Corazones : CorazonesCuenta = CorazonesCuenta + 1
                Case Carta.CartaSuit.Picas : PicasCuenta = PicasCuenta + 1
            End Select
            'Aqui contara los valores de las cartas
            Select Case TC.Carta.Value
                Case 1 : UnoCuenta = UnoCuenta + 1
                Case 2 : DosCuenta = DosCuenta + 1
                Case 3 : TresCuenta = TresCuenta + 1
                Case 4 : CuatroCuenta = CuatroCuenta + 1
                Case 5 : FiveCuenta = FiveCuenta + 1
                Case 6 : SeisCuenta = SeisCuenta + 1
                Case 7 : SieteCuenta = SieteCuenta + 1
                Case 8 : OchoCuenta = OchoCuenta + 1
                Case 9 : NueveCuenta = NueveCuenta + 1
                Case 10 : DiezCuenta = DiezCuenta + 1
                Case 11 : SotaCuenta = SotaCuenta + 1
                Case 12 : ReinaCuenta = ReinaCuenta + 1
                Case 13 : ReyCuenta = ReyCuenta + 1
            End Select
        Next
        'Todos los Ifs con todas las combinaciones posibles
        If TrebolCuenta = 5 Then ColorCuenta = 1
        If DiamantesCuenta = 5 Then ColorCuenta = 1
        If CorazonesCuenta = 5 Then ColorCuenta = 1
        If PicasCuenta = 5 Then ColorCuenta = 1

        If UnoCuenta = 4 Then PokerCuenta = 1
        If UnoCuenta = 3 Then TrioCuenta = 1
        If UnoCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If DosCuenta = 4 Then PokerCuenta = 1
        If DosCuenta = 3 Then TrioCuenta = 1
        If DosCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If TresCuenta = 4 Then PokerCuenta = 1
        If TresCuenta = 3 Then TrioCuenta = 1
        If TresCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If CuatroCuenta = 4 Then PokerCuenta = 1
        If CuatroCuenta = 3 Then TrioCuenta = 1
        If CuatroCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If FiveCuenta = 4 Then PokerCuenta = 1
        If FiveCuenta = 3 Then TrioCuenta = 1
        If FiveCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If SeisCuenta = 4 Then PokerCuenta = 1
        If SeisCuenta = 3 Then TrioCuenta = 1
        If SeisCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If SieteCuenta = 4 Then PokerCuenta = 1
        If SieteCuenta = 3 Then TrioCuenta = 1
        If SieteCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If OchoCuenta = 4 Then PokerCuenta = 1
        If OchoCuenta = 3 Then TrioCuenta = 1
        If OchoCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If NueveCuenta = 4 Then PokerCuenta = 1
        If NueveCuenta = 3 Then TrioCuenta = 1
        If NueveCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If DiezCuenta = 4 Then PokerCuenta = 1
        If DiezCuenta = 3 Then TrioCuenta = 1
        If DiezCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If SotaCuenta = 4 Then PokerCuenta = 1
        If SotaCuenta = 3 Then TrioCuenta = 1
        If SotaCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If ReinaCuenta = 4 Then PokerCuenta = 1
        If ReinaCuenta = 3 Then TrioCuenta = 1
        If ReinaCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If ReyCuenta = 4 Then PokerCuenta = 1
        If ReyCuenta = 3 Then TrioCuenta = 1
        If ReyCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : GanarParejaCuenta = 1

        If UnoCuenta = 1 AndAlso DosCuenta = 1 AndAlso TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 Then EscaleraCuenta = 1
        If DosCuenta = 1 AndAlso TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 Then EscaleraCuenta = 1
        If TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 Then EscaleraCuenta = 1
        If CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 Then EscaleraCuenta = 1
        If FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 Then EscaleraCuenta = 1
        If SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 Then EscaleraCuenta = 1
        If SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 Then EscaleraCuenta = 1
        If OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 Then EscaleraCuenta = 1
        If NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 AndAlso ReyCuenta = 1 Then EscaleraCuenta = 1
        If DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 AndAlso ReyCuenta = 1 AndAlso UnoCuenta = 1 Then EscaleraCuenta = 1 : Royal = True

        If Royal = True AndAlso EscaleraCuenta = 1 AndAlso ColorCuenta = 1 Then
            Return GanarTipo.EscaleraReal
        End If
        If EscaleraCuenta = 1 AndAlso ColorCuenta = 1 Then
            Return GanarTipo.EscaleraColor
        End If
        If EscaleraCuenta = 1 Then
            Return GanarTipo.Escalera
        End If
        If ColorCuenta = 1 Then
            Return GanarTipo.Color
        End If
        If ParejaCuenta = 2 Then Return GanarTipo.DoblePareja
        If ParejaCuenta = 1 And TrioCuenta = 1 Then Return GanarTipo.FullHouse
        If TrioCuenta = 1 Then Return GanarTipo.Trio
        If PokerCuenta = 1 Then Return GanarTipo.Poker
        If GanarParejaCuenta = 1 Then Return GanarTipo.Pareja
        Return GanarTipo.None
    End Function

    'Metodo para Iniciar la primera Ronda,
    Private Sub Iniciar(ByVal CartaSet As CartasBaraja)
        My.Computer.Audio.Play(My.Resources.shuffle, AudioPlayMode.Background)
        Wait(400)
        'Genera las cartas y las guarda en CartasBarajas
        CartasBaraja = Generarcartas(CartaSet)
        'Limpia las cartas de las dos rondas anteriores y tambien las cartas activas
        Ronda1Cartas.Clear()
        Ronda2Cartas.Clear()
        CartasActivas.Clear()
        'Va añadiendo las cartas a las dos rondas
        Ronda1Cartas.Add(CartasBaraja(0))
        Ronda1Cartas.Add(CartasBaraja(1))
        Ronda1Cartas.Add(CartasBaraja(2))
        Ronda1Cartas.Add(CartasBaraja(3))
        Ronda1Cartas.Add(CartasBaraja(4))
        Ronda2Cartas.Add(CartasBaraja(5))
        Ronda2Cartas.Add(CartasBaraja(6))
        Ronda2Cartas.Add(CartasBaraja(7))
        Ronda2Cartas.Add(CartasBaraja(8))
        Ronda2Cartas.Add(CartasBaraja(9))
        'Por cada carta borra su imagen , les pone la imagen de fondo, pone el juego en proceso
        'Pone la posicion top en la estandar , hace que si esta mantenida lo ponga en false y espera 50 segundos.
        For Each Carta As Tablero In Tableros
            Carta.Image = Nothing
            Carta.BackgroundImage = CartaSet.BarajaCartas
            Carta.JuegoEnProceso = True
            Carta.Top = Carta.EstandarTop
            Carta.Mantenida = False
            Wait(50)
        Next
        'Se establecen las cartas activas con la lista de cartas que hemos hecho antes Ronda1Cartas
        CartasActivas.Add(Ronda1Cartas(0))
        CartasActivas.Add(Ronda1Cartas(1))
        CartasActivas.Add(Ronda1Cartas(2))
        CartasActivas.Add(Ronda1Cartas(3))
        CartasActivas.Add(Ronda1Cartas(4))
        'Ya establecidas se iran poniendo los valores y sus imagenes en el programa
        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
        Tableros(0).Carta = Ronda1Cartas(0)
        Tableros(0).Image = Ronda1Cartas(0).Image
        Wait(VelocidadJuego)
        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
        Tableros(1).Carta = Ronda1Cartas(1)
        Tableros(1).Image = Ronda1Cartas(1).Image
        Wait(VelocidadJuego)
        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
        Tableros(2).Carta = Ronda1Cartas(2)
        Tableros(2).Image = Ronda1Cartas(2).Image
        Wait(VelocidadJuego)
        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
        Tableros(3).Carta = Ronda1Cartas(3)
        Tableros(3).Image = Ronda1Cartas(3).Image
        Wait(VelocidadJuego)
        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
        Tableros(4).Carta = Ronda1Cartas(4)
        Tableros(4).Image = Ronda1Cartas(4).Image
    End Sub

    'Metodo para generar las cartas con Randomize, para que no sean iguales nunca
    Function Generarcartas(ByVal CartaSet As CartasBaraja) As List(Of Carta)

        Dim RandomCartaValores As New List(Of Integer)
        Dim NuevaBaraja As New List(Of Carta)
        Randomize()
        Dim RandomCarta As New Random
        Do
            Dim Candidate As Integer = RandomCarta.Next(1, 53)
            If RandomCartaValores.IndexOf(Candidate) = -1 Then
                RandomCartaValores.Add(Candidate)
            End If
        Loop Until RandomCartaValores.Count = 52
        For Each Carta As Integer In RandomCartaValores
            NuevaBaraja.Add(New Carta(Carta, SelecBaraja))
        Next
        Return NuevaBaraja
    End Function

    'Metodo para actualizar las cartas que estan activas , lo que hara es cambiar las imagenes de las cartas por las de la baraja que eligamos.
    Sub ActualizarTableros(ByVal CartaSet As CartasBaraja)
        For Each Carta As Carta In CartasBaraja
            Carta.UpdateCarta(CartaSet)
        Next

        For Each Carta As Carta In CartasActivas
            Carta.UpdateCarta(CartaSet)
        Next

        Tableros(0).Image = CartasActivas(0).Image
        Tableros(1).Image = CartasActivas(1).Image
        Tableros(2).Image = CartasActivas(2).Image
        Tableros(3).Image = CartasActivas(3).Image
        Tableros(4).Image = CartasActivas(4).Image

        For Each Tablero As Tablero In Tableros
            Tablero.ActualizarString()
        Next
    End Sub

    'Todos los tipos de victorias
    Enum GanarTipo
        Pareja
        DoblePareja
        Trio
        Escalera
        Color
        FullHouse
        Poker
        EscaleraColor
        EscaleraReal
        None
    End Enum

End Class
