Imports EntitiesLayer

Public Class frmActualizarCurso

    Private idCurso As Integer
    Private gestorValidaciones As New GestorValidaciones

    Public Property ID As Integer
        Get
            Return idCurso
        End Get
        Set(value As Integer)
            idCurso = value
        End Set
    End Property


    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (gestorValidaciones.camposEstanValidos(pnlAgregarTipoDeBeca)) Then
            If MessageBox.Show("¿Desea guardar los cambios para este curso?", "Actualizar información de curso", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                gestorCurso.editarCurso(ID, txtNombre.Text, txtCodigo.Text, txtPrecio.Text, txtCreditos.Text)
                MessageBox.Show("Curso actualizado exitosamente", "Actualizar información de curso", MessageBoxButtons.OK)
                Me.Close()
            End If
        End If

    End Sub

    Private Sub onLoadActualizar(sender As Object, e As EventArgs) Handles MyBase.Load

        GestorValidaciones.activarValidaciones(pnlAgregarTipoDeBeca)

        If idCurso <> vbNull Then
            Dim c As Curso = gestorCurso.consultarCurso(idCurso)
            txtNombre.Text = c.Nombre
            txtCodigo.Text = c.Codigo
            txtPrecio.Text = c.Precio
            txtCreditos.Text = c.CantidadCreditos
        Else
            Me.Close()
        End If

    End Sub

End Class