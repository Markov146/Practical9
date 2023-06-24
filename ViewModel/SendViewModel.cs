using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace WpfApp18.ViewModel
{
    internal class SendViewModel
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { subject = value; OnPropertyChanged(); }
        }
        private string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; OnPropertyChanged(); }
        }
        public BindableCommand AddCommand { get; set; }
        public LoggedUser LoggedUser;
        RichTextBox textBox;
        Frame mainFrame = new Frame();

        public SendViewModel(Frame frame, RichTextBox textbox)
        {
            textBox = textbox;
            LoggedUser = ImapHelper.GetCredentials();
            AddCommand = new BindableCommand(_ => Send());
        }

        private void Send()
        {
            try
            {
                TextRange text = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                HtmlRtfConverter.ToHtml(text);
                MailMessage messege = new MailMessage(LoggedUser.Email, Subject, Email, text.Text);
                messege.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(LoggedUser.SmtpHost);
                smtp.Credentials = new NetworkCredential(LoggedUser.Email, LoggedUser.Pass);
                smtp.EnableSsl = true;
                smtp.Send(messege);
                mainFrame.Content = new InBoxPage(mainFrame);
            }
            catch (Exception ex) { MessageBox.Show("Заполни поля в правильно"); }

        }
    }
}
