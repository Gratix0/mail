using ImapX.Collections;
using ImapX;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mail
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow window;

        public MainWindow()
        {
            InitializeComponent();
            window = this;
         
        }

        private void Drag(object sender, DragEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.window.DragMove();
            }
        }

        bool MainWindowState = false;                               //Статус размера окна
        /// <summary>
        /// Кнопка "Закрыть окно"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        /// <summary>
        /// Перемещение окна приложения мышью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Разворачивание/нормализация окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindowState)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                MainWindowState = true;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                MainWindowState = false;
            }

        }

        /// <summary>
        /// Кнопка Свернуть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ImapHelper.Initialize((MailComboBox.SelectedItem as ComboBoxItem).Tag.ToString());
                if (ImapHelper.Login(MailComboBox.Text, PasswordTextBox.Text))
                {
                    //Переход на новое окно
                    MailClientWindow mailClientWindow = new MailClientWindow();
                    mailClientWindow.ShowDialog();
                    window.Hide();
                    Obosrams obosrams = new Obosrams("Суксес");
                }
                else
                {
                    Obosrams obosrams = new Obosrams("Данные вводи");
                }
            }
            catch (Exception ex)
            {
                Obosrams obosrams = new Obosrams("Данные вводи");
                obosrams.ShowDialog();
            }
        }
    }

    internal class LoggedUser
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string SmtpHost { get; set; }
    }
    internal class ImapHelper
    {
        private static ImapClient client { get; set; }
        private static LoggedUser loggedUser { get; set; } = new LoggedUser();
        public static void Initialize(string host)
        {
            client = new ImapClient(host, true);
            if (!client.Connect())
            {
                throw new Exception("Error connecting to the client.");
            }
            else
            {
                loggedUser.SmtpHost = host.Replace("imap", "smtp");
            }
        }
        public static bool Login(string u, string p)
        {
            loggedUser.Email = u;
            loggedUser.Pass = p;
            return client.Login(u, p);

        }
        public static void Logout()
        {
            // Remove the login value from the client.
            if (client.IsAuthenticated)
            {
                client.Logout();
                client.Dispose();
            }
        }
        public static CommonFolderCollection GetFolders()
        {
            client.Folders.Inbox.StartIdling(); // And continue to listen for more.
            client.Folders.Inbox.OnNewMessagesArrived += Inbox_OnNewMessagesArrived;
            return client.Folders;
        }
        private static void Inbox_OnNewMessagesArrived(object sender, IdleEventArgs e)
        {
            // Show a dialog
            MessageBox.Show($"Пришло новое сообщение в папку {e.Folder.Name}.");
        }
        public static MessageCollection GetMessagesForFolder(string name)
        {
            client.Folders[name].Messages.Download(); // Start the download process;
            return client.Folders[name].Messages;
        }
        public static LoggedUser GetCredentials()
        {
            return loggedUser;
        }
    }
}
