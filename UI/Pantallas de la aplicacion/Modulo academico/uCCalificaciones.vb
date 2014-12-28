Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

Public Class uCCalificaciones

    Dim row As Integer
    Dim result As DialogResult
    Private gestorValidaciones As New GestorValidaciones
    Private idEstudiante As Integer
    Private rolUsuario As Integer

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill
        Dim contenedor As Panel = pnlBuscar
        gestorValidaciones.activarValidaciones(contenedor)
        llenarCamposComboBox()
        hideButtons()

    End Sub

    Private Sub hideButtons()
        dgvCalificaciones.Hide()
        btnEliminar.Hide()
        btnAgregar.Hide()
        btnActualizar.Hide()
        lblNotas.Hide()
    End Sub

    Private Sub showButtons()
        dgvCalificaciones.Show()
        btnEliminar.Show()
        btnAgregar.Show()
        lblNotas.Show()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click


        Dim contenedor As Panel = pnlBuscar
        If (gestorValidaciones.camposEstanValidos(contenedor) And txtCarnet.Text <> Nothing) Then

            If (esEstudiante()) Then

                lblMsg.Text = ""
                showButtons()
                actualizarDataGrid()

            Else

                lblMsg.Text = "* El usuario no es un estudiante"
                hideButtons()

            End If

        Else

            lblMsg.Text = "* No se permiten campos vacíos"
            hideButtons()

        End If


    End Sub

    Private Function esEstudiante() As Boolean


        Dim resultado As Boolean

        Try

            Dim usuario As Usuario = gestorUsuario.consultarUsuarioPorCarnet(txtCarnet.Text)
            Dim lstRolUsuario As IList = gestorRol.consultarRolesUsuario(usuario.Id)
            Dim i As Integer = 0

            While i < lstRolUsuario.Count() And resultado = False

                If usuario.Id <> 0 And lstRolUsuario(i).Nombre = "Estudiante" Or lstRolUsuario(i).Nombre = "estudiante" Then

                    resultado = True
                    idEstudiante = usuario.Id

                Else

                    resultado = False

                End If

                i = i + 1

            End While

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

        Return resultado

    End Function

    Private Sub llenarCamposComboBox()

        Try

            cmbCarreras.DataSource = gestorTipoBeca.getCarreras()
            cmbCarreras.DisplayMember = "Nombre"
            cmbCarreras.ValueMember = "Id"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Public Sub actualizarDataGrid()

        Try

            Dim lstCalificaciones As IEnumerable = gestorCalificaciones.consultarCalificaciones(idEstudiante, cmbCarreras.SelectedValue)
            dgvCalificaciones.Rows.Clear()
            For Each calificacion As Calificacion In lstCalificaciones
                dgvCalificaciones.Rows.Add(calificacion.Id, calificacion.IdUsuario, calificacion.IdCurso, calificacion.Curso.Codigo, calificacion.Curso.Nombre, calificacion.Periodo, calificacion.Annio, calificacion.Nota, calificacion.Comentarios)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnAgregar_Click_1(sender As Object, e As EventArgs) Handles btnAgregar.Click


        Try

            Dim contenedor As Panel = pnlBuscar
            If (gestorValidaciones.camposEstanValidos(contenedor) And txtCarnet.Text <> Nothing) Then

                If (esEstudiante()) Then

                    lblMsg.Text = ""
                    Dim frmAgregarCalificacion As New frmAgregarCalificacion
                    frmAgregarCalificacion.idUsuario = idEstudiante
                    frmAgregarCalificacion.ShowDialog(Me)
                    actualizarDataGrid()

                Else

                    lblMsg.Text = "* El usuario no es un estudiante"
                    dgvCalificaciones.Hide()
                    btnEliminar.Hide()
                    lblNotas.Hide()

                End If

            Else

                lblMsg.Text = "* No se permiten campos vacíos"
                dgvCalificaciones.Hide()
                btnEliminar.Hide()
                lblNotas.Hide()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try

            result = MessageBox.Show("¿Realmente desea borrar esta calificación?", "Borrar calificación", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                row = dgvCalificaciones.CurrentRow.Index
                gestorCalificaciones.eliminarCalificacion(dgvCalificaciones.Item(0, row).Value)
                actualizarDataGrid()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class
