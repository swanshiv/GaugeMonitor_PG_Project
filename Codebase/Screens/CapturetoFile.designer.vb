<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapturetoFile
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
        Me.btnStopCapturing = New System.Windows.Forms.Button
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.btnSelectFile = New System.Windows.Forms.Button
        Me.btnCreateFile = New System.Windows.Forms.Button
        Me.btnStartCapturing = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lblFileSel = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'btnStopCapturing
        '
        Me.btnStopCapturing.BackColor = System.Drawing.Color.Red
        Me.btnStopCapturing.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnStopCapturing.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStopCapturing.Location = New System.Drawing.Point(519, 12)
        Me.btnStopCapturing.Name = "btnStopCapturing"
        Me.btnStopCapturing.Size = New System.Drawing.Size(154, 72)
        Me.btnStopCapturing.TabIndex = 57
        Me.btnStopCapturing.Text = "Stop Capturing Readings"
        Me.btnStopCapturing.UseVisualStyleBackColor = False
        Me.btnStopCapturing.Visible = False
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
        'btnSelectFile
        '
        Me.btnSelectFile.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnSelectFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectFile.Location = New System.Drawing.Point(39, 12)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(154, 72)
        Me.btnSelectFile.TabIndex = 58
        Me.btnSelectFile.Text = "Select File to Capture Readings"
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'btnCreateFile
        '
        Me.btnCreateFile.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnCreateFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateFile.Location = New System.Drawing.Point(199, 12)
        Me.btnCreateFile.Name = "btnCreateFile"
        Me.btnCreateFile.Size = New System.Drawing.Size(154, 72)
        Me.btnCreateFile.TabIndex = 59
        Me.btnCreateFile.Text = "Create New File to Capture Readings"
        Me.btnCreateFile.UseVisualStyleBackColor = True
        '
        'btnStartCapturing
        '
        Me.btnStartCapturing.BackColor = System.Drawing.Color.LimeGreen
        Me.btnStartCapturing.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnStartCapturing.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartCapturing.Location = New System.Drawing.Point(359, 12)
        Me.btnStartCapturing.Name = "btnStartCapturing"
        Me.btnStartCapturing.Size = New System.Drawing.Size(154, 72)
        Me.btnStartCapturing.TabIndex = 60
        Me.btnStartCapturing.Text = "Start Capturing Readings"
        Me.btnStartCapturing.UseVisualStyleBackColor = False
        Me.btnStartCapturing.Visible = False
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
        Me.lblFileSel.Location = New System.Drawing.Point(12, 87)
        Me.lblFileSel.Name = "lblFileSel"
        Me.lblFileSel.Size = New System.Drawing.Size(1006, 43)
        Me.lblFileSel.TabIndex = 61
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 133)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(1006, 481)
        Me.TextBox1.TabIndex = 62
        '
        'CapturetoFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(1030, 626)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblFileSel)
        Me.Controls.Add(Me.btnStartCapturing)
        Me.Controls.Add(Me.btnCreateFile)
        Me.Controls.Add(Me.btnSelectFile)
        Me.Controls.Add(Me.btnStopCapturing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturetoFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Readings Capture to File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStopCapturing As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSelectFile As System.Windows.Forms.Button
    Friend WithEvents btnCreateFile As System.Windows.Forms.Button
    Friend WithEvents btnStartCapturing As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblFileSel As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
End Class
