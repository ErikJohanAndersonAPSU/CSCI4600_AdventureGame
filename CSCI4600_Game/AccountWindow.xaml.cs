using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        public enum AccountAction
        {
            Create,
            Modify,
            Delete,
            Login
        }

        public AccountAction SelectedAccountAction { get; set; }
        bool ContinueToMainScreen { get; set; }  = false;

        public AccountWindow()
        {
            InitializeComponent();

            UpdateItemSource();
        }

        private void AccountWindowListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Create Account

            PerformAccountAction(AccountAction.Create);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Delete Selected Account

            PerformAccountAction(AccountAction.Delete);
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            //Modify Selected Account

            PerformAccountAction(AccountAction.Modify);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Log in to Selected Account

            PerformAccountAction(AccountAction.Login);
        }

        private void PerformAccountAction(AccountAction accountAction)
        {

            if (accountAction == AccountAction.Create)
            {
                CreateAccount();
            }
            else if (accountAction == AccountAction.Login || accountAction == AccountAction.Modify || accountAction == AccountAction.Delete)
            {
                if (AccountWindowListbox.SelectedItem != null)
                {
                    Account selectedAccount = AccountWindowListbox.SelectedItem as Account;

                    if (selectedAccount != null)
                    {
                        // Initialize login window
                        LoginWindowNoPass loginWindowNoPass = new LoginWindowNoPass(selectedAccount);

                        if (selectedAccount.Pass.Length == 0 || loginWindowNoPass.ShowDialog() == true)
                        {
                            if (accountAction == AccountAction.Login)
                            {
                                AdventureGameManager.SetCurrentAccount(selectedAccount);
                                ContinueToMainScreen = true;
                            }
                            else if (accountAction == AccountAction.Modify)
                            {
                                // Modify the account
                                ModifyAccount(selectedAccount);
                            }
                            else if (accountAction == AccountAction.Delete)
                            {
                                DeleteAccount(selectedAccount);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Password was not input or was incorrect");
                        }

                        // Ensure login window is closed
                        loginWindowNoPass.Close();
                    }
                    else
                    {
                        Debug.WriteLine("Selected account is null");
                    }
                }
                else
                {
                    Debug.WriteLine("No selected account");
                }
            }

            if (ContinueToMainScreen)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            }
        }

        private void CreateAccount()
        {
            //Add New Account
            UserRegistration userRegistration = new UserRegistration("Create Account", AccountAction.Create);

            if (userRegistration.ShowDialog() == true)
            {
                // Account was created
                ContinueToMainScreen = true;
            }
            else
            {
                // Account wasn't created
                Debug.WriteLine("Account creation cancelled");

                ContinueToMainScreen = false;
            }
        }

        private void ModifyAccount(Account selectedAccount)
        {
            // Open Account details window
            UserRegistration userRegistration = new UserRegistration("Modify Account", AccountAction.Modify, selectedAccount);

            if (userRegistration.ShowDialog() == true)
            {
                // Account was modified
                ContinueToMainScreen = true;
            }
            else
            {
                // Account wasn't modified
                Debug.WriteLine("Passworded userRegistration.ShowDialog() was false");

                ContinueToMainScreen = false;
            }
        }

        private void DeleteAccount(Account selectedAccount)
        {
            AccountManager.DeleteAccount(selectedAccount);
            UpdateItemSource();

            ContinueToMainScreen = true;
        }

        private void UpdateItemSource()
        {
            AdventureGameManager.RefreshAccounts();
            AccountWindowListbox.ItemsSource = AdventureGameManager.accounts;
            AccountWindowListbox.Items.Refresh();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Debug.WriteLine("ContinueToMainScreen was " + ContinueToMainScreen);
            if (!ContinueToMainScreen)
            {
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
            }
        }
    }
}
