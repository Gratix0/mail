using ImapX;
using ImapX.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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
                if (item.Subject == subjectSelected.ToString())
                {
                    TitleMessage.Text = item.Subject;
                    FromAdress.Text = $"Отправитель: {item.From.Address}";
                    Body.Text = HttpUtility.HtmlDecode(item.Body.Text);
                }
            }
        }

        /// <summary>
        /// HTML конвертр
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow.Close();
        }

        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            Answer answer = new Answer();
            answer.ShowDialog();
        }
    }
}
