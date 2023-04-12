using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class MetaShopOffer
    {
        private string _name;
        private string _desc;
        private int _id;
        private int _cost;

        public MetaShopOffer(string name, string desc, int id, int cost)
        {
            _name = name;
            _desc = desc;
            _id = id;
            _cost = cost;
        }
    }
}
