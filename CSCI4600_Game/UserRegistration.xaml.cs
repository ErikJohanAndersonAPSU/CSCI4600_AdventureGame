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
        internal Account? SelectedAccount { get; set; }
        public AccountAction SelectedAccountAction { get; set; }

        internal UserRegistration(string windowTitle, AccountAction accountAction, Account? selectedAccount = null)
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

                    // Change to display successful account creation, then open actual window w/ New Game, Load Game, Leaderboard, Wiki
                    /*MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();*/

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

            /*if (SelectedAccountAction == AccountAction.Create)
            {
                if (trimmedUsername.Length > 0 && trimmedUsername.Equals(untrimmedUsername) && textBoxPassword.Password.Equals(textBoxConfirmPassword.Password))
                {
                    if (AdventureGameManager.accounts.Find(x => x.Name.Equals(trimmedUsername)) == null)
                    {
                        // Update next available account iD, create account, then write it to a file
                        AdventureGameManager.UpdateNextAccountID();
                        Account newAccount = new Account(textBoxUserName.Text, textBoxPassword.Password);
                        AccountManager.AddAccount(newAccount);

                        // Set the current account
                        *//*AdventureGameManager.currentAccountID = newAccount.ID;
                        AdventureGameManager.UpdateAccounts();*//*
                        AdventureGameManager.SetCurrentAccount(newAccount);

                        // Change to display successful account creation, then open actual window w/ New Game, Load Game, Leaderboard, Wiki
                        NewGameWindow newGameWindow = new NewGameWindow();
                        newGameWindow.Show();
                        // Return the new account, close the dialog and report dialog result as true


                        this.DialogResult = true;

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
            }
            
            if (SelectedAccountAction == AccountAction.Modify && SelectedAccount != null)
            {
                if (trimmedUsername.Length > 0 && trimmedUsername.Equals(untrimmedUsername) && textBoxPassword.Password.Equals(textBoxConfirmPassword.Password))
                {
                    AdventureGameManager.accounts.RemoveAll(x => x.ID == SelectedAccount.ID);

                    //AdventureGameManager.accounts.Remove(SelectedAccount);
                    //AdventureGameManager.UpdateAccounts();

                    Debug.WriteLine(SelectedAccount.ID);

                    if (AdventureGameManager.accounts.Find(x => x.Name.Equals(trimmedUsername)) == null)
                    {
                        // Update next available account iD, create account, then write it to a file
                        Account newAccount = new Account(SelectedAccount, textBoxUserName.Text, textBoxPassword.Password);
                        AccountManager.AddAccount(newAccount);
                        Debug.WriteLine(newAccount);

                        // Set the current account
                        *//*AdventureGameManager.currentAccountID = newAccount.ID;
                        AdventureGameManager.UpdateAccounts();*//*
                        AdventureGameManager.SetCurrentAccount(newAccount);

                        // Change to display successful account creation, then open actual window w/ New Game, Load Game, Leaderboard, Wiki
                        NewGameWindow newGameWindow = new NewGameWindow();
                        newGameWindow.Show();

                        this.DialogResult = true;

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
            }
            else if (SelectedAccount != null) { }
            {
                Debug.WriteLine("SelectedAccount is null");
            }*/
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
