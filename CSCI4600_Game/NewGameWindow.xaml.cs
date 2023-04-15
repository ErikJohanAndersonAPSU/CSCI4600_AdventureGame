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
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
        }

    

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
          
           Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //Reset Form
        }

     

    
    }
}
