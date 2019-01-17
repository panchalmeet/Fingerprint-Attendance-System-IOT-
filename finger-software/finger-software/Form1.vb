Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form7.Show()

        UsernameTextBox.Focus()
        UsernameTextBox.CharacterCasing = CharacterCasing.Lower
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim login = LoginTableAdapter.UserPassString(UsernameTextBox.Text, PasswordTextBox.Text)
        If login Is Nothing Then
            MessageBox.Show("Invalid Username Or Password")
            Button1.BackColor = Color.Red
            UsernameTextBox.Clear()
            PasswordTextBox.Clear()
            UsernameTextBox.Focus()
        Else
            MsgBox("Login Successful")
            Button1.BackColor = Color.Green
            Dim x As form2 = New form2
            x.ShowDialog()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub LoginBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles LoginBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Stu1DataSet)
    End Sub
End Class
