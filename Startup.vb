Public Class Startup

    Private Sub Startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Font = Module1.LoadFont(Me.GetType.Assembly, "GoogleSans-Regular.ttf", 9, FontStyle.Regular)
        Me.CenterToScreen()
        Me.Activate()
    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Me.Close()
    End Sub
End Class