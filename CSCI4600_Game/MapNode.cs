using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSCI4600_Game
{
    public enum MapNodeType
    {
        Generic,
        Event,
        Combat
    }

    internal class MapNode
    {
        private int _id;
        private MapNodeType _type;
        private int _prev;
        private int _left;
        private int _right;
        private bool _unlocked;

        public int ID { get { return _id; } }
        public MapNodeType Type { get { return _type; } }
        public int Prev { get { return _prev; } }
        public int Left { get { return _left; } }
        public int Right { get { return _right; } }
        public bool Unlocked { get { return _unlocked; } }

        public MapNode(int id, MapNodeType type, int prev, int left, int right, bool unlocked)
        {
            _id = id;
            _type = type;
            _prev = prev;
            _left = left;
            _right = right;
            _unlocked = unlocked;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ID.ToString());
            sb.AppendLine(Type.ToString());
            sb.AppendLine(Prev + " " + Left + " " + Right);
            sb.AppendLine(Unlocked.ToString());

            return sb.ToString();
        }
    }
}
