using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class MapNode
    {
        private int _id;
        private MapNode _prev;
        private MapNode _left;
        private MapNode _right;

        public MapNode(int id, MapNode prev, MapNode left, MapNode right)
        {
            _id = id;
            _prev = prev;
            _left = left;
            _right = right;
        }
    }
}
