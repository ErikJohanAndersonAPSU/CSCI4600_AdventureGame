using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Combat : Event
    {
        private Character _enemyChar;

        public Combat(int id, MapNode prev, MapNode left, MapNode right, string name, string desc, string leftDesc, string rightDesc, Character enemyChar) : base(id, prev, left, right, name, desc, leftDesc, rightDesc)
        {
            _enemyChar = enemyChar;
        }

        public void RunCombat()
        {

        }
    }
}
