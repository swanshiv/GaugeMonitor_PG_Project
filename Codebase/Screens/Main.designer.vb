<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectExistingDataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateNewDataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CommunicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.PartDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeLoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TricolorColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OctaGageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReadToCSVFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.toolStripStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.InterfaceCheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CommunicationPortTableAdapter = New VersaGageMonitor.VersaGageMonitorDataSetTableAdapters.CommunicationPortTableAdapter
        Me.VersaGageMonitorDataSet = New VersaGageMonitor.VersaGageMonitorDataSet
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.VersaGageMonitorDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.OldLace
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataFileToolStripMenuItem, Me.CommunicationToolStripMenuItem, Me.FileToolStripMenuItem, Me.UserManagementToolStripMenuItem, Me.ProductToolStripMenuItem, Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 27)
        Me.MenuStrip1.TabIndex = 27
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataFileToolStripMenuItem
        '
        Me.DataFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectExistingDataFileToolStripMenuItem, Me.CreateNewDataFileToolStripMenuItem})
        Me.DataFileToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataFileToolStripMenuItem.Name = "DataFileToolStripMenuItem"
        Me.DataFileToolStripMenuItem.Size = New System.Drawing.Size(82, 23)
        Me.DataFileToolStripMenuItem.Text = "&Data File"
        Me.DataFileToolStripMenuItem.Visible = False
        '
        'SelectExistingDataFileToolStripMenuItem
        '
        Me.SelectExistingDataFileToolStripMenuItem.Name = "SelectExistingDataFileToolStripMenuItem"
        Me.SelectExistingDataFileToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.SelectExistingDataFileToolStripMenuItem.Text = "&Select Existing Data File"
        '
        'CreateNewDataFileToolStripMenuItem
        '
        Me.CreateNewDataFileToolStripMenuItem.Name = "CreateNewDataFileToolStripMenuItem"
        Me.CreateNewDataFileToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.CreateNewDataFileToolStripMenuItem.Text = "&Create New Data File"
        '
        'CommunicationToolStripMenuItem
        '
        Me.CommunicationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem1})
        Me.CommunicationToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommunicationToolStripMenuItem.Name = "CommunicationToolStripMenuItem"
        Me.CommunicationToolStripMenuItem.Size = New System.Drawing.Size(132, 23)
        Me.CommunicationToolStripMenuItem.Text = "C&ommunication"
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(150, 24)
        Me.SettingsToolStripMenuItem1.Text = "Se&ttings"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem2, Me.PartDetailsToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(77, 23)
        Me.FileToolStripMenuItem.Text = "&Settings"
        '
        'SettingsToolStripMenuItem2
        '
        Me.SettingsToolStripMenuItem2.Name = "SettingsToolStripMenuItem2"
        Me.SettingsToolStripMenuItem2.Size = New System.Drawing.Size(214, 24)
        Me.SettingsToolStripMenuItem2.Text = "&Customer Details"
        Me.SettingsToolStripMenuItem2.Visible = False
        '
        'PartDetailsToolStripMenuItem
        '
        Me.PartDetailsToolStripMenuItem.Name = "PartDetailsToolStripMenuItem"
        Me.PartDetailsToolStripMenuItem.Size = New System.Drawing.Size(214, 24)
        Me.PartDetailsToolStripMenuItem.Text = "&Part Details"
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeLoginToolStripMenuItem, Me.AddUserToolStripMenuItem, Me.DeleteUserToolStripMenuItem, Me.ChangePasswordToolStripMenuItem})
        Me.UserManagementToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(148, 23)
        Me.UserManagementToolStripMenuItem.Text = "&User Management"
        Me.UserManagementToolStripMenuItem.Visible = False
        '
        'ChangeLoginToolStripMenuItem
        '
        Me.ChangeLoginToolStripMenuItem.Name = "ChangeLoginToolStripMenuItem"
        Me.ChangeLoginToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.ChangeLoginToolStripMenuItem.Text = "Chan&ge Login"
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.AddUserToolStripMenuItem.Text = "&Add User"
        '
        'DeleteUserToolStripMenuItem
        '
        Me.DeleteUserToolStripMenuItem.Name = "DeleteUserToolStripMenuItem"
        Me.DeleteUserToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.DeleteUserToolStripMenuItem.Text = "De&lete User"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.ChangePasswordToolStripMenuItem.Text = "C&hange Password"
        '
        'ProductToolStripMenuItem
        '
        Me.ProductToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TricolorColumnToolStripMenuItem, Me.OctaGageToolStripMenuItem1, Me.ReadToCSVFileToolStripMenuItem1})
        Me.ProductToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem"
        Me.ProductToolStripMenuItem.Size = New System.Drawing.Size(79, 23)
        Me.ProductToolStripMenuItem.Text = "&Measure"
        '
        'TricolorColumnToolStripMenuItem
        '
        Me.TricolorColumnToolStripMenuItem.Name = "TricolorColumnToolStripMenuItem"
        Me.TricolorColumnToolStripMenuItem.Size = New System.Drawing.Size(217, 24)
        Me.TricolorColumnToolStripMenuItem.Text = "&Tricolor Column"
        '
        'OctaGageToolStripMenuItem1
        '
        Me.OctaGageToolStripMenuItem1.Name = "OctaGageToolStripMenuItem1"
        Me.OctaGageToolStripMenuItem1.Size = New System.Drawing.Size(217, 24)
        Me.OctaGageToolStripMenuItem1.Text = "OctaGage"
        '
        'ReadToCSVFileToolStripMenuItem1
        '
        Me.ReadToCSVFileToolStripMenuItem1.Name = "ReadToCSVFileToolStripMenuItem1"
        Me.ReadToCSVFileToolStripMenuItem1.Size = New System.Drawing.Size(217, 24)
        Me.ReadToCSVFileToolStripMenuItem1.Text = "Capture .CSV File"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(64, 23)
        Me.AboutToolStripMenuItem.Text = "A&bout"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 23)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(152, 24)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(47, 23)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.toolStripStatus, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 644)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1016, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel1.Text = "Status:"
        '
        'toolStripStatus
        '
        Me.toolStripStatus.BackColor = System.Drawing.Color.Transparent
        Me.toolStripStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.toolStripStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripStatus.Name = "toolStripStatus"
        Me.toolStripStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.Color.Lime
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.ToolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(0, 17)
        Me.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InterfaceCheckTimer
        '
        Me.InterfaceCheckTimer.Interval = 10
        '
        'CommunicationPortTableAdapter
        '
        Me.CommunicationPortTableAdapter.ClearBeforeFill = True
        '
        'VersaGageMonitorDataSet
        '
        Me.VersaGageMonitorDataSet.DataSetName = "VersaGageMonitorDataSet"
        Me.VersaGageMonitorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "..\..\GageMonitorUtility.chm"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(1016, 666)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Versa Gage Monitor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.VersaGageMonitorDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectExistingDataFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewDataFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommunicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeLoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TricolorColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OctaGageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommunicationPortTableAdapter As VersaGageMonitor.VersaGageMonitorDataSetTableAdapters.CommunicationPortTableAdapter
    Friend WithEvents VersaGageMonitorDataSet As VersaGageMonitor.VersaGageMonitorDataSet
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents toolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents InterfaceCheckTimer As System.Windows.Forms.Timer
    Friend WithEvents ReadToCSVFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider


End Class
