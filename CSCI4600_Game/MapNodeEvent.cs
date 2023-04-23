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
        private int _unlockItemID;

        public string Name { get { return _name; } }
        public string Desc { get { return _desc; } }
        public string LeftDescUnlocked { get { return _leftDescUnlocked; } }
        internal string LeftDescLocked { get { return _leftDescLocked; } }
        public string RightDescUnlocked { get { return _rightDescUnlocked; } }
        public string RightDescLocked { get { return _rightDescLocked; } }

        public MapNodeEvent(int id, MapNodeType type, int prev, int left, int right, bool unlocked, int unlockItemID,
            string name, string desc, string leftDescUnlocked, string leftDescLocked, string rightDescUnlocked, string rightDescLocked):
            base(id, type, prev, left, right, unlocked, unlockItemID)
        {
            _name = name;
            _desc = desc;
            _leftDescUnlocked = leftDescUnlocked;
            _leftDescLocked = leftDescLocked;
            _rightDescUnlocked = rightDescUnlocked;
            _rightDescLocked = rightDescLocked;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine(">----");

            sb.AppendLine(Name + " : " + Desc);
            sb.AppendLine(LeftDescUnlocked);
            sb.AppendLine(LeftDescLocked);
            sb.AppendLine(RightDescUnlocked);
            sb.AppendLine(RightDescLocked);

            return sb.ToString();
        }
    }
}
