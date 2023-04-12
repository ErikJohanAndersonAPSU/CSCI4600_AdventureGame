using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Event : MapNode
    {
        private string _name;
        private string _desc;
        private string _leftDesc;
        private string _rightDesc;
        
        public Event(int id, MapNode prev, MapNode left, MapNode right, string name, string desc, string leftDesc, string rightDesc) : base(id, prev, left, right)
        {
            _name = name;
            _desc = desc;
            _leftDesc = leftDesc;
            _rightDesc = rightDesc;
        }
    }
}
