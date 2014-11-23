Option Strict On
Imports System.Drawing.Text
Public Class Form1
    WithEvents Tablero1, Tablero2, Tablero3, Tablero4, Tablero5 As New Tablero

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBank = New Contabilidad(Label3)
        MyBank.InsertMoney(Contabilidad.BetIncrememt.Hundred)
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
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClassicSelect.Click, pbHeartsSelect.Click, pbSeasonsSelect.Click
        UpdateSelection(sender, pbClassicSelect, pbHeartsSelect, pbSeasonsSelect)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CurrentCartaJuego.JuegoEnProceso = True Then
            CurrentCartaJuego.NextAction(SelectedDeck, Label1, Button1)
        Else
            Select Case MyBank.PayMachine(CurrentIncrement, BetCreditQuantity)
                Case True
                    CurrentCartaJuego.NextAction(SelectedDeck, Label1, Button1)
                Case False
                    Label1.Text = "Vete a casa"
                    My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background)
            End Select
        End If

    End Sub

    Private Sub pbInsert(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        Dim TargetValue As Double
        Dim ExpandMode As Integer = 0
        Dim TargetIncrement As Contabilidad.BetIncrememt
        

        Select Case TargetIncrement
            Case Contabilidad.BetIncrememt.Hundred : TargetValue = 100
            Case Contabilidad.BetIncrememt.Fifty : TargetValue = 50
            Case Contabilidad.BetIncrememt.Twenty : TargetValue = 20
            Case Contabilidad.BetIncrememt.Ten : TargetValue = 10
            Case Contabilidad.BetIncrememt.Five : TargetValue = 5
            Case Contabilidad.BetIncrememt.Two : TargetValue = 2
            Case Contabilidad.BetIncrememt.One : TargetValue = 1
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

        'MyBank.InsertMoney(Contabilidad.BetIncrememt.Hundred)
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
                    Case 5
                        BetCreditQuantity = 1
                    Case 4
                        BetCreditQuantity = 5
                    Case 3
                        BetCreditQuantity = 4
                    Case 2
                        BetCreditQuantity = 3
                    Case 1
                        BetCreditQuantity = 2
                End Select
            Case btnDecreaseBet.Name
                Select Case BetCreditQuantity
                    Case 5
                        BetCreditQuantity = 4
                    Case 4
                        BetCreditQuantity = 3
                    Case 3
                        BetCreditQuantity = 2
                    Case 2
                        BetCreditQuantity = 1
                    Case 1
                        BetCreditQuantity = 5
                End Select
        End Select
        Label7.Text = CStr(BetCreditQuantity)
    End Sub
End Class
