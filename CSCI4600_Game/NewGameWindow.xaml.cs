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
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public CharClass SelectedCharClass { get; set; }

        public NewGameWindow()
        {
            InitializeComponent();

            List<CharClassAndImage> charClassAndImages = new List<CharClassAndImage>();
            charClassAndImages.Add(new CharClassAndImage(CharClass.boy, @"\Resources\characterImage_Boy.png"));
            charClassAndImages.Add(new CharClassAndImage(CharClass.girl, @"\Resources\characterImage_Girl.png"));
            charClassAndImages.Add(new CharClassAndImage(CharClass.dog, @"\Resources\characterImage_Puppers.png"));
            charClassAndImages.Add(new CharClassAndImage(CharClass.robot, @"\Resources\characterImage_Robot.png"));

            ClassSelectListBox.ItemsSource = charClassAndImages;

            CharacterNameTextBox.Text = AdventureGameManager.currentAccount.Name;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (ClassSelectListBox.SelectedItem != null)
            {
                CharClassAndImage? charClassAndImage = ClassSelectListBox.SelectedItem as CharClassAndImage;

                if (charClassAndImage != null)
                {
                    string name = CharacterNameTextBox.Text.Trim();
                    if (name.Length == 0)
                    {
                        name = AdventureGameManager.currentAccount.Name;
                    }

                    string desc = CharacterDescTextBox.Text.Trim();

                    string charClassName = charClassAndImage.CharClass.ToString();

                    CharacterClass charClass = AdventureGameManager.charClasses.Find(x => x.ClassName.Equals(charClassName));

                    /*Debug.WriteLine("Printing account items, n = " + AdventureGameManager.currentAccount.MetaShopPurchases.Count());
                    foreach (var item in AdventureGameManager.currentAccount.MetaShopPurchases)
                    {
                        Debug.WriteLine(item);
                    }*/

                    Character newCharacter = new Character(name, desc, charClass, new Inventory(AdventureGameManager.currentAccount.MetaShopPurchases));

                    SaveGameState saveGameState = new SaveGameState(newCharacter);

                    GameplayWindow gameplayWindow = new GameplayWindow(saveGameState);
                    gameplayWindow.Show();

                    Close();
                }

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            CharacterNameTextBox.Clear();
            CharacterDescTextBox.Clear();
        }

        public class CharClassAndImage
        {
            public CharClass CharClass { get; set; }
            public string Filepath { get; set; }

            public CharClassAndImage(CharClass charClass, string filepath)
            {
                CharClass = charClass;
                Filepath = filepath;
            }
        }
    }
}
