Option Strict On
Imports System.Drawing.Text

Public Class Form1
    'Aqui nombro las 5 cartas como un tablero , especificado en la clase Tablero.vb
    WithEvents Tablero1, Tablero2, Tablero3, Tablero4, Tablero5 As New Tablero

    'Lo que se ejecutará nada mas cargar el programa
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Creo un objeto Contabilidad que llamare MiBanco (variable nombrada en Misc) , 
        ' y que esta vinculado con el Label3 dodne se muestra el dinero que se posee
        MiBanco = New Contabilidad(Label3)
        'Mostramos el Form2 donde nos pregunta con que cantidad de dinero queremos empezar
        Form2.Show()
        'Las siguientes lineas es para poner bonito los paneles y labels del Form1
        Panel1.SendToBack()
        Panel1.BackColor = Color.FromArgb(64, Panel1.BackColor.R, Panel1.BackColor.G, Panel1.BackColor.B)
        Label3.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        'Soluciona los problemas de parpadeo
        Me.DoubleBuffered = True
        'Pone imagen al Boton de Apostar.
        Button1.BackgroundImage = My.Resources.Deal
        'Vacia el Label1 de Texto
        Label1.Text = ""
        'Obtiene el rectángulo que representa el área cliente del control.
        Label1.Width = Me.ClientRectangle.Width
        'Establezco que el texto se ponga a la izquierda para que ocupe todo el Form1
        Label1.Left = 0
        'Pongo el tablero de cartas clasico para empezar el juego
        SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.Clasico)
        'Se selecciona la imagen de la baraja de cartas clasico, la redimensiona y la pone arriba del todo y la trae al frente
        SelectorActual = pbClasicoSelect
        pbClasicoSelect.Size = CType(TamañoAmpliadoSelec, Drawing.Size)
        pbClasicoSelect.Top = 0
        pbClasicoSelect.BringToFront()
        'Despues establezco la posicion de las cartas que nombre arriba y las añado al objeto "tableros", 
        'y en el for imprementas las cartas en la coleccion Controls y le ponemos el fondo a las cartas.
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
            Tablero.BackgroundImage = SelectorActual.BackgroundImage
        Next
        'Nombramos una variable CartaJuego para que se aplique a la baraja las reglas de la clase CartaJuego
        Dim CartaJuego As New CartaJuego(SelecBaraja)
        'Ponemos ActualCartaJuego como esta variable anterior
        ActualCartaJuego = CartaJuego
    End Sub
    'Metodo para cambiar las barajas entre las 5 disponibles
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClasicoSelect.Click, pbCorazonesSelect.Click, pbEstacionesSelect.Click
        ActualizarSelec1(sender, pbClasicoSelect, pbCorazonesSelect, pbEstacionesSelect)
    End Sub

    Private Sub pbStripPokerSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbStripPokerSelect.Click
        If Stripoker = True Then
            ActualizarSelec2(sender, pbStripPokerSelect)
        Else
            My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub pbLOTRSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLOTRSelect.Click
        If LOTR = True Then
            ActualizarSelec3(sender, pbLOTRSelect)
        Else
            My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background)
        End If
    End Sub


    'Metodo para el boton principal del programa ,aqui empieza el juego,
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Si el juego esta en proceso , al darle click pasar a la siguiente accion
        If ActualCartaJuego.JuegoEnProceso = True Then
            ActualCartaJuego.NextAccion(SelecBaraja, Label1, Button1)
        Else
            'Si no esta en proceso y PagarMaquina esta en True (tienes dinero para empezar) pues empezara el juego,
            'Si esta en False te sacara un mensaje de que no tiene dinero.
            Select Case MiBanco.PagarMaquina(IncrementoActual, CantidadApostada)
                Case True
                    ActualCartaJuego.NextAccion(SelecBaraja, Label1, Button1)
                Case False
                    Label1.Text = "Vete a casa, has gastado todo"
                    My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background)
            End Select
        End If

    End Sub
    'Metodo para los botones de aumentar o bajar cantidad apostada en cada juego
    Private Sub Apostar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncrementarApuesta.Click, btnBajarApuesta.Click
        'Si el juego esta proceso nos denegara cambiar la cantidad apostada hasta que no acabemos la partida
        If ActualCartaJuego.JuegoEnProceso Then My.Computer.Audio.Play(My.Resources.no, AudioPlayMode.Background) : Exit Sub
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
        'Aqui ira cambiando la cantidad segun el valor de la cantidad apostada y de que boton pulsemos
        Select Case DirectCast(sender, Button).Name
            Case btnIncrementarApuesta.Name
                Select Case CantidadApostada
                    Case 100
                        CantidadApostada = 5
                    Case 50
                        CantidadApostada = 100
                    Case 20
                        CantidadApostada = 50
                    Case 10
                        CantidadApostada = 20
                    Case 5
                        CantidadApostada = 10
                End Select
            Case btnBajarApuesta.Name
                Select Case CantidadApostada
                    Case 100
                        CantidadApostada = 50
                    Case 50
                        CantidadApostada = 20
                    Case 20
                        CantidadApostada = 10
                    Case 10
                        CantidadApostada = 5
                    Case 5
                        CantidadApostada = 100
                End Select
        End Select
        'Sacara el valor que corresponda segun cual hayamos clickado
        Label7.Text = CStr(CantidadApostada)
    End Sub

    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form2.Close()
        Form3.Close()
    End Sub

    Private Sub Info_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MessageBox.Show("Información" & Chr(13) & _
                        Chr(13) & _
                        "Multiplicadores de dinero ganado por tipo de victoria" & Chr(13) & _
                        Chr(13) & _
                        "Pareja : Multiplicador = 2" & Chr(13) & _
                        "DoblePareja : Multiplicador = 5" & Chr(13) & _
                        "Trio : Multiplicador = 15" & Chr(13) & _
                        "Escalera : Multiplicador = 20" & Chr(13) & _
                        "Color : Multiplicador = 25" & Chr(13) & _
                        "FullHouse : Multiplicador = 30" & Chr(13) & _
                        "Poker : Multiplicador = 35" & Chr(13) & _
                        "EscaleraColor : Multiplicador = 50" & Chr(13) & _
                        "EscaleraReal : Multiplicador = 250" & Chr(13) & _
                        Chr(13) & _
                        "¡Buena Suerte!", "Ultimate Poker")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form3.Show()
    End Sub

End Class
