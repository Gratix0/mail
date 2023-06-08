using ImapX.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mail
{
    /// <summary>
    /// Логика взаимодействия для MailClientWindow.xaml
    /// </summary>
    public partial class MailClientWindow : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        public static MailClientWindow mailClientWindow;
        MessageCollection messages;
        public MailClientWindow()
        {
            InitializeComponent();
            foreach (var item in folders) 
            {
                if (item.Name == "INBOX")
                {
                    FolderList.Items.Add("Входящие");
                }
                else
                {
                    FolderList.Items.Add(item.Name);
                }
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void FolderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string folder;
            string inbox = "INBOX";
            folder = FolderList.SelectedItem.ToString();
            if (folder == "Входящие")
            {
                messages = ImapHelper.GetMessagesForFolder(inbox);
            }
            Task.Run(() =>
            {
                 messages = ImapHelper.GetMessagesForFolder(folder);
            });
            MessageList.Items.Clear();
            foreach(var message in messages)
            {
                //Добавляем в листвью
                MessageList.Items.Add(message.Subject);
            }
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //if (Mouse.LeftButton == MouseButtonState.Pressed)
            //{
            //    MailClientWindow.mailClientWindow.DragMove();
            //}
        }
    }
}
