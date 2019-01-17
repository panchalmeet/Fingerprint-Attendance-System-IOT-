Imports System
Imports System.Threading
Imports System.ComponentModel
Public Class Form3
    Dim myport As Array
    Delegate Sub setTextCallBack(ByVal [text] As String)
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Sub connectDB()
        con.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT\finger-software\finger-software\stu1.accdb")
        rs.Open("select * from finger_match", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        MessageBox.Show(SerialPort1.ReadLine())
    End Sub
    Public Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myport = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myport)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Call connectDB()
            rs.MoveFirst()
            rs.AddNew()
            rs(0).Value = TextBox1.Text
            rs(1).Value = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
            If TextBox1.TextLength > 0 Then
                rs(2).Value = "Present"
            Else
                rs(2).Value = "Absent"
            End If
            rs.Update()
        Catch ex As Exception
            MessageBox.Show("Please Enter Valid Candidates")
        End Try
        con.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.Open()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        SerialPort1.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

End Class