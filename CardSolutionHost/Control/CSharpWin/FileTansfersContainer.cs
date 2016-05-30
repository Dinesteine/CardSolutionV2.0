using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace CSharpWin
{
    public class FileTansfersContainer : Panel
    {
        private IFileTransfersItemText _fileTransfersItemText;

        public FileTansfersContainer()
        {
            this.AutoScroll = true;
        }

        public FileTransfersItem AddItem(string text, string fileName, Image image, long fileSize, FileTransfersItemStyle style)
        {
            FileTransfersItem item = new FileTransfersItem
            {
                Text = text,
                FileName = fileName,
                Image = image,
                FileSize = fileSize,
                Style = style,
                FileTransfersText = this.FileTransfersItemText,
                Dock = DockStyle.Top
            };
            base.SuspendLayout();
            base.Controls.Add(item);
            item.BringToFront();
            base.ResumeLayout(true);
            return item;
        }

        public FileTransfersItem AddItem(string name, string text, string fileName, Image image, long fileSize, FileTransfersItemStyle style)
        {
            FileTransfersItem item = new FileTransfersItem
            {
                Name = name,
                Text = text,
                FileName = fileName,
                Image = image,
                FileSize = fileSize,
                Style = style,
                FileTransfersText = this.FileTransfersItemText,
                Dock = DockStyle.Top
            };
            base.SuspendLayout();
            base.Controls.Add(item);
            item.BringToFront();
            base.ResumeLayout(true);
            return item;
        }

        public void RemoveItem(FileTransfersItem item)
        {
            base.Controls.Remove(item);
        }

        public void RemoveItem(Predicate<FileTransfersItem> match)
        {
            FileTransfersItem itemRemove = null;
            foreach (FileTransfersItem item in base.Controls)
            {
                if (match(item))
                {
                    itemRemove = item;
                }
            }
            base.Controls.Remove(itemRemove);
        }

        public void RemoveItem(string name)
        {
            base.Controls.RemoveByKey(name);
        }

        public FileTransfersItem Search(Predicate<FileTransfersItem> match)
        {
            foreach (FileTransfersItem item in base.Controls)
            {
                if (match(item))
                {
                    return item;
                }
            }
            return null;
        }

        public FileTransfersItem Search(string name)
        {
            return (base.Controls[name] as FileTransfersItem);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IFileTransfersItemText FileTransfersItemText
        {
            get
            {
                if (this._fileTransfersItemText == null)
                {
                    this._fileTransfersItemText = new CSharpWin.FileTransfersItemText();
                }
                return this._fileTransfersItemText;
            }
            set
            {
                this._fileTransfersItemText = value;
                foreach (FileTransfersItem item in base.Controls)
                {
                    item.FileTransfersText = this._fileTransfersItemText;
                }
            }
        }
    }
}

