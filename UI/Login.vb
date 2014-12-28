Imports EntitiesLayer

Public Class Login

    Public Sub cambiarPantalla(pantalla As UserControl)

        pnlContenido.Controls.Clear()
        pnlContenido.Controls.Add(pantalla)
        pnlContenido.Update()

    End Sub

    Private Sub onLoginLoad(sender As Object, e As EventArgs) Handles MyBase.Load

        cambiarPantalla(New uCLogin)

    End Sub

    Private Sub LblSalir_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblSalir.LinkClicked
        Me.Close()
    End Sub
End Class