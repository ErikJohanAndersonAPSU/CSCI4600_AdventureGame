using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class SaveGameState
    {
        private int _accountID;
        private int _saveID;
        private DateTime _saveDateTime = DateTime.Now;

        private int _currentMapNode;
        private Character _character;

        public int AccountID { get { return _accountID; } set { _accountID = value; } }
        public int SaveID { get { return _saveID; } set { _saveID = value; } }
        public DateTime SaveDateTime { get { return _saveDateTime; } set { _saveDateTime = value; } }
        public int CurrentMapNode { get { return _currentMapNode; } set { _currentMapNode = value; } }
        public Character Character { get { return _character; } set { _character = value; } }

        public SaveGameState(int accountID, int saveID, int currentMapNode, Character character)
        {
            AccountID = accountID;
            SaveID = saveID;
            SaveDateTime = DateTime.Now;
            CurrentMapNode = currentMapNode;
            Character = character;
        }
        public SaveGameState(int currentMapNode, Character character)
        {
            AccountID = AdventureGameManager.currentAccount.ID;
            SaveID = ++AdventureGameManager.currentAccount.NumSavesSaved;
            SaveDateTime = DateTime.Now;
            CurrentMapNode = currentMapNode;
            Character = character;
        }

        public override string ToString()
        {
            return AccountID.ToString() + " : " + SaveID.ToString() + "\n" + SaveDateTime.ToString() + "\n" + CurrentMapNode.ToString() + "\n" + Character;
        }
    }
}
