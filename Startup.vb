Public Class Startup
    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click
        Me.Close()
    End Sub

    Private Sub Startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.Activate()
    End Sub
End Class