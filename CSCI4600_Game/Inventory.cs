using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public class Inventory
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

        public Inventory(Item item)
        {
            _items = new List<Item>();
            _items.Add(item);
        }

        public Inventory(List<Item> items)
        {
            _items = new List<Item>();
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public override string ToString()
        {
            string outputStr = "";

            foreach (Item item in Items)
            {
                outputStr += item.ToString() + " ";
            }

            return outputStr;
        }

        public void AddItem(Item? item)
        {
            if (item != null && !Items.Contains(item))
            {
                if (!Items.Contains(item))
                {
                    Items.Add(item);
                } else
                {
                    Debug.WriteLine("Attempted to add item already in inventory");
                }
            } else
            {
                Debug.WriteLine("Attempted to add null item");
            }
        }

        public void RemoveItem(Item? item)
        {
            if (item != null)
            {
                if (Items.Contains(item))
                {
                    Items.Remove(item);
                }
                else
                {
                    Debug.WriteLine("Attempted to remove item not in inventory");
                }
            }
            else
            {
                Debug.WriteLine("Attempted to remove null item");
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
