Imports EntitiesLayer

Public Class frmAgregarCurso

    Private gestorValidaciones As New GestorValidaciones
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            If (gestorValidaciones.camposEstanValidos(pnlAgregarTipoDeBeca)) Then
                If MessageBox.Show("¿Desea agregar este nuevo curso?", "Agregar nuevo curso", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    gestorCurso.agregarCurso(txtNombre.Text, txtCodigo.Text, txtPrecio.Text, txtCreditos.Text)
                    MessageBox.Show("Nuevo curso agregado exitosamente", "Agregar nuevo curso", MessageBoxButtons.OK)
                    Me.Close()
                End If
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
        
        
    End Sub

    Private Sub onLoadAgregarCurso(sender As Object, e As EventArgs) Handles MyBase.Load
        gestorValidaciones.activarValidaciones(pnlAgregarTipoDeBeca)
    End Sub
End Class