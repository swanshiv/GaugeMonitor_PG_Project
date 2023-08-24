<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Measure
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TriColorColumn = New System.Windows.Forms.Panel
        Me.triColorRunChart = New VersaGageMonitor.RunChart
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCustName = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnCreateFile = New System.Windows.Forms.Button
        Me.lbllslColor = New System.Windows.Forms.Label
        Me.btnSelectFile = New System.Windows.Forms.Button
        Me.txtlsl = New System.Windows.Forms.TextBox
        Me.lblnvColor = New System.Windows.Forms.Label
        Me.txtnv = New System.Windows.Forms.TextBox
        Me.lblnvtext = New System.Windows.Forms.Label
        Me.lbllclColor = New System.Windows.Forms.Label
        Me.lbllsltext = New System.Windows.Forms.Label
        Me.lbllcltext = New System.Windows.Forms.Label
        Me.txtlcl = New System.Windows.Forms.TextBox
        Me.lbluclColor = New System.Windows.Forms.Label
        Me.lbluslColor = New System.Windows.Forms.Label
        Me.lblusltext = New System.Windows.Forms.Label
        Me.txtusl = New System.Windows.Forms.TextBox
        Me.txtucl = New System.Windows.Forms.TextBox
        Me.lblucltext = New System.Windows.Forms.Label
        Me.cmbPart = New System.Windows.Forms.ComboBox
        Me.PartdetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VersaGageMonitorDataSet = New VersaGageMonitor.VersaGageMonitorDataSet
        Me.lblMeasurement = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblReadingSaved = New System.Windows.Forms.Label
        Me.btnResetCounter = New System.Windows.Forms.Button
        Me.lblCounter = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lblFileSel = New System.Windows.Forms.Label
        Me.PartdetailsTableAdapter = New VersaGageMonitor.VersaGageMonitorDataSetTableAdapters.partdetailsTableAdapter
        Me.TriColorColumn.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PartdetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VersaGageMonitorDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TriColorColumn
        '
        Me.TriColorColumn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TriColorColumn.Controls.Add(Me.triColorRunChart)
        Me.TriColorColumn.Controls.Add(Me.GroupBox2)
        Me.TriColorColumn.Controls.Add(Me.DataGridView1)
        Me.TriColorColumn.Location = New System.Drawing.Point(9, 9)
        Me.TriColorColumn.Name = "TriColorColumn"
        Me.TriColorColumn.Size = New System.Drawing.Size(1019, 590)
        Me.TriColorColumn.TabIndex = 10
        '
        'triColorRunChart
        '
        Me.triColorRunChart.BackColor = System.Drawing.Color.Black
        Me.triColorRunChart.Clickable = True
        Me.triColorRunChart.ControlCause = 0.0!
        Me.triColorRunChart.Location = New System.Drawing.Point(6, 302)
        Me.triColorRunChart.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.triColorRunChart.Name = "triColorRunChart"
        Me.triColorRunChart.RunChartCurrentSampleCount = 50
        Me.triColorRunChart.RunChartLCL = -0.025!
        Me.triColorRunChart.RunChartLCLColor = System.Drawing.Color.Yellow
        Me.triColorRunChart.RunChartLSL = -0.04!
        Me.triColorRunChart.RunChartLSLColor = System.Drawing.Color.Red
        Me.triColorRunChart.RunChartNominal = 0.0!
        Me.triColorRunChart.RunChartNominalColor = System.Drawing.Color.Green
        Me.triColorRunChart.RunChartSamplesValue = 0.0!
        Me.triColorRunChart.RunChartTotalSampleCount = 50
        Me.triColorRunChart.RunChartUCL = 0.025!
        Me.triColorRunChart.RunChartUCLColor = System.Drawing.Color.Yellow
        Me.triColorRunChart.RunChartUSL = 0.04!
        Me.triColorRunChart.RunChartUSLColor = System.Drawing.Color.Red
        Me.triColorRunChart.Size = New System.Drawing.Size(749, 279)
        Me.triColorRunChart.TabIndex = 51
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(755, 293)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCustName)
        Me.Panel2.Controls.Add(Me.btnStart)
        Me.Panel2.Controls.Add(Me.btnCreateFile)
        Me.Panel2.Controls.Add(Me.lbllslColor)
        Me.Panel2.Controls.Add(Me.btnSelectFile)
        Me.Panel2.Controls.Add(Me.txtlsl)
        Me.Panel2.Controls.Add(Me.lblnvColor)
        Me.Panel2.Controls.Add(Me.txtnv)
        Me.Panel2.Controls.Add(Me.lblnvtext)
        Me.Panel2.Controls.Add(Me.lbllclColor)
        Me.Panel2.Controls.Add(Me.lbllsltext)
        Me.Panel2.Controls.Add(Me.lbllcltext)
        Me.Panel2.Controls.Add(Me.txtlcl)
        Me.Panel2.Controls.Add(Me.lbluclColor)
        Me.Panel2.Controls.Add(Me.lbluslColor)
        Me.Panel2.Controls.Add(Me.lblusltext)
        Me.Panel2.Controls.Add(Me.txtusl)
        Me.Panel2.Controls.Add(Me.txtucl)
        Me.Panel2.Controls.Add(Me.lblucltext)
        Me.Panel2.Controls.Add(Me.cmbPart)
        Me.Panel2.Controls.Add(Me.lblMeasurement)
        Me.Panel2.Location = New System.Drawing.Point(4, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(745, 226)
        Me.Panel2.TabIndex = 54
        '
        'lblCustName
        '
        Me.lblCustName.BackColor = System.Drawing.Color.Transparent
        Me.lblCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustName.ForeColor = System.Drawing.Color.Black
        Me.lblCustName.Location = New System.Drawing.Point(182, 53)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(551, 20)
        Me.lblCustName.TabIndex = 50
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(6, 102)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(154, 49)
        Me.btnStart.TabIndex = 55
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnCreateFile
        '
        Me.btnCreateFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateFile.ForeColor = System.Drawing.Color.Black
        Me.btnCreateFile.Location = New System.Drawing.Point(6, 58)
        Me.btnCreateFile.Name = "btnCreateFile"
        Me.btnCreateFile.Size = New System.Drawing.Size(154, 38)
        Me.btnCreateFile.TabIndex = 57
        Me.btnCreateFile.Text = "Create Data File"
        Me.btnCreateFile.UseVisualStyleBackColor = True
        '
        'lbllslColor
        '
        Me.lbllslColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbllslColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllslColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllslColor.Location = New System.Drawing.Point(721, 197)
        Me.lbllslColor.Name = "lbllslColor"
        Me.lbllslColor.Size = New System.Drawing.Size(12, 23)
        Me.lbllslColor.TabIndex = 80
        Me.lbllslColor.Text = "Label17"
        '
        'btnSelectFile
        '
        Me.btnSelectFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectFile.ForeColor = System.Drawing.Color.Black
        Me.btnSelectFile.Location = New System.Drawing.Point(6, 6)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(154, 46)
        Me.btnSelectFile.TabIndex = 56
        Me.btnSelectFile.Text = "Select Data File"
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'txtlsl
        '
        Me.txtlsl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlsl.Location = New System.Drawing.Point(610, 197)
        Me.txtlsl.MaxLength = 9
        Me.txtlsl.Name = "txtlsl"
        Me.txtlsl.ReadOnly = True
        Me.txtlsl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtlsl.Size = New System.Drawing.Size(59, 23)
        Me.txtlsl.TabIndex = 79
        Me.txtlsl.Text = "0"
        '
        'lblnvColor
        '
        Me.lblnvColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblnvColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnvColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnvColor.Location = New System.Drawing.Point(721, 139)
        Me.lblnvColor.Name = "lblnvColor"
        Me.lblnvColor.Size = New System.Drawing.Size(12, 23)
        Me.lblnvColor.TabIndex = 77
        Me.lblnvColor.Text = "Label5"
        '
        'txtnv
        '
        Me.txtnv.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnv.Location = New System.Drawing.Point(610, 139)
        Me.txtnv.MaxLength = 9
        Me.txtnv.Name = "txtnv"
        Me.txtnv.ReadOnly = True
        Me.txtnv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtnv.Size = New System.Drawing.Size(59, 23)
        Me.txtnv.TabIndex = 75
        Me.txtnv.Text = "0"
        '
        'lblnvtext
        '
        Me.lblnvtext.AutoSize = True
        Me.lblnvtext.BackColor = System.Drawing.Color.Transparent
        Me.lblnvtext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnvtext.ForeColor = System.Drawing.Color.Black
        Me.lblnvtext.Location = New System.Drawing.Point(573, 142)
        Me.lblnvtext.Name = "lblnvtext"
        Me.lblnvtext.Size = New System.Drawing.Size(23, 15)
        Me.lblnvtext.TabIndex = 76
        Me.lblnvtext.Text = "NV"
        '
        'lbllclColor
        '
        Me.lbllclColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbllclColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllclColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllclColor.Location = New System.Drawing.Point(721, 168)
        Me.lbllclColor.Name = "lbllclColor"
        Me.lbllclColor.Size = New System.Drawing.Size(12, 23)
        Me.lbllclColor.TabIndex = 73
        Me.lbllclColor.Text = "Label16"
        '
        'lbllsltext
        '
        Me.lbllsltext.AutoSize = True
        Me.lbllsltext.BackColor = System.Drawing.Color.Transparent
        Me.lbllsltext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllsltext.ForeColor = System.Drawing.Color.Black
        Me.lbllsltext.Location = New System.Drawing.Point(573, 200)
        Me.lbllsltext.Name = "lbllsltext"
        Me.lbllsltext.Size = New System.Drawing.Size(29, 15)
        Me.lbllsltext.TabIndex = 72
        Me.lbllsltext.Text = "LSL"
        '
        'lbllcltext
        '
        Me.lbllcltext.AutoSize = True
        Me.lbllcltext.BackColor = System.Drawing.Color.Transparent
        Me.lbllcltext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllcltext.ForeColor = System.Drawing.Color.Black
        Me.lbllcltext.Location = New System.Drawing.Point(575, 171)
        Me.lbllcltext.Name = "lbllcltext"
        Me.lbllcltext.Size = New System.Drawing.Size(29, 15)
        Me.lbllcltext.TabIndex = 70
        Me.lbllcltext.Text = "LCL"
        '
        'txtlcl
        '
        Me.txtlcl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlcl.Location = New System.Drawing.Point(610, 168)
        Me.txtlcl.MaxLength = 9
        Me.txtlcl.Name = "txtlcl"
        Me.txtlcl.ReadOnly = True
        Me.txtlcl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtlcl.Size = New System.Drawing.Size(59, 23)
        Me.txtlcl.TabIndex = 69
        Me.txtlcl.Text = "0"
        '
        'lbluclColor
        '
        Me.lbluclColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbluclColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbluclColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluclColor.Location = New System.Drawing.Point(721, 110)
        Me.lbluclColor.Name = "lbluclColor"
        Me.lbluclColor.Size = New System.Drawing.Size(12, 23)
        Me.lbluclColor.TabIndex = 68
        Me.lbluclColor.Text = "Label4"
        '
        'lbluslColor
        '
        Me.lbluslColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbluslColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbluslColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluslColor.Location = New System.Drawing.Point(721, 81)
        Me.lbluslColor.Name = "lbluslColor"
        Me.lbluslColor.Size = New System.Drawing.Size(12, 23)
        Me.lbluslColor.TabIndex = 67
        Me.lbluslColor.Text = "Label4"
        '
        'lblusltext
        '
        Me.lblusltext.AutoSize = True
        Me.lblusltext.BackColor = System.Drawing.Color.Transparent
        Me.lblusltext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusltext.ForeColor = System.Drawing.Color.Black
        Me.lblusltext.Location = New System.Drawing.Point(573, 84)
        Me.lblusltext.Name = "lblusltext"
        Me.lblusltext.Size = New System.Drawing.Size(31, 15)
        Me.lblusltext.TabIndex = 64
        Me.lblusltext.Text = "USL"
        '
        'txtusl
        '
        Me.txtusl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusl.Location = New System.Drawing.Point(610, 81)
        Me.txtusl.MaxLength = 9
        Me.txtusl.Name = "txtusl"
        Me.txtusl.ReadOnly = True
        Me.txtusl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtusl.Size = New System.Drawing.Size(59, 23)
        Me.txtusl.TabIndex = 63
        Me.txtusl.Text = "0"
        '
        'txtucl
        '
        Me.txtucl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtucl.Location = New System.Drawing.Point(610, 110)
        Me.txtucl.MaxLength = 9
        Me.txtucl.Name = "txtucl"
        Me.txtucl.ReadOnly = True
        Me.txtucl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtucl.Size = New System.Drawing.Size(59, 23)
        Me.txtucl.TabIndex = 65
        Me.txtucl.Text = "0"
        '
        'lblucltext
        '
        Me.lblucltext.AutoSize = True
        Me.lblucltext.BackColor = System.Drawing.Color.Transparent
        Me.lblucltext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblucltext.ForeColor = System.Drawing.Color.Black
        Me.lblucltext.Location = New System.Drawing.Point(573, 113)
        Me.lblucltext.Name = "lblucltext"
        Me.lblucltext.Size = New System.Drawing.Size(31, 15)
        Me.lblucltext.TabIndex = 66
        Me.lblucltext.Text = "UCL"
        '
        'cmbPart
        '
        Me.cmbPart.DataSource = Me.PartdetailsBindingSource
        Me.cmbPart.DisplayMember = "partname"
        Me.cmbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPart.FormattingEnabled = True
        Me.cmbPart.Location = New System.Drawing.Point(186, 5)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(284, 32)
        Me.cmbPart.TabIndex = 52
        Me.cmbPart.ValueMember = "partId"
        '
        'PartdetailsBindingSource
        '
        Me.PartdetailsBindingSource.DataMember = "partdetails"
        Me.PartdetailsBindingSource.DataSource = Me.VersaGageMonitorDataSet
        '
        'VersaGageMonitorDataSet
        '
        Me.VersaGageMonitorDataSet.DataSetName = "VersaGageMonitorDataSet"
        Me.VersaGageMonitorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblMeasurement
        '
        Me.lblMeasurement.BackColor = System.Drawing.Color.LightGray
        Me.lblMeasurement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMeasurement.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasurement.ForeColor = System.Drawing.Color.Black
        Me.lblMeasurement.Location = New System.Drawing.Point(186, 98)
        Me.lblMeasurement.Name = "lblMeasurement"
        Me.lblMeasurement.Size = New System.Drawing.Size(381, 117)
        Me.lblMeasurement.TabIndex = 8
        Me.lblMeasurement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblReadingSaved)
        Me.Panel3.Controls.Add(Me.btnResetCounter)
        Me.Panel3.Controls.Add(Me.lblCounter)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Location = New System.Drawing.Point(4, 234)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(745, 55)
        Me.Panel3.TabIndex = 53
        '
        'lblReadingSaved
        '
        Me.lblReadingSaved.AutoSize = True
        Me.lblReadingSaved.BackColor = System.Drawing.Color.Lime
        Me.lblReadingSaved.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadingSaved.ForeColor = System.Drawing.Color.Black
        Me.lblReadingSaved.Location = New System.Drawing.Point(397, 15)
        Me.lblReadingSaved.Name = "lblReadingSaved"
        Me.lblReadingSaved.Size = New System.Drawing.Size(130, 20)
        Me.lblReadingSaved.TabIndex = 32
        Me.lblReadingSaved.Text = "Reading Saved..."
        Me.lblReadingSaved.Visible = False
        '
        'btnResetCounter
        '
        Me.btnResetCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetCounter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnResetCounter.Location = New System.Drawing.Point(262, 15)
        Me.btnResetCounter.Name = "btnResetCounter"
        Me.btnResetCounter.Size = New System.Drawing.Size(122, 23)
        Me.btnResetCounter.TabIndex = 30
        Me.btnResetCounter.Text = "Reset Counter"
        Me.btnResetCounter.UseVisualStyleBackColor = True
        '
        'lblCounter
        '
        Me.lblCounter.AutoSize = True
        Me.lblCounter.BackColor = System.Drawing.Color.Transparent
        Me.lblCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter.ForeColor = System.Drawing.Color.Black
        Me.lblCounter.Location = New System.Drawing.Point(203, 12)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(22, 26)
        Me.lblCounter.TabIndex = 29
        Me.lblCounter.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(191, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Reading Storage Counter"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3})
        Me.DataGridView1.Location = New System.Drawing.Point(762, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DimGray
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(250, 579)
        Me.DataGridView1.TabIndex = 48
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.HeaderText = "Date;Time"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 125
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "Parameter Value"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 125
        '
        'Timer3
        '
        Me.Timer3.Interval = 300
        '
        'Timer2
        '
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CreatePrompt = True
        Me.SaveFileDialog1.DefaultExt = "csv"
        Me.SaveFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        Me.SaveFileDialog1.Title = "Create file for capturing data"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.AddExtension = False
        Me.OpenFileDialog1.DefaultExt = "csv"
        Me.OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        Me.OpenFileDialog1.Title = "Select file for capturing data"
        '
        'lblFileSel
        '
        Me.lblFileSel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFileSel.Location = New System.Drawing.Point(9, 602)
        Me.lblFileSel.Name = "lblFileSel"
        Me.lblFileSel.Size = New System.Drawing.Size(1019, 24)
        Me.lblFileSel.TabIndex = 56
        '
        'PartdetailsTableAdapter
        '
        Me.PartdetailsTableAdapter.ClearBeforeFill = True
        '
        'Measure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(1030, 626)
        Me.Controls.Add(Me.lblFileSel)
        Me.Controls.Add(Me.TriColorColumn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Measure"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Measure Part"
        Me.TriColorColumn.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PartdetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VersaGageMonitorDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TriColorColumn As System.Windows.Forms.Panel
    Friend WithEvents triColorRunChart As VersaGageMonitor.RunChart
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbllslColor As System.Windows.Forms.Label
    Friend WithEvents txtlsl As System.Windows.Forms.TextBox
    Friend WithEvents lblCustName As System.Windows.Forms.Label
    Friend WithEvents lblnvColor As System.Windows.Forms.Label
    Friend WithEvents txtnv As System.Windows.Forms.TextBox
    Friend WithEvents lblnvtext As System.Windows.Forms.Label
    Friend WithEvents lbllclColor As System.Windows.Forms.Label
    Friend WithEvents lbllsltext As System.Windows.Forms.Label
    Friend WithEvents lbllcltext As System.Windows.Forms.Label
    Friend WithEvents txtlcl As System.Windows.Forms.TextBox
    Friend WithEvents lbluclColor As System.Windows.Forms.Label
    Friend WithEvents lbluslColor As System.Windows.Forms.Label
    Friend WithEvents lblusltext As System.Windows.Forms.Label
    Friend WithEvents txtusl As System.Windows.Forms.TextBox
    Friend WithEvents txtucl As System.Windows.Forms.TextBox
    Friend WithEvents lblucltext As System.Windows.Forms.Label
    Friend WithEvents cmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents lblMeasurement As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblReadingSaved As System.Windows.Forms.Label
    Friend WithEvents btnResetCounter As System.Windows.Forms.Button
    Friend WithEvents lblCounter As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents VersaGageMonitorDataSet As VersaGageMonitor.VersaGageMonitorDataSet
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PartdetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFileSel As System.Windows.Forms.Label
    Friend WithEvents btnCreateFile As System.Windows.Forms.Button
    Friend WithEvents btnSelectFile As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents PartdetailsTableAdapter As VersaGageMonitor.VersaGageMonitorDataSetTableAdapters.partdetailsTableAdapter
End Class
