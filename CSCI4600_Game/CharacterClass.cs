using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class CharacterClass
    {
        private string _className;
        private CharacterStats _characterStats;

        public CharacterClass(string className, CharacterStats stats)
        {
            _className = className;
            _characterStats = stats;
        }
    }
}
