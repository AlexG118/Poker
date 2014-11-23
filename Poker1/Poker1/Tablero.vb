Public Class Tablero
    Inherits PictureBox
    Public StandardSize As New Point(144, 194)
    Public JuegoEnProceso As Boolean = False
    Public StandardTop As Integer = 201
    Public Held As Boolean = False
    Public Carta As Carta
    Sub New()
        Me.Size = StandardSize
        Me.Top = StandardTop
        Me.BackColor = Color.White
        Me.Cursor = Cursors.Arrow
        Me.DoubleBuffered = True
        Me.BringToFront()
    End Sub
    Shadows Sub Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseClick
        If JuegoEnProceso Then
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            Select Case Held
                Case False
                    Me.Top = Me.Top - 40
                    Held = True
                Case True
                    Me.Top = Me.Top + 40
                    Held = False
            End Select
            UpdateString()
        End If
    End Sub
    Sub UpdateString()
        Me.Image = Me.Carta.Image
        Me.Update()
        Dim HoldFont As Font = New Font("System", 32, FontStyle.Bold)
        If Held Then Me.CreateGraphics.DrawString("HOLD", HoldFont, Brushes.Red, 0, (Me.Height \ 2) - 32)
    End Sub
End Class
