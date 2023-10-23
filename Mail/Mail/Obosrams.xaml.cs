﻿using System;
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
    /// Логика взаимодействия для Obosrams.xaml
    /// </summary>
    public partial class Obosrams : Window
    {
        public static Obosrams obosrams;
        public Obosrams(string TextForMessageBox, string ex)
        {
            InitializeComponent();
            obosrams = this;
            TextBox.Text = TextForMessageBox;
            LabelText.Content = ex;
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            obosrams.Hide();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Obosrams.obosrams.DragMove();
            }
        }
    }

}
