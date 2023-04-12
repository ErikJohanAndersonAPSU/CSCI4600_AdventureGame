using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Character
    {
        private string _name;
        private string _desc;
        private CharacterClass? _charClass = null;
        private CharacterStats _charStats;
        private Inventory _charInventory;

        public Character(string name, string desc, CharacterClass? charClass, CharacterStats charStats, Inventory charInventory)
        {
            _name = name;
            _desc = desc;
            _charClass = charClass;
            _charStats = charStats;
            _charInventory = charInventory;
        }

        public CharacterStats GetStartingStats()
        {
            return new CharacterStats();
        }
    }
}
