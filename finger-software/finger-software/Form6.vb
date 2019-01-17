Public Class form6
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Sub connectDB()
        con.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT\finger-software\finger-software\stu1.accdb")
        rs.Open("select * from stu_info", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If TextBox1.Text = "" Then
            ListView1.Items.Clear()
            Return
        End If
        Call connectDB()
        If rs.BOF = True Then
            con.Close()
            Return
        End If
        ListView1.Items.Clear()
        rs.MoveFirst()
        Do Until rs.EOF = True
            If StrComp(TextBox1.Text, Mid(rs(0).Value, 1, Len(TextBox1.Text)), vbTextCompare) = 0 Then
                ListView1.Items.Add(rs(0).Value)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(rs(0).Value)
            End If
            rs.MoveNext()
        Loop
        con.Close()
    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Dim item As String = ListView1.Items(ListView1.SelectedIndices(0)).Text
        connectDB()
        rs.MoveFirst()
        Do Until rs.EOF = True
            If item = rs(0).Value Then
                TextBox7.Text = rs(0).Value
                TextBox2.Text = rs(1).Value
                TextBox3.Text = rs(2).Value
                TextBox4.Text = rs(3).Value
                TextBox5.Text = rs(4).Value
                TextBox6.Text = rs(5).Value
                RichTextBox1.Text = rs(6).Value
                Exit Do
            End If
            rs.MoveNext()
        Loop
        con.Close()
    End Sub
    Sub clearText()
        TextBox7.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        RichTextBox1.Clear()
        ListView1.Clear()
        TextBox1.Focus()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connectDB()
        rs.MoveFirst()
        Do Until rs.EOF = True
            If rs(0).Value = TextBox1.Text Then
                rs.Delete()
                MsgBox("Data Deleted Successfully")
                Exit Do
            End If
            rs.MoveNext()
        Loop
        con.Close()
        clearText()
    End Sub
    Private Sub form6_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Focus()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
End Class