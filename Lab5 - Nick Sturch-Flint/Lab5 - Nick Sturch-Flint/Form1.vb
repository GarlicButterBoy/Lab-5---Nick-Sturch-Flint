Option Strict On
Imports System.IO
Public Class TextEditorForm
    'declarations
    Dim workingFileName As String = String.Empty
    Dim tempString As String

    ''' <summary>
    ''' Starts a new file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewClick(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        txtMain.Text = String.Empty
        ' reset workingFileName
        workingFileName = String.Empty
        lblStatus.Text = "New File Started"
        tempString = txtMain.Text
    End Sub


    ''' <summary>
    ''' Opens an existing text file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenFile(sender As Object, e As EventArgs) Handles mnuFileOpen.Click
        Dim inputStream As StreamReader

        If openDialog.ShowDialog() = DialogResult.OK Then
            inputStream = New StreamReader(openDialog.FileName)
            txtMain.Text = inputStream.ReadToEnd()
            inputStream.Close()
            'update working file name
            workingFileName = openDialog.FileName
            tempString = txtMain.Text
            lblStatus.Text = "Loaded File " & openDialog.FileName
        End If
    End Sub


    ''' <summary>
    ''' When user clicks Save As
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveFileAs(sender As Object, e As EventArgs) Handles mnuFileSaveAs.Click

        '   prompt savefiledialog
        saveDialog.ShowDialog()
        '       workingFileName = saveDialog.filename
        workingFileName = saveDialog.FileName
        '   if savedialog is ok
        SaveRoutine(workingFileName) '     saveRoutine(workingFileName)
    End Sub


    ''' <summary>
    ''' When user clicks save and the file exists
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveExistingFile(sender As Object, e As EventArgs) Handles mnuFileSave.Click
        ' if workingFileName is empty
        If workingFileName = String.Empty Then
            '   prompt savefiledialog
            saveDialog.ShowDialog()
            workingFileName = saveDialog.FileName
            '   if savedialog is ok
            '       saveRoutine(workingFileName)
            SaveRoutine(workingFileName)
        Else
            SaveRoutine(workingFileName)
            lblStatus.Text = "Saved File " & saveDialog.FileName
        End If
    End Sub


    ''' <summary>
    ''' sub method to be called when saving a file
    ''' </summary>
    ''' <param name="filePath"></param>
    Private Sub SaveRoutine(ByVal filePath As String)

        ' declare streamwriter = New StreamWriter(filePath)
        Dim outputStream As StreamWriter = New StreamWriter(filePath)
        ' write text using streamwriter
        outputStream.Write(txtMain.Text)
        ' close streamwriter
        outputStream.Close()
        tempString = txtMain.Text
        lblStatus.Text = "Saved File " & saveDialog.FileName
    End Sub


    ''' <summary>
    ''' Method for the Copy Command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CopyClick(sender As Object, e As EventArgs) Handles mnuEditCopy.Click
        My.Computer.Clipboard.SetText(txtMain.SelectedText)
    End Sub


    ''' <summary>
    ''' Method for the Cut Command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CutClick(sender As Object, e As EventArgs) Handles mnuEditCut.Click
        My.Computer.Clipboard.SetText(txtMain.SelectedText)
        txtMain.SelectedText = ""
    End Sub


    ''' <summary>
    ''' Method for the Paste Command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PasteClick(sender As Object, e As EventArgs) Handles mnuEditPaste.Click
        txtMain.SelectedText = My.Computer.Clipboard.GetText()
    End Sub


    ''' <summary>
    ''' When the about button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutClick(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Dim aboutModal As New AboutForm

        aboutModal.ShowDialog() 'show new window
    End Sub


    ''' <summary>
    ''' When the close button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitClick(sender As Object, e As EventArgs) Handles mnuFileExit.Click

        ConfirmClose()

    End Sub

    Private Sub ConfirmClose()

        Dim confirmCloseModal As New ConfirmClose

        If txtMain.Text IsNot tempString Then 'if the file wasn't just saved, open prompt
            confirmCloseModal.ShowDialog()
        Else
            Me.Close()
        End If
    End Sub

End Class
