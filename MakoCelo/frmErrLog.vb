Public Class frmErrLog
  Private Sub frmErrLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim A As String = ""

    'R4.41 Get the data from the main form listbox.
    For t = 0 To frmMain.lstLog.Items.Count - 1
      A = A & frmMain.lstLog.Items(t) & vbCrLf
    Next

    'R4.41 Place the log data into the text box and unselect the text.
    tbErrLog.Text = A
    tbErrLog.SelectionStart = 0
    tbErrLog.SelectionLength = 0

  End Sub

  Private Sub cmCopy_Click(sender As Object, e As EventArgs) Handles cmCopy.Click
    'R4.41 Post the log to the clipboard.
    Clipboard.Clear()
    Clipboard.SetText(tbErrLog.Text)
  End Sub

  Private Sub cmExit_Click(sender As Object, e As EventArgs) Handles cmExit.Click
    Me.Close()
  End Sub

End Class