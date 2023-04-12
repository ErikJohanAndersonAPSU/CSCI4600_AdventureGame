using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Item
    {
        private string _name;
        private string _desc;
        private CharacterStats _statMod;

        public Item(string name, string desc, CharacterStats statMod)
        {
            _name = name;
            _desc = desc;
            _statMod = statMod;
        }
    }
}
