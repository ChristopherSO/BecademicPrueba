Imports EntitiesLayer

''' <summary>
''' Formulario donde se consultan los beneficios.
''' </summary>
''' <remarks>Además se puede agregar, modificar y eliminar un beneficio.</remarks>
Public Class uCBeneficios

    Dim row As Integer
    Dim idBeneficio As Integer
    Dim result As DialogResult

    ''' <summary>
    ''' oncontrolLoad carga los datos del datagrid y válida si el usuario tiene permiso para realizar ciertas funciones.
    ''' </summary>
    Public Sub onControlLoad() Handles MyBase.Load

        Try
            Me.Dock = DockStyle.Fill

            actualizarDataGrid()

            dgvBeneficios.AutoResizeColumns()
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        idBeneficio = 0
        BtnAgregar.Visible = gestorAuth.tieneElPermiso(7)
        BtnModificar.Visible = gestorAuth.tieneElPermiso(8)
        BtnEliminar.Visible = gestorAuth.tieneElPermiso(9)

    End Sub

    ''' <summary>
    ''' Actualiza el datagrid.
    ''' </summary>
    Private Sub actualizarDataGrid()

        Try

            Dim listaBeneficios As IEnumerable = gestorBeneficios.consultarBeneficios
            dgvBeneficios.Rows.Clear()
            For Each beneficio As Beneficio In listaBeneficios
                dgvBeneficios.Rows.Add(beneficio.Id, beneficio.TipoBeneficio.Nombre, beneficio.Nombre, beneficio.Descripcion, beneficio.Valor)
            Next

            If dgvBeneficios.RowCount > 0 Then
                idBeneficio = dgvBeneficios.Item(0, 0).Value
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub dgvBeneficios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBeneficios.CellClick

        Try
            row = dgvBeneficios.CurrentRow.Index
            idBeneficio = dgvBeneficios.Item(0, row).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Llama al formulario agregar nuevo beneficio.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario de agregar cada vez que se presiona el botón agregar.</remarks>
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        Dim formularioAgregar As frmAgregarBeneficio = New frmAgregarBeneficio


        formularioAgregar.ShowDialog(Me)
        actualizarDataGrid()


    End Sub

    ''' <summary>
    ''' Llama al formulario actualizar beneficio.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario de modificar cada vez que se presiona el botón modificar.</remarks>
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click

        Dim formularioActualizar As frmActualizarBeneficios = New frmActualizarBeneficios

        If idBeneficio = 0 Then

            MessageBox.Show("Seleccione un beneficio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            formularioActualizar.idBeneficio = idBeneficio
            formularioActualizar.ShowDialog(Me)
            actualizarDataGrid()

        End If

    End Sub

    ''' <summary>
    ''' Llama al formulario eliminar beneficio.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Elimina un beneficio cada vez que se presiona el botón eliminar.</remarks>
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        If idBeneficio = 0 Then

            MessageBox.Show("Seleccione un beneficio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try
                Dim cantTiposDeBecasAsociados As Integer = gestorBeneficios.consultarCantTiposDeBecaPorIdBeneficio(idBeneficio)

                If cantTiposDeBecasAsociados > 0 Then
                    MessageBox.Show("No se puede eliminar el beneficio debido a que está asignado a un tipo de beca. Para poder eliminarlo debe remover este beneficio del tipo de beca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    result = MessageBox.Show("¿Realmente desea borrar este beneficio?", "Borrar beneficio", MessageBoxButtons.YesNo)
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        gestorBeneficios.eliminarBeneficio(idBeneficio)
                        actualizarDataGrid()
                        MessageBox.Show("Beneficio borrado")
                        idBeneficio = 0
                    End If
                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

            actualizarDataGrid()

        End If

    End Sub

End Class
