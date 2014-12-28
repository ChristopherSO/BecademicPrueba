Imports EntitiesLayer

''' <summary>
''' Formulario donde se consulta los tipos de beca.
''' </summary>
''' <remarks>Además se puede agregar, modificar y eliminar un tipo de beca.
''' Se puede asignar requisitos, beneficios y carreras.</remarks>
Public Class uCTiposDeBecas

    Dim row As Integer
    Dim result As DialogResult
    Dim idTipoBeca As Integer

    ''' <summary>
    ''' oncontrolLoad carga los datos del datagrid y válida si el usuario tiene permiso para realizar ciertas funciones.
    ''' </summary>
    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill
        actualizarDatagrid()

        ' Permisos
        btnAgregarTipoBeca.Visible = gestorAuth.tieneElPermiso(3)
        btnModificarTipoBeca.Visible = gestorAuth.tieneElPermiso(4)
        btnAsignarBeneficio.Visible = gestorAuth.tieneElPermiso(4)
        btnAsignarRequisito.Visible = gestorAuth.tieneElPermiso(4)
        btnAsignarCarrera.Visible = gestorAuth.tieneElPermiso(4)
        btnEliminarTipoBeca.Visible = gestorAuth.tieneElPermiso(5)

        idTipoBeca = 0

    End Sub

    ''' <summary>
    ''' Actualiza el datagrid a la hora de agregar un nuevo tipo de beca o se actualiza la misma.
    ''' </summary>
    ''' <remarks>Este método se usa a cada momento porque actualiza el datagridview.</remarks>
    Private Sub actualizarDatagrid()

        Try

            Dim lstTipoBeca As IEnumerable = gestorTipoBeca.consultarTipoBecas
            dgvTipoBecas.Rows.Clear()
            For Each tipoBeca As TipoBeca In lstTipoBeca
                dgvTipoBecas.Rows.Add(tipoBeca.Id, tipoBeca.Nombre, tipoBeca.Descripcion, tipoBeca.Icono, tipoBeca.Color)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' Llama al formulario agregar nuevo tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario cada vez que presiona el botón agregar tipo de beca.</remarks>
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoBeca.Click

        Dim frmAgregarTipoBeca = New frmAgregarTipoBeca()

        Try

            frmAgregarTipoBeca.ShowDialog(Me)
            actualizarDatagrid()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try


    End Sub

    ''' <summary>
    ''' Llama al formulario actualizar tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario cada vez que presiona el botón modificar tipo de beca.</remarks>
    Private Sub btnModificarTipoBeca_Click(sender As Object, e As EventArgs) Handles btnModificarTipoBeca.Click

        Dim frmActualizarTipoDeBeca As New frmActualizarTipoDeBeca

        If idTipoBeca = 0 Then

            MessageBox.Show("Seleccione un tipo de beca ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try

                row = dgvTipoBecas.CurrentRow.Index
                frmActualizarTipoDeBeca.idTipoBeca = dgvTipoBecas.Item(0, row).Value
                frmActualizarTipoDeBeca.ShowDialog(Me)
                actualizarDatagrid()


            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End If

    End Sub

    ''' <summary>
    ''' Llama al formulario eliminar tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Elimina un tipo de beca cada vez que presiona el botón eliminar tipo de beca.</remarks>
    Private Sub btnEliminarTipoBeca_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoBeca.Click

        If idTipoBeca = 0 Then

            MessageBox.Show("Seleccione un tipo de beca ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try

                result = MessageBox.Show("¿Realmente desea borrar este tipo de beca?", "Borrar tipo de beca", MessageBoxButtons.YesNo)

                If result = System.Windows.Forms.DialogResult.Yes Then
                    row = dgvTipoBecas.CurrentRow.Index
                    gestorTipoBeca.eliminarTipoBeca(dgvTipoBecas.Item(0, row).Value)
                    actualizarDatagrid()
                    idTipoBeca = 0
                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End If

    End Sub

    ''' <summary>
    ''' Llama al formulario asignar beneficio a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario cada vez que presiona el botón beneficios asignados a un tipo de beca previamente seleccionada.</remarks>
    Private Sub btnAsignarBeneficio_Click(sender As Object, e As EventArgs) Handles btnAsignarBeneficio.Click
        Dim frmBeneficiosAsignados = New frmBeneficiosAsignados()


        If idTipoBeca = 0 Then

            MessageBox.Show("Seleccione un tipo de beca ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try

                row = dgvTipoBecas.CurrentRow.Index
                frmBeneficiosAsignados.idTipoBeca = dgvTipoBecas.Item(0, row).Value
                frmBeneficiosAsignados.nombreTipoBeca = dgvTipoBecas.Item(1, row).Value
                frmBeneficiosAsignados.ShowDialog(Me)



            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End If

    End Sub

    ''' <summary>
    ''' Llama al formulario asignar requisito a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario cada vez que presiona el botón requisitos asignados a un tipo de beca previamente seleccionada.</remarks>
    Private Sub btnAsignarRequisito_Click(sender As Object, e As EventArgs) Handles btnAsignarRequisito.Click

        Dim frmRequisitosAsignados = New frmRequisitosAsignados()

        If idTipoBeca = 0 Then

            MessageBox.Show("Seleccione un tipo de beca ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try
                row = dgvTipoBecas.CurrentRow.Index
                frmRequisitosAsignados.idTipoBeca = dgvTipoBecas.Item(0, row).Value
                frmRequisitosAsignados.nombreTipoBeca = dgvTipoBecas.Item(1, row).Value
                frmRequisitosAsignados.ShowDialog(Me)



            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End If

    End Sub

    ''' <summary>
    ''' Llama al formulario asignar carrera a un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Llama al formulario cada vez que presiona el botón carreras asignadas a un tipo de beca previamente seleccionada.</remarks>
    Private Sub btnAsignarCarrera_Click(sender As Object, e As EventArgs) Handles btnAsignarCarrera.Click

        Dim frmCarrerasAsignadas = New frmCarrerasAsignadas()

        If idTipoBeca = 0 Then

            MessageBox.Show("Seleccione un tipo de beca ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try


                row = dgvTipoBecas.CurrentRow.Index
                frmCarrerasAsignadas.idTipoBeca = dgvTipoBecas.Item(0, row).Value
                frmCarrerasAsignadas.nombreTipoBeca = dgvTipoBecas.Item(1, row).Value
                frmCarrerasAsignadas.ShowDialog(Me)

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End If



    End Sub

    ''' <summary>
    ''' Filtra los tipos de becas.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Se filtran según se vayan ingresado el nombre del tipo de beca a filtrar.</remarks>
    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged

        Try

            If txtBusqueda.Text = "" Then

                actualizarDatagrid()

            Else

                row = dgvTipoBecas.CurrentRow.Index
                Dim nombre As String = txtBusqueda.Text

                Dim lstTipoBeca As IEnumerable = gestorTipoBeca.buscarTipoBeca(nombre)
                dgvTipoBecas.Rows.Clear()

                For Each tipoBeca As TipoBeca In lstTipoBeca
                    dgvTipoBecas.Rows.Add(tipoBeca.Id, tipoBeca.Nombre, tipoBeca.Descripcion, tipoBeca.Icono, tipoBeca.Color)
                Next

            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipoBecas.CellClick

        idTipoBeca = dgvTipoBecas.Item(0, row).Value


    End Sub



End Class
