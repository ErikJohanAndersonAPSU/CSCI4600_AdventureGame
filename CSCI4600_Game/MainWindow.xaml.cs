﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //AdventureGameManager.Test();
        }


        //TEST BUTTON to Window1
        
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            /*Window1 window1 = new Window1();
            window1.Show();*/

            /*AccountWindow accountWindow = new AccountWindow();
            accountWindow.Show();*/

            /*StartWindow startWindow = new StartWindow();
            startWindow.ShowDialog();*/
        }
        
        //MainWindow Buttons
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            /*UserRegistration userregistrationWindow = new UserRegistration("Create Account", UserRegistration.AccountAction.Create);
            userregistrationWindow.Show();*/
        }
        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            SaveMenuWindow saveMenuWindow = new SaveMenuWindow();

            if (saveMenuWindow.ShowDialog() == true)
            {
                Close();
            }
        }
        private void MetaShop_Click(object sender, RoutedEventArgs e)
        {
            MetaShopWindow metaShopWindow = new MetaShopWindow();
            metaShopWindow.ShowDialog();
        }
        private void Wiki_Click(object sender, RoutedEventArgs e)
        {
            WikiWindow wikiWindow = new WikiWindow();
            wikiWindow.ShowDialog();
        }
        private void LeaderBoard_Click(object sender, RoutedEventArgs e)
        {  
            LeaderBoardWindow leaderBoardWindow = new LeaderBoardWindow();
            leaderBoardWindow.ShowDialog();
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            AdventureGameManager.ResetCurrentAccount();

            StartWindow startWindow = new StartWindow();
            startWindow.Show();

            Close();
        }
    }
}
