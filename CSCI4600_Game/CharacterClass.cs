using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public enum CharClass
    {
        robot,
        dog,
        boy,
        girl
    }

    public class CharacterClass
    {
        private string _className;
        private CharacterStats _startingStats;

        public string ClassName { get { return _className; } }
        public CharacterStats StartingStats { get { return _startingStats; } }

        public CharacterClass(string className, CharacterStats stats)
        {
            _className = className;
            _startingStats = stats;
        }

        public override string ToString()
        {
            return ClassName + " : " + StartingStats.ToString();
        }
    }
}
