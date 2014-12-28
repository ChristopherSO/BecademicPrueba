Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports EntitiesLayer
Public Class frmActualizarRequisito

    Private gestorValidaciones As New GestorValidaciones
    Private idRequisito As Integer
    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlModificarRequisito
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        cargarDatos()
    End Sub

    Public Property ID As Integer
        Get
            Return idRequisito
        End Get
        Set(value As Integer)
            idRequisito = value
        End Set
    End Property

    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim contenedor As Panel = pnlModificarRequisito

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            modificarRequisito()
        End If

    End Sub
    Private Sub modificarRequisito()
        Try
            Dim nombre As String = txtNombre.Text
            Dim tipoRequisito As Integer = cmbTipoRequisito.SelectedValue
            Dim descripcion As String = txtDescripcion.Text

            gestorRequisito.editarRequisito(idRequisito, nombre, tipoRequisito, descripcion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Close()
    End Sub
    Private Sub frmActualizarRequisito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Private Sub cargarDatos()

        cmbTipoRequisito.DataSource = gestorRequisito.listarTipoRequisitos()
        cmbTipoRequisito.ValueMember = "Id"
        cmbTipoRequisito.DisplayMember = "Nombre"

        Dim requisito As New Requisito()
        requisito = RequisitoRepository.Instance.GetById(idRequisito)
        txtNombre.Text = requisito.Nombre
        txtDescripcion.Text = requisito.Descripcion

    End Sub
End Class