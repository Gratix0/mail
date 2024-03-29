﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для Answer.xaml
    /// </summary>
    public partial class Answer : Window
    {
        
        public Answer()
        {
            InitializeComponent();
        }
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Hide();
        }

        /// <summary>
        /// Процесс заполнения даных и отправки сообщения по Smtp. Для примера вбил на свою почту
        /// </summary>
 
        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            MailMessage m = new MailMessage("oganisyan.sanya1@mail.ru", "isip_a.s.oganisyan@mpt.ru", TitleMessage.Text, Body.Text);
            m.IsBodyHtml = false;
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 587);
            smtpClient.Credentials = new NetworkCredential("oganisyan.sanya1@mail.ru", "S01Lwp6NH3zgaEU0yvJZ");
            smtpClient.EnableSsl = true;
            smtpClient.Send(m);
            }
            catch (Exception ex) { }

            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow.Close();

        }
    }
}
