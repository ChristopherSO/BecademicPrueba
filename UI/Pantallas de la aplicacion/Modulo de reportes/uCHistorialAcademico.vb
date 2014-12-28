Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports EntitiesLayer
Imports BLL

Public Class uCHistorialAcademico

    Private gestorValidaciones As New GestorValidaciones
    Private idEstudiante As Integer

    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlCampos
        gestorValidaciones.activarValidaciones(contenedor)
        Me.rpvHistorialAcademico.RefreshReport()
        llenarCamposComboBox()
        Me.Dock = DockStyle.Fill

    End Sub

    Private Sub llenarCamposComboBox()

        Try

            cmbCarreras.DataSource = gestorTipoBeca.getCarreras()
            cmbCarreras.DisplayMember = "Nombre"
            cmbCarreras.ValueMember = "Id"
            cmbCarreras.Text = "(Seleccione una carrera...)"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim contenedor As Panel = pnlCampos

        Try

            If (gestorValidaciones.camposEstanValidos(contenedor) And txtCarnet.Text <> Nothing) Then

                If (esEstudiante()) Then

                    lblMsg.Text = ""
                    actualizarReportViewer()

                Else

                    lblMsg.Text = "* El usuario no es un estudiante"

                End If

            Else

                lblMsg.Text = "* No se permiten campos vacíos"

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

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

    Private Sub actualizarReportViewer()

        Dim idCarrera As Integer = cmbCarreras.SelectedValue

        Me.pa_reporte_historial_academicoTableAdapter.Fill(Me.beca_becademicDataSet.pa_reporte_historial_academico, idEstudiante, idCarrera)
        Me.rpvHistorialAcademico.RefreshReport()
    End Sub

End Class
