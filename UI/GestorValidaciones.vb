Imports System.Text.RegularExpressions
Imports System.Threading

Public Class GestorValidaciones

    Private formularioPadre As Form
    Private contenedor As Panel
    Private nombreDelIcono As String
    Private iconoInformacion As Label

    Public GestorValidaciones()

    Public Sub activarValidaciones(pContenedor As Panel)
        contenedor = pContenedor
        For Each control As Control In contenedor.Controls

            If control.GetType Is GetType(TextBox) Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                AddHandler textBox.GotFocus, AddressOf textBoxConFoco
                AddHandler textBox.LostFocus, AddressOf textBoxSinFoco
            End If

            If control.GetType Is GetType(ComboBox) Then
                Dim comboBox As ComboBox = DirectCast(control, ComboBox)
                AddHandler comboBox.GotFocus, AddressOf comboBoxConFoco
                AddHandler comboBox.LostFocus, AddressOf comboBoxSinFoco
            End If

        Next
    End Sub

    Public Sub textBoxConFoco(pTextBox As TextBox, e As System.EventArgs)

        pTextBox.BackColor = Color.Lavender
        pTextBox.ForeColor = Color.Black

        formularioPadre = pTextBox.FindForm
        nombreDelIcono = "i" + pTextBox.Name
        If (formularioPadre.Controls.Find(nombreDelIcono, True).Length > 0) Then
            iconoInformacion = formularioPadre.Controls.Find(nombreDelIcono, True).ElementAt(0)
            contenedor.Controls.Remove(iconoInformacion)
        End If

    End Sub

    Public Sub textBoxSinFoco(textBox As TextBox, e As System.EventArgs)

        Dim tipoValidacion As String = textBox.Tag

        Select Case tipoValidacion
            Case "Txt", "txt", "TxtOpcional", "txtOpcional", "txtopcional"
                If contieneSoloLetras(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "El campo no debe contener solo números")
                End If
            Case "Num", "num", "NumOpcional", "numOpcional", "numopcional"
                If contieneSoloNumerosDecimales(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "El campo debe contener solo números")
                End If
            Case "Tel", "tel", "TelOpcional", "telOpcional", "telopcional"
                If esUnNumeroDeTelefono(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "Formato inválido. Ingrese 8 números sin espacios ni caracteres especiales")
                End If
            Case "Anio", "anio", "AnioOpcional", "anioOpcional", "anioopcional"
                If esUnAnio(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "Formato inválido. Ingrese 4 números sin espacios ni caracteres especiales")
                End If

            Case "Cedula", "cedula", "CedulaOpcional", "cedulaOpcional", "cedulaopcional"
                If esUnaCedula(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "Formato inválido. Ingrese 9 números")
                End If

            Case "Correo", "correo"
                If esUnCorreoDeCenfotec(textBox.Text) Then
                    textBox.ForeColor = Color.Black
                Else
                    avisarCampoInvalido(textBox, "Ingrese un correo de la universidad Cenfotec válido")
                End If
        End Select

        textBox.BackColor = Color.White
    End Sub

    Public Sub comboBoxConFoco(comboBox As ComboBox, e As System.EventArgs)

        comboBox.BackColor = Color.Lavender
        comboBox.ForeColor = Color.Black

        formularioPadre = comboBox.FindForm
        nombreDelIcono = "i" + comboBox.Name
        If (formularioPadre.Controls.Find(nombreDelIcono, True).Length > 0) Then
            iconoInformacion = formularioPadre.Controls.Find(nombreDelIcono, True).ElementAt(0)
            contenedor.Controls.Remove(iconoInformacion)
        End If

    End Sub

    Public Sub comboBoxSinFoco(comboBox As ComboBox, e As System.EventArgs)

        comboBox.BackColor = Color.White

    End Sub

    Private Sub avisarCampoInvalido(pTextBox As TextBox, pMensaje As String)

        Dim i As New Label
        i.Text = "i"
        i.Name = "i" + pTextBox.Name
        i.Location = New Point(pTextBox.Location.X + pTextBox.Size.Width, pTextBox.Location.Y)
        i.Font = New Font("Webdings", 16)
        i.ForeColor = Color.FromArgb(0, 255, 0, 0)
        contenedor.Controls.Add(i)
        pTextBox.ForeColor = Color.Red

        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(i, pMensaje)
        toolTip.ToolTipIcon = ToolTipIcon.Warning
        toolTip.ToolTipTitle = "Aviso"
        toolTip.IsBalloon = True

    End Sub

    Public Function camposEstanValidos(contenedor As Panel) As Boolean

        Dim contadorCamposVacios As Integer = 0
        Dim contadorCamposInvalidos As Integer = 0
        Dim contadorComboBoxSinSeleccionar As Integer = 0

        For Each control As Control In contenedor.Controls

            ' Evaluación de TexBoxes
            If (TypeOf control Is TextBox) Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                ' Evaluando espacios requeridos vacíos
                If (Not esUnCampoOpcional(textBox.Tag) And textBox.Text = "") Then
                    avisarCampoVacio(textBox)
                    contadorCamposVacios += 1
                End If
                ' Evaluando campos que tienen alerta de error
                If (textBox.ForeColor = Color.Red) Then
                    contadorCamposInvalidos += 1
                End If
            End If

            ' Evaluación de ComboBoxes
            If (TypeOf control Is ComboBox) Then
                Dim comboBox As ComboBox = DirectCast(control, ComboBox)
                If (Mid(comboBox.Text, 1, 1) = "(") Then
                    avisarComboBoxSinSeleccionar(comboBox)
                    contadorComboBoxSinSeleccionar += 1
                End If
            End If

        Next

        If (contadorCamposInvalidos > 0) Then
            Return False
        ElseIf (contadorCamposVacios > 0) Then
            Return False
        ElseIf (contadorComboBoxSinSeleccionar > 0) Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function esUnCampoOpcional(tag As String) As Boolean
        If (tag = "TxtOpcional" _
            Or tag = "txtOpcional" _
            Or tag = "txtopcional" _
            Or tag = "NumOpcional" _
            Or tag = "numOpcional" _
            Or tag = "numopcional" _
            Or tag = "TelOpcional" _
            Or tag = "telOpcional" _
            Or tag = "telopcional" _
            Or tag = "anioOpcional" _
            Or tag = "AnioOpcional" _
            Or tag = "anioOpcional" _
            Or tag = "CedulaOpcional" _
            Or tag = "cedulaOpcional" _
            Or tag = "cedulaopcional") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub avisarCampoVacio(pTextBox As TextBox)

        Dim i As New Label
        i.Text = "i"
        i.Name = "i" + pTextBox.Name
        i.Location = New Point(pTextBox.Location.X + pTextBox.Size.Width, pTextBox.Location.Y)
        i.Font = New Font("Webdings", 16)
        i.ForeColor = Color.Red
        contenedor.Controls.Add(i)
        pTextBox.BackColor = Color.LightPink

        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(i, "El campo no puede estar vacío")
        toolTip.ToolTipIcon = ToolTipIcon.Warning
        toolTip.ToolTipTitle = "Aviso"
        toolTip.IsBalloon = True

    End Sub

    Private Sub avisarComboBoxSinSeleccionar(pComboBox As ComboBox)

        Dim i As New Label
        i.Text = "i"
        i.Name = "i" + pComboBox.Name
        i.Location = New Point(pComboBox.Location.X + pComboBox.Size.Width, pComboBox.Location.Y)
        i.Font = New Font("Webdings", 16)
        i.ForeColor = Color.Red
        contenedor.Controls.Add(i)
        pComboBox.BackColor = Color.LightPink

        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(i, "Debe seleccionar una opción")
        toolTip.ToolTipIcon = ToolTipIcon.Warning
        toolTip.ToolTipTitle = "Aviso"
        toolTip.IsBalloon = True

    End Sub

    Private Function contieneSoloLetras(ByRef pTexto As String) As Boolean
        If pTexto = "" Or Regex.IsMatch(pTexto, "^[a-zA-Z]") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function contieneLetrasYNumeros(ByRef pTexto As String) As Boolean
        If pTexto = "" Or Regex.IsMatch(pTexto, "^[a-zA-Z0-9]") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function contieneSoloNumerosEnteros(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "^[0-9]") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function contieneSoloNumerosDecimales(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "^[0-9]{1,10}(\.[0-9]{0,10})?$") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function esUnNumeroDeTelefono(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "^[0-9]{8}") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function esUnaCedula(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "^[0-9]{9}") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function esUnAnio(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "^[0-9]{4}") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function esUnCorreoDeCenfotec(ByRef pNumero As String) As Boolean
        If pNumero = "" Or Regex.IsMatch(pNumero, "\w+([-+.']\w+)*@(ucenfotec.ac.cr)") Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
