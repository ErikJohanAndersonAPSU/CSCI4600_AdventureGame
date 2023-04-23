using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class MetaShopOffer
    {
        private int _metaShopID;
        private string _name;
        private string _desc;
        private int _cost;
        private int _itemID;

        public int MetaShopID
        {
            get { return _metaShopID; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string Desc
        {
            get { return _desc; }
        }
        public int Cost
        {
            get { return _cost; }
        }
        public int ItemID
        {
            get { return _itemID; }
        }

        public MetaShopOffer(int metaShopID, string name, string desc, int cost, int itemID)
        {
            _metaShopID = metaShopID;
            _name = name;
            _desc = desc;
            _cost = cost;
            _itemID = itemID;
        }

        public override string ToString()
        {
            return MetaShopID.ToString() + " : " + Name + " : " + Desc + " : " + Cost.ToString() + " : " + ItemID.ToString();
        }
    }
}
