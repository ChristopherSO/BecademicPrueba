<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarCurso
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
        Me.txtCreditos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
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
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(624, 351)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtCreditos)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label3)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtPrecio)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label2)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtCodigo)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label1)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtNombre)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Label4)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnGuardar)
        Me.pnlAgregarTipoDeBeca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(624, 351)
        Me.pnlAgregarTipoDeBeca.TabIndex = 3
        '
        'txtCreditos
        '
        Me.txtCreditos.Location = New System.Drawing.Point(140, 226)
        Me.txtCreditos.Name = "txtCreditos"
        Me.txtCreditos.Size = New System.Drawing.Size(421, 26)
        Me.txtCreditos.TabIndex = 24
        Me.txtCreditos.Tag = "num"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(26, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Creditos:"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(140, 172)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(421, 26)
        Me.txtPrecio.TabIndex = 22
        Me.txtPrecio.Tag = "num"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(26, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Precio:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(140, 123)
        Me.txtCodigo.Multiline = True
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(421, 24)
        Me.txtCodigo.TabIndex = 20
        Me.txtCodigo.Tag = "txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(26, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Código:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(140, 73)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(421, 26)
        Me.txtNombre.TabIndex = 18
        Me.txtNombre.Tag = "txt"
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(26, 78)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(62, 17)
        Me.lblNombreTipoBeca.TabIndex = 17
        Me.lblNombreTipoBeca.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label4.Location = New System.Drawing.Point(18, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(235, 29)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Agregar nuevo curso"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(254, 287)
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
        Me.btnGuardar.Location = New System.Drawing.Point(411, 287)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmAgregarCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 351)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar curso"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.pnlAgregarTipoDeBeca.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCreditos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
End Class
