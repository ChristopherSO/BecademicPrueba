<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizarRequisito
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
        Me.pnlModificarRequisito = New System.Windows.Forms.Panel()
        Me.cmbTipoRequisito = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlModificarRequisito.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlModificarRequisito)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(580, 350)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlModificarRequisito
        '
        Me.pnlModificarRequisito.Controls.Add(Me.cmbTipoRequisito)
        Me.pnlModificarRequisito.Controls.Add(Me.lblTipo)
        Me.pnlModificarRequisito.Controls.Add(Me.txtDescripcion)
        Me.pnlModificarRequisito.Controls.Add(Me.Label1)
        Me.pnlModificarRequisito.Controls.Add(Me.txtNombre)
        Me.pnlModificarRequisito.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlModificarRequisito.Controls.Add(Me.lblSubTitulo)
        Me.pnlModificarRequisito.Controls.Add(Me.btnCancelar)
        Me.pnlModificarRequisito.Controls.Add(Me.btnGuardar)
        Me.pnlModificarRequisito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlModificarRequisito.Location = New System.Drawing.Point(0, 0)
        Me.pnlModificarRequisito.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlModificarRequisito.Name = "pnlModificarRequisito"
        Me.pnlModificarRequisito.Size = New System.Drawing.Size(580, 350)
        Me.pnlModificarRequisito.TabIndex = 3
        '
        'cmbTipoRequisito
        '
        Me.cmbTipoRequisito.FormattingEnabled = True
        Me.cmbTipoRequisito.Location = New System.Drawing.Point(133, 120)
        Me.cmbTipoRequisito.Name = "cmbTipoRequisito"
        Me.cmbTipoRequisito.Size = New System.Drawing.Size(421, 28)
        Me.cmbTipoRequisito.TabIndex = 20
        Me.cmbTipoRequisito.Text = "Imagen"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(19, 123)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(43, 20)
        Me.lblTipo.TabIndex = 19
        Me.lblTipo.Text = "Tipo:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(133, 160)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(421, 106)
        Me.txtDescripcion.TabIndex = 18
        Me.txtDescripcion.Text = "Documento de identidad costarricense, cedula de residencia o pasaporte."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(19, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Descripción:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(133, 76)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(421, 26)
        Me.txtNombre.TabIndex = 16
        Me.txtNombre.Text = "Documento de identidad"
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(19, 81)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(62, 17)
        Me.lblNombreTipoBeca.TabIndex = 15
        Me.lblNombreTipoBeca.Text = "Nombre:"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSubTitulo.Location = New System.Drawing.Point(17, 19)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(304, 29)
        Me.lblSubTitulo.TabIndex = 14
        Me.lblSubTitulo.Text = "Modificar requisito de beca"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(406, 279)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(249, 279)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmActualizarRequisito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 350)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmActualizarRequisito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modificar requisito"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlModificarRequisito.ResumeLayout(False)
        Me.pnlModificarRequisito.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlModificarRequisito As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoRequisito As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
End Class
