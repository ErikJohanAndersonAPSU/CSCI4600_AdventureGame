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

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

      

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Pass Username and Password 
            //if true then open Account window attached to username and password

            AccountWindow accountWindow = new AccountWindow(); 
            accountWindow.Show();
            Close();
        }

      
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            textBoxPassword.Clear();
            textBoxUserName.Clear();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
