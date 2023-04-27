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
        public enum LeaderboardVisibility
        {
            Account,
            Global
        }

        public LeaderboardVisibility leaderboardVisibility { get; set; }

        public LeaderBoardWindow()
        {
            InitializeComponent();

            leaderboardVisibility = LeaderboardVisibility.Global;

            SetLeaderboardListboxVisiblity(leaderboardVisibility);
        }

        private void ChangeLeaderboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (leaderboardVisibility == LeaderboardVisibility.Account)
            {
                leaderboardVisibility = LeaderboardVisibility.Global;
                ChangeLeaderboardButton.Content = "View local leaderboard";
            }
            else
            {
                leaderboardVisibility = LeaderboardVisibility.Account;
                ChangeLeaderboardButton.Content = "View global leaderboard";
            }

            SetLeaderboardListboxVisiblity(leaderboardVisibility);
        }

        private void SetLeaderboardListboxVisiblity(LeaderboardVisibility newLeaderboardVisibility)
        {
            List<LeaderboardEntry> leaderboardEntries = AdventureGameManager.leaderboardEntries.ToList();
            List<LeaderboardEntryFormatted> leaderboardEntriesFormatted = new List<LeaderboardEntryFormatted>();

            if (newLeaderboardVisibility == LeaderboardVisibility.Account)
            {
                leaderboardEntries = AdventureGameManager.leaderboardEntries.ToList().FindAll(x => x.AccountName.Equals(AdventureGameManager.currentAccount.Name));
            }
            else
            {
                leaderboardEntries = AdventureGameManager.leaderboardEntries.ToList();
            }

            foreach (var entry in leaderboardEntries)
            {
                leaderboardEntriesFormatted.Add(new LeaderboardEntryFormatted(entry));
            }
            leaderboardEntriesFormatted.Sort();

            LeaderboardListbox.ItemsSource = leaderboardEntriesFormatted;
        }
    }

    public class LeaderboardEntryFormatted : IComparable<LeaderboardEntryFormatted>
    {
        public string AccountName { get; set; }
        public string CharacterName { get; set; }
        public string Desc { get; set; }
        public string Score { get; set; }

        public LeaderboardEntryFormatted(LeaderboardEntry leaderboardEntry)
        {
            AccountName = "Account: " + leaderboardEntry.AccountName;
            CharacterName = "Character: " + leaderboardEntry.CharacterName;
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
}
