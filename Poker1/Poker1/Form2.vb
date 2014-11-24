Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyBank.InsertMoney(Contabilidad.BetIncrement1.Cien)
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MyBank.InsertMoney(Contabilidad.BetIncrement1.Cincuenta)
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MyBank.InsertMoney(Contabilidad.BetIncrement1.Diez)
        Me.Hide()
    End Sub
End Class