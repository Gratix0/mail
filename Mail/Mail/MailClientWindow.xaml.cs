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
    /// 
    public partial class MailClientWindow : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        public static MailClientWindow mailClientWindow;
        string folder;
        MessageCollection messages;
        public MailClientWindow()
        {
            InitializeComponent();
            foreach (var item in folders) 
            {
                  FolderList.Items.Add(item.Name);
            }
        }


        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void FolderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageList.Items.Clear();
            folder = FolderList.SelectedItem.ToString();
            messages = ImapHelper.GetMessagesForFolder(folder);

            AddListView(messages);
        }

        private void AddListView(MessageCollection messages)
        {
            foreach (var mes in messages)
            {
                //Добавляем в листвью
                if (mes.Subject == " " || mes.Subject == "" || mes.Subject == null)
                {
                    mes.Subject = "Без темы";
                    MessageList.Items.Add(mes.Subject);
                }
                else
                {
                    MessageList.Items.Add(mes.Subject);
                }
            }
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //if (Mouse.LeftButton == MouseButtonState.Pressed)
            //{
            //    MailClientWindow.mailClientWindow.DragMove();
            //}
        }

        private void MessageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
