Public Class Startup2
    Private Sub Startup2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.Activate()
    End Sub

    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click
        Me.Close()
    End Sub
End Class