Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede asignar/remover una carrera a un tipo de beca.
''' </summary>
''' <remarks>Para asignar una carrera a un tipo de beca previamente se tuvo que haber seleccionado en el uCTiposDeBecas.</remarks>
Public Class frmCarrerasAsignadas
    Public idTipoBeca As Integer
    Public idCarrera As Integer
    Dim row As Integer
    Public nombreTipoBeca As String
    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Carga los datos de las carreras asignadas del tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para que carge los datos tuvo que haber sido seleccionado previamente el tipo de beca.</remarks>
    Private Sub onLoadfrmCarrerasAsignadas(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Lista de carreras asignadas de tipo de beca " & nombreTipoBeca
        Dim contenedor As Panel = pnlContenidoPrincipal
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        actualizarDatagrid()
        llenarCamposComboBox()

    End Sub

    ''' <summary>
    ''' Llama al método asignarCarreraBeca que ejecuta la acción de la asignación.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de asignar.</remarks>
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim contenedor As Panel = pnlContenidoPrincipal

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            asignarCarreraBeca()
        End If

    End Sub

    ''' <summary>
    ''' Asigna la carrera escogida al tipo de beca.
    ''' </summary>
    ''' <remarks>Para asignar la carrera se tuvo que haber seleccionado previamente.</remarks>
    Private Sub asignarCarreraBeca()

        Try

            idCarrera = cmbCarreras.SelectedValue
            gestorTipoBeca.asignarCarrera(idTipoBeca, idCarrera)
            actualizarDatagrid()
            MessageBox.Show("Se ha asignado una carrera", "Información", MessageBoxButtons.OK)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Actualiza el datagridview de las carreras asignadas al tipo de beca.
    ''' </summary>
    ''' <remarks>Método llamado desde el frmCarrerasAsignadas_Load().</remarks>
    Private Sub actualizarDatagrid()

        Try

            cmbCarreras.Text = "(Seleccione una carrera...)"
            Dim lstCarreras As IEnumerable = gestorTipoBeca.consultarCarrerasBeca(idTipoBeca)
            dgvCarrerasBeca.Rows.Clear()

            For Each carrera As Carrera In lstCarreras
                dgvCarrerasBeca.Rows.Add(carrera.Id, carrera.Nombre, carrera.Descripcion)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Carga las carreras registradas en el combobox.
    ''' </summary>
    ''' <remarks>Se cargan los beneficios apenas se entra al formulario.</remarks>
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

    ''' <summary>
    ''' Remueve una carrera al tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para remover la carrera se tuvo que haber seleccionado previamente.</remarks>
    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click

        Dim result As DialogResult

        Try

            result = MessageBox.Show("¿Realmente desea quitar la carrera a la beca?", "Quitar carrera a beca", MessageBoxButtons.YesNo)

            If result = System.Windows.Forms.DialogResult.Yes Then
                row = dgvCarrerasBeca.CurrentRow.Index
                gestorTipoBeca.eliminarCarreraBeca(dgvCarrerasBeca.Item(0, row).Value, idTipoBeca)
                actualizarDatagrid()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de asignar/remover carreras a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de cancelar.</remarks>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub
End Class