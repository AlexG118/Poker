Public Class Form3

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MiBanco.Creditos = 100 Then
            MessageBox.Show("¡Te vas a quedar en blanca!")
        End If
        If MiBanco.Creditos > 100 Then
            MiBanco.Creditos = MiBanco.Creditos - 100
            MiBanco.CreditosLabel.Text = "€" & MiBanco.Creditos.ToString("##0.00")
            LOTR = True
            MessageBox.Show("¡Has conseguido una skin para tu baraja!" & Chr(13) & _
                            "Puedes elegirla en el menu de imagenes en la esquina superior izquierda del juego" & Chr(13) & _
                            "Gracias por jugar :)")
            Label4.Text = "Desbloquedo"
        End If
        If MiBanco.Creditos < 100 Then
            MessageBox.Show("¡Necesitas mas dinero!")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MiBanco.Creditos = 200 Then
            MessageBox.Show("¡Te vas a quedar en blanca!")
        End If
        If MiBanco.Creditos > 200 Then
            MiBanco.Creditos = MiBanco.Creditos - 200
            MiBanco.CreditosLabel.Text = "€" & MiBanco.Creditos.ToString("##0.00")
            Stripoker = True
            MessageBox.Show("¡Has conseguido el premio ULTIMATE!" & Chr(13) & _
                            "Puedes elegirla en el menu de imagenes en la esquina superior izquierda del juego" & Chr(13) & _
                            "Gracias por jugar :)")
            Label6.Text = "Desbloquedo"
        End If
        If MiBanco.Creditos < 200 Then
            MessageBox.Show("¡Necesitas mas dinero!")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MiBanco.Creditos >= 1000 Then
            MiBanco.Creditos = MiBanco.Creditos - 1000
            MiBanco.CreditosLabel.Text = "€" & MiBanco.Creditos.ToString("##0.00")
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=i-Qc4oA23XQ")
            Label5.Text = "Desbloquedo"
        End If
        If MiBanco.Creditos < 1000 Then
            MessageBox.Show("¡Necesitas mas dinero!")
        End If
    End Sub
End Class