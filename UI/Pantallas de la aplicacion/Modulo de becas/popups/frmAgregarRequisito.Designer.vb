<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarRequisito
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
        Me.pnlAgregarRequisito = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbTipoRequisito = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.pnlAgregarRequisito.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAgregarRequisito
        '
        Me.pnlAgregarRequisito.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarRequisito.Controls.Add(Me.btnGuardar)
        Me.pnlAgregarRequisito.Controls.Add(Me.cmbTipoRequisito)
        Me.pnlAgregarRequisito.Controls.Add(Me.lblTipo)
        Me.pnlAgregarRequisito.Controls.Add(Me.txtDescripcion)
        Me.pnlAgregarRequisito.Controls.Add(Me.Label1)
        Me.pnlAgregarRequisito.Controls.Add(Me.txtNombre)
        Me.pnlAgregarRequisito.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlAgregarRequisito.Controls.Add(Me.lblSubTitulo)
        Me.pnlAgregarRequisito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarRequisito.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarRequisito.Name = "pnlAgregarRequisito"
        Me.pnlAgregarRequisito.Size = New System.Drawing.Size(580, 379)
        Me.pnlAgregarRequisito.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(407, 303)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 11, 3, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 51)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(233, 303)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 11, 3, 16)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 51)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'cmbTipoRequisito
        '
        Me.cmbTipoRequisito.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoRequisito.FormattingEnabled = True
        Me.cmbTipoRequisito.Location = New System.Drawing.Point(136, 122)
        Me.cmbTipoRequisito.Name = "cmbTipoRequisito"
        Me.cmbTipoRequisito.Size = New System.Drawing.Size(421, 26)
        Me.cmbTipoRequisito.TabIndex = 16
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(22, 126)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(41, 19)
        Me.lblTipo.TabIndex = 15
        Me.lblTipo.Text = "Tipo:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(136, 166)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(421, 115)
        Me.txtDescripcion.TabIndex = 14
        Me.txtDescripcion.Tag = "txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Descripción:"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(136, 75)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(421, 26)
        Me.txtNombre.TabIndex = 12
        Me.txtNombre.Tag = "txt"
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(22, 80)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(64, 19)
        Me.lblNombreTipoBeca.TabIndex = 11
        Me.lblNombreTipoBeca.Text = "Nombre:"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.Location = New System.Drawing.Point(16, 21)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(379, 33)
        Me.lblSubTitulo.TabIndex = 10
        Me.lblSubTitulo.Text = "Agregar nuevo requisito de beca"
        '
        'frmAgregarRequisito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 379)
        Me.Controls.Add(Me.pnlAgregarRequisito)
        Me.Name = "frmAgregarRequisito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Requisito"
        Me.pnlAgregarRequisito.ResumeLayout(False)
        Me.pnlAgregarRequisito.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAgregarRequisito As System.Windows.Forms.Panel
    Friend WithEvents cmbTipoRequisito As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
