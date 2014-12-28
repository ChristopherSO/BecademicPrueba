<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarDirectorCarrera
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbDirectoresAcademicos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccionBorrar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlContenidoPrincipal.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.Button1)
        Me.pnlContenidoPrincipal.Controls.Add(Me.cmbDirectoresAcademicos)
        Me.pnlContenidoPrincipal.Controls.Add(Me.Label1)
        Me.pnlContenidoPrincipal.Controls.Add(Me.DataGridView1)
        Me.pnlContenidoPrincipal.Controls.Add(Me.lblTitulo)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(692, 442)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(530, 372)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 50)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Asignar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbDirectoresAcademicos
        '
        Me.cmbDirectoresAcademicos.FormattingEnabled = True
        Me.cmbDirectoresAcademicos.Location = New System.Drawing.Point(16, 383)
        Me.cmbDirectoresAcademicos.Name = "cmbDirectoresAcademicos"
        Me.cmbDirectoresAcademicos.Size = New System.Drawing.Size(347, 28)
        Me.cmbDirectoresAcademicos.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 347)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Asignar director académico:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNombre, Me.colCodigo, Me.colAccionBorrar})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(664, 272)
        Me.DataGridView1.TabIndex = 1
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colAccionBorrar
        '
        Me.colAccionBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAccionBorrar.HeaderText = "Acciones"
        Me.colAccionBorrar.Name = "colAccionBorrar"
        Me.colAccionBorrar.ReadOnly = True
        Me.colAccionBorrar.Text = "Borrar"
        Me.colAccionBorrar.UseColumnTextForButtonValue = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(12, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(127, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Lista de carreras"
        '
        'frmAgregarDirectorCarrera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 442)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarDirectorCarrera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cursos asignados"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlContenidoPrincipal.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents cmbDirectoresAcademicos As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccionBorrar As System.Windows.Forms.DataGridViewButtonColumn
End Class
