Public Class Carta
        Public Image As Image
        Public Value As Integer
    Public IsAs As Boolean = False
    Public RawValue As Integer
    Public Suit As CartaSuit
    Sub New(ByVal _Value As Integer, ByVal CartaSet As CartasBaraja)
        RawValue = _Value
        UpdateCarta(CartaSet)
    End Sub
    Sub UpdateCarta(ByVal CartaSet As CartasBaraja)
        Select Case RawValue
            Case 1 : Image = CartaSet.AsDeTreboles : Value = 1 : Suit = CartaSuit.Treboles : IsAs = True
            Case 2 : Image = CartaSet.DosDeTreboles : Value = 2 : Suit = CartaSuit.Treboles
            Case 3 : Image = CartaSet.TresDeTreboles : Value = 3 : Suit = CartaSuit.Treboles
            Case 4 : Image = CartaSet.CuatroDeTreboles : Value = 4 : Suit = CartaSuit.Treboles
            Case 5 : Image = CartaSet.CincoDeTreboles : Value = 5 : Suit = CartaSuit.Treboles
            Case 6 : Image = CartaSet.SeisDeTreboles : Value = 6 : Suit = CartaSuit.Treboles
            Case 7 : Image = CartaSet.SieteDeTreboles : Value = 7 : Suit = CartaSuit.Treboles
            Case 8 : Image = CartaSet.OchoDeTreboles : Value = 8 : Suit = CartaSuit.Treboles
            Case 9 : Image = CartaSet.NueveDeTreboles : Value = 9 : Suit = CartaSuit.Treboles
            Case 10 : Image = CartaSet.DiezDeTreboles : Value = 10 : Suit = CartaSuit.Treboles
            Case 11 : Image = CartaSet.SotaDeTreboles : Value = 11 : Suit = CartaSuit.Treboles
            Case 12 : Image = CartaSet.ReinaDeTreboles : Value = 12 : Suit = CartaSuit.Treboles
            Case 13 : Image = CartaSet.ReyDeTreboles : Value = 13 : Suit = CartaSuit.Treboles
            Case 14 : Image = CartaSet.AsDeDiamantes : Value = 1 : Suit = CartaSuit.Diamantes : IsAs = True
            Case 15 : Image = CartaSet.DosDeDiamantes : Value = 2 : Suit = CartaSuit.Diamantes
            Case 16 : Image = CartaSet.TresDeDiamantes : Value = 3 : Suit = CartaSuit.Diamantes
            Case 17 : Image = CartaSet.CuatroDeDiamantes : Value = 4 : Suit = CartaSuit.Diamantes
            Case 18 : Image = CartaSet.CincoDeDiamantes : Value = 5 : Suit = CartaSuit.Diamantes
            Case 19 : Image = CartaSet.SeisDeDiamantes : Value = 6 : Suit = CartaSuit.Diamantes
            Case 20 : Image = CartaSet.SieteDeDiamantes : Value = 7 : Suit = CartaSuit.Diamantes
            Case 21 : Image = CartaSet.OchoDeDiamantes : Value = 8 : Suit = CartaSuit.Diamantes
            Case 22 : Image = CartaSet.NueveDeDiamantes : Value = 9 : Suit = CartaSuit.Diamantes
            Case 23 : Image = CartaSet.DiezDeDiamantes : Value = 10 : Suit = CartaSuit.Diamantes
            Case 24 : Image = CartaSet.SotaDeDiamantes : Value = 11 : Suit = CartaSuit.Diamantes
            Case 25 : Image = CartaSet.ReinaDeDiamantes : Value = 12 : Suit = CartaSuit.Diamantes
            Case 26 : Image = CartaSet.ReyDeDiamantes : Value = 13 : Suit = CartaSuit.Diamantes
            Case 27 : Image = CartaSet.AsDeCorazones : Value = 1 : Suit = CartaSuit.Corazones : IsAs = True
            Case 28 : Image = CartaSet.DosDeCorazones : Value = 2 : Suit = CartaSuit.Corazones
            Case 29 : Image = CartaSet.TresDeCorazones : Value = 3 : Suit = CartaSuit.Corazones
            Case 30 : Image = CartaSet.CuatroDeCorazones : Value = 4 : Suit = CartaSuit.Corazones
            Case 31 : Image = CartaSet.CincoDeCorazones : Value = 5 : Suit = CartaSuit.Corazones
            Case 32 : Image = CartaSet.SeisDeCorazones : Value = 6 : Suit = CartaSuit.Corazones
            Case 33 : Image = CartaSet.SieteDeCorazones : Value = 7 : Suit = CartaSuit.Corazones
            Case 34 : Image = CartaSet.OchoDeCorazones : Value = 8 : Suit = CartaSuit.Corazones
            Case 35 : Image = CartaSet.NueveDeCorazones : Value = 9 : Suit = CartaSuit.Corazones
            Case 36 : Image = CartaSet.DiezDeCorazones : Value = 10 : Suit = CartaSuit.Corazones
            Case 37 : Image = CartaSet.SotaDeCorazones : Value = 11 : Suit = CartaSuit.Corazones
            Case 38 : Image = CartaSet.ReinaDeCorazones : Value = 12 : Suit = CartaSuit.Corazones
            Case 39 : Image = CartaSet.ReyDeCorazones : Value = 13 : Suit = CartaSuit.Corazones
            Case 40 : Image = CartaSet.AsDePicas : Value = 1 : Suit = CartaSuit.Picas : IsAs = True
            Case 41 : Image = CartaSet.DosDePicas : Value = 2 : Suit = CartaSuit.Picas
            Case 42 : Image = CartaSet.TresDePicas : Value = 3 : Suit = CartaSuit.Picas
            Case 43 : Image = CartaSet.CuatroDePicas : Value = 4 : Suit = CartaSuit.Picas
            Case 44 : Image = CartaSet.CincoDePicas : Value = 5 : Suit = CartaSuit.Picas
            Case 45 : Image = CartaSet.SeisDePicas : Value = 6 : Suit = CartaSuit.Picas
            Case 46 : Image = CartaSet.SieteDePicas : Value = 7 : Suit = CartaSuit.Picas
            Case 47 : Image = CartaSet.OchoDePicas : Value = 8 : Suit = CartaSuit.Picas
            Case 48 : Image = CartaSet.NueveDePicas : Value = 9 : Suit = CartaSuit.Picas
            Case 49 : Image = CartaSet.DiezDePicas : Value = 10 : Suit = CartaSuit.Picas
            Case 50 : Image = CartaSet.SotaDePicas : Value = 11 : Suit = CartaSuit.Picas
            Case 51 : Image = CartaSet.ReinaDePicas : Value = 12 : Suit = CartaSuit.Picas
            Case 52 : Image = CartaSet.ReyDePicas : Value = 13 : Suit = CartaSuit.Picas
        End Select
    End Sub
    Enum CartaSuit
        Treboles = 1
        Diamantes = 2
        Corazones = 3
        Picas = 4
    End Enum
End Class
