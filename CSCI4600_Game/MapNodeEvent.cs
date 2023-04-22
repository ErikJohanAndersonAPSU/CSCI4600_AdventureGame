using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class MapNodeEvent : MapNode
    {
        private string _name;
        private string _desc;
        private string _leftDescUnlocked;
        private string _leftDescLocked;
        private string _rightDescUnlocked;
        private string _rightDescLocked;

        public MapNodeEvent(int id, MapNodeType type, MapNode prev, MapNode left, MapNode right, bool unlocked,
            string name, string desc, string leftDescUnlocked, string leftDescLocked, string rightDescUnlocked, string rightDescLocked):
            base(id, type, prev, left, right, unlocked)
        {
            _name = name;
            _desc = desc;
            _leftDescUnlocked = leftDescUnlocked;
            _leftDescLocked = leftDescLocked;
            _rightDescUnlocked = rightDescUnlocked;
            _rightDescLocked = rightDescLocked;
        }
    }
}
