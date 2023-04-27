using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public class Account : IComparable
    {
        private int _id;
        private string _name;
        private string _pass;
        private int _metaCurrency;
        private int _numGamesPlayed;
        private List<Item> _metaShopPurchases;
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

        public List<Item> MetaShopPurchases
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

        public Account(int id, string name, string pass, int metaCurrency, int numGamesPlayed, List<Item> metaShopPurchases, int numSavesSaved)
        {
            ID = id;
            Name = name ?? "default";
            Pass = pass ?? "";
            MetaCurrency = metaCurrency;
            NumGamesPlayed = numGamesPlayed;
            MetaShopPurchases = metaShopPurchases ?? new List<Item>();
            NumSavesSaved = numSavesSaved;
        }

        public Account(Account account, string name, string pass)
        {
            ID = account.ID;
            Name = name ?? "default";
            Pass = pass ?? "";
            MetaCurrency = account.MetaCurrency;
            NumGamesPlayed = account.NumGamesPlayed;
            MetaShopPurchases = account.MetaShopPurchases;
            NumSavesSaved = account.NumSavesSaved;
        }

        public Account(string name, string pass)
        {
            ID = AdventureGameManager.nextAccountID;
            Name = name ?? "default";
            Pass = pass ?? "";
            MetaCurrency = 0;
            NumGamesPlayed = 0;
            MetaShopPurchases = new List<Item> { AdventureGameManager.items.Find(x => x.ID == -1) };
            NumSavesSaved = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ID.ToString());
            sb.AppendLine(Name);
            sb.AppendLine(Pass);
            sb.AppendLine(MetaCurrency.ToString());
            sb.AppendLine(NumGamesPlayed.ToString());

            foreach (var item in MetaShopPurchases)
            {
                sb.Append(item.ToString() + " ");
            }
            sb.AppendLine();

            sb.AppendLine(NumSavesSaved.ToString());

            return sb.ToString();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Account otherAccountObj = obj as Account;

            if (otherAccountObj != null)
            {
                return this.Name.CompareTo(otherAccountObj.Name);
            }
            else
            {
                throw new ArgumentException("Object is not an Account");
            }
        }
    }
}
