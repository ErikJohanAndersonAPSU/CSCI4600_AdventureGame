using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
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
using static CSCI4600_Game.AccountWindow;

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public Account? SelectedAccount { get; set; }
        public AccountAction SelectedAccountAction { get; set; }

        public UserRegistration(string windowTitle, AccountAction accountAction, Account? selectedAccount = null)
        {
            this.Title = windowTitle;
            SelectedAccountAction = accountAction;
            SelectedAccount = selectedAccount;

            InitializeComponent();

            if (accountAction == AccountAction.Modify && selectedAccount != null)
            {
                textBoxUserName.Text = selectedAccount.Name;
                LoginButton.Content = "Modify";
                this.Title = "Modify Account";
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string untrimmedUsername = textBoxUserName.Text;
            string trimmedUsername = textBoxUserName.Text.Trim();

            if (trimmedUsername.Length > 0 && trimmedUsername.Equals(untrimmedUsername) && textBoxPassword.Password.Equals(textBoxConfirmPassword.Password))
            {
                Account? newAccount = null;

                if (SelectedAccountAction == AccountAction.Create)
                {
                    AdventureGameManager.UpdateNextAccountID();
                    newAccount = new Account(textBoxUserName.Text, textBoxPassword.Password);
                }
                else if (SelectedAccountAction == AccountAction.Modify && SelectedAccount != null)
                {
                    AdventureGameManager.accounts.RemoveAll(x => x.ID == SelectedAccount.ID);
                    newAccount = new Account(SelectedAccount, textBoxUserName.Text, textBoxPassword.Password);
                }
                else
                {
                    Debug.WriteLine("Did not have Create or Modify AccountAction");
                }

                if (newAccount != null && AdventureGameManager.accounts.Find(x => x.Name.Equals(trimmedUsername)) == null)
                {
                    AccountManager.AddAccount(newAccount);

                    // Set the current account
                    AdventureGameManager.SetCurrentAccount(newAccount);

                    // Return the new account, close the dialog and report dialog result as true
                    this.DialogResult = true;

                    Close();
                }
                else if (newAccount == null)
                {
                    Debug.WriteLine("New account was null");
                }
                else
                {
                    Debug.WriteLine("An account with that name already exists");
                }
            }
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
    }
}
