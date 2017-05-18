<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim MainColorScheme2 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Dim MainColorScheme1 As MetroSuite.MetroButton.MainColorScheme = New MetroSuite.MetroButton.MainColorScheme()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.checkbox_saveword2 = New System.Windows.Forms.CheckBox()
        Me.checkbox_saveword3 = New System.Windows.Forms.CheckBox()
        Me.metrobutton_load = New MetroSuite.MetroButton()
        Me.textbox_saveword1 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.textbox_saveword2 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.textbox_saveword3 = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.metrobutton_cancel = New MetroSuite.MetroButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 37)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Saveword Input"
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'checkbox_saveword2
        '
        Me.checkbox_saveword2.AutoSize = True
        Me.checkbox_saveword2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_saveword2.Location = New System.Drawing.Point(45, 169)
        Me.checkbox_saveword2.Name = "checkbox_saveword2"
        Me.checkbox_saveword2.Size = New System.Drawing.Size(210, 29)
        Me.checkbox_saveword2.TabIndex = 5
        Me.checkbox_saveword2.Text = "Load Saveword Part 2"
        Me.checkbox_saveword2.UseVisualStyleBackColor = True
        '
        'checkbox_saveword3
        '
        Me.checkbox_saveword3.AutoSize = True
        Me.checkbox_saveword3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_saveword3.Location = New System.Drawing.Point(45, 254)
        Me.checkbox_saveword3.Name = "checkbox_saveword3"
        Me.checkbox_saveword3.Size = New System.Drawing.Size(210, 29)
        Me.checkbox_saveword3.TabIndex = 6
        Me.checkbox_saveword3.Text = "Load Saveword Part 2"
        Me.checkbox_saveword3.UseVisualStyleBackColor = True
        '
        'metrobutton_load
        '
        MainColorScheme2.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme2.FillColor = System.Drawing.Color.White
        MainColorScheme2.HoverFillColor = System.Drawing.Color.White
        MainColorScheme2.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme2.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_load.ColorScheme = MainColorScheme2
        Me.metrobutton_load.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_load.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_load.Location = New System.Drawing.Point(588, 367)
        Me.metrobutton_load.Name = "metrobutton_load"
        Me.metrobutton_load.Size = New System.Drawing.Size(147, 38)
        Me.metrobutton_load.TabIndex = 8
        Me.metrobutton_load.Text = "Load"
        '
        'textbox_saveword1
        '
        Me.textbox_saveword1.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword1.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword1.Location = New System.Drawing.Point(45, 114)
        Me.textbox_saveword1.Name = "textbox_saveword1"
        Me.textbox_saveword1.Size = New System.Drawing.Size(690, 31)
        Me.textbox_saveword1.TabIndex = 9
        Me.textbox_saveword1.Text = "Saveword Part 1"
        '
        'textbox_saveword2
        '
        Me.textbox_saveword2.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword2.Enabled = False
        Me.textbox_saveword2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword2.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword2.Location = New System.Drawing.Point(45, 199)
        Me.textbox_saveword2.Name = "textbox_saveword2"
        Me.textbox_saveword2.Size = New System.Drawing.Size(690, 31)
        Me.textbox_saveword2.TabIndex = 10
        Me.textbox_saveword2.Text = "Saveword Part 2"
        '
        'textbox_saveword3
        '
        Me.textbox_saveword3.BorderColor = System.Drawing.Color.SeaGreen
        Me.textbox_saveword3.Enabled = False
        Me.textbox_saveword3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_saveword3.ForeColor = System.Drawing.Color.DarkGray
        Me.textbox_saveword3.Location = New System.Drawing.Point(45, 284)
        Me.textbox_saveword3.Name = "textbox_saveword3"
        Me.textbox_saveword3.Size = New System.Drawing.Size(690, 31)
        Me.textbox_saveword3.TabIndex = 11
        Me.textbox_saveword3.Text = "Saveword Part 3"
        '
        'metrobutton_cancel
        '
        MainColorScheme1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(240, Byte), Integer))
        MainColorScheme1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        MainColorScheme1.FillColor = System.Drawing.Color.White
        MainColorScheme1.HoverFillColor = System.Drawing.Color.White
        MainColorScheme1.PressAccentColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        MainColorScheme1.PressFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.metrobutton_cancel.ColorScheme = MainColorScheme1
        Me.metrobutton_cancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.metrobutton_cancel.ForeColor = System.Drawing.Color.Black
        Me.metrobutton_cancel.Location = New System.Drawing.Point(415, 367)
        Me.metrobutton_cancel.Name = "metrobutton_cancel"
        Me.metrobutton_cancel.Size = New System.Drawing.Size(147, 38)
        Me.metrobutton_cancel.TabIndex = 12
        Me.metrobutton_cancel.Text = "Cancel"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 444)
        Me.Controls.Add(Me.metrobutton_cancel)
        Me.Controls.Add(Me.textbox_saveword3)
        Me.Controls.Add(Me.textbox_saveword2)
        Me.Controls.Add(Me.textbox_saveword1)
        Me.Controls.Add(Me.metrobutton_load)
        Me.Controls.Add(Me.checkbox_saveword3)
        Me.Controls.Add(Me.checkbox_saveword2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents metrobutton_load As MetroSuite.MetroButton
    Friend WithEvents checkbox_saveword3 As CheckBox
    Friend WithEvents checkbox_saveword2 As CheckBox
    Friend WithEvents textbox_saveword1 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents textbox_saveword3 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents textbox_saveword2 As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents metrobutton_cancel As MetroSuite.MetroButton
    Friend WithEvents Label1 As Label
End Class
