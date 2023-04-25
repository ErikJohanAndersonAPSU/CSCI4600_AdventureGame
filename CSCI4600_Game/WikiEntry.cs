using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public class WikiEntry
    {
        private string _name;
        private string _desc;

        public WikiEntry(string name, string desc)
        {
            _name = name;
            _desc = desc;
        }

        public string Name { get { return _name; } }

        public string Desc { get { return _desc; } }
    }
}
