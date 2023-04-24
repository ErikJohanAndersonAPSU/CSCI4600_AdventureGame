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
    /// Interaction logic for MetaShopWindow.xaml
    /// </summary>
    public partial class MetaShopWindow : Window
    {
        public MetaShopWindow()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            //Moves item from Available list to Owned List
          
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            //Moves Item from Owned List TO Available List
        }
    }
}
