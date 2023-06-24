using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp18.Model;

namespace WpfApp18.ViewModel
{
    internal class StartViewModel
    {
        Window WinWork;
        public BindableCommand AddCommand { get; set; }
        private ObservableCollection<AutorezationMail> _itemInComboBox = new ObservableCollection<AutorezationMail>();
        public StartViewModel(Window win)
        {
            WinWork = win;
            ItemInComboBox = new ObservableCollection<AutorezationMail>
            {
             new AutorezationMail { Email = "Mail.ru", Link = "imap.mail.ru" },
             new AutorezationMail { Email = "Ramnler.ru", Link = "imap.rambler.ru" },
             new AutorezationMail { Email = "Yandex.ru", Link = "imap.yandex.ru " }
            };
            AddCommand = new BindableCommand(_ => AutorizationClick());
        }

        private string password;
        private string login;
        int mail;

        public ObservableCollection<AutorezationMail> ItemInComboBox
        {
            get { return _itemInComboBox; }
            set { _itemInComboBox = value; }
        }
        public int Mail
        {
            get { return mail; }
            set { mail = value; OnPropertyChanged(); }
        }

        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private void AutorizationClick()
        {
            ImapHelper.Initialize(_itemInComboBox[Mail].Link.ToString());
            try
            {
                if (ImapHelper.Login(login, password))
                {
                    Window window = new MainWindow();
                    window.Show();
                    WinWork.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
}
