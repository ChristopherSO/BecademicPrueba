<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCCarreras
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIcono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlAgregarTipoDeBeca = New System.Windows.Forms.Panel()
        Me.btnAdministrarDirectores = New System.Windows.Forms.Button()
        Me.btnAdministrarCursos = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.txtAgregarCarrera = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.tblTiposDeBecas.SuspendLayout()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAgregarTipoDeBeca.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(228, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar carreras"
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.gridListaDatos, 0, 1)
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlAgregarTipoDeBeca, 0, 2)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 4
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.gridListaDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridListaDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre, Me.colDescripcion, Me.colIcono, Me.colColor})
        Me.gridListaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaDatos.Location = New System.Drawing.Point(25, 68)
        Me.gridListaDatos.Margin = New System.Windows.Forms.Padding(25, 3, 25, 3)
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.ReadOnly = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.gridListaDatos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridListaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaDatos.Size = New System.Drawing.Size(1057, 331)
        Me.gridListaDatos.TabIndex = 1
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
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colIcono
        '
        Me.colIcono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colIcono.HeaderText = "Icono"
        Me.colIcono.Name = "colIcono"
        Me.colIcono.ReadOnly = True
        '
        'colColor
        '
        Me.colColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colColor.HeaderText = "Color"
        Me.colColor.Name = "colColor"
        Me.colColor.ReadOnly = True
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnAdministrarDirectores)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnAdministrarCursos)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnModificar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtAgregarCarrera)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnBorrar)
        Me.pnlAgregarTipoDeBeca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 402)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(1107, 300)
        Me.pnlAgregarTipoDeBeca.TabIndex = 2
        '
        'btnAdministrarDirectores
        '
        Me.btnAdministrarDirectores.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.btnAdministrarDirectores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdministrarDirectores.ForeColor = System.Drawing.Color.White
        Me.btnAdministrarDirectores.Location = New System.Drawing.Point(235, 104)
        Me.btnAdministrarDirectores.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAdministrarDirectores.Name = "btnAdministrarDirectores"
        Me.btnAdministrarDirectores.Size = New System.Drawing.Size(174, 47)
        Me.btnAdministrarDirectores.TabIndex = 15
        Me.btnAdministrarDirectores.Text = "Directores asociados"
        Me.btnAdministrarDirectores.UseVisualStyleBackColor = False
        '
        'btnAdministrarCursos
        '
        Me.btnAdministrarCursos.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.btnAdministrarCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdministrarCursos.ForeColor = System.Drawing.Color.White
        Me.btnAdministrarCursos.Location = New System.Drawing.Point(25, 104)
        Me.btnAdministrarCursos.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAdministrarCursos.Name = "btnAdministrarCursos"
        Me.btnAdministrarCursos.Size = New System.Drawing.Size(174, 47)
        Me.btnAdministrarCursos.TabIndex = 14
        Me.btnAdministrarCursos.Text = "Cursos asociados"
        Me.btnAdministrarCursos.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.Color.Green
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.ForeColor = System.Drawing.Color.White
        Me.btnModificar.Location = New System.Drawing.Point(235, 32)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(174, 47)
        Me.btnModificar.TabIndex = 13
        Me.btnModificar.Text = "Modificar carrera"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'txtAgregarCarrera
        '
        Me.txtAgregarCarrera.BackColor = System.Drawing.Color.DodgerBlue
        Me.txtAgregarCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtAgregarCarrera.ForeColor = System.Drawing.Color.White
        Me.txtAgregarCarrera.Location = New System.Drawing.Point(25, 32)
        Me.txtAgregarCarrera.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.txtAgregarCarrera.Name = "txtAgregarCarrera"
        Me.txtAgregarCarrera.Size = New System.Drawing.Size(174, 47)
        Me.txtAgregarCarrera.TabIndex = 3
        Me.txtAgregarCarrera.Text = "Agregar carrera"
        Me.txtAgregarCarrera.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.DimGray
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrar.ForeColor = System.Drawing.Color.White
        Me.btnBorrar.Location = New System.Drawing.Point(444, 32)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(174, 47)
        Me.btnBorrar.TabIndex = 12
        Me.btnBorrar.Text = "Eliminar carrera"
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'uCCarreras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCCarreras"
        Me.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents txtAgregarCarrera As System.Windows.Forms.Button
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAdministrarCursos As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIcono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAdministrarDirectores As System.Windows.Forms.Button

End Class
