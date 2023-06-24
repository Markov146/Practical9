using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace WpfApp18.ViewModel
{
    internal class MessageViewModel
    {
        private string _recipient;
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; OnPropertyChanged(); }
        }

        private string _sender;
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; OnPropertyChanged(); }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; OnPropertyChanged(); }
        }

        private FlowDocument _richTextContent;
        public FlowDocument RichTextContent
        {
            get { return _richTextContent; }
            set { _richTextContent = value; OnPropertyChanged(); }
        }
        public BindableCommand AddCommand { get; set; }

        Frame fframe = new Frame();

        public MessageViewModel(Message message, RichTextBox richTextBox, Frame frame)
        {
            fframe = frame;
            AddCommand = new BindableCommand(_ => SendViewClick(fframe));
            HtmlRtfConverter converter = new HtmlRtfConverter();
            Recipient = message.To.FirstOrDefault()?.Address;
            Sender = message.From.Address;
            Subject = message.Subject;

            HtmlRtfConverter.ToRtf(message.Body.Html);
            var text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            FileStream fs = new FileStream("msg.rtf", FileMode.Open);
            text.Load(fs, DataFormats.Rtf);
            fs.Close();
            File.Delete("msg.rtf");
            // Начальное значение RichTextContent может быть установлено здесь, если необходимо
        }
        private void SendViewClick(Frame frame)
        {
            frame.Content = new SendPage(frame);
        }
    }
}
