Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Bugfix 1 for metrotab
        Dim speed As Integer = MetroTabControl1.Speed : MetroTabControl1.Speed = 20
        For i As Integer = 0 To MetroTabControl1.TabPages.Count
            MetroTabControl1.SelectedIndex = i
        Next
        MetroTabControl1.SelectedIndex = 0 : MetroTabControl1.Speed = speed

        'Moves sidepanel to correct position (because moved out of way for development)
        Sidepanel.Width = 367



        'SHOW PRE-RELEASE WARNING
        Panel_PreReleaseWarning.Visible = True

        'Highlight first option
        buttontab_1.selected = True

    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Application.Exit()
        End
    End Sub



    Private Sub buttontab_1_Click(sender As Object, e As EventArgs) Handles buttontab_1.Click

        MetroTabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub buttontab_2_Click(sender As Object, e As EventArgs) Handles buttontab_2.Click

        MetroTabControl1.SelectedTab = TabPage2

    End Sub

    Private Sub BunifuTileButton1_Click(sender As Object, e As EventArgs) Handles BunifuTileButton1.Click

    End Sub
End Class

