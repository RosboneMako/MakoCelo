using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MakoCelo
{
    public partial class frmAbout
    {
        public frmAbout()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
        }

        // Public synth As New Speech.Synthesis.SpeechSynthesizer
        // Public WithEvents recognizer As New Speech.Recognition.SpeechRecognitionEngine
        // Dim gram As New System.Speech.Recognition.DictationGrammar()

        private void frmAbout_Load(object sender, EventArgs e)
        {
            rtbHelp.Rtf = My.Resources.Resources.MakoCELO_HelpFile_0446;
        }

        private void frmAbout_Shown(object sender, EventArgs e)
        {
            // R4.00 Textbox defaults to all text selected.
            // tbHelp.SelectionLength = 0
        }

        private void frmAbout_KeyDown(object sender, KeyEventArgs e)
        {

            // R4.10 KEY PREVIEW is on, check for ESCAPE or RETURN to exit.
            if ((int)e.KeyCode == 27 | (int)e.KeyCode == 13)
                Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var Recipients = new List<string>();
            Recipients.Add("Receiver@hotmail.com");
            string FromEmailAddress = "Sender@hotmail.com";
            string Subject = "This email came from MakoCELO.";
            string Body = "This code is not implemented but here for future possible use.";
            string UserName = "Sender@hotmail.com";
            string Password = "";
            int Port = 587;
            string Server = "smtp.live.com";
            var Attachments = new List<string>();
            Interaction.MsgBox(SendEmail(Recipients, FromEmailAddress, Subject, Body, UserName, Password, Server, Port, Attachments));
        }

        public string SendEmail(List<string> Recipients, string FromAddress, string Subject, string Body, string UserName, string Password, string Server = "smtp.live.com", int Port = 587, List<string> Attachments = null)
        {
            var Email = new MailMessage();
            try
            {
                var SMTPServer = new SmtpClient();
                foreach (string Attachment in Attachments)
                    Email.Attachments.Add(new Attachment(Attachment));
                Email.From = new MailAddress(FromAddress);
                foreach (string Recipient in Recipients)
                    Email.To.Add(Recipient);
                Email.Subject = Subject;
                Email.Body = Body;
                SMTPServer.Host = Server;
                SMTPServer.Port = Port;
                SMTPServer.Credentials = new NetworkCredential(UserName, Password);
                SMTPServer.EnableSsl = true;
                SMTPServer.Send(Email);
                Email.Dispose();
                return "Email to " + Recipients[0] + " from " + FromAddress + " was sent.";
            }
            catch (SmtpException ex)
            {
                Email.Dispose();
                return ex.Message;
            }
            // Return "Sending Email Failed. Smtp Error."

            catch (ArgumentOutOfRangeException ex)
            {
                Email.Dispose();
                return "Sending Email Failed. Check Port Number.";
            }
            catch (InvalidOperationException Ex)
            {
                Email.Dispose();
                return "Sending Email Failed. Check Port Number.";
            }
        }
    }
}