<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrarDirectoresCarrera
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContenidoPrincipal = New System.Windows.Forms.Panel()
        Me.pnlAdministrarDirectores = New System.Windows.Forms.Panel()
        Me.btnBorrarAsignacion = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvDirectores = New System.Windows.Forms.DataGridView()
        Me.cmbListaDirectores = New System.Windows.Forms.ComboBox()
        Me.lblNombreDirectorAcademico = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApellido1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAdministrarDirectores.SuspendLayout()
        CType(Me.dgvDirectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAdministrarDirectores)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(845, 435)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAdministrarDirectores
        '
        Me.pnlAdministrarDirectores.Controls.Add(Me.btnBorrarAsignacion)
        Me.pnlAdministrarDirectores.Controls.Add(Me.btnCancelar)
        Me.pnlAdministrarDirectores.Controls.Add(Me.dgvDirectores)
        Me.pnlAdministrarDirectores.Controls.Add(Me.cmbListaDirectores)
        Me.pnlAdministrarDirectores.Controls.Add(Me.lblNombreDirectorAcademico)
        Me.pnlAdministrarDirectores.Controls.Add(Me.btnGuardar)
        Me.pnlAdministrarDirectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAdministrarDirectores.Location = New System.Drawing.Point(0, 0)
        Me.pnlAdministrarDirectores.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdministrarDirectores.Name = "pnlAdministrarDirectores"
        Me.pnlAdministrarDirectores.Size = New System.Drawing.Size(845, 435)
        Me.pnlAdministrarDirectores.TabIndex = 3
        '
        'btnBorrarAsignacion
        '
        Me.btnBorrarAsignacion.BackColor = System.Drawing.Color.Green
        Me.btnBorrarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarAsignacion.ForeColor = System.Drawing.Color.White
        Me.btnBorrarAsignacion.Location = New System.Drawing.Point(481, 364)
        Me.btnBorrarAsignacion.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnBorrarAsignacion.Name = "btnBorrarAsignacion"
        Me.btnBorrarAsignacion.Size = New System.Drawing.Size(150, 47)
        Me.btnBorrarAsignacion.TabIndex = 25
        Me.btnBorrarAsignacion.Text = "Remover"
        Me.btnBorrarAsignacion.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(650, 364)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 24
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'dgvDirectores
        '
        Me.dgvDirectores.AllowUserToAddRows = False
        Me.dgvDirectores.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvDirectores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDirectores.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvDirectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDirectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre, Me.colApellido1})
        Me.dgvDirectores.Location = New System.Drawing.Point(22, 51)
        Me.dgvDirectores.Name = "dgvDirectores"
        Me.dgvDirectores.ReadOnly = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvDirectores.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDirectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDirectores.Size = New System.Drawing.Size(788, 268)
        Me.dgvDirectores.TabIndex = 23
        '
        'cmbListaDirectores
        '
        Me.cmbListaDirectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDirectores.FormattingEnabled = True
        Me.cmbListaDirectores.Location = New System.Drawing.Point(22, 377)
        Me.cmbListaDirectores.Name = "cmbListaDirectores"
        Me.cmbListaDirectores.Size = New System.Drawing.Size(256, 28)
        Me.cmbListaDirectores.TabIndex = 22
        '
        'lblNombreDirectorAcademico
        '
        Me.lblNombreDirectorAcademico.AutoSize = True
        Me.lblNombreDirectorAcademico.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreDirectorAcademico.Location = New System.Drawing.Point(19, 341)
        Me.lblNombreDirectorAcademico.Name = "lblNombreDirectorAcademico"
        Me.lblNombreDirectorAcademico.Size = New System.Drawing.Size(184, 17)
        Me.lblNombreDirectorAcademico.TabIndex = 16
        Me.lblNombreDirectorAcademico.Text = "Asignar director académico:"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(313, 364)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Asignar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'colId
        '
        Me.colId.HeaderText = "Id"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colApellido1
        '
        Me.colApellido1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colApellido1.HeaderText = "Primer Apellido"
        Me.colApellido1.Name = "colApellido1"
        Me.colApellido1.ReadOnly = True
        '
        'frmAdministrarDirectoresCarrera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 435)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAdministrarDirectoresCarrera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Directores académicos asignados"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAdministrarDirectores.ResumeLayout(False)
        Me.pnlAdministrarDirectores.PerformLayout()
        CType(Me.dgvDirectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAdministrarDirectores As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblNombreDirectorAcademico As System.Windows.Forms.Label
    Friend WithEvents cmbListaDirectores As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDirectores As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnBorrarAsignacion As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApellido1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
