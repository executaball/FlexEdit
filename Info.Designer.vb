<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Info
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
        Me.components = New System.ComponentModel.Container()
        Dim MainColorScheme2 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Header = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.metrobutton_exit = New MetroSuite.MetroButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.Header.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FlexEdit Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Credits"
        '
        'metrobutton_exit
        '
        Me.metrobutton_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MainColorScheme2.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme2.FillColor = System.Drawing.Color.White
        MainColorScheme2.HoverFillColor = System.Drawing.Color.White
        MainColorScheme2.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme2.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_exit.ColorScheme = MainColorScheme2
        Me.metrobutton_exit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_exit.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_exit.Location = New System.Drawing.Point(624, 460)
        Me.metrobutton_exit.Name = "metrobutton_exit"
        Me.metrobutton_exit.Size = New System.Drawing.Size(147, 38)
        Me.metrobutton_exit.TabIndex = 16
        Me.metrobutton_exit.Text = "Close"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(743, 38)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "FlexEdit is developed by executaball and is currently open source on Github:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(743, 36)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Flexible Survival is an Inform based text game developed by Silver Games LLC. "
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(664, 115)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "All icon assets are used under Creative Commons — Attribution 3.0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon Authors: " &
    "Google Material Design, Freepik, GraphicsBay, Madebyoliver, Vectors market"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LinkLabel1.Location = New System.Drawing.Point(27, 148)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(342, 28)
        Me.LinkLabel1.TabIndex = 20
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "https://executaball.github.io/FlexEdit/"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LinkLabel2.Location = New System.Drawing.Point(27, 234)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(292, 28)
        Me.LinkLabel2.TabIndex = 21
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "http://blog.flexiblesurvival.com/"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LinkLabel3.Location = New System.Drawing.Point(27, 271)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(383, 28)
        Me.LinkLabel3.TabIndex = 22
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "https://github.com/Nuku/Flexible-Survival"
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Header
        Me.BunifuDragControl1.Vertical = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 460)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 28)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "v2.0.16 BETA"
        '
        'Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 528)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.metrobutton_exit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Info"
        Me.Text = "Form1"
        Me.Header.ResumeLayout(False)
        Me.Header.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Header As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents metrobutton_exit As MetroSuite.MetroButton
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Label6 As Label
End Class
