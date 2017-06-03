<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim MainColorScheme5 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim MainColorScheme4 As MetroSuite.MetroSwitch.MainColorScheme = New MetroSuite.MetroSwitch.MainColorScheme()
        Dim MainColorScheme3 As MetroSuite.MetroSwitch.MainColorScheme = New MetroSuite.MetroSwitch.MainColorScheme()
        Dim MainColorScheme2 As MetroSuite.MetroSwitch.MainColorScheme = New MetroSuite.MetroSwitch.MainColorScheme()
        Dim MainColorScheme1 As MetroSuite.MetroSwitch.MainColorScheme = New MetroSuite.MetroSwitch.MainColorScheme()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Header = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.metrobutton_exit = New MetroSuite.MetroButton()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.MetroSwitch1 = New MetroSuite.MetroSwitch()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MetroSwitch2 = New MetroSuite.MetroSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MetroSwitch3 = New MetroSuite.MetroSwitch()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MetroSwitch4 = New MetroSuite.MetroSwitch()
        Me.Header.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Header.Controls.Add(Me.Label2)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(793, 37)
        Me.Header.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FlexEdit Settings"
        '
        'metrobutton_exit
        '
        Me.metrobutton_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme5.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme5.FillColor = System.Drawing.Color.White
        MainColorScheme5.HoverFillColor = System.Drawing.Color.White
        MainColorScheme5.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme5.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_exit.ColorScheme = MainColorScheme5
        Me.metrobutton_exit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_exit.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_exit.Location = New System.Drawing.Point(624, 460)
        Me.metrobutton_exit.Name = "metrobutton_exit"
        Me.metrobutton_exit.Size = New System.Drawing.Size(147, 38)
        Me.metrobutton_exit.TabIndex = 17
        Me.metrobutton_exit.Text = "Close"
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Header
        Me.BunifuDragControl1.Vertical = True
        '
        'MetroSwitch1
        '
        MainColorScheme4.BackColor = System.Drawing.SystemColors.Control
        MainColorScheme4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme4.BorderColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme4.ColorLeft = System.Drawing.SystemColors.Control
        MainColorScheme4.ColorRight = System.Drawing.SystemColors.Control
        MainColorScheme4.ColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme4.FillColor = System.Drawing.SystemColors.Control
        Me.MetroSwitch1.ColorScheme = MainColorScheme4
        Me.MetroSwitch1.Location = New System.Drawing.Point(36, 73)
        Me.MetroSwitch1.Name = "MetroSwitch1"
        Me.MetroSwitch1.Size = New System.Drawing.Size(68, 28)
        Me.MetroSwitch1.TabIndex = 18
        Me.MetroSwitch1.UseFixedSwitchSize = False
        Me.MetroSwitch1.UseMiddleStatus = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 32)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Enable Raw Variable Edits"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label3.Location = New System.Drawing.Point(110, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(382, 32)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Allow saveword version mismatch"
        '
        'MetroSwitch2
        '
        MainColorScheme3.BackColor = System.Drawing.SystemColors.Control
        MainColorScheme3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme3.BorderColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme3.ColorLeft = System.Drawing.SystemColors.Control
        MainColorScheme3.ColorRight = System.Drawing.SystemColors.Control
        MainColorScheme3.ColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme3.FillColor = System.Drawing.SystemColors.Control
        Me.MetroSwitch2.ColorScheme = MainColorScheme3
        Me.MetroSwitch2.Location = New System.Drawing.Point(36, 142)
        Me.MetroSwitch2.Name = "MetroSwitch2"
        Me.MetroSwitch2.Size = New System.Drawing.Size(68, 28)
        Me.MetroSwitch2.TabIndex = 20
        Me.MetroSwitch2.UseFixedSwitchSize = False
        Me.MetroSwitch2.UseMiddleStatus = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(337, 32)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Create backup files on export"
        '
        'MetroSwitch3
        '
        MainColorScheme2.BackColor = System.Drawing.SystemColors.Control
        MainColorScheme2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme2.BorderColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme2.ColorLeft = System.Drawing.SystemColors.Control
        MainColorScheme2.ColorRight = System.Drawing.SystemColors.Control
        MainColorScheme2.ColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme2.FillColor = System.Drawing.SystemColors.Control
        Me.MetroSwitch3.ColorScheme = MainColorScheme2
        Me.MetroSwitch3.Location = New System.Drawing.Point(36, 211)
        Me.MetroSwitch3.Name = "MetroSwitch3"
        Me.MetroSwitch3.Size = New System.Drawing.Size(68, 28)
        Me.MetroSwitch3.TabIndex = 22
        Me.MetroSwitch3.UseFixedSwitchSize = False
        Me.MetroSwitch3.UseMiddleStatus = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(110, 284)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(587, 32)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Check for updates on app startup (prompt to install)"
        '
        'MetroSwitch4
        '
        MainColorScheme1.BackColor = System.Drawing.SystemColors.Control
        MainColorScheme1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme1.BorderColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme1.ColorLeft = System.Drawing.SystemColors.Control
        MainColorScheme1.ColorRight = System.Drawing.SystemColors.Control
        MainColorScheme1.ColorSwitch = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        MainColorScheme1.FillColor = System.Drawing.SystemColors.Control
        Me.MetroSwitch4.ColorScheme = MainColorScheme1
        Me.MetroSwitch4.Location = New System.Drawing.Point(36, 287)
        Me.MetroSwitch4.Name = "MetroSwitch4"
        Me.MetroSwitch4.Size = New System.Drawing.Size(68, 28)
        Me.MetroSwitch4.TabIndex = 24
        Me.MetroSwitch4.UseFixedSwitchSize = False
        Me.MetroSwitch4.UseMiddleStatus = False
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 528)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MetroSwitch4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MetroSwitch3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MetroSwitch2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MetroSwitch1)
        Me.Controls.Add(Me.metrobutton_exit)
        Me.Controls.Add(Me.Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SettingsForm"
        Me.Text = "SettingsForm"
        Me.Header.ResumeLayout(False)
        Me.Header.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Header As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents metrobutton_exit As MetroSuite.MetroButton
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents MetroSwitch1 As MetroSuite.MetroSwitch
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents MetroSwitch3 As MetroSuite.MetroSwitch
    Friend WithEvents Label3 As Label
    Friend WithEvents MetroSwitch2 As MetroSuite.MetroSwitch
    Friend WithEvents Label5 As Label
    Friend WithEvents MetroSwitch4 As MetroSuite.MetroSwitch
End Class
