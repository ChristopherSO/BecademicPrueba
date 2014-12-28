<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarBeneficio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlContenidoPrincipal = New System.Windows.Forms.Panel()
        Me.pnlAgregarTipoDeBeca = New System.Windows.Forms.Panel()
        Me.CmbTipoDeBeneficio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAgregarTipoDeBeca.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAgregarTipoDeBeca)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(604, 411)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.CmbTipoDeBeneficio)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label3)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.TxtValor)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label2)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.TxtDescripcion)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label1)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.TxtNombre)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.lblSubTitulo)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.BtnAgregar)
        Me.pnlAgregarTipoDeBeca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(604, 411)
        Me.pnlAgregarTipoDeBeca.TabIndex = 3
        '
        'CmbTipoDeBeneficio
        '
        Me.CmbTipoDeBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoDeBeneficio.FormattingEnabled = True
        Me.CmbTipoDeBeneficio.Location = New System.Drawing.Point(140, 73)
        Me.CmbTipoDeBeneficio.Name = "CmbTipoDeBeneficio"
        Me.CmbTipoDeBeneficio.Size = New System.Drawing.Size(421, 28)
        Me.CmbTipoDeBeneficio.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(35, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Valor:"
        '
        'TxtValor
        '
        Me.TxtValor.Location = New System.Drawing.Point(140, 290)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(80, 26)
        Me.TxtValor.TabIndex = 4
        Me.TxtValor.Tag = "numOpcional"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(35, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(140, 165)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(421, 106)
        Me.TxtDescripcion.TabIndex = 3
        Me.TxtDescripcion.Tag = "txtOpcional"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(35, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Descripción:"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(140, 120)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(421, 26)
        Me.TxtNombre.TabIndex = 2
        Me.TxtNombre.Tag = "txt"
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(35, 125)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(62, 17)
        Me.lblNombreTipoBeca.TabIndex = 15
        Me.lblNombreTipoBeca.Text = "Nombre:"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSubTitulo.Location = New System.Drawing.Point(33, 19)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(297, 29)
        Me.lblSubTitulo.TabIndex = 14
        Me.lblSubTitulo.Text = "Agregar beneficio de beca"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(411, 340)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.Color.White
        Me.BtnAgregar.Location = New System.Drawing.Point(240, 340)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(150, 47)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'frmAgregarBeneficio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 411)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarBeneficio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar beneficio de beca"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.pnlAgregarTipoDeBeca.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoDeBeneficio As System.Windows.Forms.ComboBox
End Class
