Option Strict On

'Clase para dos metodos miscelaneos
Module Misc
    'Declaracion de variables publicas

    'Variable para referirse a la ronda/juego actual
    Public ActualCartaJuego As CartaJuego
    'Variable para referirse a la baaja seleccionada
    Public SelecBaraja As CartasBaraja
    'Variable para referirse al tamaño estandar para las imagenes en la esquina superior izquierda
    Public TamañoEstandarSelec As New Point(57, 75)
    'Variable para referirse al tamaño ampliado para las imagenes en la esquina superior izquierda
    Public TamañoAmpliadoSelec As New Point(65, 84)
    'Variable para referirse al valor que subiran las imagenes en la esquina superior izquierda al ser seleccionadas
    Public SeleccionTop As Integer = 15
    'Variable para referirse a la baraja actual seleccionada
    Public SelectorActual As PictureBox
    'Variable para referirse al  conjunto de cartas representadas en el programa
    Public Tableros As New List(Of Tablero)
    'Variable para referirse a un objeto de contabilidad
    Public MiBanco As Contabilidad
    'Variable para referirse al incremento actual que sera 1 para despues se multiplique por las apuestas correspondientes
    Public IncrementoActual As Contabilidad.ApuestaIncremento1 = Contabilidad.ApuestaIncremento1.Uno
    'Variable para referirse al valor de la cantidad apostada que de valor inicial tendra 5
    Public CantidadApostada As Integer = 5

    Public Stripoker As Boolean = False
    Public LOTR As Boolean = False
    'Metodo para cambiar de baraja entre las 5 disponibles
    Sub ActualizarSelec1(ByVal Sender As Object, ByVal pbClasicoSelect As PictureBox, ByVal pbCorazonesSelect As PictureBox, ByVal pbSeasonsSelect As PictureBox)
        'Si la baraja que queremos usar no es la seleccionada entonces ocurrira lo siguiente

        If Not SelectorActual Is DirectCast(Sender, PictureBox) Then
            'Selector Actual pasara a ser la que hemos elegido
            SelectorActual = DirectCast(Sender, PictureBox)
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            'Todos los demas selectores se pondran a tamaño normal
            pbClasicoSelect.Size = CType(TamañoEstandarSelec, Size)
            pbCorazonesSelect.Size = CType(TamañoEstandarSelec, Size)
            pbSeasonsSelect.Size = CType(TamañoEstandarSelec, Size)
            ' pbStripPokerSelect.Size = CType(TamañoEstandarSelec, Size)
            ' pbLOTRSelect.Size = CType(TamañoEstandarSelec, Size)
            'Se pondra al frente la imagen de baraja seleccionada y pasara a tener tamaño ampliado
            DirectCast(Sender, PictureBox).BringToFront()
            DirectCast(Sender, PictureBox).Size = CType(TamañoAmpliadoSelec, Size)

            'Segun que baraja eligamos la carta subira 15 puntos haca arriba, las cartas cambiaran y el fondo tambien
            Select Case DirectCast(Sender, PictureBox).Name
                Case pbClasicoSelect.Name
                    pbClasicoSelect.Top = SeleccionTop
                    SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.Clasico)
                    Form1.BackgroundImage = My.Resources.Poker1
                Case pbCorazonesSelect.Name
                    pbCorazonesSelect.Top = SeleccionTop
                    SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.Corazones)
                    Form1.BackgroundImage = My.Resources.Poker2
                Case pbSeasonsSelect.Name
                    pbSeasonsSelect.Top = SeleccionTop
                    SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.Estaciones)
                    Form1.BackgroundImage = My.Resources.Poker3
                    'Case pbStripPokerSelect.Name
                    ' pbStripPokerSelect.Top = SeleccionTop
                    'SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.StripPoker)
                    ' Form1.BackgroundImage = My.Resources.Poker4
                    ' Case pbLOTRSelect.Name
                    'pbLOTRSelect.Top = SeleccionTop
                    'SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.LOTRPoker)
                    'Form1.BackgroundImage = My.Resources.LOTRPoker
            End Select
            'Pone el fondo de carta segun la baraja seleccionada
            For Each Tablero As Tablero In Tableros
                Tablero.BackgroundImage = SelectorActual.BackgroundImage
            Next
        End If
        'Las cartas que haya activas en el momento que cambiemos de baraja se cambiaran por las de la baraja que eligamos.
        'Agrupadas en un try catch ya que sino ejecuta un error el visual basic de IndexOutOfValues
        Try
            ActualCartaJuego.ActualizarTableros(SelecBaraja)
        Catch ex As Exception
        End Try
    End Sub

    Sub ActualizarSelec2(ByVal Sender As Object, ByVal pbStripPokerSelect As PictureBox)
        'Si la baraja que queremos usar no es la seleccionada entonces ocurrira lo siguiente
        If Not SelectorActual Is DirectCast(Sender, PictureBox) Then
            'Selector Actual pasara a ser la que hemos elegido
            SelectorActual = DirectCast(Sender, PictureBox)
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            'Todos los demas selectores se pondran a tamaño normal
            pbStripPokerSelect.Size = CType(TamañoEstandarSelec, Size)
            'Se pondra al frente la imagen de baraja seleccionada y pasara a tener tamaño ampliado
            DirectCast(Sender, PictureBox).BringToFront()
            DirectCast(Sender, PictureBox).Size = CType(TamañoAmpliadoSelec, Size)
            'Segun que baraja eligamos la carta subira 15 puntos haca arriba, las cartas cambiaran y el fondo tambien
            pbStripPokerSelect.Top = SeleccionTop
            SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.StripPoker)
            Form1.BackgroundImage = My.Resources.Poker4
            'Pone el fondo de carta segun la baraja seleccionada
            For Each Tablero As Tablero In Tableros
                Tablero.BackgroundImage = SelectorActual.BackgroundImage
            Next
        End If
        'Las cartas que haya activas en el momento que cambiemos de baraja se cambiaran por las de la baraja que eligamos.
        'Agrupadas en un try catch ya que sino ejecuta un error el visual basic de IndexOutOfValues
        Try
            ActualCartaJuego.ActualizarTableros(SelecBaraja)
        Catch ex As Exception
        End Try
    End Sub

    Sub ActualizarSelec3(ByVal Sender As Object, ByVal pbLOTRSelect As PictureBox)
        'Si la baraja que queremos usar no es la seleccionada entonces ocurrira lo siguiente
        If Not SelectorActual Is DirectCast(Sender, PictureBox) Then
            'Selector Actual pasara a ser la que hemos elegido
            SelectorActual = DirectCast(Sender, PictureBox)
            My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
            'Todos los demas selectores se pondran a tamaño normal
            pbLOTRSelect.Size = CType(TamañoEstandarSelec, Size)
            'Se pondra al frente la imagen de baraja seleccionada y pasara a tener tamaño ampliado
            DirectCast(Sender, PictureBox).BringToFront()
            DirectCast(Sender, PictureBox).Size = CType(TamañoAmpliadoSelec, Size)
            'Segun que baraja eligamos la carta subira 15 puntos haca arriba, las cartas cambiaran y el fondo tambien
            pbLOTRSelect.Top = SeleccionTop
            SelecBaraja = New CartasBaraja(CartasBaraja.DeckDesign.LOTRPoker)
            Form1.BackgroundImage = My.Resources.LOTRPoker
            'Pone el fondo de carta segun la baraja seleccionada
            For Each Tablero As Tablero In Tableros
                Tablero.BackgroundImage = SelectorActual.BackgroundImage
            Next
        End If
        'Las cartas que haya activas en el momento que cambiemos de baraja se cambiaran por las de la baraja que eligamos.
        'Agrupadas en un try catch ya que sino ejecuta un error el visual basic de IndexOutOfValues
        Try
            ActualCartaJuego.ActualizarTableros(SelecBaraja)
        Catch ex As Exception
        End Try
    End Sub

    'Metodo para que el programa espere x milisegundos
    Public Sub Wait(ByVal milliseconds As Integer)
        Dim Sw As Stopwatch = Stopwatch.StartNew
        Do
            Application.DoEvents()
        Loop Until Sw.ElapsedMilliseconds = milliseconds
    End Sub
End Module
