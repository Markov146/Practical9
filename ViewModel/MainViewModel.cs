using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp18.Model;

namespace WpfApp18.ViewModel
{
    internal class MainViewModel
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        private List<Folder> folder = new List<Folder>();
        private Frame mainFrame;


        public BindableCommand AddCommand { get; set; }
        public MainViewModel(Frame frame)
        {
            mainFrame = frame;
            AddCommand = new BindableCommand(parameter => Cl_Frame_InBox(parameter)); 

        }

        private void Cl_Frame_InBox(object commandParameter)
        {
            if (commandParameter is string parameter)
            {
                InfoInFolder info = new InfoInFolder();
                Folder fold = info.GetFolder(folders, parameter);
                mainFrame.Content = new InBoxPage(mainFrame, fold);
            }
        }
    }
}
