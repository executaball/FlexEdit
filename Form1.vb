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
    'top right exit button
    Private Sub topbarbutton_exit_Click(sender As Object, e As EventArgs) Handles topbarbutton_exit.Click
        Application.Exit()
    End Sub

    'top right minimize button
    Private Sub topbarbutton_min_Click(sender As Object, e As EventArgs) Handles topbarbutton_min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'TAB BUTTONS

    'Tab1
    Private Sub buttontab_1_Click(sender As Object, e As EventArgs) Handles buttontab_1.Click

        MetroTabControl1.SelectedTab = TabPage1

    End Sub
    'Tab2
    Private Sub buttontab_2_Click(sender As Object, e As EventArgs) Handles buttontab_2.Click

        MetroTabControl1.SelectedTab = TabPage2

    End Sub
    'Tab3
    Private Sub buttontab_3_Click(sender As Object, e As EventArgs) Handles buttontab_3.Click

        MetroTabControl1.SelectedTab = TabPage3

    End Sub
    'Tab4
    Private Sub buttontab_4_Click(sender As Object, e As EventArgs) Handles buttontab_4.Click

        MetroTabControl1.SelectedTab = TabPage4

    End Sub
    'Tab5
    Private Sub buttontab_5_Click(sender As Object, e As EventArgs) Handles buttontab_5.Click

        MetroTabControl1.SelectedTab = TabPage5

    End Sub
End Class

