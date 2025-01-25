Imports System.ComponentModel

Public Class Form8
    Dim isConnected As Boolean = False
    Dim myPort As Array
    Delegate Sub SetTextCallBack(ByVal [text] As String)

    Dim A, C
    Dim RR(20), GG(20)
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 設定 Timer1 顯示時間
        Timer1.Interval = 1000
        Timer1.Start()
        ' 定義我的 IO Port 接角有哪些並顯示到 cbo1
        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myPort)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If isConnected = True Then
            For i = 0 To 7
                GG(i).FillStyle = 1
                RR(i).FillStyle = 1
            Next
            If A = 1 Then
            End If
        End If

        A = 0 : C = 0
        Display(GG(C))
        Dim colors As Color() = {Color.Green, Color.Green, Color.Green, Color.Green, Color.Green, Color.Green, Color.Green}
    End Sub

    Private Sub Display(No)
        For i = 0 To 7
            If No Mod 2 = 1 And A = 1 Then GG(i).FillColor = RGB(0, 255, 0)
            If No Mod 2 = 1 And A = 2 Then RR(i).FillColor = RGB(255, 0, 0)
            No = No \ 2
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim isConnected As Boolean = False

        If ComboBox1.SelectedItem IsNot Nothing Then
            SerialPort1.PortName = ComboBox1.SelectedItem.ToString()

            SerialPort1.BaudRate = 9600
            Try
                SerialPort1.Open()
                Button1.Text = "Disconnect Bluetooth"
                isConnected = True
            Catch ex As Exception

            End Try
            isConnected = True
        Else
            isConnected = False
        End If

        ' 初始化 SerialPort
        SerialPort1 = New IO.Ports.SerialPort
        SerialPort1.BaudRate = 9600
        SerialPort1.Parity = IO.Ports.Parity.None
        SerialPort1.DataBits = 8
        SerialPort1.StopBits = IO.Ports.StopBits.One
        SerialPort1.Handshake = IO.Ports.Handshake.None
        ' 開啟連接
        Try
            SerialPort1.Open()
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("通訊埠被佔用:" & ex.Message)
        Catch ex As Exception

        End Try

        If isConnected Then
            SerialPort1.Close()
            Button1.Text = "DisConnect Bluetooth"
        End If

        Try
            If ComboBox1.SelectedItem IsNot Nothing Then
                SerialPort1.DiscardInBuffer()
                SerialPort1.DiscardOutBuffer()
                SerialPort1.Close()
                'Threading.Thread.Sleep(100)
            End If
            isConnected = False
            Button1.Text = "Connect Bluetooth"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox1.Text = "Current Time: " & DateTime.Now.ToString("hh:mm:ss tt")
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        Dim r As Graphics = e.Graphics
        Dim brush As Brush = Brushes.White
        Dim pen As Pen = Pens.Black
        For i As Integer = 0 To 15
            g.FillEllipse(brush, 50 + i * 30, 100, 20, 20) ' 填充圓形
            g.DrawEllipse(pen, 50 + i * 30, 100, 20, 20)  ' 畫圓邊
        Next

        'For j As Integer = 0 To 7
        '    r.FillEllipse(brush, 50 + j * 30, 100, 20, 20) '填充圖形
        '    r.DrawEllipse(pen, 50 + j * 30, 100, 20, 20) '畫圖邊
        'Next
    End Sub
End Class