using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class Save
    {
        private int _accountID;
        private int _saveID;
        private GameState _gameState;
        private DateTime _saveDateTime = DateTime.Now;

        public DateTime SaveDateTime
        {
            get { return _saveDateTime; }
            set { _saveDateTime = DateTime.Now; }
        }

        public Save(GameState gameState)
        {

        }
    }
}
