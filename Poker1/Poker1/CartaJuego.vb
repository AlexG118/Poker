Option Strict On
Public Class CartaJuego

    Public RondaActual As Integer = 1
    Public CartasBaraja As New List(Of Carta)
    Public NextIndex As Integer = 5
    Public Ronda1Cartas As New List(Of Carta)
    Public Ronda2Cartas As New List(Of Carta)
    Public CartasActivas As New List(Of Carta)
    Public VelocidadJuego As Integer = 200
    Public PerformTest As Boolean = False
    Public ModoTest As GanarTipo = GanarTipo.EscaleraReal
    Public JuegoEnProceso As Boolean = False
    Sub New(ByVal CartaSet As CartasBaraja)
        RondaActual = 1
    End Sub
    Sub NextAction(ByVal CartaSet As CartasBaraja, ByVal RoundLabel As Label, ByVal SendingButton As Button)
        SendingButton.Visible = False
        SendingButton.BackgroundImage = My.Resources.Draw
        Select Case RondaActual
            Case 1
                Me.JuegoEnProceso = True
                RoundLabel.Text = ""
                FreshGame(CartaSet)
                RoundLabel.Text = "Haz Click sobra una carat para mantenerla/quitarla"
                RondaActual = 2
                Select Case ScoreGame()
                    Case GanarTipo.None
                    Case Else
                        My.Computer.Audio.Play(My.Resources.hint, AudioPlayMode.Background)
                End Select
                For Each C As Tablero In Tableros
                    C.Cursor = Cursors.Hand
                Next
                SendingButton.Visible = True
            Case 2
                Me.JuegoEnProceso = False
                RoundLabel.Text = ""
                Dim NextCuentaer As Integer = 0
                Select Case ScoreGame()
                    Case GanarTipo.None
                    Case Else
                        My.Computer.Audio.Play(My.Resources.hint, AudioPlayMode.Background)
                End Select
                For Each C As Tablero In Tableros
                    If C.Held = False Then
                        C.Image = Nothing
                    End If
                Next
                For Each C As Tablero In Tableros
                    C.Cursor = Cursors.Arrow
                    If C.Held = True Then
                    Else
                        My.Computer.Audio.Play(My.Resources.DealCard, AudioPlayMode.Background)
                        Wait(VelocidadJuego)
                        C.Image = Ronda2Cartas(NextCuentaer).Image
                        C.Carta = Ronda2Cartas(NextCuentaer)
                        CartasActivas(NextCuentaer) = Ronda2Cartas(NextCuentaer)
                        NextCuentaer = NextCuentaer + 1
                    End If
                Next
                Dim CurrentWin As GanarTipo = ScoreGame()
                Select Case CurrentWin
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
                For Each T As Tablero In Tableros
                    T.JuegoEnProceso = False
                    T.Top = T.StandardTop
                    T.Held = False
                    T.UpdateString()
                Next
                SendingButton.Visible = True
                SendingButton.BackgroundImage = My.Resources.Deal
                RondaActual = 1
                Wait(600)
                Select Case RoundLabel.Text = ""
                    Case True
                        RoundLabel.Text = "¡Game Over!"
                    Case Else
                        RoundLabel.Text = RoundLabel.Text & vbCrLf & "¡Game Over!"
                End Select
                MyBank.PayWinnings(CurrentIncrement, BetCreditQuantity, CurrentWin)
        End Select
    End Sub
    Function ScoreGame() As GanarTipo
        Dim TrebolCuenta As Integer = 0 : Dim DiamantesCuenta As Integer = 0 : Dim CorazonesCuenta As Integer = 0
        Dim PicasCuenta As Integer = 0 : Dim UnoCuenta As Integer = 0 : Dim DosCuenta As Integer = 0
        Dim TresCuenta As Integer = 0 : Dim CuatroCuenta As Integer = 0 : Dim FiveCuenta As Integer = 0
        Dim SeisCuenta As Integer = 0 : Dim SieteCuenta As Integer = 0 : Dim OchoCuenta As Integer = 0
        Dim NueveCuenta As Integer = 0 : Dim DiezCuenta As Integer = 0 : Dim SotaCuenta As Integer = 0
        Dim ReinaCuenta As Integer = 0 : Dim ReyCuenta As Integer = 0
        Dim ParejaCuenta As Integer = 0
        Dim WinningParejaCuenta As Integer = 0
        Dim TrioCuenta As Integer = 0
        Dim PokerCuenta As Integer = 0
        Dim FullHouseCuenta As Integer = 0
        Dim CanBeRoyal As Boolean = False
        Dim EscaleraCuenta As Integer = 0
        Dim ColorCuenta As Integer = 0
        Dim EscaleraRealCuenta As Integer = 0
        For Each TC As Tablero In Tableros
            Select Case TC.Carta.Suit
                Case Carta.CartaSuit.Treboles : TrebolCuenta = TrebolCuenta + 1
                Case Carta.CartaSuit.Diamantes : DiamantesCuenta = DiamantesCuenta + 1
                Case Carta.CartaSuit.Corazones : CorazonesCuenta = CorazonesCuenta + 1
                Case Carta.CartaSuit.Picas : PicasCuenta = PicasCuenta + 1
            End Select
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
        If TrebolCuenta = 5 Then ColorCuenta = 1
        If DiamantesCuenta = 5 Then ColorCuenta = 1
        If CorazonesCuenta = 5 Then ColorCuenta = 1
        If PicasCuenta = 5 Then ColorCuenta = 1

        If UnoCuenta = 4 Then PokerCuenta = 1
        If UnoCuenta = 3 Then TrioCuenta = 1
        If UnoCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If DosCuenta = 4 Then PokerCuenta = 1
        If DosCuenta = 3 Then TrioCuenta = 1
        If DosCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If TresCuenta = 4 Then PokerCuenta = 1
        If TresCuenta = 3 Then TrioCuenta = 1
        If TresCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If CuatroCuenta = 4 Then PokerCuenta = 1
        If CuatroCuenta = 3 Then TrioCuenta = 1
        If CuatroCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If FiveCuenta = 4 Then PokerCuenta = 1
        If FiveCuenta = 3 Then TrioCuenta = 1
        If FiveCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If SeisCuenta = 4 Then PokerCuenta = 1
        If SeisCuenta = 3 Then TrioCuenta = 1
        If SeisCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If SieteCuenta = 4 Then PokerCuenta = 1
        If SieteCuenta = 3 Then TrioCuenta = 1
        If SieteCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If OchoCuenta = 4 Then PokerCuenta = 1
        If OchoCuenta = 3 Then TrioCuenta = 1
        If OchoCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If NueveCuenta = 4 Then PokerCuenta = 1
        If NueveCuenta = 3 Then TrioCuenta = 1
        If NueveCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If DiezCuenta = 4 Then PokerCuenta = 1
        If DiezCuenta = 3 Then TrioCuenta = 1
        If DiezCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If SotaCuenta = 4 Then PokerCuenta = 1
        If SotaCuenta = 3 Then TrioCuenta = 1
        If SotaCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If ReinaCuenta = 4 Then PokerCuenta = 1
        If ReinaCuenta = 3 Then TrioCuenta = 1
        If ReinaCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If ReyCuenta = 4 Then PokerCuenta = 1
        If ReyCuenta = 3 Then TrioCuenta = 1
        If ReyCuenta = 2 Then ParejaCuenta = ParejaCuenta + 1 : WinningParejaCuenta = 1

        If UnoCuenta = 1 AndAlso DosCuenta = 1 AndAlso TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 Then EscaleraCuenta = 1
        If DosCuenta = 1 AndAlso TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 Then EscaleraCuenta = 1
        If TresCuenta = 1 AndAlso CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 Then EscaleraCuenta = 1
        If CuatroCuenta = 1 AndAlso FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 Then EscaleraCuenta = 1
        If FiveCuenta = 1 AndAlso SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 Then EscaleraCuenta = 1
        If SeisCuenta = 1 AndAlso SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 Then EscaleraCuenta = 1
        If SieteCuenta = 1 AndAlso OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 Then EscaleraCuenta = 1
        If OchoCuenta = 1 AndAlso NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 Then EscaleraCuenta = 1
        If NueveCuenta = 1 AndAlso DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 AndAlso ReyCuenta = 1 Then EscaleraCuenta = 1
        If DiezCuenta = 1 AndAlso SotaCuenta = 1 AndAlso ReinaCuenta = 1 AndAlso ReyCuenta = 1 AndAlso UnoCuenta = 1 Then EscaleraCuenta = 1 : CanBeRoyal = True

        If CanBeRoyal = True AndAlso EscaleraCuenta = 1 AndAlso ColorCuenta = 1 Then
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
        If WinningParejaCuenta = 1 Then Return GanarTipo.Pareja
        Return GanarTipo.None
    End Function
    Private Sub FreshGame(ByVal CartaSet As CartasBaraja)
        My.Computer.Audio.Play(My.Resources.shuffle, AudioPlayMode.Background)
        Wait(400)
        CartasBaraja = ShuffleCartas(CartaSet)
        Ronda1Cartas.Clear()
        Ronda2Cartas.Clear()
        CartasActivas.Clear()
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
        For Each Carta As Tablero In Tableros
            Carta.Image = Nothing
            Carta.BackgroundImage = CartaSet.DeckCard
            Carta.JuegoEnProceso = True
            Carta.Top = Carta.StandardTop
            Carta.Held = False
            Wait(50)
        Next
        CartasActivas.Add(Ronda1Cartas(0))
        CartasActivas.Add(Ronda1Cartas(1))
        CartasActivas.Add(Ronda1Cartas(2))
        CartasActivas.Add(Ronda1Cartas(3))
        CartasActivas.Add(Ronda1Cartas(4))

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
    Function ShuffleCartas(ByVal CartaSet As CartasBaraja) As List(Of Carta)

        Dim RandomCartaValues As New List(Of Integer)
        Dim NewDeck As New List(Of Carta)
        Select Case PerformTest
            Case True
                For Each PPC As CartaProg In GetPreProgrammedDeck()
                    NewDeck.Add(New Carta(PPC.RawValue, CartaSet))
                Next
            Case False
                Randomize()
                Dim RandomCarta As New Random
                Do
                    Dim Candidate As Integer = RandomCarta.Next(1, 53)
                    If RandomCartaValues.IndexOf(Candidate) = -1 Then
                        RandomCartaValues.Add(Candidate)
                    End If
                Loop Until RandomCartaValues.Count = 52
                For Each Carta As Integer In RandomCartaValues
                    NewDeck.Add(New Carta(Carta, SelectedDeck))
                Next
        End Select
        Return NewDeck
    End Function
    Sub UpdateTableros(ByVal CartaSet As CartasBaraja)
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
            Tablero.UpdateString()
        Next
    End Sub
    Function GetPreProgrammedDeck() As List(Of CartaProg)
        Dim PreProgrammedDeck As New List(Of CartaProg)
        Select Case ModoTest
            Case GanarTipo.Pareja
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(4, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.DoblePareja
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.Trio
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.Escalera
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
            Case GanarTipo.Color
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(7, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(3, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(7, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.FullHouse
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.Poker
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(5, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Picas))
                PreProgrammedDeck.Add(New CartaProg(CType(2, CartaProg.CartaValue), CartaProg.CartaSuit.Corazones))
                PreProgrammedDeck.Add(New CartaProg(CType(6, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.EscaleraColor
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(9, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
            Case GanarTipo.EscaleraReal
                'Round1
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Treboles))
                'Round2
                PreProgrammedDeck.Add(New CartaProg(CType(1, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(10, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(11, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(12, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
                PreProgrammedDeck.Add(New CartaProg(CType(13, CartaProg.CartaValue), CartaProg.CartaSuit.Diamantes))
        End Select
        Return PreProgrammedDeck
    End Function
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
