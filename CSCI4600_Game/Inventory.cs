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
        private List<Item> _items;

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item != null && !Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(Item item)
        {
            if (item != null && Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        public void ClearInventory()
        {
            Items.Clear();
        }

        public bool HasItem(Item item)
        {
            return Items.Contains(item);
        }
    }
}
