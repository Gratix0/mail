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
    /// Логика взаимодействия для SelectedMessage.xaml
    /// </summary>
    public partial class SelectedMessage : Window
    {
        public SelectedMessage(MessageCollection message, string subjectSelected)
        {
            InitializeComponent();
            string bodyTest;
            foreach (var item in message)
            {
                if (item.Subject == subjectSelected) ;
                {
                    TitleMessage.Text = item.Subject;
                    FromAdress.Text = item.From.Address;
                    //bodyTest = HtmlRtf.HtmlRtfConverter.ToRtf(item.Body.ToString());
                   
                    Body.Text = HtmlRtf.HtmlRtfConverter.ToRtf(item.Body.ToString());
                }
            }
        }
    }
}
