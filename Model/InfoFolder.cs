using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp18.Model
{
    internal class InfoFolder
    {
        public Folder GetFolder(CommonFolderCollection folders, string NameFolder)
        {
            if (NameFolder == "All")
            {
                return folders.All;
            }
            else if (NameFolder == "Archive")
            {
                return folders.Archive;
            }
            else if (NameFolder == "Inbox")
            {
                return folders.Inbox;
            }
            else if (NameFolder == "Drafts")
            {
                return folders.Drafts;
            }
            else if (NameFolder == "Important")
            {
                return folders.Important;
            }
            else if (NameFolder == "Flagged")
            {
                return folders.Flagged;
            }
            else if (NameFolder == "Junk")
            {
                return folders.Junk;
            }
            else if (NameFolder == "Sent")
            {
                return folders.Sent;
            }
            else if (NameFolder == "Trash")
            {
                return folders.Trash;
            }
            else
            {
                return null;
            }


        }
    }
