<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCHistorialAcademico
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
        Me.pa_reporte_historial_academicoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.beca_becademicDataSet = New UI.beca_becademicDataSet()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.rpvHistorialAcademico = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlParameters = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.txtCarnet = New System.Windows.Forms.MaskedTextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblCantResultado = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHistorialAcademico = New System.Windows.Forms.Label()
        Me.pa_reporte_historial_academicoTableAdapter = New UI.beca_becademicDataSetTableAdapters.pa_reporte_historial_academicoTableAdapter()
        Me.cmbCarreras = New System.Windows.Forms.ComboBox()
        CType(Me.pa_reporte_historial_academicoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlParameters.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pa_reporte_historial_academicoBindingSource
        '
        Me.pa_reporte_historial_academicoBindingSource.DataMember = "pa_reporte_historial_academico"
        Me.pa_reporte_historial_academicoBindingSource.DataSource = Me.beca_becademicDataSet
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
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.rpvHistorialAcademico)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(3, 192)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1101, 561)
        Me.pnlPrincipal.TabIndex = 0
        '
        'rpvHistorialAcademico
        '
        Me.rpvHistorialAcademico.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetReportes"
        ReportDataSource1.Value = Me.pa_reporte_historial_academicoBindingSource
        Me.rpvHistorialAcademico.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvHistorialAcademico.LocalReport.ReportEmbeddedResource = "UI.ReporteHistorialAcademico.rdlc"
        Me.rpvHistorialAcademico.Location = New System.Drawing.Point(0, 0)
        Me.rpvHistorialAcademico.Name = "rpvHistorialAcademico"
        Me.rpvHistorialAcademico.Size = New System.Drawing.Size(1101, 561)
        Me.rpvHistorialAcademico.TabIndex = 0
        '
        'pnlParameters
        '
        Me.pnlParameters.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParameters.Location = New System.Drawing.Point(3, 79)
        Me.pnlParameters.Name = "pnlParameters"
        Me.pnlParameters.Size = New System.Drawing.Size(1101, 107)
        Me.pnlParameters.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.4723!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5277!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlCampos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlButton, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1101, 107)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.txtCarnet)
        Me.pnlCampos.Controls.Add(Me.lblMsg)
        Me.pnlCampos.Controls.Add(Me.cmbCarreras)
        Me.pnlCampos.Controls.Add(Me.lblCantResultado)
        Me.pnlCampos.Controls.Add(Me.lblCarrera)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCampos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCampos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(885, 107)
        Me.pnlCampos.TabIndex = 0
        '
        'txtCarnet
        '
        Me.txtCarnet.Location = New System.Drawing.Point(209, 32)
        Me.txtCarnet.Mask = "000000000"
        Me.txtCarnet.Name = "txtCarnet"
        Me.txtCarnet.Size = New System.Drawing.Size(197, 26)
        Me.txtCarnet.TabIndex = 18
        Me.txtCarnet.Tag = "cedula"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Maroon
        Me.lblMsg.Location = New System.Drawing.Point(216, 63)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 13)
        Me.lblMsg.TabIndex = 17
        '
        'lblCantResultado
        '
        Me.lblCantResultado.AutoSize = True
        Me.lblCantResultado.Location = New System.Drawing.Point(52, 30)
        Me.lblCantResultado.Name = "lblCantResultado"
        Me.lblCantResultado.Size = New System.Drawing.Size(136, 20)
        Me.lblCantResultado.TabIndex = 11
        Me.lblCantResultado.Text = "Carnet estudiante"
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Location = New System.Drawing.Point(506, 30)
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
        Me.pnlButton.Size = New System.Drawing.Size(216, 107)
        Me.pnlButton.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.ForestGreen
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(40, 30)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(150, 47)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblHistorialAcademico)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1107, 76)
        Me.pnlHeader.TabIndex = 2
        '
        'lblHistorialAcademico
        '
        Me.lblHistorialAcademico.AutoSize = True
        Me.lblHistorialAcademico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistorialAcademico.Location = New System.Drawing.Point(370, 24)
        Me.lblHistorialAcademico.Name = "lblHistorialAcademico"
        Me.lblHistorialAcademico.Size = New System.Drawing.Size(314, 29)
        Me.lblHistorialAcademico.TabIndex = 0
        Me.lblHistorialAcademico.Text = "Reporte historial académico"
        '
        'pa_reporte_historial_academicoTableAdapter
        '
        Me.pa_reporte_historial_academicoTableAdapter.ClearBeforeFill = True
        '
        'cmbCarreras
        '
        Me.cmbCarreras.DisplayMember = "0"
        Me.cmbCarreras.FormattingEnabled = True
        Me.cmbCarreras.Location = New System.Drawing.Point(583, 30)
        Me.cmbCarreras.Name = "cmbCarreras"
        Me.cmbCarreras.Size = New System.Drawing.Size(215, 28)
        Me.cmbCarreras.TabIndex = 14
        Me.cmbCarreras.Text = "(Seleccione una opción)"
        '
        'uCHistorialAcademico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCHistorialAcademico"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.pa_reporte_historial_academicoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlParameters.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents rpvHistorialAcademico As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlParameters As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHistorialAcademico As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents lblCantResultado As System.Windows.Forms.Label
    Friend WithEvents lblCarrera As System.Windows.Forms.Label
    Friend WithEvents pa_reporte_historial_academicoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents beca_becademicDataSet As UI.beca_becademicDataSet
    Friend WithEvents pa_reporte_historial_academicoTableAdapter As UI.beca_becademicDataSetTableAdapters.pa_reporte_historial_academicoTableAdapter
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents txtCarnet As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmbCarreras As System.Windows.Forms.ComboBox

End Class
