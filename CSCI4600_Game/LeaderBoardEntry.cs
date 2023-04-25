using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public class LeaderboardEntry : IComparable
    {
        private string _accountName;
        private string _characterName;
        private string _desc;
        private int _score;
        private int _id;

        public string AccountName { get { return _accountName; } }

        public string CharacterName { get { return _characterName; } }

        public string Desc { get { return _desc; } }

        public int Score { get { return _score; } }

        public int Id { get { return _id; } }

        public LeaderboardEntry(SaveGameState gameState)
        {

        }
        public LeaderboardEntry(string accountName, string characterName, string desc, int score, int id)
        {
            _accountName = accountName;
            _characterName = characterName;
            _desc = desc;
            _score = score;
            _id = id;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            LeaderboardEntry otherLeaderboardEntry = obj as LeaderboardEntry;

            if (otherLeaderboardEntry != null)
            {
                return this.Score.CompareTo(otherLeaderboardEntry.Score)*-1;
            }
            else
            {
                throw new ArgumentException("Object is not a LeaderboardEntry");
            }
        }
    }
}
