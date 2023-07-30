Imports System.IO

Public Class Form1


    Dim FileRead As StreamReader
    Dim FileWrite As StreamWriter
    Dim accountname As String
    Dim passcode As String
    Dim getfiletxt As String
    Dim fname As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accountname = TextBox1.Text
        passcode = TextBox2.Text
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MessageBox.Show("Please enter the account name and Password")
                Exit Sub
            End If
            accountname = TextBox1.Text.Trim.ToLower
            fname = "E:\PROJECTS\VS\PasscodeManagement\passcode\" + accountname + ".txt"
            If System.IO.File.Exists(fname) Then
                MessageBox.Show(accountname + " account name already exist please use another account name")
                Exit Sub
            Else
                FileWrite = My.Computer.FileSystem.OpenTextFileWriter("E:\PROJECTS\VS\PasscodeManagement\passcode\" + accountname + ".txt", True)

                FileWrite.WriteLine("Account Name: " + accountname + " Password: " + passcode)
                FileWrite.Close()
                MessageBox.Show("Password stored successfully against " + accountname + " account")
                Button1.Enabled = False
                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accountname = TextBox3.Text
        Try
            If TextBox3.Text = "" Then
                MessageBox.Show("Please enter the account name")
                Exit Sub
            End If
            accountname = TextBox3.Text.Trim.ToLower
            fname = "E:\PROJECTS\VS\PasscodeManagement\passcode\" + accountname + ".txt"
            If Not System.IO.File.Exists(fname) Then
                MessageBox.Show(accountname + " account is not found, please enter the valid account name")
                Exit Sub
            Else
                FileRead = My.Computer.FileSystem.OpenTextFileReader("E:\PROJECTS\VS\PasscodeManagement\passcode\" + accountname + ".txt")
                getfiletxt = FileRead.ReadToEnd()
                RichTextBox1.Text = getfiletxt
                FileRead.Close()
                Button2.Enabled = False
                RichTextBox1.ReadOnly = True
                TextBox3.ReadOnly = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim updfilename As String
        accountname = TextBox5.Text
        passcode = TextBox4.Text
        Try
            If TextBox4.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("Please enter the existing account name and set updated Password")
                Exit Sub
            End If
            accountname = TextBox5.Text.Trim.ToLower
            updfilename = "E:\PROJECTS\VS\PasscodeManagement\passcode\" + accountname + ".txt"

            If Not System.IO.File.Exists(updfilename) Then
                MessageBox.Show(accountname + " account is not found, please enter the valid account name")
            Else
                System.IO.File.Delete(updfilename)
                FileWrite = My.Computer.FileSystem.OpenTextFileWriter(updfilename, True)
                FileWrite.WriteLine("Account Name: " + accountname + " Password: " + passcode)
                FileWrite.Close()
                MessageBox.Show("Password updated successfully against " + accountname + " account")
                Button3.Enabled = False
                TextBox4.ReadOnly = True
                TextBox5.ReadOnly = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class
