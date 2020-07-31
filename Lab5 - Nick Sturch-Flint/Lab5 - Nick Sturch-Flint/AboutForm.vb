Option Strict On

''' <summary>
''' Adds text to the label for the form
''' </summary>
Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAbout.Text = "NETD2200" & Environment.NewLine & Environment.NewLine & "Lab #5" & Environment.NewLine & Environment.NewLine & "N. Sturch-Flint"
    End Sub
End Class