
Imports System.Net
Imports System.Text.Encoding
Public Class Form1
    Dim ipadd As New Sockets.UdpClient(0)
    Dim port As New Sockets.UdpClient(100)
    Dim portnum As String = "100"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        port.Client.ReceiveTimeout = 100
        port.Client.Blocking = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ipadd.Connect(TextBox1.Text, portnum)
        Dim send() As Byte = UTF8.GetBytes(TextBox3.Text)
        ipadd.Send(send, send.Length)
        TextBox2.Text = TextBox2.Text & Environment.NewLine & TextBox3.Text
        TextBox3.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            Dim ep As IPEndPoint = New IPEndPoint(IPAddress.Any, portnum)
            Dim rec() As Byte = port.Receive(ep)
            TextBox2.Text = TextBox2.Text & Environment.NewLine & UTF8.GetString(rec)
        Catch ex As Exception

        End Try
    End Sub
End Class
