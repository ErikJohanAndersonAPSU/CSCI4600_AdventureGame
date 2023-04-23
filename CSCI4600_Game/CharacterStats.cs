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
            set { _health = value; }
        }

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        public CharacterStats(int health, int attack, int defense)
        {
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public CharacterStats(string health, string attack, string defense)
        {
            Health = int.Parse(health);
            Attack = int.Parse(attack);
            Defense = int.Parse(defense);
        }

        public CharacterStats(string[] stats)
        {
            Health = int.Parse(stats[0]);
            Attack = int.Parse(stats[1]);
            Defense = int.Parse(stats[2]);
        }

        public override string ToString()
        {
            return "(" + Health.ToString() + "," + Attack.ToString() + "," + Defense.ToString() + ")";
        }

        public Boolean DoStatsPass(CharacterStats stats)
        {
            return (Health >= stats.Health
                && Attack >= stats.Attack
                && Defense >= stats.Defense);
        }
    }
}
