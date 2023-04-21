using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class CharacterStats
    {
        private int _health;
        private int _attack;
        private int _defense;

        public int Health
        {
            get { return _health; }
        }

        public int Attack
        {
            get { return _attack; }
        }

        public int Defense
        {
            get { return _defense; }
        }

        public Boolean DoStatsPass(CharacterStats stats)
        {
            return (Health >= stats.Health
                && Attack >= stats.Attack
                && Defense >= stats.Defense);
        }
    }
}
