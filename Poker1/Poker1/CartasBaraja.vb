﻿'Clase para definir las cartas de la baraja , asi tambien para definir las imagenes correspondientes segun que diseño de cartas eligamos
Public Class CartasBaraja
    Public AsDeTreboles, DosDeTreboles, TresDeTreboles, CuatroDeTreboles, CincoDeTreboles, SeisDeTreboles, SieteDeTreboles, OchoDeTreboles, NueveDeTreboles, DiezDeTreboles, SotaDeTreboles, ReinaDeTreboles, ReyDeTreboles As Image
    Public AsDeDiamantes, DosDeDiamantes, TresDeDiamantes, CuatroDeDiamantes, CincoDeDiamantes, SeisDeDiamantes, SieteDeDiamantes, OchoDeDiamantes, NueveDeDiamantes, DiezDeDiamantes, SotaDeDiamantes, ReinaDeDiamantes, ReyDeDiamantes As Image
    Public AsDeCorazones, DosDeCorazones, TresDeCorazones, CuatroDeCorazones, CincoDeCorazones, SeisDeCorazones, SieteDeCorazones, OchoDeCorazones, NueveDeCorazones, DiezDeCorazones, SotaDeCorazones, ReinaDeCorazones, ReyDeCorazones As Image
    Public AsDePicas, DosDePicas, TresDePicas, CuatroDePicas, CincoDePicas, SeisDePicas, SieteDePicas, OchoDePicas, NueveDePicas, DiezDePicas, SotaDePicas, ReinaDePicas, ReyDePicas As Image
    'Definidas las cartas , paso a definir estas dos variablrd para definir las baraja y su familia
    Public BarajaCartas As Image
    Public BarajaFamilia As DeckDesign
    Public Strippoker As Boolean = False
    'Metodo para establecer las imagenes de las cartas que cambian con cada baraja, solo cambiaran las jotas,reinas y reyes de los 4 palos , y tambien la imagen de detras de las cartas
    Sub New(ByVal BarajaFamilia1 As DeckDesign)
        CartasComunes()
        BarajaFamilia = BarajaFamilia1
        Select Case BarajaFamilia
            Case DeckDesign.Clasico
                SotaDeTreboles = My.Resources.CC11 : SotaDeDiamantes = My.Resources.CD11 : SotaDeCorazones = My.Resources.CH11 : SotaDePicas = My.Resources.CS11
                ReinaDeTreboles = My.Resources.CC12 : ReinaDeDiamantes = My.Resources.CD12 : ReinaDeCorazones = My.Resources.CH12 : ReinaDePicas = My.Resources.CS12
                ReyDeTreboles = My.Resources.CC13 : ReyDeDiamantes = My.Resources.CD13 : ReyDeCorazones = My.Resources.CH13 : ReyDePicas = My.Resources.CS13
                BarajaCartas = My.Resources.DeckClassic
            Case DeckDesign.Corazones
                SotaDeTreboles = My.Resources.HC11 : SotaDeDiamantes = My.Resources.HD11 : SotaDeCorazones = My.Resources.HH11 : SotaDePicas = My.Resources.HS11
                ReinaDeTreboles = My.Resources.HC12 : ReinaDeDiamantes = My.Resources.HD12 : ReinaDeCorazones = My.Resources.HH12 : ReinaDePicas = My.Resources.HS12
                ReyDeTreboles = My.Resources.HC13 : ReyDeDiamantes = My.Resources.HD13 : ReyDeCorazones = My.Resources.HH13 : ReyDePicas = My.Resources.HS13
                BarajaCartas = My.Resources.DeckHearts
            Case DeckDesign.Estaciones
                SotaDeTreboles = My.Resources.SC11 : SotaDeDiamantes = My.Resources.SD11 : SotaDeCorazones = My.Resources.SH11 : SotaDePicas = My.Resources.SS11
                ReinaDeTreboles = My.Resources.SC12 : ReinaDeDiamantes = My.Resources.SD12 : ReinaDeCorazones = My.Resources.SH12 : ReinaDePicas = My.Resources.SS12
                ReyDeTreboles = My.Resources.SC13 : ReyDeDiamantes = My.Resources.SD13 : ReyDeCorazones = My.Resources.SH13 : ReyDePicas = My.Resources.SS13
                BarajaCartas = My.Resources.SeasonsDeck
            Case DeckDesign.StripPoker
                SotaDeTreboles = My.Resources.SPC11 : SotaDeDiamantes = My.Resources.SPD11 : SotaDeCorazones = My.Resources.SPH11 : SotaDePicas = My.Resources.SPS11
                ReinaDeTreboles = My.Resources.SPC12 : ReinaDeDiamantes = My.Resources.SPC12 : ReinaDeCorazones = My.Resources.SPC12 : ReinaDePicas = My.Resources.SPC12
                ReyDeTreboles = My.Resources.SPC13 : ReyDeDiamantes = My.Resources.SPC13 : ReyDeCorazones = My.Resources.SPC13 : ReyDePicas = My.Resources.SPC13
                BarajaCartas = My.Resources.StripPokerDeck
            Case DeckDesign.LOTRPoker
                SotaDeTreboles = My.Resources.LC11 : SotaDeDiamantes = My.Resources.LD11 : SotaDeCorazones = My.Resources.LH11 : SotaDePicas = My.Resources.LS11
                ReinaDeTreboles = My.Resources.LC12 : ReinaDeDiamantes = My.Resources.LD12 : ReinaDeCorazones = My.Resources.LC12 : ReinaDePicas = My.Resources.LS12
                ReyDeTreboles = My.Resources.LC13 : ReyDeDiamantes = My.Resources.LD13 : ReyDeCorazones = My.Resources.LC13 : ReyDePicas = My.Resources.LS13
                BarajaCartas = My.Resources.LOTRDeck
        End Select
    End Sub
    'Metodo que establece las cartas comunes para todos , del As hasta el 10
    Sub CartasComunes()
        AsDeTreboles = My.Resources.C1 : DosDeTreboles = My.Resources.C2
        TresDeTreboles = My.Resources.C3 : CuatroDeTreboles = My.Resources.C4
        CincoDeTreboles = My.Resources.C5 : SeisDeTreboles = My.Resources.C6
        SieteDeTreboles = My.Resources.C7 : OchoDeTreboles = My.Resources.C8
        NueveDeTreboles = My.Resources.C9 : DiezDeTreboles = My.Resources.C10
        AsDeDiamantes = My.Resources.D1 : DosDeDiamantes = My.Resources.D2
        TresDeDiamantes = My.Resources.D3 : CuatroDeDiamantes = My.Resources.D4
        CincoDeDiamantes = My.Resources.D5 : SeisDeDiamantes = My.Resources.D6
        SieteDeDiamantes = My.Resources.D7 : OchoDeDiamantes = My.Resources.D8
        NueveDeDiamantes = My.Resources.D9 : DiezDeDiamantes = My.Resources.D10
        AsDeCorazones = My.Resources.H1 : DosDeCorazones = My.Resources.H2
        TresDeCorazones = My.Resources.H3 : CuatroDeCorazones = My.Resources.H4
        CincoDeCorazones = My.Resources.H5 : SeisDeCorazones = My.Resources.H6
        SieteDeCorazones = My.Resources.H7 : OchoDeCorazones = My.Resources.H8
        NueveDeCorazones = My.Resources.H9 : DiezDeCorazones = My.Resources.H10
        AsDePicas = My.Resources.S1 : DosDePicas = My.Resources.S2
        TresDePicas = My.Resources.S3 : CuatroDePicas = My.Resources.S4
        CincoDePicas = My.Resources.S5 : SeisDePicas = My.Resources.S6
        SieteDePicas = My.Resources.S7 : OchoDePicas = My.Resources.S8
        NueveDePicas = My.Resources.S9 : DiezDePicas = My.Resources.S10
    End Sub
    'Los tipos de barajas que hay para elegir
    Enum DeckDesign
        Clasico
        Corazones
        Estaciones
        StripPoker
        LOTRPoker
    End Enum

End Class
