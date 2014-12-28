Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede asignar/remover un requisito a un tipo de beca.
''' </summary>
''' <remarks>Para asignar un requisito a un tipo de beca previamente se tuvo que haber seleccionado en el uCTiposDeBecas.</remarks>
Public Class frmRequisitosAsignados

    Public idTipoBeca As Integer
    Public idRequisito As Integer
    Public nombreTipoBeca As String
    Dim row As Integer
    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Carga los datos de los beneficios asignados del tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para que carge los datos tuvo que haber sido seleccionado previamente el tipo de beca.</remarks>
    Private Sub frmRequisitosAsignados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Lista de requisitos asignados de tipo de beca " & nombreTipoBeca
        Dim contenedor As Panel = pnlContenidoPrincipal
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        actualizarDatagrid()
        llenarCamposComboBox()

    End Sub

    ''' <summary>
    ''' Llama al método asignarRequisitoBeca que ejecuta la acción de la asignación.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de asignar.</remarks>
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim contenedor As Panel = pnlContenidoPrincipal

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            asignarRequisitoBeca()
        End If

    End Sub

    ''' <summary>
    ''' Asigna el requisto escogido al tipo de beca.
    ''' </summary>
    ''' <remarks>Para asignar el requisito se tuvo que haber seleccionado previamente.</remarks>
    Private Sub asignarRequisitoBeca()

        Try

            idRequisito = cmbRequisitos.SelectedValue
            gestorTipoBeca.asignarRequisito(idTipoBeca, idRequisito)
            MessageBox.Show("Se ha asignado un requisito", "Información", MessageBoxButtons.OK)
            actualizarDatagrid()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
        

    End Sub

    ''' <summary>
    ''' Actualiza el datagridview de los requisitos asignados al tipo de beca.
    ''' </summary>
    ''' <remarks>Método llamado desde el frmRequisitosAsignados_Load().</remarks>
    Private Sub actualizarDatagrid()

        Try

            Dim lstRequisitos As IEnumerable = gestorTipoBeca.consultarRequisitosBeca(idTipoBeca)
            dgvRequisitosBeca.Rows.Clear()

            For Each requisito As Requisito In lstRequisitos
                dgvRequisitosBeca.Rows.Add(requisito.Id, requisito.Nombre, requisito.Descripcion)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try


    End Sub

    ''' <summary>
    ''' Carga los requisitos registrados en el combobox.
    ''' </summary>
    ''' <remarks>Se cargan los requisitos apenas se entra al formulario.</remarks>
    Private Sub llenarCamposComboBox()

        Try

            cmbRequisitos.DataSource = gestorTipoBeca.getRequisitos()
            cmbRequisitos.DisplayMember = "Nombre"
            cmbRequisitos.ValueMember = "Id"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Remueve un requisito al tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para remover el requisito se tuvo que haber seleccionado previamente.</remarks>
    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click

        Dim result As DialogResult

        Try

            result = MessageBox.Show("¿Realmente desea quitar el riquisito a la beca?", "Quitar requisito a beca", MessageBoxButtons.YesNo)

            If result = System.Windows.Forms.DialogResult.Yes Then
                row = dgvRequisitosBeca.CurrentRow.Index
                gestorTipoBeca.eliminarRequisitoBeca(dgvRequisitosBeca.Item(0, row).Value, idTipoBeca)
                actualizarDatagrid()
            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de asignar/remover requisitos a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de cancelar.</remarks>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class