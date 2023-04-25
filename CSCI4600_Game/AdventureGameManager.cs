using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal static class AdventureGameManager
    {
        // Variables that only need to be initialized once
        internal static List<Item> items = ItemManager.ReadItemsFromFile();
        internal static List<CharacterClass> charClasses = CharacterClassManager.ReadCharacterClassFromFile();
        internal static List<MapNode> mapNodes = MapManager.ReadNodesFromFile();
        internal static WikiEntry[] wikiEntries = WikiManager.ReadWikiEntryFromFile();

        // Variables that need to be updated to avoid mixups
        internal static List<Account> accounts = AccountManager.ReadAccountsFromFile();
        internal static Account? currentAccount;
        internal static int currentAccountID = -1;
        internal static int nextAccountID = 1;
        internal static bool changedAccount = false;

        internal static List<SaveGameState> saves = SaveManager.ReadSavesFromFile();
        internal static SaveGameState currentSave;

        internal static LeaderboardEntry[] leaderboardEntries = LeaderboardManager.ReadLeaderboardsFromFile();

        internal static List<MetaShopOffer> metaShopOffers = MetaShopManager.ReadMetaShopOffersFromFile();

        public static void UpdateNextAccountID()
        {
            accounts = AccountManager.ReadAccountsFromFile();

            foreach(var account in accounts)
            {
                if (account != null && account.ID == nextAccountID)
                {
                    nextAccountID++;
                }
            }
        }

        public static void UpdateAccounts()
        {
            accounts = AccountManager.ReadAccountsFromFile();
        }

        public static void UpdateAccountsAndID(int currentAccountID)
        {
            accounts = AccountManager.ReadAccountsFromFile();
            AdventureGameManager.currentAccountID = currentAccountID;
        }

        public static void UpdateAccountsAndID(Account currentAccount)
        {
            accounts = AccountManager.ReadAccountsFromFile();
            currentAccountID = currentAccount.ID;
        }

        public static void SetCurrentAccount(Account newCurrentAccount)
        {
            accounts = AccountManager.ReadAccountsFromFile();

            currentAccountID = newCurrentAccount.ID;
            currentAccount = accounts.Find(x => x.ID == currentAccountID);
        }

        public static void ResetCurrentAccount()
        {
            accounts = AccountManager.ReadAccountsFromFile();

            currentAccountID = -1;
            currentAccount = null;
        }

        public static void UpdateSaves()
        {
            saves = SaveManager.ReadSavesFromFile();
        }

        public static void UpdateGameVariablesEndOfGame()
        {

        }

        public static void Test()
        {
            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test directory
            /*string[] Documents = System.IO.Directory.GetFiles("../../../Resources/Leaderboard/");
            foreach(string File in Documents)
            {
                Trace.WriteLine(File);
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test wiki
            Debug.WriteLine("Testing ReadWikiEntryFromFile");

            WikiManager.ReadWikiEntryFromFile();

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading leaderboard
            Debug.WriteLine("Testing ReadLeaderboardsFromFile");

            LeaderboardEntry[] testLB1 = LeaderboardManager.ReadLeaderboardsFromFile();
            foreach (LeaderboardEntry entry in testLB1)
            {
                Trace.WriteLine(entry.AccountName);
                Trace.WriteLine(entry.CharacterName);
                Trace.WriteLine(entry.Desc);
                Trace.WriteLine(entry.Score);
                Trace.WriteLine(entry.Id);
                Trace.WriteLine("");
            }

            Account testAcc = new Account(0, "Bob", "montecarlo", 100, 12, new List<int>(), 1);

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");



            Debug.WriteLine("Testing GetGlobalLeaderboardsSorted");

            LeaderboardEntry[] testLB2 = LeaderboardManager.GetGlobalLeaderboardsSorted(testLB1);
            foreach (LeaderboardEntry entry in testLB2)
            {
                Trace.WriteLine(entry.AccountName);
                Trace.WriteLine(entry.CharacterName);
                Trace.WriteLine(entry.Desc);
                Trace.WriteLine(entry.Score);
                Trace.WriteLine(entry.Id);
                Trace.WriteLine("");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test writing leaderboard
            Debug.WriteLine("Testing WriteNewLeaderboardsToFile");

            LeaderboardEntry[] newLeaderboardEntries = new LeaderboardEntry[1];
            newLeaderboardEntries[0] = new LeaderboardEntry("kate", "kate", "", 450, 22);

            //Commented to stop 20 new leaderboard files from existing after testing
            //LeaderboardManager.WriteNewLeaderboardsToFile(newLeaderboardEntries);

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading accounts
            Debug.WriteLine("Testing ReadAccountsFromFile()");

            List<Account> accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test writing accounts
            Debug.WriteLine("Testing WriteAccountsToFile()");

            accounts.Add(new Account(21, "bobby", "", 1, 1, new List<int> { 0 }, 1));
            accounts.Add(new Account(32, "nana", "horker", 555, 4, new List<int> { 1, 2, 3, 5, 6, 7, 8, 9 }, 22));
            accounts.Add(new Account(81, "bobithy", "", 0, 0, new List<int> { 0 }, 0));

            AccountManager.WriteAccountsToFile(accounts);

            accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account add
            Debug.WriteLine("Testing AddAccount");

            Account testAccount1 = new Account(828, "whover", "password", 1000, 3, new List<int> { 22, 23, 24, 27, 8 }, 22);
            AccountManager.AddAccount(testAccount1);

            accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account modify
            Debug.WriteLine("Testing ModifyAccount");

            Account testAccount2 = new Account(828, "whover", "betterPassword", 1000, 5, new List<int> { 22, 23, 24, 27, 8, 99 }, 27);
            AccountManager.ModifyAccount(testAccount2);

            accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account delete
            Debug.WriteLine("Testing DeleteAccount");

            AccountManager.DeleteAccount(testAccount2);

            accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading nodes
            Debug.WriteLine("Testing ReadNodesFromFile()");

            List<MapNode> nodes = MapManager.ReadNodesFromFile();
            foreach (MapNode node in nodes)
            {
                Debug.WriteLine(node);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading items
            Debug.WriteLine("Testing ReadItemsFromFile()");

            List<Item> items = ItemManager.ReadItemsFromFile();
            foreach (Item item in items)
            {
                Debug.WriteLine(item);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading metashop offers
            Debug.WriteLine("Testing ReadMetaShopOffersFromFile()");

            List<MetaShopOffer> metashopOffers = MetaShopManager.ReadMetaShopOffersFromFile();
            foreach (MetaShopOffer metashopOffer in metashopOffers)
            {
                Debug.WriteLine(metashopOffer);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test calculating metashop offers
            Debug.WriteLine("Testing CalcAvailableMetaShopOffers()");

            MetaShopManager.CalcAvailableMetaShopOffers(accounts.Find(x => x.ID == 1), metashopOffers);
            foreach (MetaShopOffer metashopOffer in metashopOffers)
            {
                Debug.WriteLine(metashopOffer);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test purchasing metashop offers
            Debug.WriteLine("Testing PurchaseMetaShopOffer()");
            Debug.WriteLine("");

            Debug.WriteLine("Account before purchase");
            Debug.WriteLine(accounts.Find(x => x.ID == 1));
            Debug.WriteLine("");

            MetaShopManager.PurchaseMetaShopOffer(accounts.Find(x => x.ID == 1), 3, metashopOffers);

            Debug.WriteLine("Account after purchase");
            Debug.WriteLine(accounts.Find(x => x.ID == 1));
            Debug.WriteLine("");

            foreach (MetaShopOffer metashopOffer in metashopOffers)
            {
                Debug.WriteLine(metashopOffer);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading character classes
            Debug.WriteLine("Testing ReadCharacterClassFromFile()");
            Debug.WriteLine("");

            foreach (CharacterClass characterClass in charClasses)
            {
                Debug.WriteLine(characterClass);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading saves
            Debug.WriteLine("Testing ReadSavesFromFile()");
            Debug.WriteLine("");

            saves = SaveManager.ReadSavesFromFile();
            foreach (SaveGameState save in saves)
            {
                Debug.WriteLine(save.ToString());
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test loading account-specific saves
            Debug.WriteLine("Testing LoadAccountSaves()");

            Debug.WriteLine("Looking for Bobby's saves");
            currentAccount = accounts.Find(x => x.ID == 21);
            Debug.WriteLine(currentAccount);

            saves = SaveManager.LoadAccountSaves(currentAccount, saves);
            foreach (SaveGameState save in saves)
            {
                Debug.WriteLine(save);
                Debug.WriteLine("----------------------------------------\n");
            }



            saves = SaveManager.ReadSavesFromFile();

            Debug.WriteLine("Looking for nana's saves");

            currentAccount = accounts.Find(x => x.ID == 32);
            Debug.WriteLine(currentAccount);

            saves = SaveManager.LoadAccountSaves(accounts.Find(x => x.ID == 32), saves);
            foreach (SaveGameState save in saves)
            {
                Debug.WriteLine(save);
                Debug.WriteLine("----------------------------------------\n");
            }

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test writing saves
            Debug.WriteLine("Testing WriteSavesToFile()");
            Debug.WriteLine("");

            Character testChar = new Character("giradeli", "a chocolatey explorer", charClasses.Find(x => x.ClassName == "robot"), new Inventory(items.Find(x => x.ID == -1)));
            saves.Add(new SaveGameState(22, testChar));

            SaveManager.WriteSavesToFile(saves);

            Debug.WriteLine("\n^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
            //-------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
