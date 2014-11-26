Public Class Form2
    'Tres botones para insertar 100,50 o 10 creditos al principio.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MiBanco.InsertarDinero(Contabilidad.ApuestaIncremento1.Cien)
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MiBanco.InsertarDinero(Contabilidad.ApuestaIncremento1.Cincuenta)
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MiBanco.InsertarDinero(Contabilidad.ApuestaIncremento1.Diez)
        Me.Hide()
    End Sub
End Class