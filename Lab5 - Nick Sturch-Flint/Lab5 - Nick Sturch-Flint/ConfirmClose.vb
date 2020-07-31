Option Strict On

Public Class ConfirmClose

    Private Sub YesClick(sender As Object, e As EventArgs) Handles btnYes.Click
        Application.Exit()
    End Sub

    Private Sub NoClick(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.Close()
    End Sub

End Class