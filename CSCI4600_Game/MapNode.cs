using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public enum MapNodeType
    {
        Event,
        Combat
    }

    internal class MapNode
    {
        private int _id;
        private MapNodeType _type;
        private MapNode _prev;
        private MapNode _left;
        private MapNode _right;
        private bool _unlocked;

        public MapNode(int id, MapNodeType type, MapNode prev, MapNode left, MapNode right, bool unlocked)
        {
            _id = id;
            _type = type;
            _prev = prev;
            _left = left;
            _right = right;
            _unlocked = unlocked;
        }
    }
}
