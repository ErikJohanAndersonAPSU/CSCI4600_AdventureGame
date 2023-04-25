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
using static CSCI4600_Game.AccountWindow;

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for SaveMenuWindow.xaml
    /// </summary>
    public partial class SaveMenuWindow : Window
    {
        public enum SaveAction
        {
            Load,
            Delete
        }

        public SaveAction SelectedSaveAction { get; set; }

        public SaveMenuWindow()
        {
            InitializeComponent();

            UpdateItemSource();
        }

        private void UpdateItemSource()
        {
            AdventureGameManager.UpdateSaves();

            List<SaveGameState> accountSaves = AdventureGameManager.saves.FindAll(x => x.AccountID.Equals(AdventureGameManager.currentAccountID));
            List<SaveGameStateFormatted> accountSavesFormatted = new List<SaveGameStateFormatted>();

            foreach (SaveGameState state in accountSaves)
            {
                accountSavesFormatted.Add(new SaveGameStateFormatted(state));
            }

            SaveMenuWindowListBox.ItemsSource = accountSavesFormatted;
            SaveMenuWindowListBox.Items.Refresh();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (SaveMenuWindowListBox.SelectedItem != null)
            {
                SaveGameStateFormatted selectedSaveFormatted = SaveMenuWindowListBox.SelectedItem as SaveGameStateFormatted;

                if (selectedSaveFormatted != null)
                {
                    SaveGameState selectedSave = AdventureGameManager.saves.Find(x => (x.AccountID == selectedSaveFormatted.AccountID && x.SaveID == selectedSaveFormatted.SaveID));

                    if (selectedSave != null)
                    {

                    }
                    else
                    {
                        Debug.WriteLine("Selected save is null");
                    }
                }
                else
                {
                    Debug.WriteLine("Formatted selected save is null");
                }
            }
            else
            {
                Debug.WriteLine("No selected save");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SaveMenuWindowListBox.SelectedItem != null)
            {
                SaveGameStateFormatted selectedSaveFormatted = SaveMenuWindowListBox.SelectedItem as SaveGameStateFormatted;

                if (selectedSaveFormatted != null)
                {
                    SaveGameState selectedSave = AdventureGameManager.saves.Find(x => (x.AccountID == selectedSaveFormatted.AccountID && x.SaveID == selectedSaveFormatted.SaveID));
                    
                    if (selectedSave != null)
                    {
                        SaveManager.DeleteSave(selectedSave);

                        UpdateItemSource();
                    }
                    else
                    {
                        Debug.WriteLine("Selected save is null");
                    }
                }
                else
                {
                    Debug.WriteLine("Formatted selected save is null");
                }
            }
            else
            {
                Debug.WriteLine("No selected save");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public class SaveGameStateFormatted : IComparable<SaveGameStateFormatted>
        {
            public int AccountID { get; set; }
            public int SaveID { get; set; }

            public string CharacterName { get; set; }
            public string CharacterClass { get; set; }
            public string CharacterStats { get; set; }
            public string CharacterDesc { get; set; }
            public string SaveDateTime { get; set; }

            internal SaveGameStateFormatted(SaveGameState saveGameState)
            {
                AccountID = saveGameState.AccountID;
                SaveID = saveGameState.SaveID;
                CharacterName = saveGameState.CurrentCharacter.Name;
                CharacterClass = saveGameState.CurrentCharacter.CharClass.ClassName.ToString();
                CharacterStats = saveGameState.CurrentCharacter.CharStats.ToString();
                CharacterDesc = saveGameState.CurrentCharacter.Desc;
                SaveDateTime = saveGameState.SaveDateTime.ToString();
            }

            public int CompareTo(SaveGameStateFormatted? other)
            {
                if (other == null) return 1;

                SaveGameStateFormatted otherSaveGameState = other as SaveGameStateFormatted;

                if (otherSaveGameState != null)
                {
                    return DateTime.Parse(SaveDateTime).CompareTo(DateTime.Parse(other.SaveDateTime));
                }
                else
                {
                    throw new ArgumentException("Object is not a LeaderboardEntry");
                }
            }
        }
    }
}
