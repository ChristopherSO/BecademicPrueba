Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports BLL

Public Class uCProforma

    Private gestorValidaciones As New GestorValidaciones

    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlCampos
        gestorValidaciones.activarValidaciones(contenedor)
        Me.rpvProforma.RefreshReport()
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

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            actualizarReportViewer()
        End If

    End Sub

    Private Sub actualizarReportViewer()

        Dim idCarrera As Integer = cmbCarreras.SelectedValue

        Me.pa_reporte_proformaTableAdapter.Fill(Me.beca_becademicDataSet.pa_reporte_proforma, idCarrera)

        Me.rpvProforma.RefreshReport()

    End Sub

End Class
