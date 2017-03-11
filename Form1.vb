Imports System.IO
Imports MySql
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Public IP As String
    Public Port As String
    Public c As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dr As MySqlDataReader
    Public ds, ds1 As New DataSet
    Public myConnectionString As String
    Dim X As Integer
    Dim Y As Integer
	Public databaseip as String = "127.0.0.1"
	Public username as String = "root"
	Public password as String = "root"
    Public database As String = "Nostale"
    Public Forum As String = "http://board.nostale.de/"
    Public Website As String = "http://nostale.de/"

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        X = e.X
        Y = e.Y
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = e.Button.Left Then
            Me.Left = e.X - X + Me.Left
            Me.Top = e.Y - Y + Me.Top
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub NosTale4DELauncher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            myConnectionString = "server=" + databaseip + ";uid=" + username + ";pwd=" + password + ";database=" + database + "; "
            c.ConnectionString = myConnectionString
            ds.Clear()
            c.Open()
            cmd = New MySqlCommand("select * from launcher", c)
            da = New MySqlDataAdapter(cmd)
            da.Fill(ds, "launcher")
            IP = ds.Tables(0).Rows(0).Item(1)
            Port = ds.Tables(0).Rows(0).Item(2)
            ds.Clear()
            cmd = New MySqlCommand("SELECT title,Content_launcher,date FROM blog SORT ORDER BY id DESC Limit 2", c)
            da = New MySqlDataAdapter(cmd)
            da.Fill(ds, "blog")
            Label1.Text = ds.Tables(1).Rows(0).Item(0)
            Label1.Text += vbNewLine
            Label1.Text += vbNewLine
            Label1.Text += ds.Tables(1).Rows(0).Item(1)
            Label2.Text = ds.Tables(1).Rows(1).Item(0)
            Label2.Text += vbNewLine
            Label2.Text += vbNewLine
            Label2.Text += ds.Tables(1).Rows(1).Item(1)
            Label3.Text = ds.Tables(1).Rows(0).Item(2)
            Label4.Text = ds.Tables(1).Rows(1).Item(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        c.Close()
    End Sub

    Private Sub ProgressBar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Application.Exit()

    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        PictureBox1.Image = My.Resources.Quit21

    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.Quit
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        PictureBox2.Image = My.Resources.Start41

    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.buttonstart

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Image = My.Resources.Quit
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Process.Start(Website)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Process.Start(Forum)
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim Test As String
        Dim Test2 As String
        Test = "IP="
        Test2 = "Port="
        Dim IP2 As String = (Test + IP)
        Dim PORT2 As String = (Test2 + Port)
        If Not File.Exists(Application.StartupPath + "/NostaleX.dat") Then
            MessageBox.Show("Please move the Launcher into your Nostale Folder")
        Else
            Dim path As String = Application.StartupPath + "/config.ini"
            Dim Checked As Boolean = False
            Dim port__1 As Boolean = False
            Dim ip__2 As Boolean = False
            If File.Exists(path) Then

                Dim list As New List(Of String)
                Using r As StreamReader = New StreamReader(path)
                    Dim line As String
                    line = r.ReadLine
                    Do While (Not line Is Nothing)
                        list.Add(line)
                        Console.WriteLine(line)
                        line = r.ReadLine
                    Loop
                    r.Close()
                End Using
                If list.Contains(PORT2) Then
                    port__1 = True
                End If
                If list.Contains(IP2) Then
                    ip__2 = True
                End If
                If ip__2 AndAlso port__1 Then
                    Checked = True
                Else
                    File.Delete(path)
                    Using sw As StreamWriter = File.CreateText(path)
                        sw.WriteLine("[NosTale_Network]")
                        sw.WriteLine(IP2)
                        sw.WriteLine(PORT2)
                        Checked = True
                        sw.Close()
                    End Using
                End If
            Else
                Using sw As StreamWriter = File.CreateText(path)
                    sw.WriteLine("[NosTale_Network]")
                    sw.WriteLine(IP2)
                    sw.WriteLine(PORT2)
                    Checked = True
                    sw.Close()
                End Using
            End If
            If Checked Then
                Dim nostalex As String = (Application.StartupPath + "/NostaleX.dat")
                Dim path2 As String = """"
                path2 += nostalex
                path2 += """"
                Dim argument As String = "/c START "
                argument += """"
                argument += """"
                argument += " "
                argument += path2
                argument += " EntwellNostaleClientLoadFromIni"
                Dim p As New Process()
                p.StartInfo = New ProcessStartInfo("cmd.exe", argument)
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.Start()
                Application.[Exit]()
            End If
        End If
    End Sub
End Class