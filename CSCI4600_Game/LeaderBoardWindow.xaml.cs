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
    /// Interaction logic for LeaderBoardWindow.xaml
    /// </summary>
    public partial class LeaderBoardWindow : Window
    {
        public LeaderBoardWindow()
        {
            InitializeComponent();

            List<LeaderboardEntryFormatted> leaderboardEntryFormatted = new List<LeaderboardEntryFormatted>();

            foreach(var entry in AdventureGameManager.leaderboardEntries)
            {
                leaderboardEntryFormatted.Add(new LeaderboardEntryFormatted(entry));
            }
            leaderboardEntryFormatted.Sort();

            LeaderboardListbox.ItemsSource = leaderboardEntryFormatted;
        }
    }

    public class LeaderboardEntryFormatted : IComparable<LeaderboardEntryFormatted>
    {
        public string AccountName { get; set; }
        public string CharacterName { get; set; }
        public string Desc { get; set; }
        public string Score { get; set; }

        internal LeaderboardEntryFormatted(LeaderboardEntry leaderboardEntry)
        {
            AccountName = "Account: " + leaderboardEntry.AccountName;
            CharacterName = "CurrentCharacter: " + leaderboardEntry.CharacterName;
            Desc = leaderboardEntry.Desc;
            Score = leaderboardEntry.Score.ToString();
        }

        public int CompareTo(LeaderboardEntryFormatted? other)
        {
            if (other == null) return 1;

            LeaderboardEntryFormatted otherLeaderboardEntry = other as LeaderboardEntryFormatted;

            if (otherLeaderboardEntry != null)
            {
                return int.Parse(this.Score).CompareTo(int.Parse(otherLeaderboardEntry.Score)) * -1;
            }
            else
            {
                throw new ArgumentException("Object is not a LeaderboardEntry");
            }
        }
    }

    /*internal class ViewModel
    {
        public List<LeaderboardEntry> LeaderboardEntries = AdventureGameManager.leaderboardEntries.ToList();
    }*/
}
