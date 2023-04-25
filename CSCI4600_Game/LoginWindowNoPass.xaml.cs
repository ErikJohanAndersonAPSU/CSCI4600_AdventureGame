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
    public partial class LoginWindowNoPass : Window
    {
        internal Account SelectedAccount;

        internal LoginWindowNoPass(Account account)
        {
            SelectedAccount = account;

            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            AdventureGameManager.UpdateAccounts();

            // Pass Password 
            if (SelectedAccount != null && textBoxPassword.Password.Equals(SelectedAccount.Pass))
            {
                this.DialogResult = true;
                //CorrectPassword = true;

                Close();
            }
            else if (SelectedAccount == null)
            {
                MessageBox.Show("No account selected.");
            }
            else
            {
                MessageBox.Show("Incorrect password.");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            textBoxPassword.Clear();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //public bool CorrectPassword { get; set; } = false;
    }
}
