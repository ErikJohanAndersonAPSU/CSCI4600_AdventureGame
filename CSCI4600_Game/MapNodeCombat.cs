using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class MapNodeCombat : MapNodeEvent
    {
        private Character _enemyChar;

        public MapNodeCombat(int id, MapNodeType type, MapNode prev, MapNode left, MapNode right, bool unlocked,
            string name, string desc, string leftDescUnlocked, string leftDescLocked, string rightDescUnlocked, string rightDescLocked,
            Character enemyChar):
            base(id, type, prev, left, right, unlocked, name, desc, leftDescUnlocked, leftDescLocked, rightDescUnlocked, rightDescLocked)
        {
            _enemyChar = enemyChar;
        }

        public void RunCombat()
        {

        }
    }
}
