<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCMejoresPromediosXCarrera
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.pa_reporte_mejores_promedios_por_carreraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.beca_becademicDataSet = New UI.beca_becademicDataSet()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.rpvMejorPromedioPorCarrera = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlParameters = New System.Windows.Forms.Panel()
        Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.cmbPeriodoInicial = New System.Windows.Forms.ComboBox()
        Me.lblMsgAnio = New System.Windows.Forms.Label()
        Me.lblMsgPeriodo = New System.Windows.Forms.Label()
        Me.txtAnioFinal = New System.Windows.Forms.TextBox()
        Me.txtAnioInicio = New System.Windows.Forms.TextBox()
        Me.cmbPeriodoFinal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPeriodoFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblPeriodoInicio = New System.Windows.Forms.Label()
        Me.lblMsgCantResultado = New System.Windows.Forms.Label()
        Me.txtCantResultado = New System.Windows.Forms.TextBox()
        Me.lblCantResultado = New System.Windows.Forms.Label()
        Me.cmbCarreras = New System.Windows.Forms.ComboBox()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblMejorPromedioXCarrera = New System.Windows.Forms.Label()
        Me.pa_reporte_mejores_promedios_por_carreraTableAdapter = New UI.beca_becademicDataSetTableAdapters.pa_reporte_mejores_promedios_por_carreraTableAdapter()
        CType(Me.pa_reporte_mejores_promedios_por_carreraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlParameters.SuspendLayout()
        Me.tlpHeader.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pa_reporte_mejores_promedios_por_carreraBindingSource
        '
        Me.pa_reporte_mejores_promedios_por_carreraBindingSource.DataMember = "pa_reporte_mejores_promedios_por_carrera"
        Me.pa_reporte_mejores_promedios_por_carreraBindingSource.DataSource = Me.beca_becademicDataSet
        '
        'beca_becademicDataSet
        '
        Me.beca_becademicDataSet.DataSetName = "beca_becademicDataSet"
        Me.beca_becademicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.pnlPrincipal, 0, 2)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlParameters, 0, 1)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlHeader, 0, 0)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 3
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.rpvMejorPromedioPorCarrera)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(3, 235)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1101, 518)
        Me.pnlPrincipal.TabIndex = 0
        '
        'rpvMejorPromedioPorCarrera
        '
        Me.rpvMejorPromedioPorCarrera.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "MejoresPromediosXCarreraDataSet"
        ReportDataSource1.Value = Me.pa_reporte_mejores_promedios_por_carreraBindingSource
        Me.rpvMejorPromedioPorCarrera.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvMejorPromedioPorCarrera.LocalReport.ReportEmbeddedResource = "UI.ReporteMejoresPromediosXCarrera.rdlc"
        Me.rpvMejorPromedioPorCarrera.Location = New System.Drawing.Point(0, 0)
        Me.rpvMejorPromedioPorCarrera.Name = "rpvMejorPromedioPorCarrera"
        Me.rpvMejorPromedioPorCarrera.Size = New System.Drawing.Size(1101, 518)
        Me.rpvMejorPromedioPorCarrera.TabIndex = 0
        '
        'pnlParameters
        '
        Me.pnlParameters.Controls.Add(Me.tlpHeader)
        Me.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParameters.Location = New System.Drawing.Point(3, 79)
        Me.pnlParameters.Name = "pnlParameters"
        Me.pnlParameters.Size = New System.Drawing.Size(1101, 150)
        Me.pnlParameters.TabIndex = 1
        '
        'tlpHeader
        '
        Me.tlpHeader.ColumnCount = 2
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.4723!))
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5277!))
        Me.tlpHeader.Controls.Add(Me.pnlCampos, 0, 0)
        Me.tlpHeader.Controls.Add(Me.pnlButton, 1, 0)
        Me.tlpHeader.Location = New System.Drawing.Point(0, 0)
        Me.tlpHeader.Name = "tlpHeader"
        Me.tlpHeader.RowCount = 1
        Me.tlpHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpHeader.Size = New System.Drawing.Size(1101, 150)
        Me.tlpHeader.TabIndex = 0
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.cmbPeriodoInicial)
        Me.pnlCampos.Controls.Add(Me.lblMsgAnio)
        Me.pnlCampos.Controls.Add(Me.lblMsgPeriodo)
        Me.pnlCampos.Controls.Add(Me.txtAnioFinal)
        Me.pnlCampos.Controls.Add(Me.txtAnioInicio)
        Me.pnlCampos.Controls.Add(Me.cmbPeriodoFinal)
        Me.pnlCampos.Controls.Add(Me.Label4)
        Me.pnlCampos.Controls.Add(Me.lblPeriodoFinal)
        Me.pnlCampos.Controls.Add(Me.lblFechaInicio)
        Me.pnlCampos.Controls.Add(Me.lblPeriodoInicio)
        Me.pnlCampos.Controls.Add(Me.lblMsgCantResultado)
        Me.pnlCampos.Controls.Add(Me.txtCantResultado)
        Me.pnlCampos.Controls.Add(Me.lblCantResultado)
        Me.pnlCampos.Controls.Add(Me.cmbCarreras)
        Me.pnlCampos.Controls.Add(Me.lblCarrera)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCampos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCampos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(885, 150)
        Me.pnlCampos.TabIndex = 0
        '
        'cmbPeriodoInicial
        '
        Me.cmbPeriodoInicial.FormattingEnabled = True
        Me.cmbPeriodoInicial.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoInicial.Location = New System.Drawing.Point(213, 15)
        Me.cmbPeriodoInicial.Name = "cmbPeriodoInicial"
        Me.cmbPeriodoInicial.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoInicial.TabIndex = 42
        Me.cmbPeriodoInicial.Text = "(Seleciones una opción)"
        '
        'lblMsgAnio
        '
        Me.lblMsgAnio.AutoSize = True
        Me.lblMsgAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgAnio.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgAnio.Location = New System.Drawing.Point(308, 76)
        Me.lblMsgAnio.Name = "lblMsgAnio"
        Me.lblMsgAnio.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgAnio.TabIndex = 41
        '
        'lblMsgPeriodo
        '
        Me.lblMsgPeriodo.AutoSize = True
        Me.lblMsgPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgPeriodo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgPeriodo.Location = New System.Drawing.Point(210, 43)
        Me.lblMsgPeriodo.Name = "lblMsgPeriodo"
        Me.lblMsgPeriodo.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgPeriodo.TabIndex = 40
        '
        'txtAnioFinal
        '
        Me.txtAnioFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioFinal.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioFinal.Location = New System.Drawing.Point(654, 62)
        Me.txtAnioFinal.Name = "txtAnioFinal"
        Me.txtAnioFinal.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioFinal.TabIndex = 39
        Me.txtAnioFinal.Tag = "anio"
        '
        'txtAnioInicio
        '
        Me.txtAnioInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioInicio.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioInicio.Location = New System.Drawing.Point(213, 63)
        Me.txtAnioInicio.Name = "txtAnioInicio"
        Me.txtAnioInicio.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioInicio.TabIndex = 38
        Me.txtAnioInicio.Tag = "anio"
        '
        'cmbPeriodoFinal
        '
        Me.cmbPeriodoFinal.DisplayMember = "0"
        Me.cmbPeriodoFinal.FormattingEnabled = True
        Me.cmbPeriodoFinal.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoFinal.Location = New System.Drawing.Point(654, 15)
        Me.cmbPeriodoFinal.Name = "cmbPeriodoFinal"
        Me.cmbPeriodoFinal.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoFinal.TabIndex = 37
        Me.cmbPeriodoFinal.Text = "(Seleccione una opción)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(538, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Año final"
        '
        'lblPeriodoFinal
        '
        Me.lblPeriodoFinal.AutoSize = True
        Me.lblPeriodoFinal.Location = New System.Drawing.Point(538, 18)
        Me.lblPeriodoFinal.Name = "lblPeriodoFinal"
        Me.lblPeriodoFinal.Size = New System.Drawing.Size(96, 20)
        Me.lblPeriodoFinal.TabIndex = 34
        Me.lblPeriodoFinal.Text = "Periodo final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(31, 65)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(77, 20)
        Me.lblFechaInicio.TabIndex = 33
        Me.lblFechaInicio.Text = "Año inicio"
        '
        'lblPeriodoInicio
        '
        Me.lblPeriodoInicio.AutoSize = True
        Me.lblPeriodoInicio.Location = New System.Drawing.Point(31, 15)
        Me.lblPeriodoInicio.Name = "lblPeriodoInicio"
        Me.lblPeriodoInicio.Size = New System.Drawing.Size(102, 20)
        Me.lblPeriodoInicio.TabIndex = 32
        Me.lblPeriodoInicio.Text = "Periodo inicio"
        '
        'lblMsgCantResultado
        '
        Me.lblMsgCantResultado.AutoSize = True
        Me.lblMsgCantResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgCantResultado.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgCantResultado.Location = New System.Drawing.Point(419, 124)
        Me.lblMsgCantResultado.Name = "lblMsgCantResultado"
        Me.lblMsgCantResultado.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgCantResultado.TabIndex = 31
        '
        'txtCantResultado
        '
        Me.txtCantResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantResultado.ForeColor = System.Drawing.Color.LightGray
        Me.txtCantResultado.Location = New System.Drawing.Point(213, 113)
        Me.txtCantResultado.Name = "txtCantResultado"
        Me.txtCantResultado.Size = New System.Drawing.Size(200, 26)
        Me.txtCantResultado.TabIndex = 30
        Me.txtCantResultado.Tag = "num"
        '
        'lblCantResultado
        '
        Me.lblCantResultado.AutoSize = True
        Me.lblCantResultado.Location = New System.Drawing.Point(31, 114)
        Me.lblCantResultado.Name = "lblCantResultado"
        Me.lblCantResultado.Size = New System.Drawing.Size(138, 20)
        Me.lblCantResultado.TabIndex = 29
        Me.lblCantResultado.Text = "Cantidad registros"
        '
        'cmbCarreras
        '
        Me.cmbCarreras.DisplayMember = "0"
        Me.cmbCarreras.FormattingEnabled = True
        Me.cmbCarreras.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbCarreras.Location = New System.Drawing.Point(654, 110)
        Me.cmbCarreras.Name = "cmbCarreras"
        Me.cmbCarreras.Size = New System.Drawing.Size(200, 28)
        Me.cmbCarreras.TabIndex = 14
        Me.cmbCarreras.Text = "(Seleccione una opción)"
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Location = New System.Drawing.Point(538, 113)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(62, 20)
        Me.lblCarrera.TabIndex = 10
        Me.lblCarrera.Text = "Carrera"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnGenerar)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlButton.Location = New System.Drawing.Point(885, 0)
        Me.pnlButton.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(216, 150)
        Me.pnlButton.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.ForestGreen
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(34, 53)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(150, 47)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblMejorPromedioXCarrera)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1107, 76)
        Me.pnlHeader.TabIndex = 2
        '
        'lblMejorPromedioXCarrera
        '
        Me.lblMejorPromedioXCarrera.AutoSize = True
        Me.lblMejorPromedioXCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMejorPromedioXCarrera.Location = New System.Drawing.Point(332, 20)
        Me.lblMejorPromedioXCarrera.Name = "lblMejorPromedioXCarrera"
        Me.lblMejorPromedioXCarrera.Size = New System.Drawing.Size(440, 29)
        Me.lblMejorPromedioXCarrera.TabIndex = 0
        Me.lblMejorPromedioXCarrera.Text = "Reporte mejores promedios por carrera"
        '
        'pa_reporte_mejores_promedios_por_carreraTableAdapter
        '
        Me.pa_reporte_mejores_promedios_por_carreraTableAdapter.ClearBeforeFill = True
        '
        'uCMejoresPromediosXCarrera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCMejoresPromediosXCarrera"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.pa_reporte_mejores_promedios_por_carreraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlParameters.ResumeLayout(False)
        Me.tlpHeader.ResumeLayout(False)
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents rpvMejorPromedioPorCarrera As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlParameters As System.Windows.Forms.Panel
    Friend WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblMejorPromedioXCarrera As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbCarreras As System.Windows.Forms.ComboBox
    Friend WithEvents lblCarrera As System.Windows.Forms.Label
    Friend WithEvents lblMsgAnio As System.Windows.Forms.Label
    Friend WithEvents lblMsgPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtAnioFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtAnioInicio As System.Windows.Forms.TextBox
    Friend WithEvents cmbPeriodoFinal As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoFinal As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoInicio As System.Windows.Forms.Label
    Friend WithEvents lblMsgCantResultado As System.Windows.Forms.Label
    Friend WithEvents txtCantResultado As System.Windows.Forms.TextBox
    Friend WithEvents lblCantResultado As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoInicial As System.Windows.Forms.ComboBox
    Friend WithEvents pa_reporte_mejores_promedios_por_carreraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents beca_becademicDataSet As UI.beca_becademicDataSet
    Friend WithEvents pa_reporte_mejores_promedios_por_carreraTableAdapter As UI.beca_becademicDataSetTableAdapters.pa_reporte_mejores_promedios_por_carreraTableAdapter

End Class
