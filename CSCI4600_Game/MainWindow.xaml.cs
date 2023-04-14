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
        }


        //MainWindow Buttons
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {  

        }
        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {  

        }
        private void MetaShop_Click(object sender, RoutedEventArgs e)
        {  

        }
        private void Wiki_Click(object sender, RoutedEventArgs e)
        {
            WikiWindow wikiWindow = new WikiWindow();
            wikiWindow.Show();

        }
        private void LeaderBoard_Click(object sender, RoutedEventArgs e)
        {  

        }

    }
}
