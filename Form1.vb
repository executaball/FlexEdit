Public Class Startup2
    Private Sub Startup2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.Activate()
    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Me.Close()
    End Sub
End Class