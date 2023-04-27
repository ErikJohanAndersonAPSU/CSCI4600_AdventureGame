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
    /// Interaction logic for GameplayWindowQuitDialog.xaml
    /// </summary>
    public partial class GameplayWindowQuitDialog : Window
    {
        public enum QuitAction
        {
            Close,
            Save,
            QuitToMenu,
            CloseGame
        }

        public QuitAction QuitActionResult { get; set; } = QuitAction.Close;
        public SaveGameState Save { get; set; }

        public GameplayWindowQuitDialog(SaveGameState save)
        {
            InitializeComponent();

            Save = save;
        }

        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            QuitActionResult = QuitAction.Save;

            if (AdventureGameManager.saves.Find(x => x.AccountID == Save.AccountID && x.SaveID == Save.SaveID) != null)
            {
                MessageBoxResult OverWriteSaveDialogResult = MessageBox.Show("Overwrite your current save?", "", MessageBoxButton.YesNoCancel);

                if (OverWriteSaveDialogResult == MessageBoxResult.Yes)
                {
                    AddAndWriteSave();
                }
                else if (OverWriteSaveDialogResult == MessageBoxResult.No)
                {
                    SetNewValidSaveID();

                    AddAndWriteSave();
                }
            }
            else
            {
                SetNewValidSaveID();

                AddAndWriteSave();
            }
        }

        private void AddAndWriteSave()
        {
            Save.SaveDateTime = DateTime.Now;

            AdventureGameManager.saves.Add(Save);
            SaveManager.WriteSavesToFile(AdventureGameManager.saves);

            SaveWarningTextBlock.Text = "Game saved!";
        }

        private void SetNewValidSaveID()
        {
            int maxSaveID = Save.SaveID;
            foreach (SaveGameState save in AdventureGameManager.saves.FindAll(x => x.AccountID == Save.AccountID))
            {
                if (save.SaveID > maxSaveID)
                {
                    maxSaveID = save.SaveID;
                }
            }

            Save.SaveID = maxSaveID + 1;
        }

        private void QuitToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            QuitActionResult= QuitAction.QuitToMenu;
            this.DialogResult = true;
        }

        private void CloseGameButton_Click(object sender, RoutedEventArgs e)
        {
            QuitActionResult = QuitAction.CloseGame;
            this.DialogResult = true;
        }
    }
}
