Public Class Form7

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        'ProgressBar1.Value = ProgressBar1.Value + 5
        Label1.Text = ProgressBar1.Value & "%"

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Form1.Show()
            Me.Close()

        End If
    End Sub
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()


    End Sub
End Class