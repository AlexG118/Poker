Option Strict On
Imports System.Drawing.Text
Public Class Form1
    WithEvents Tablero1, Tablero2, Tablero3, Tablero4, Tablero5 As New Tablero

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBank = New Contabilidad(Label3)
        Form2.Show()
        Panel1.SendToBack()
        Panel1.BackColor = Color.FromArgb(64, Panel1.BackColor.R, Panel1.BackColor.G, Panel1.BackColor.B)
        Label3.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Me.DoubleBuffered = True
        Button1.BackgroundImage = My.Resources.Deal
        Label1.Text = ""
        Label1.Width = Me.ClientRectangle.Width
        Label1.Left = 0
        SelectedDeck = New CartasBaraja(CartasBaraja.DeckDesign.Classic)
        CurrentSelector = pbClassicSelect
        pbClassicSelect.Size = CType(EnlargedSelectorSize, Drawing.Size)
        pbClassicSelect.Top = 0
        pbClassicSelect.BringToFront()
        Tablero1.Left = 75
        Tablero2.Left = 227
        Tablero3.Left = 379
        Tablero4.Left = 531
        Tablero5.Left = 683
        Tableros.Add(Tablero1)
        Tableros.Add(Tablero2)
        Tableros.Add(Tablero3)
        Tableros.Add(Tablero4)
        Tableros.Add(Tablero5)
        For Each Tablero As Tablero In Tableros
            Me.Controls.Add(Tablero)
            Tablero.BackgroundImage = CurrentSelector.BackgroundImage
        Next
        Dim CartaJuego As New CartaJuego(SelectedDeck)
        CurrentCartaJuego = CartaJuego
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClassicSelect.Click, pbHeartsSelect.Click, pbSeasonsSelect.Click, pbStripPokerSelect.Click, pbLOTRSelect.Click
        UpdateSelection(sender, pbClassicSelect, pbHeartsSelect, pbSeasonsSelect, pbStripPokerSelect, pbLOTRSelect)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CurrentCartaJuego.JuegoEnProceso = True Then
            CurrentCartaJuego.NextAction(SelectedDeck, Label1, Button1)
        Else
            Select Case MyBank.PayMachine(CurrentIncrement, BetCreditQuantity)
                Case True
                    CurrentCartaJuego.NextAction(SelectedDeck, Label1, Button1)
                Case False
                    Label1.Text = "Vete a casa, has gastado todo"
                    My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background)
            End Select
        End If

    End Sub

    Private Sub pbInsert(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        Dim TargetValue As Double
        Dim ExpandMode As Integer = 0
        Dim TargetIncrement As Contabilidad.BetIncrement1

        Select Case TargetIncrement
            Case Contabilidad.BetIncrement1.Cien : TargetValue = 100
            Case Contabilidad.BetIncrement1.Cincuenta : TargetValue = 50
            Case Contabilidad.BetIncrement1.Veinte : TargetValue = 20
            Case Contabilidad.BetIncrement1.Diez : TargetValue = 10
            Case Contabilidad.BetIncrement1.Cinco : TargetValue = 5
            Case Contabilidad.BetIncrement1.Uno : TargetValue = 1
        End Select
        If TargetValue + MyBank.Credits > 100 Then
            MyBank.InsertMoney(TargetIncrement)
        End If
        DirectCast(sender, PictureBox).BringToFront()
        DirectCast(sender, PictureBox).Left = DirectCast(sender, PictureBox).Left - 4
        DirectCast(sender, PictureBox).Top = DirectCast(sender, PictureBox).Top - 4
        DirectCast(sender, PictureBox).Width = DirectCast(sender, PictureBox).Width + 8
        DirectCast(sender, PictureBox).Height = DirectCast(sender, PictureBox).Height + 8
        DirectCast(sender, PictureBox).Invalidate()

    End Sub

    Private Sub pbMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DirectCast(sender, PictureBox).Left = DirectCast(sender, PictureBox).Left + 4
        DirectCast(sender, PictureBox).Top = DirectCast(sender, PictureBox).Top + 4

        DirectCast(sender, PictureBox).Width = DirectCast(sender, PictureBox).Width - 8
        DirectCast(sender, PictureBox).Height = DirectCast(sender, PictureBox).Height - 8

        DirectCast(sender, PictureBox).SendToBack()
    End Sub



    Private Sub Bet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncreaseBet.Click, btnDecreaseBet.Click
        If CurrentCartaJuego.JuegoEnProceso Then My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background) : Exit Sub
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
        Select Case DirectCast(sender, Button).Name
            Case btnIncreaseBet.Name
                Select Case BetCreditQuantity
                    Case 100
                        BetCreditQuantity = 5
                    Case 50
                        BetCreditQuantity = 100
                    Case 20
                        BetCreditQuantity = 50
                    Case 10
                        BetCreditQuantity = 20
                    Case 5
                        BetCreditQuantity = 10
                End Select
            Case btnDecreaseBet.Name
                Select Case BetCreditQuantity
                    Case 100
                        BetCreditQuantity = 50
                    Case 50
                        BetCreditQuantity = 20
                    Case 20
                        BetCreditQuantity = 10
                    Case 10
                        BetCreditQuantity = 5
                    Case 5
                        BetCreditQuantity = 100
                End Select
        End Select
        Label7.Text = CStr(BetCreditQuantity)
    End Sub

End Class
