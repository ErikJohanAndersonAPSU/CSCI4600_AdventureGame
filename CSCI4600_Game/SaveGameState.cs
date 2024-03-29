﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public class SaveGameState
    {
        private int _accountID;
        private int _saveID;
        private DateTime _saveDateTime = DateTime.Now;

        private int _currentMapNode;
        private Character _currentCharacter;

        public int AccountID { get { return _accountID; } set { _accountID = value; } }
        public int SaveID { get { return _saveID; } set { _saveID = value; } }
        public DateTime SaveDateTime { get { return _saveDateTime; } set { _saveDateTime = value; } }
        public int CurrentMapNode { get { return _currentMapNode; } set { _currentMapNode = value; } }
        public Character CurrentCharacter { get { return _currentCharacter; } set { _currentCharacter = value; } }
        public SaveGameState(int accountID, int saveID, DateTime saveDateTime, int currentMapNode, Character character)
        {
            AccountID = accountID;
            SaveID = saveID;
            SaveDateTime = saveDateTime;
            CurrentMapNode = currentMapNode;
            CurrentCharacter = character;
        }
        public SaveGameState(int accountID, int saveID, int currentMapNode, Character character)
        {
            AccountID = accountID;
            SaveID = saveID;
            SaveDateTime = DateTime.Now;
            CurrentMapNode = currentMapNode;
            CurrentCharacter = character;
        }
        public SaveGameState(int currentMapNode, DateTime saveDateTime, Character character)
        {
            AccountID = AdventureGameManager.currentAccount.ID;
            SaveID = ++AdventureGameManager.currentAccount.NumSavesSaved;
            SaveDateTime = saveDateTime;
            CurrentMapNode = currentMapNode;
            CurrentCharacter = character;
        }
        public SaveGameState(int currentMapNode, Character character)
        {
            AccountID = AdventureGameManager.currentAccount.ID;
            SaveID = ++AdventureGameManager.currentAccount.NumSavesSaved;
            SaveDateTime = DateTime.Now;
            CurrentMapNode = currentMapNode;
            CurrentCharacter = character;
        }
        public SaveGameState(Character character)
        {
            AccountID = AdventureGameManager.currentAccount.ID;
            SaveID = ++AdventureGameManager.currentAccount.NumSavesSaved;
            SaveDateTime = DateTime.Now;
            CurrentMapNode = 1;
            CurrentCharacter = character;
        }

        public override string ToString()
        {
            return AccountID.ToString() + " : " + SaveID.ToString() + "\n" + CurrentMapNode + "\n" + SaveDateTime.ToString() + "\n" + CurrentCharacter;
        }
    }
}
