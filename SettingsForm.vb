Public Class SettingsForm
    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click
        Me.Close()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Right

        If My.Settings.RawEditsEnable = True Then
            MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Right
        Else
            MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
        End If

    End Sub

    Private Sub MetroSwitch1_Click(sender As Object, e As EventArgs) Handles MetroSwitch1.Click


        If MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Right Then

            If My.Settings.RawEditsEnable = False Then

                Select Case MsgBox("Raw edits is a developer feature only and should not be used without knowledge of the game code. Editing values in these variables can easily break whole quest chains irreversibily for your current play-through. Not even FS writers can fix a broken saveword. You will have to start a new game if that happens. IF YOU DECIDE TO USE THIS, PLEASE BACKUP YOUR SAVES.", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
                    Case MsgBoxResult.Yes
                        My.Settings.RawEditsEnable = True
                        'saving
                        My.Settings.Save()
            ' Do something if yes
                    Case MsgBoxResult.No
                        'if user does not agree, change button back
                        MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
                End Select

            ElseIf My.Settings.RawEditsEnable = True Then

            End If

        End If

        If MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Left Then

            My.Settings.RawEditsEnable = False
            'saving
            My.Settings.Save()

        End If

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        MainForm.UpdaterOptions()
    End Sub
End Class