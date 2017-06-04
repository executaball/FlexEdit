Public Class SettingsForm
    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click
        Me.Close()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        If My.Settings.RawEditsEnable = True Then
            MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Right
        Else
            MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
        End If

        If My.Settings.MakeBackupsOnSave = True Then
            MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Right
        Else
            MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
        End If

        If My.Settings.AutoupdatePref = True Then
            MetroSwitch4.Status = MetroSuite.MetroSwitch.CurrentStatus.Right
        Else
            MetroSwitch4.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
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

            End If

        End If

        If MetroSwitch1.Status = MetroSuite.MetroSwitch.CurrentStatus.Left Then

            My.Settings.RawEditsEnable = False
            'saving
            My.Settings.Save()

        End If

    End Sub

    Private Sub MetroSwitch2_Click(sender As Object, e As EventArgs) Handles MetroSwitch2.Click
        MsgBox("Sorry, Saveword versioning is not implemented yet.", vbInformation, "FlexEdit")
        MetroSwitch2.Status = MetroSuite.MetroSwitch.CurrentStatus.Left
    End Sub

    Private Sub MetroSwitch3_Click(sender As Object, e As EventArgs) Handles MetroSwitch3.Click


        If MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Left Then

            If My.Settings.MakeBackupsOnSave = True Then

                Select Case MsgBox("Unexpected errors can happen on saving. If you make raw variable edits you are also highly advised to check this backup option. FlexEdit overwrites your save files directly. Are you sure you want to disable the creation of backup files on saving?", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
                    Case MsgBoxResult.Yes
                        My.Settings.MakeBackupsOnSave = False
                        'saving
                        My.Settings.Save()
            ' Do something if yes
                    Case MsgBoxResult.No
                        'if user does not agree, change button back
                        MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Right
                End Select

            End If

        End If

        If MetroSwitch3.Status = MetroSuite.MetroSwitch.CurrentStatus.Right Then

            My.Settings.MakeBackupsOnSave = True
            'saving
            My.Settings.Save()

        End If

    End Sub

    Private Sub MetroSwitch4_Click(sender As Object, e As EventArgs) Handles MetroSwitch4.Click


        If MetroSwitch4.Status = MetroSuite.MetroSwitch.CurrentStatus.Left Then

            If My.Settings.AutoupdatePref = True Then

                MsgBox("Checking for updates on app startup is now disabled. You can still check for updates by clicking the 'update' menu button.", vbInformation, "Autoupdates disabled")

                My.Settings.AutoupdatePref = False
                'saving
                My.Settings.Save()

            End If

        End If

        If MetroSwitch4.Status = MetroSuite.MetroSwitch.CurrentStatus.Right Then

            My.Settings.AutoupdatePref = True
            'saving
            My.Settings.Save()

        End If

    End Sub

End Class