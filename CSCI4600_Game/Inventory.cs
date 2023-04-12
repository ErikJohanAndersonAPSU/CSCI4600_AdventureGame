using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Inventory
    {
        private ArrayList _items;

        public ArrayList Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void AddItem(Item item)
        {

        }

        public void RemoveItem(Item item)
        {

        }

        public void ClearInventory()
        {

        }

        public Boolean HasItem(Item item)
        {
            return true;
        }
    }
}
