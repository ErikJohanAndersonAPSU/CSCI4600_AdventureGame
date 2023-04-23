using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Item
    {
        private int _id;
        private string _name;
        private string _desc;
        private CharacterStats _statMod;

        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Desc
        {
            get { return _desc; }
        }

        public CharacterStats StatMod
        {
            get { return _statMod; }
        }

        public Item(int id, string name, string desc, CharacterStats statMod)
        {
            _id = id;
            _name = name;
            _desc = desc;
            _statMod = statMod;
        }

        public override string ToString()
        {
            return ID.ToString() + " : " + Name + " : " + Desc + " : " + StatMod.ToString();
        }
    }
}
