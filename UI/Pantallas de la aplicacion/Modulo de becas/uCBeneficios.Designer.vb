<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCBeneficios
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.dgvBeneficios = New System.Windows.Forms.DataGridView()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlAgregarTipoDeBeca = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.BtnModificar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoBeneficio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvBeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlAgregarTipoDeBeca.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(356, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar beneficios de becas"
        '
        'dgvBeneficios
        '
        Me.dgvBeneficios.AllowUserToAddRows = False
        Me.dgvBeneficios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvBeneficios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBeneficios.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBeneficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBeneficios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.TipoBeneficio, Me.Nombre, Me.Descripcion, Me.Valor})
        Me.dgvBeneficios.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBeneficios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBeneficios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBeneficios.Location = New System.Drawing.Point(25, 68)
        Me.dgvBeneficios.Margin = New System.Windows.Forms.Padding(25, 3, 25, 3)
        Me.dgvBeneficios.MultiSelect = False
        Me.dgvBeneficios.Name = "dgvBeneficios"
        Me.dgvBeneficios.ReadOnly = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvBeneficios.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBeneficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBeneficios.Size = New System.Drawing.Size(1057, 331)
        Me.dgvBeneficios.TabIndex = 1
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.dgvBeneficios, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlAgregarTipoDeBeca, 0, 2)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 3
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 402)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(1107, 90)
        Me.pnlAgregarTipoDeBeca.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnAgregar)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnModificar)
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnEliminar)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1107, 124)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.Color.White
        Me.BtnAgregar.Location = New System.Drawing.Point(10, 20)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(174, 47)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "Agregar beneficio"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.Green
        Me.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.ForeColor = System.Drawing.Color.White
        Me.BtnModificar.Location = New System.Drawing.Point(204, 20)
        Me.BtnModificar.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(174, 47)
        Me.BtnModificar.TabIndex = 12
        Me.BtnModificar.Text = "Modificar beneficio"
        Me.BtnModificar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.DimGray
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.ForeColor = System.Drawing.Color.White
        Me.BtnEliminar.Location = New System.Drawing.Point(398, 20)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(10, 20, 25, 10)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(174, 47)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "Eliminar beneficio"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'TipoBeneficio
        '
        Me.TipoBeneficio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipoBeneficio.HeaderText = "Tipo de beneficio"
        Me.TipoBeneficio.Name = "TipoBeneficio"
        Me.TipoBeneficio.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Valor
        '
        Me.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        '
        'uCBeneficios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCBeneficios"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.dgvBeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents dgvBeneficios As System.Windows.Forms.DataGridView
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnModificar As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoBeneficio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
