Public Class Info
    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click
        Me.Close()
    End Sub

    Private Sub Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://github.com/executaball/FlexEdit-Metro")
        Catch
            'Code to handle the error.
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            System.Diagnostics.Process.Start("http://blog.flexiblesurvival.com/")
        Catch
            'Code to handle the error.
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://github.com/Nuku/Flexible-Survival")
        Catch
            'Code to handle the error.
        End Try
    End Sub
End Class