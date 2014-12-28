Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede asignar/remover un beneficio a un tipo de beca.
''' </summary>
''' <remarks>Para asignar un beneficio a un tipo de beca previamente se tuvo que haber seleccionado en el uCTiposDeBecas.</remarks>
Public Class frmBeneficiosAsignados

    Public idTipoBeca As Integer
    Public idBeneficio As Integer
    Dim row As Integer
    Public nombreTipoBeca As String
    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Carga los datos de los beneficios asignados del tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para que carge los datos tuvo que haber sido seleccionado previamente el tipo de beca.</remarks>
    Private Sub frmBeneficiosAsignados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Lista de beneficios asignados de tipo de beca " & nombreTipoBeca
        Dim contenedor As Panel = pnlContenidoPrincipal
        gestorValidaciones.activarValidaciones(contenedor)

        Me.Dock = DockStyle.Fill
        actualizarDataGrid()
        llenarCamposComboBox()

    End Sub

    ''' <summary>
    ''' Llama al método asignarBeneficioBeca que ejecuta la acción de la asignación.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de asignar.</remarks>
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim contenedor As Panel = pnlContenidoPrincipal

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            asignarBeneficioBeca()
        End If


    End Sub

    ''' <summary>
    ''' Asigna el beneficio escogido al tipo de beca.
    ''' </summary>
    ''' <remarks>Para asignar el beneficio se tuvo que haber seleccionado previamente.</remarks>
    Private Sub asignarBeneficioBeca()

        Try
            idBeneficio = cmbBeneficios.SelectedValue

            If idBeneficio = 0 Then

                MessageBox.Show("Debe seleccionar una opción válida", "Error", MessageBoxButtons.OK)

            Else

                gestorTipoBeca.asignarBeneficio(idTipoBeca, idBeneficio)
                actualizarDataGrid()
                MessageBox.Show("Se ha asignado un beneficio", "Información", MessageBoxButtons.OK)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Actualiza el datagridview de los beneficios asignados al tipo de beca.
    ''' </summary>
    ''' <remarks>Método llamado desde el frmBeneficiosAsignados_Load().</remarks>
    Private Sub actualizarDataGrid()

        Try

            Dim lstBeneficios As IEnumerable = gestorTipoBeca.consultarBeneficiosBeca(idTipoBeca)
            dgvBeneficiosBecas.Rows.Clear()

            For Each beneficio As Beneficio In lstBeneficios
                dgvBeneficiosBecas.Rows.Add(beneficio.Id, beneficio.Nombre, beneficio.Descripcion)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Carga los beneficios registrados en el combobox.
    ''' </summary>
    ''' <remarks>Se cargan los beneficios apenas se entra al formulario.</remarks>
    Private Sub llenarCamposComboBox()

        Try

            cmbBeneficios.DataSource = gestorTipoBeca.getBeneficios()
            cmbBeneficios.DisplayMember = "Nombre"
            cmbBeneficios.ValueMember = "Id"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Remueve un beneficio al tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para remover el beneficio se tuvo que haber seleccionado previamente.</remarks>
    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click

        Dim result As DialogResult

        Try

            result = MessageBox.Show("¿Realmente desea quitar el beneficio a la beca?", "Quitar beneficio a beca", MessageBoxButtons.YesNo)

            If result = System.Windows.Forms.DialogResult.Yes Then
                row = dgvBeneficiosBecas.CurrentRow.Index
                gestorTipoBeca.eliminarBeneficioBeca(dgvBeneficiosBecas.Item(0, row).Value, idTipoBeca)
                actualizarDataGrid()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de asignar/remover beneficios a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de cancelar.</remarks>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub
End Class