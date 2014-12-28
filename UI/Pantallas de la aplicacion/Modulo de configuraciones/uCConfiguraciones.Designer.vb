<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCConfiguraciones
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
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(310, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar configuraciones"
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNombre, Me.colValor})
        Me.gridListaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaDatos.Location = New System.Drawing.Point(25, 63)
        Me.gridListaDatos.Margin = New System.Windows.Forms.Padding(25, 3, 25, 3)
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.Size = New System.Drawing.Size(1057, 600)
        Me.gridListaDatos.TabIndex = 1
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colValor
        '
        Me.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colValor.HeaderText = "Valor"
        Me.colValor.Name = "colValor"
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.gridListaDatos, 0, 1)
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.btnGuardar, 0, 2)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 3
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(135, 676)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(174, 47)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'uCConfiguraciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCConfiguraciones"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValor As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
