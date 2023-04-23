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
        private bool _combatCompleted;
        private string _leftCombatDesc, _rightCombatDesc;

        public Character EnemyChar
        {
            get { return _enemyChar; }
            set { _enemyChar = value; }
        }
        public bool CombatCompleted { get { return _combatCompleted; } }
        public string LeftCombatDesc { get { return _leftCombatDesc; } }
        public string RightCombatDesc { get { return _rightCombatDesc; } }


        public MapNodeCombat(int id, MapNodeType type, int prev, int left, int right, bool unlocked, int unlockItemID,
            string name, string desc, string leftDescUnlocked, string leftDescLocked, string rightDescUnlocked, string rightDescLocked,
            Character enemyChar, bool combatCompleted, string leftCombatDesc, string rightCombatDesc):
            base(id, type, prev, left, right, unlocked, unlockItemID, name, desc, leftDescUnlocked, leftDescLocked, rightDescUnlocked, rightDescLocked)
        {
            _enemyChar = enemyChar;
            _combatCompleted = combatCompleted;
            _leftCombatDesc = leftCombatDesc;
            _rightCombatDesc = rightCombatDesc;
        }

        public void RunCombat()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine(">----");

            sb.AppendLine(EnemyChar.Name + " : " + EnemyChar.CharStats.Health + "," + EnemyChar.CharStats.Attack + "," + EnemyChar.CharStats.Defense);
            sb.AppendLine(CombatCompleted.ToString());
            sb.AppendLine(LeftCombatDesc);
            sb.AppendLine(RightCombatDesc);


            return sb.ToString();
        }
    }
}
