Imports System.Net
Imports System.Net.Mail
Imports System.Speech.Synthesis

Public Class frmAbout

  'Public synth As New Speech.Synthesis.SpeechSynthesizer
  'Public WithEvents recognizer As New Speech.Recognition.SpeechRecognitionEngine
  'Dim gram As New System.Speech.Recognition.DictationGrammar()

  Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    rtbHelp.Rtf = My.Resources.MakoCELO_HelpFile_0446

  End Sub

  Private Sub frmAbout_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    'R4.00 Textbox defaults to all text selected.
    'tbHelp.SelectionLength = 0
  End Sub

  Private Sub frmAbout_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    'R4.10 KEY PREVIEW is on, check for ESCAPE or RETURN to exit.
    If (e.KeyCode = 27) Or (e.KeyCode = 13) Then Me.Close()

  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    Dim Recipients As New List(Of String)
    Recipients.Add("Receiver@hotmail.com")
    Dim FromEmailAddress As String = "Sender@hotmail.com"
    Dim Subject As String = "This email came from MakoCELO."
    Dim Body As String = "This code is not implemented but here for future possible use."
    Dim UserName As String = "Sender@hotmail.com"
    Dim Password As String = ""
    Dim Port As Integer = 587
    Dim Server As String = "smtp.live.com"
    Dim Attachments As New List(Of String)
    MsgBox(SendEmail(Recipients, FromEmailAddress, Subject, Body, UserName, Password, Server, Port, Attachments))

  End Sub

  Function SendEmail(ByVal Recipients As List(Of String), ByVal FromAddress As String, ByVal Subject As String, ByVal Body As String, ByVal UserName As String, ByVal Password As String, Optional ByVal Server As String = "smtp.live.com", Optional ByVal Port As Integer = 587, Optional ByVal Attachments As List(Of String) = Nothing) As String

    Dim Email As New MailMessage()

    Try
      Dim SMTPServer As New SmtpClient
      For Each Attachment As String In Attachments
        Email.Attachments.Add(New Attachment(Attachment))
      Next
      Email.From = New MailAddress(FromAddress)
      For Each Recipient As String In Recipients
        Email.To.Add(Recipient)
      Next
      Email.Subject = Subject
      Email.Body = Body
      SMTPServer.Host = Server
      SMTPServer.Port = Port
      SMTPServer.Credentials = New System.Net.NetworkCredential(UserName, Password)
      SMTPServer.EnableSsl = True
      SMTPServer.Send(Email)
      Email.Dispose()
      Return "Email to " & Recipients(0) & " from " & FromAddress & " was sent."

    Catch ex As SmtpException
      Email.Dispose()
      Return ex.Message
      '    Return "Sending Email Failed. Smtp Error."

    Catch ex As ArgumentOutOfRangeException
      Email.Dispose()
      Return "Sending Email Failed. Check Port Number."

    Catch Ex As InvalidOperationException
      Email.Dispose()
      Return "Sending Email Failed. Check Port Number."

    End Try

  End Function


End Class