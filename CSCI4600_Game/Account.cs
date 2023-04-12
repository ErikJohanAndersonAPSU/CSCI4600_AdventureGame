using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Account
    {
        private int _id;
        private string _name;
        private string _pass;
        private int _metaCurrency;
        private int _numGamesPlayed;
        private int[] _metaShopPurchases;
        private int _numSavesSaved;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;  }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
            }
        }

        public int MetaCurrency
        {
            get { return _metaCurrency; }
            set
            {
                _metaCurrency = value;
            }
        }

        public int NumGamesPlayed
        {
            get { return _numGamesPlayed; }
            set
            {
                _numGamesPlayed = value;
            }
        }

        public int[] MetaShopPurchases
        {
            get { return _metaShopPurchases; }
            set
            {
                _metaShopPurchases = value;
            }
        }

        public int NumSavesSaved
        {
            get { return _numSavesSaved; }
            set
            {
                _numSavesSaved = value;
            }
        }

        public Account(int id, string name, string pass, int metaCurrency, int numGamesPlayed, int[] metaShopPurchases, int numSavesSaved)
        {
            ID = id;
            Name = name ?? "default";
            Pass = pass ?? "default";
            MetaCurrency = metaCurrency;
            NumGamesPlayed = numGamesPlayed;
            MetaShopPurchases = metaShopPurchases ?? Array.Empty<int>();
            NumSavesSaved = numSavesSaved;
        }
    }
}
