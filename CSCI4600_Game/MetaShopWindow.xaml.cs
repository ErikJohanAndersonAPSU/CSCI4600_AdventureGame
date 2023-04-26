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
    /// Interaction logic for MetaShopWindow.xaml
    /// </summary>
    public partial class MetaShopWindow : Window
    {
        public MetaShopWindow()
        {
            InitializeComponent();

            UpdateItemSource();
        }

        public void UpdateItemSource()
        {
            List<MetaShopOffer> availableMetaShopoffers = new List<MetaShopOffer>(AdventureGameManager.metaShopOffers);
            List<MetaShopOffer> purchasedMetaShopOffers = new List<MetaShopOffer>();

            foreach (Item metaShopItemOffer in AdventureGameManager.currentAccount.MetaShopPurchases)
            {
                MetaShopOffer metaShopOffer = AdventureGameManager.metaShopOffers.Find(x => x.ItemID == metaShopItemOffer.ID);

                purchasedMetaShopOffers.Add(metaShopOffer);
                availableMetaShopoffers.Remove(metaShopOffer);
            }

            purchasedMetaShopOffers.Sort();
            availableMetaShopoffers.Sort();

            PurchasedItemListBox.ItemsSource = purchasedMetaShopOffers;
            PurchasedItemListBox.Items.Refresh();

            AvailableItemListBox.ItemsSource = availableMetaShopoffers;
            AvailableItemListBox.Items.Refresh();

            MetaCurrencyTextBlock.Text = AdventureGameManager.currentAccount.MetaCurrency.ToString();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            //Moves item from Available list to Purchased List
            if (AvailableItemListBox.SelectedItem != null)
            {
                var selectedMetaShopOffer = AvailableItemListBox.SelectedItem as MetaShopOffer;

                if (selectedMetaShopOffer != null)
                {
                    if (AdventureGameManager.currentAccount.MetaCurrency >= selectedMetaShopOffer.Cost)
                    {
                        AdventureGameManager.currentAccount.MetaCurrency -= selectedMetaShopOffer.Cost;

                        AdventureGameManager.currentAccount.MetaShopPurchases.Add(AdventureGameManager.items.Find(x => x.ID == selectedMetaShopOffer.ItemID));

                        AdventureGameManager.WriteUpdatedAccounts();
                        UpdateItemSource();
                    }
                    else
                    {
                        MessageBox.Show("Not enough MetaCurrency");
                    }
                }
                else
                {
                    Debug.WriteLine("Item was not MetaShopOffer");
                }
            }
            else
            {
                Debug.WriteLine("No item selected");
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            //Moves Item from Purchased List to Available List
            if (PurchasedItemListBox.SelectedItem != null)
            {
                var selectedMetaShopOffer = PurchasedItemListBox.SelectedItem as MetaShopOffer;

                if (selectedMetaShopOffer != null)
                {
                    AdventureGameManager.currentAccount.MetaCurrency += selectedMetaShopOffer.Cost;

                    AdventureGameManager.currentAccount.MetaShopPurchases.RemoveAll(x => x.ID == selectedMetaShopOffer.ItemID);

                    AdventureGameManager.WriteUpdatedAccounts();
                    UpdateItemSource();
                }
                else
                {
                    Debug.WriteLine("Item was not MetaShopOffer");
                }
            }
            else
            {
                Debug.WriteLine("No item selected");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateItemSource();
        }
    }
}
