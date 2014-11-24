Option Strict On

Module Misc
    Public CurrentCartaJuego As CartaJuego
    Public SelectedDeck As CartasBaraja
    Public StandardSelectorSize As New Point(57, 75)
    Public EnlargedSelectorSize As New Point(65, 84)
    Public StandardSelectorTop As Integer = 15
    Public CurrentSelector As PictureBox
    Public Tableros As New List(Of Tablero)
    Public MyBank As Contabilidad
    Public CurrentIncrement As Contabilidad.BetIncrement1 = Contabilidad.BetIncrement1.Uno
    Public BetCreditQuantity As Integer = 5
    Sub UpdateSelection(ByVal Sender As Object, ByVal pbClassicSelect As PictureBox, ByVal pbHeartsSelect As PictureBox, ByVal pbSeasonsSelect As PictureBox, ByVal pbStripPokerSelect As PictureBox, ByVal pbLOTRSelect As PictureBox)
        If Not CurrentSelector Is DirectCast(Sender, PictureBox) Then
            CurrentSelector = DirectCast(Sender, PictureBox)
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            pbClassicSelect.Size = CType(StandardSelectorSize, Size)
            pbHeartsSelect.Size = CType(StandardSelectorSize, Size)
            pbSeasonsSelect.Size = CType(StandardSelectorSize, Size)
            pbStripPokerSelect.Size = CType(StandardSelectorSize, Size)
            pbLOTRSelect.Size = CType(StandardSelectorSize, Size)
            DirectCast(Sender, PictureBox).BringToFront()
            DirectCast(Sender, PictureBox).Size = CType(EnlargedSelectorSize, Size)

            DirectCast(Sender, PictureBox).Top = DirectCast(Sender, PictureBox).Top - 15

            Select Case DirectCast(Sender, PictureBox).Name
                Case pbClassicSelect.Name
                    pbClassicSelect.Top = StandardSelectorTop
                    SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.Classic)
                    Form1.BackgroundImage = My.Resources.Poker1
                Case pbHeartsSelect.Name
                    pbHeartsSelect.Top = StandardSelectorTop
                    SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.Corazones)
                    Form1.BackgroundImage = My.Resources.Poker2
                Case pbSeasonsSelect.Name
                    pbSeasonsSelect.Top = StandardSelectorTop
                    SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.Seasons)
                    Form1.BackgroundImage = My.Resources.Poker3
                Case pbStripPokerSelect.Name
                    pbStripPokerSelect.Top = StandardSelectorTop
                    SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.StripPoker)
                    Form1.BackgroundImage = My.Resources.Poker4
                Case pbLOTRSelect.Name
                    pbLOTRSelect.Top = StandardSelectorTop
                    SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.LOTRPoker)
                    Form1.BackgroundImage = My.Resources.LOTRPoker
            End Select
            For Each Tablero As Tablero In Tableros
                Tablero.BackgroundImage = CurrentSelector.BackgroundImage
            Next
        End If
        Try
            CurrentCartaJuego.UpdateTableros(SelectedDeck)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Wait(ByVal milliseconds As Integer)
        Dim Sw As Stopwatch = Stopwatch.StartNew
        Do
            Application.DoEvents()
        Loop Until Sw.ElapsedMilliseconds = milliseconds
    End Sub
End Module
