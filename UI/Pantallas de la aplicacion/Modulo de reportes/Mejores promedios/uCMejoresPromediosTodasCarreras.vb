Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports BLL

Public Class uCMejoresPromediosTodasCarreras

    Private gestorValidaciones As New GestorValidaciones

    Public Sub onControlLoad() Handles MyBase.Load

        Dim contenedor As Panel = pnlCampos
        gestorValidaciones.activarValidaciones(contenedor)
        Me.rpvMejorPromedioTodasCarrera.RefreshReport()
        Me.Dock = DockStyle.Fill

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim contenedor As Panel = pnlCampos

        If (gestorValidaciones.camposEstanValidos(contenedor)) And cmbPeriodoInicio.Text <= cmbPeriodoFinal.Text And txtAnioInicio.Text <= txtAnioFinal.Text Then

            lblMsgPeriodo.Text = ""
            lblMsgAnio.Text = ""
            actualizarReportViewer()

        Else

            If cmbPeriodoInicio.Text > cmbPeriodoFinal.Text Then

                lblMsgPeriodo.Text = "*Periodo inicial no puede ser mayor"

            Else

                lblMsgPeriodo.Text = ""

            End If

            If txtAnioInicio.Text > txtAnioFinal.Text Then

                lblMsgAnio.Text = "*El año inico no puede ser mayor"

            Else

                lblMsgAnio.Text = ""

            End If

        End If

    End Sub

    Private Sub actualizarReportViewer()

        Dim cantRegistro As Integer = txtCantResultado.Text
        Dim periodoInicial As Integer = cmbPeriodoInicio.Text
        Dim anioInicial As Integer = txtAnioInicio.Text
        Dim periodoFinal As Integer = cmbPeriodoFinal.Text
        Dim anioFinal As Integer = txtAnioFinal.Text

        Me.pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter.Fill(Me.beca_becademicDataSet.pa_reporte_mejores_promedios_todas_las_carreras, cantRegistro, periodoInicial, anioInicial, periodoFinal, anioFinal)

        Me.rpvMejorPromedioTodasCarrera.RefreshReport()

    End Sub

End Class
