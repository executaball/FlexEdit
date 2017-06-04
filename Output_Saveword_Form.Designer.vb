<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Output_Saveword_Form
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
        Dim MainColorScheme7 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim MainColorScheme6 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim MainColorScheme5 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim MainColorScheme8 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Output_Saveword_Form))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Header = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.textbox_saveword3 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.textbox_saveword2 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.textbox_saveword1 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.metrobutton_copy1 = New MetroSuite.MetroButton()
        Me.metrobutton_copy2 = New MetroSuite.MetroButton()
        Me.metrobutton_copy3 = New MetroSuite.MetroButton()
        Me.metrobutton_exit = New MetroSuite.MetroButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
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
        Me.Header.Controls.Add(Me.Label1)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(770, 37)
        Me.Header.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Saveword Export"
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Header
        Me.BunifuDragControl1.Vertical = True
        '
        'textbox_saveword3
        '
        Me.textbox_saveword3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textbox_saveword3.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword3.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword3.Location = New System.Drawing.Point(45, 284)
        Me.textbox_saveword3.Name = "textbox_saveword3"
        Me.textbox_saveword3.ReadOnly = True
        Me.textbox_saveword3.Size = New System.Drawing.Size(556, 31)
        Me.textbox_saveword3.TabIndex = 18
        '
        'textbox_saveword2
        '
        Me.textbox_saveword2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textbox_saveword2.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword2.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword2.Location = New System.Drawing.Point(45, 199)
        Me.textbox_saveword2.Name = "textbox_saveword2"
        Me.textbox_saveword2.ReadOnly = True
        Me.textbox_saveword2.Size = New System.Drawing.Size(556, 31)
        Me.textbox_saveword2.TabIndex = 17
        '
        'textbox_saveword1
        '
        Me.textbox_saveword1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textbox_saveword1.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword1.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword1.Location = New System.Drawing.Point(45, 114)
        Me.textbox_saveword1.Name = "textbox_saveword1"
        Me.textbox_saveword1.ReadOnly = True
        Me.textbox_saveword1.Size = New System.Drawing.Size(556, 31)
        Me.textbox_saveword1.TabIndex = 16
        '
        'metrobutton_copy1
        '
        Me.metrobutton_copy1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme7.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme7.FillColor = System.Drawing.Color.White
        MainColorScheme7.HoverFillColor = System.Drawing.Color.White
        MainColorScheme7.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme7.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_copy1.ColorScheme = MainColorScheme7
        Me.metrobutton_copy1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_copy1.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_copy1.Location = New System.Drawing.Point(624, 98)
        Me.metrobutton_copy1.Name = "metrobutton_copy1"
        Me.metrobutton_copy1.Size = New System.Drawing.Size(111, 47)
        Me.metrobutton_copy1.TabIndex = 20
        Me.metrobutton_copy1.Text = "Copy"
        '
        'metrobutton_copy2
        '
        Me.metrobutton_copy2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme6.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme6.FillColor = System.Drawing.Color.White
        MainColorScheme6.HoverFillColor = System.Drawing.Color.White
        MainColorScheme6.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme6.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_copy2.ColorScheme = MainColorScheme6
        Me.metrobutton_copy2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_copy2.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_copy2.Location = New System.Drawing.Point(624, 183)
        Me.metrobutton_copy2.Name = "metrobutton_copy2"
        Me.metrobutton_copy2.Size = New System.Drawing.Size(111, 47)
        Me.metrobutton_copy2.TabIndex = 21
        Me.metrobutton_copy2.Text = "Copy"
        '
        'metrobutton_copy3
        '
        Me.metrobutton_copy3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme5.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme5.FillColor = System.Drawing.Color.White
        MainColorScheme5.HoverFillColor = System.Drawing.Color.White
        MainColorScheme5.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme5.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_copy3.ColorScheme = MainColorScheme5
        Me.metrobutton_copy3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_copy3.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_copy3.Location = New System.Drawing.Point(624, 268)
        Me.metrobutton_copy3.Name = "metrobutton_copy3"
        Me.metrobutton_copy3.Size = New System.Drawing.Size(111, 47)
        Me.metrobutton_copy3.TabIndex = 22
        Me.metrobutton_copy3.Text = "Copy"
        '
        'metrobutton_exit
        '
        Me.metrobutton_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme8.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme8.FillColor = System.Drawing.Color.White
        MainColorScheme8.HoverFillColor = System.Drawing.Color.White
        MainColorScheme8.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme8.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_exit.ColorScheme = MainColorScheme8
        Me.metrobutton_exit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_exit.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_exit.Location = New System.Drawing.Point(588, 367)
        Me.metrobutton_exit.Name = "metrobutton_exit"
        Me.metrobutton_exit.Size = New System.Drawing.Size(147, 38)
        Me.metrobutton_exit.TabIndex = 15
        Me.metrobutton_exit.Text = "Close"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Output_Saveword_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 444)
        Me.Controls.Add(Me.metrobutton_copy3)
        Me.Controls.Add(Me.metrobutton_copy2)
        Me.Controls.Add(Me.metrobutton_copy1)
        Me.Controls.Add(Me.textbox_saveword3)
        Me.Controls.Add(Me.textbox_saveword2)
        Me.Controls.Add(Me.textbox_saveword1)
        Me.Controls.Add(Me.metrobutton_exit)
        Me.Controls.Add(Me.Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Output_Saveword_Form"
        Me.Text = "FlexEdit - Export"
        Me.Header.ResumeLayout(False)
        Me.Header.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Header As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents textbox_saveword3 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents textbox_saveword2 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents textbox_saveword1 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents metrobutton_copy3 As MetroSuite.MetroButton
    Friend WithEvents metrobutton_copy2 As MetroSuite.MetroButton
    Friend WithEvents metrobutton_copy1 As MetroSuite.MetroButton
    Friend WithEvents metrobutton_exit As MetroSuite.MetroButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
End Class
