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

                Select Case MsgBox("Are you sure you want to disable the raw variable edit warning prompt? Please backup your saves before editing any variables.", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
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

                Select Case MsgBox("FlexEdit overwrites your saveword files directly. Are you sure you want to disable the creation of backup files (txt files created alongside an export) on saving?", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
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