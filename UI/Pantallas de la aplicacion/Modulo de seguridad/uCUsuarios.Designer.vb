<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCUsuarios
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApellido1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApellido2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGenero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVerRol = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlAgregarTipoDeBeca = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
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
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(231, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar usuarios"
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.gridListaDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridListaDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colNombre1, Me.colNombre2, Me.colApellido1, Me.colApellido2, Me.colCorreo, Me.colGenero, Me.colTelefono, Me.colEstado, Me.colVerRol})
        Me.gridListaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridListaDatos.Location = New System.Drawing.Point(25, 68)
        Me.gridListaDatos.Margin = New System.Windows.Forms.Padding(25, 3, 25, 3)
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.ReadOnly = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.gridListaDatos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridListaDatos.RowTemplate.Height = 27
        Me.gridListaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaDatos.ShowCellErrors = False
        Me.gridListaDatos.ShowCellToolTips = False
        Me.gridListaDatos.ShowEditingIcon = False
        Me.gridListaDatos.ShowRowErrors = False
        Me.gridListaDatos.Size = New System.Drawing.Size(1057, 331)
        Me.gridListaDatos.TabIndex = 1
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colNombre1
        '
        Me.colNombre1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colNombre1.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNombre1.HeaderText = "Nombre"
        Me.colNombre1.Name = "colNombre1"
        Me.colNombre1.ReadOnly = True
        '
        'colNombre2
        '
        Me.colNombre2.HeaderText = "Segundo Nombre"
        Me.colNombre2.Name = "colNombre2"
        Me.colNombre2.ReadOnly = True
        Me.colNombre2.Width = 120
        '
        'colApellido1
        '
        Me.colApellido1.HeaderText = "Apellido"
        Me.colApellido1.Name = "colApellido1"
        Me.colApellido1.ReadOnly = True
        '
        'colApellido2
        '
        Me.colApellido2.HeaderText = "Segundo Apellido"
        Me.colApellido2.Name = "colApellido2"
        Me.colApellido2.ReadOnly = True
        '
        'colCorreo
        '
        Me.colCorreo.HeaderText = "Correo"
        Me.colCorreo.Name = "colCorreo"
        Me.colCorreo.ReadOnly = True
        Me.colCorreo.Width = 150
        '
        'colGenero
        '
        Me.colGenero.HeaderText = "Género"
        Me.colGenero.Name = "colGenero"
        Me.colGenero.ReadOnly = True
        '
        'colTelefono
        '
        Me.colTelefono.HeaderText = "Teléfono"
        Me.colTelefono.Name = "colTelefono"
        Me.colTelefono.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colVerRol
        '
        Me.colVerRol.HeaderText = "Rol"
        Me.colVerRol.Name = "colVerRol"
        Me.colVerRol.ReadOnly = True
        Me.colVerRol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVerRol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colVerRol.Text = "Ver"
        Me.colVerRol.UseColumnTextForButtonValue = True
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
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 337.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnEliminar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnModificar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.btnAgregar)
        Me.pnlAgregarTipoDeBeca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 402)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(1107, 337)
        Me.pnlAgregarTipoDeBeca.TabIndex = 2
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.DimGray
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(400, 17)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(174, 47)
        Me.btnEliminar.TabIndex = 27
        Me.btnEliminar.Text = "Eliminar usuario"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.Color.Green
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.ForeColor = System.Drawing.Color.White
        Me.btnModificar.Location = New System.Drawing.Point(211, 17)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(174, 47)
        Me.btnModificar.TabIndex = 26
        Me.btnModificar.Text = "Modificar usuario"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(25, 17)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(174, 47)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar usuario"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'uCUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCUsuarios"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApellido1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApellido2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGenero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTelefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVerRol As System.Windows.Forms.DataGridViewButtonColumn

End Class
