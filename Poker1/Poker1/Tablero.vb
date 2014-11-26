'Clase como imagen para definir cada carta
Public Class Tablero
    Inherits PictureBox
    'El tamaño estandar de cada carta
    Public TamañoEstandar As New Point(144, 194)
    'Boolean apra saber si el juego sigue en proceso
    Public JuegoEnProceso As Boolean = False
    'Variable para la posicion de arriba de valor estandar para las cartas
    Public EstandarTop As Integer = 201
    'Boolean para saber si la carta esta mantenida o no
    Public Mantenida As Boolean = False
    'Objeto Carta
    Public Carta As Carta
    'Propiedades de la carta, el tamaño, posicion, color, cursor al pasar sobre el, y que este siempre delante
    Sub New()
        Me.Size = TamañoEstandar
        Me.Top = EstandarTop
        Me.BackColor = Color.White
        Me.Cursor = Cursors.Arrow
        Me.BringToFront()
    End Sub
    'Metodo para cuando hagamos click sobre una carta
    Shadows Sub Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseClick
        'Si el juego esta en proceso entonces se podnra en modo mantenida o no segun lo este o no.
        If JuegoEnProceso Then
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            Select Case Mantenida
                Case False
                    Me.Top = Me.Top - 40
                    Mantenida = True
                Case True
                    Me.Top = Me.Top + 40
                    Mantenida = False
            End Select
            ActualizarString()
        End If
    End Sub
    'Metodo para añadir un String con valor HOLD para saber cuando esta mantenida la carta o no
    Sub ActualizarString()
        Me.Image = Me.Carta.Image
        Me.Update()
        Dim HoldFont As Font = New Font("System", 32, FontStyle.Bold)
        If Mantenida Then Me.CreateGraphics.DrawString("HOLD", HoldFont, Brushes.Red, 0, (Me.Height \ 2) - 32)
    End Sub
End Class
