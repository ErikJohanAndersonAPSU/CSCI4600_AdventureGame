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
        private string _desc = "";
        private CharacterClass? _charClass = null;
        private CharacterStats _charStats;
        private Inventory _charInventory = new();

        public string Name { get { return _name; } set { _name = value; } }
        public string Desc { get { return _desc; } set { _desc = value; } }
        public CharacterClass CharClass { get { return _charClass; } set { _charClass = value; } }
        public CharacterStats CharStats { get { return _charStats; } set { _charStats = value; } }
        public Inventory CharInventory { get { return _charInventory; } set { _charInventory = value; } }

        // Create a character with specified stats
        public Character(string name, string desc, CharacterClass charClass, CharacterStats charStats, Inventory charInventory)
        {
            _name = name;
            _desc = desc;
            _charClass = charClass;
            _charStats = charStats;
            _charInventory = charInventory;
        }

        // Create a character with their class's base stats
        public Character(string name, string desc, CharacterClass charClass, Inventory charInventory)
        {
            _name = name;
            _desc = desc;
            _charClass = charClass;
            _charStats = charClass.CharacterStats;
            _charInventory = charInventory;
        }

        // Create an (enemy) character with only name and stats
        public Character(string name, CharacterStats charStats)
        {
            _name = name;
            _charStats = charStats;
        }

        public override string ToString()
        {
            return Name + " : " + Desc + "\n" + CharClass + "\n" + CharStats + "\n" + CharInventory;
        }

        /*public CharacterStats GetStartingStats()
        {
            return new CharacterStats(0, 0, 0);
        }*/
    }
}
