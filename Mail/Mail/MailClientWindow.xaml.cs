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
    public partial class MailClientWindow : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();
        public static MailClientWindow mailClientWindow;
        string folder, selectedSubject;
        MessageCollection messages;
        public MailClientWindow()
        {
            InitializeComponent();

            //Подгрузим все папки в интерфейс (левую панель с папками)
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

        /// <summary>
        /// Обработчик смены выбранной папки.
        /// </summary>
        private void FolderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //При каждом новом нажатии на папку будем отчищать правый лист с сообщениями и подгружать из выбраной папки
            MessageList.Items.Clear();
            folder = FolderList.SelectedItem.ToString();

            // Закоментировал т.к некорректно обновляются папки
            //Task.Run(() =>
            //{
            messages = ImapHelper.GetMessagesForFolder(folder);
            //});
            AddListView(messages);
            
        }


        /// <summary>
        /// Метод добавления сообщений в правую панель с собобщениями
        /// </summary>
        /// <param name="messages"></param>
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

        /// <summary>
        /// Возможность перетаскивания окна зажимая мышку на статусбаре
        /// </summary>
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //if (Mouse.LeftButton == MouseButtonState.Pressed)
            //{
            //    MailClientWindow.mailClientWindow.DragMove();
            //}
        }

        /// <summary>
        /// Вызов окна с формой для заполнения и отправления сообщения
        /// </summary>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Answer answer = new Answer();
            answer.ShowDialog();
        }

        /// <summary>
        /// Обработчки смены выделения сообщения
        /// </summary>
        private void MessageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            selectedSubject = MessageList.SelectedItem.ToString();
            
            SelectedMessage selectedMessage = new SelectedMessage(messages, selectedSubject);
            selectedMessage.ShowDialog();

            ContextMenu.Items.Add("");
            }
            catch(Exception ex)
            {

            }
            

        }
    }
}
