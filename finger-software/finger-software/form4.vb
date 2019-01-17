Imports System
Imports System.Threading
Imports System.ComponentModel
Public Class form4
    Dim myport As Array
    Delegate Sub setTextCallBack(ByVal [text] As String)
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Sub connectDB()
        con.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT\finger-software\finger-software\stu1.accdb")
        rs.Open("select * from stu_info", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        SerialPort1.Close()
    End Sub
    Private Sub Button1_Click(sendertet As Object, e As EventArgs) Handles Button1.Click
        Try
            Call connectDB()
            rs.AddNew()
            rs(0).Value = TextBox1.Text
            rs(1).Value = TextBox2.Text
            rs(2).Value = TextBox3.Text
            rs(3).Value = TextBox4.Text
            rs(4).Value = DateTimePicker1.Text
            rs(5).Value = TextBox6.Text
            rs(6).Value = RichTextBox1.Text
            SerialPort1.Write(TextBox1.Text & vbCr)
            rs.Update()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox6.Clear()
            RichTextBox1.Clear()
        Catch ex As Exception
            MessageBox.Show("Please Enter Valid Candidates")
        End Try
        con.Close()
    End Sub
    Private Sub form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myport = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myport)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.Open()
    End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        MessageBox.Show(SerialPort1.ReadLine())
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub
End Class