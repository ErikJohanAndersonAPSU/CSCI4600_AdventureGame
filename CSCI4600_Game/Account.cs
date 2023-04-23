﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<int> _metaShopPurchases;
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

        public List<int> MetaShopPurchases
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

        public Account(int id, string name, string pass, int metaCurrency, int numGamesPlayed, List<int> metaShopPurchases, int numSavesSaved)
        {
            ID = id;
            Name = name ?? "default";
            Pass = pass ?? "";
            MetaCurrency = metaCurrency;
            NumGamesPlayed = numGamesPlayed;
            MetaShopPurchases = metaShopPurchases ?? new List<int>();
            NumSavesSaved = numSavesSaved;
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
    }
}
