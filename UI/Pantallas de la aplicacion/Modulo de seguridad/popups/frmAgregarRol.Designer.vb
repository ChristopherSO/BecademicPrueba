<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarRol
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
        Me.pnlAgregarRol = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFase = New System.Windows.Forms.ComboBox()
        Me.lblFaseDeIntervencion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAgregarRol.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAgregarRol)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(589, 383)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAgregarRol
        '
        Me.pnlAgregarRol.Controls.Add(Me.Label1)
        Me.pnlAgregarRol.Controls.Add(Me.cmbFase)
        Me.pnlAgregarRol.Controls.Add(Me.lblFaseDeIntervencion)
        Me.pnlAgregarRol.Controls.Add(Me.txtDescripcion)
        Me.pnlAgregarRol.Controls.Add(Me.lblDescripcion)
        Me.pnlAgregarRol.Controls.Add(Me.txtNombre)
        Me.pnlAgregarRol.Controls.Add(Me.lblNombre)
        Me.pnlAgregarRol.Controls.Add(Me.lblSubTitulo)
        Me.pnlAgregarRol.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarRol.Controls.Add(Me.btnGuardar)
        Me.pnlAgregarRol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarRol.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarRol.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarRol.Name = "pnlAgregarRol"
        Me.pnlAgregarRol.Size = New System.Drawing.Size(589, 383)
        Me.pnlAgregarRol.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(25, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 29)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Agregar rol"
        '
        'cmbFase
        '
        Me.cmbFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFase.FormattingEnabled = True
        Me.cmbFase.Location = New System.Drawing.Point(195, 231)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(367, 28)
        Me.cmbFase.TabIndex = 20
        '
        'lblFaseDeIntervencion
        '
        Me.lblFaseDeIntervencion.AutoSize = True
        Me.lblFaseDeIntervencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblFaseDeIntervencion.Location = New System.Drawing.Point(27, 236)
        Me.lblFaseDeIntervencion.Name = "lblFaseDeIntervencion"
        Me.lblFaseDeIntervencion.Size = New System.Drawing.Size(144, 17)
        Me.lblFaseDeIntervencion.TabIndex = 19
        Me.lblFaseDeIntervencion.Text = "Fase de intervención:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(195, 118)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(367, 93)
        Me.txtDescripcion.TabIndex = 18
        Me.txtDescripcion.Tag = "opcional"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblDescripcion.Location = New System.Drawing.Point(27, 123)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(86, 17)
        Me.lblDescripcion.TabIndex = 17
        Me.lblDescripcion.Text = "Descripción:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(195, 69)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(367, 26)
        Me.txtNombre.TabIndex = 16
        Me.txtNombre.Tag = "txt"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombre.Location = New System.Drawing.Point(23, 69)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(62, 17)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre:"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSubTitulo.Location = New System.Drawing.Point(21, 19)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(0, 29)
        Me.lblSubTitulo.TabIndex = 14
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(412, 312)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(238, 312)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmAgregarRol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 383)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarRol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar rol"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAgregarRol.ResumeLayout(False)
        Me.pnlAgregarRol.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAgregarRol As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbFase As System.Windows.Forms.ComboBox
    Friend WithEvents lblFaseDeIntervencion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
