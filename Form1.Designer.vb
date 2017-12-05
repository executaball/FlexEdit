<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Startup2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Startup2))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Header = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MaterialFlatButton1 = New MaterialSkin.Controls.MaterialFlatButton()
        Me.Header.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Nothing
        Me.BunifuDragControl1.Vertical = True
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Header.Controls.Add(Me.Label2)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(760, 37)
        Me.Header.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Notice"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Google Sans", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 40)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Disclaimer"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(681, 144)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(681, 66)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "       Because of the frequency of Flexible Survival updates, this feature cannot" &
    " be disabled."
        '
        'MaterialFlatButton1
        '
        Me.MaterialFlatButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaterialFlatButton1.AutoSize = True
        Me.MaterialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialFlatButton1.Depth = 0
        Me.MaterialFlatButton1.Icon = Nothing
        Me.MaterialFlatButton1.Location = New System.Drawing.Point(498, 367)
        Me.MaterialFlatButton1.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaterialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialFlatButton1.Name = "MaterialFlatButton1"
        Me.MaterialFlatButton1.Primary = False
        Me.MaterialFlatButton1.Size = New System.Drawing.Size(230, 36)
        Me.MaterialFlatButton1.TabIndex = 26
        Me.MaterialFlatButton1.Text = "Agree and proceed"
        Me.MaterialFlatButton1.UseVisualStyleBackColor = True
        '
        'Startup2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 459)
        Me.Controls.Add(Me.MaterialFlatButton1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Startup2"
        Me.Text = "Notice"
        Me.Header.ResumeLayout(False)
        Me.Header.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Header As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents MaterialFlatButton1 As MaterialSkin.Controls.MaterialFlatButton
End Class
