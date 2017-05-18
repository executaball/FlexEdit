Public Class Form1

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles metrobutton_cancel.Click
        Me.Close()
    End Sub

    Private Sub checkbox_saveword2_Click(sender As Object, e As EventArgs) Handles checkbox_saveword2.Click

        If checkbox_saveword2.Checked = True Then

            textbox_saveword2.Enabled = True
            MainForm.saveword2enabled = True

        ElseIf checkbox_saveword2.Checked = False Then

            textbox_saveword2.Enabled = False
            textbox_saveword3.Enabled = False
            checkbox_saveword3.Checked = False

            MainForm.saveword2enabled = False
            MainForm.saveword3enabled = False

        End If

    End Sub

    Private Sub checkbox_saveword3_Click(sender As Object, e As EventArgs) Handles checkbox_saveword3.Click

        If textbox_saveword2.Enabled = True Then

            If checkbox_saveword3.Checked = True Then

                textbox_saveword3.Enabled = True
                MainForm.saveword3enabled = True

            ElseIf checkbox_saveword3.Checked = False Then

                textbox_saveword3.Enabled = False
                MainForm.saveword3enabled = False

            End If

        ElseIf textbox_saveword2.Enabled = False Then

            checkbox_saveword3.Checked = False
            textbox_saveword3.Enabled = False
            MsgBox("Sorry, you cannot enable saveword part 3 without enabling part 2.")

            MainForm.saveword3enabled = False

        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub textbox_saveword1_Click(sender As Object, e As EventArgs) Handles textbox_saveword1.Click
        textbox_saveword1.Text = ""
        textbox_saveword1.ForeColor = Color.Black
    End Sub

    Private Sub textbox_saveword2_Click(sender As Object, e As EventArgs) Handles textbox_saveword2.Click
        textbox_saveword2.Text = ""
        textbox_saveword2.ForeColor = Color.Black
    End Sub

    Private Sub textbox_saveword3_Click(sender As Object, e As EventArgs) Handles textbox_saveword3.Click
        textbox_saveword3.Text = ""
        textbox_saveword3.ForeColor = Color.Black
    End Sub

    Private Sub textbox_saveword1_TextChanged(sender As Object, e As EventArgs) Handles textbox_saveword1.TextChanged
        If textbox_saveword1.Text IsNot "" Then
            metrobutton_load.Enabled = True
            metrobutton_load.ColorScheme.AccentColor = Color.FromArgb(0, 164, 240)
            metrobutton_load.ColorScheme.BorderColor = Color.FromArgb(98, 98, 98)
            metrobutton_load.ColorScheme.FillColor = Color.White
            metrobutton_load.ColorScheme.HoverFillColor = Color.White
            metrobutton_load.ColorScheme.PressAccentColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.PressFillColor = Color.FromArgb(101, 101, 101)
        Else
            metrobutton_load.Enabled = False
            metrobutton_load.ColorScheme.AccentColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.BorderColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.FillColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.HoverFillColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.PressAccentColor = Color.FromArgb(101, 101, 101)
            metrobutton_load.ColorScheme.PressFillColor = Color.FromArgb(101, 101, 101)
        End If
    End Sub

    Private Sub textbox_saveword2_TextChanged(sender As Object, e As EventArgs) Handles textbox_saveword2.TextChanged

    End Sub

    Private Sub textbox_saveword3_TextChanged(sender As Object, e As EventArgs) Handles textbox_saveword3.TextChanged

    End Sub

    Private Sub button_load_Click(sender As Object, e As EventArgs) Handles button_load.Click

    End Sub

    Private Sub button_cancel_Click(sender As Object, e As EventArgs) Handles button_cancel.Click
        Me.Close()
    End Sub
End Class