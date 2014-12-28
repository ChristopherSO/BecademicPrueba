Imports EntitiesLayer
Imports System.Runtime.InteropServices

''' <summary>
''' Formulario donde se puede modificar un beneficio.
''' </summary>
Public Class frmActualizarBeneficios

    Private gestorValidaciones As New GestorValidaciones
    Public idBeneficio As Integer

    ''' <summary>
    ''' Carga los datos en los TextBox de un beneficio.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    Private Sub frmActualizarBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim beneficio As Beneficio = gestorBeneficios.consultarBeneficioPorID(idBeneficio)
        
            gestorValidaciones.activarValidaciones(pnlAgregarTipoDeBeca)
            llenarComboBoxTiposDeBeneficios()
            CmbTipoDeBeneficio.SelectedValue = beneficio.IdTipoBeneficio
            TxtNombre.Text = beneficio.Nombre
            TxtDescripcion.Text = beneficio.Descripcion
            TxtValor.Text = beneficio.Valor

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Llena los campos de los textBox.
    ''' </summary>
    Private Sub llenarComboBoxTiposDeBeneficios()

        Try
            Dim listaTiposDeBeneficios As IEnumerable = gestorBeneficios.buscarTiposDeBeneficios

            CmbTipoDeBeneficio.DataSource = listaTiposDeBeneficios
            CmbTipoDeBeneficio.ValueMember = "Id"
            CmbTipoDeBeneficio.DisplayMember = "Nombre"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de actualizar el beneficio cuando se presiona el botón Cancelar.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    ''' <summary>
    ''' Cuando se presiona el botón Guardar llama al método modificarBeneficio que ejecuta la acción de la modificación, esto después de validar todos los campos.
    ''' </summary>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarTipoDeBeca

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            Dim result As DialogResult = MessageBox.Show("¿Realmente desea modificar este beneficio?", "Modificar beneficio", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                modificarBeneficio()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Guarda la información del tipo de beca.
    ''' </summary>
    Private Sub modificarBeneficio()

        Try
            Dim idTipo As Integer = CmbTipoDeBeneficio.SelectedValue
            Dim nombre As String = TxtNombre.Text
            Dim descripcion As String = TxtDescripcion.Text
            Dim valor As String = TxtValor.Text

            gestorBeneficios.editarBeneficio(idBeneficio, idTipo, nombre, descripcion, valor)

            MessageBox.Show("Beneficio modificado")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class