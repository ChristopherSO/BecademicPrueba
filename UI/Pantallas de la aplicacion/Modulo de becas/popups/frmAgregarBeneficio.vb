Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede agregar un nuevo beneficio.
''' </summary>
Public Class frmAgregarBeneficio

    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Método que se ajecuta al iniciar el formulario el cual inicia la escucha de las validaciones y llama al método que llena las opciones del ComboBox de tipos de beneficios.
    ''' </summary>
    Private Sub frmActualizarBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarTipoDeBeca
        gestorValidaciones.activarValidaciones(contenedor)

        llenarComboBoxTiposDeBeneficios()

    End Sub

    ''' <summary>
    ''' Método que llena las opciones del ComboBox de tipos de beneficios.
    ''' </summary>
    Private Sub llenarComboBoxTiposDeBeneficios()

        Try
            Dim listaTiposDeBeneficios As IEnumerable = gestorBeneficios.buscarTiposDeBeneficios

            CmbTipoDeBeneficio.DataSource = listaTiposDeBeneficios
            CmbTipoDeBeneficio.ValueMember = "Id"
            CmbTipoDeBeneficio.DisplayMember = "Nombre"
            CmbTipoDeBeneficio.Text = "(Seleccione un tipo)"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de agregar beneficio cuando se presiona el botón Cancelar.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        CmbTipoDeBeneficio.Text = "(Seleccione un tipo)"
        TxtNombre.Clear()
        TxtDescripcion.Clear()
        TxtValor.Clear()
        Me.Close()

    End Sub

    ''' <summary>
    ''' Cuando se presiona el botón Agregar llama al método agregarBeneficio que ejecuta la acción agregar nuevo beneficio.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de guardar.</remarks>
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        Dim contenedor As Panel = pnlAgregarTipoDeBeca

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarBeneficio()
        End If

    End Sub

    ''' <summary>
    ''' Método que agrega un nuevo beneficio.
    ''' </summary>
    Private Sub agregarBeneficio()

        Try
            Dim idTipo As Integer = CmbTipoDeBeneficio.SelectedValue
            Dim nombre As String = TxtNombre.Text
            Dim descripcion As String = TxtDescripcion.Text
            Dim valor As String = TxtValor.Text

            gestorBeneficios.agregarBeneficio(idTipo, nombre, descripcion, valor)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class