Public Class Balanceinq
    Dim cmd As New OleDb.OleDbCommand
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim con As New OleDb.OleDbConnection
    Dim sql As String

    Private Sub Balanceinq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = Date.Now


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Dim Log_in As New DataTable
        Try
            If txtpin.Text = "" Then
                MsgBox("Pls Enter Your Pin")

            Else
                con.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\ATMsystem.accdb")
                sql = "SELECT * FROM tblinfo where  pin_code = " & txtpin.Text & ""

                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da.SelectCommand = cmd
                da.Fill(Log_in)
                If Log_in.Rows.Count > 0 Then
                    Dim balance As String

                    balance = Log_in.Rows(0).Item("balance")

                    Receipt.Show()
                    'Receipt.lblaccno.Text = lblaccno.Text
                    Receipt.lblbal.Text = balance
                    Receipt.Label4.Hide()
                    Receipt.Label3.Hide()
                    Receipt.lbldep.Hide()
                    Receipt.lblwith.Hide()
                    Receipt.Label6.Hide()
                    Receipt.lblnewbal.Hide()

                    Me.Hide()


                Else
                    MsgBox("Pincode is incorrect")

                End If




            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try


        txtpin.Text = ""
    End Sub
End Class