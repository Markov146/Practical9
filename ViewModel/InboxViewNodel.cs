using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp18.ViewModel
{
    internal class InboxViewNodel
    {
        #region Методы

        private MessageCollection messages;
        private MessageCollection itemInList;
        private Message selectedMessage;
        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set { selectedMessage = value; OnPropertyChanged(); }
        }
        public MessageCollection ItemInList
        {
            get { return itemInList; }
            set { itemInList = value; OnPropertyChanged(); }
        }

        public BindableCommand SelectionChangedCommand { get; set; }
        #endregion
        public InBoxViewModel(Frame frame, Folder folder = null)
        {
            if (folder != null)
            {
                SelectionChangedCommand = new BindableCommand(_ => SelectionChangedExecute(SelectedMessage, frame));
                Task.Run(() =>
                {
                    messages = ImapHelper.GetMessagesForFolder(folder.Name);
                    ItemInList = messages;
                });
            }
            { }
        }
        private void SelectionChangedExecute(object parameter, Frame frame)
        {
            SelectedMessage = parameter as Message;

            if (SelectedMessage != null)
            {
                frame.Content = new MessagePage(SelectedMessage, frame);
            }
        }

    }
}
  