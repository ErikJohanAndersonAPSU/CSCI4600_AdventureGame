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
            AdventureGameManager.RefreshAccounts();

            string trimmedUsername = textBoxUserName.Text.Trim();

            //Pass Username and Password 
            //if true then open Account window attached to username and password
            if (textBoxUserName.Text.Trim().Length > 0)
            {
                Account? account = AdventureGameManager.accounts.Find(x => x.Name.Equals(trimmedUsername));

                if (account != null && textBoxPassword.Password.Equals(account.Pass))
                {
                    AdventureGameManager.currentAccount = account;
                    //AdventureGameManager.currentAccountID = account.ID;

                    textBoxUserName.Clear();
                    textBoxPassword.Clear();

                    NewGameWindow newGameWindow = new NewGameWindow();
                    newGameWindow.Show();
                    Close();
                }
                else if (account == null)
                {
                    MessageBox.Show("No account exists with that name.");
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                }
            }
            else
            {
                // Should show a popup saying exactly what's wrong, i.e. no non-whitespace username, no non-whitespace password, mismatch password, etc
                MessageBox.Show("No username entered.");
            }

            /*AccountWindow accountWindow = new AccountWindow(); 
            accountWindow.Show();
            Close();*/
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
