Imports System.Runtime.InteropServices
Imports System.Drawing.Text

Public Class frmAgregarRequisito

    Private gestorValidaciones As New GestorValidaciones

    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarRequisito
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        cargarRequisito()
    End Sub
    Private Sub cargarRequisito()

        cmbTipoRequisito.DataSource = gestorRequisito.listarTipoRequisitos()
        cmbTipoRequisito.ValueMember = "Id"
        cmbTipoRequisito.DisplayMember = "Nombre"
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarRequisito

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarRequisito()

        End If

    End Sub
    Private Sub agregarRequisito()
        Try
            Dim nombre As String = txtNombre.Text
            Dim tipoRequisito As Integer = cmbTipoRequisito.SelectedValue
            Dim descripcion As String = txtDescripcion.Text

            gestorRequisito.agregarRequisito(nombre, tipoRequisito, descripcion)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class