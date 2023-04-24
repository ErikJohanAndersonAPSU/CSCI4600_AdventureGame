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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           //Add New Account
           NewGameWindow newGameWindow = new NewGameWindow();
           newGameWindow.Show();
           Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Delete Selected Account
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            //Modify Selected Account
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            //Should pass account to AdventureGameManager();
            Window1 window1 = new Window1();
            window1.Show();
        }
    }
}
