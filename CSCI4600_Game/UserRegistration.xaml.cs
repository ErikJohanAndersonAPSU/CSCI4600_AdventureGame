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

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        //Buttons for User Registration Window

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow();
            newGameWindow.Show();
            Close();    
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxConfirmPassword.Clear();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
