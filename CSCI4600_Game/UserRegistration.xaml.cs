using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string trimmedUsername = textBoxUserName.Text.Trim();

            if (trimmedUsername.Length > 0 && textBoxPassword.Password.Equals(textBoxConfirmPassword.Password))
            {
                if (AdventureGameManager.accounts.Find(x => x.Name.Equals(trimmedUsername)) == null)
                {
                    AdventureGameManager.UpdateNextAccountID();
                    Account newAccount = new Account(textBoxUserName.Text, textBoxPassword.Password);
                    AccountManager.AddAccount(newAccount);
                    AccountManager.WriteAccountsToFile();
                    AdventureGameManager.currentAccountID = newAccount.ID;

                    NewGameWindow newGameWindow = new NewGameWindow();
                    newGameWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("An account already exists with that name.");
                }
            }
            else
            {
                // Should show a popup saying exactly what's wrong, i.e. no non-whitespace username, no non-whitespace password, mismatch password, etc
                MessageBox.Show("Invalid password.");
            }


            /*textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxConfirmPassword.Clear();*/

            /*
            NewGameWindow newGameWindow = new NewGameWindow();
            newGameWindow.Show();
            Close();    
            */
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
