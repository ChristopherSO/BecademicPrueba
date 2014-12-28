Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports BLL

Public Class uCMejoresPromediosXCarrera

    Private gestorValidaciones As New GestorValidaciones

    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlCampos
        gestorValidaciones.activarValidaciones(contenedor)
        Me.rpvMejorPromedioPorCarrera.RefreshReport()
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

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim contenedor As Panel = pnlCampos

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then

            lblMsgPeriodo.Text = ""
            lblMsgAnio.Text = ""
            lblMsgCantResultado.Text = ""
            actualizarReportViewer()

        End If

    End Sub

    Private Sub actualizarReportViewer()

        Dim periodoInicial As Integer = cmbPeriodoInicial.Text
        Dim anioInicial As Integer = txtAnioInicio.Text
        Dim periodoFinal As Integer = cmbPeriodoFinal.Text
        Dim anioFinal As Integer = txtAnioFinal.Text
        Dim cantRegistros As Integer = txtCantResultado.Text
        Dim idCarrera As Integer = cmbCarreras.SelectedValue

        Me.pa_reporte_mejores_promedios_por_carreraTableAdapter.Fill(Me.beca_becademicDataSet.pa_reporte_mejores_promedios_por_carrera, idCarrera, cantRegistros, periodoInicial, anioInicial, periodoFinal, anioFinal)

        Me.rpvMejorPromedioPorCarrera.RefreshReport()

    End Sub

End Class
