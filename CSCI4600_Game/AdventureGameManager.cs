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
    internal class AdventureGameManager
    {
        internal static Account[] accounts;
        internal static Account currentAccount;

        internal static Save[] saves;

        internal static List<Item> itemsList;
        internal static Item[] itemsArr = {
            new Item(
                1,
                "name1",
                "desc1",
                new CharacterStats(0,0,0)
            ),
            new Item(
                2,
                "name2",
                "desc2",
                new CharacterStats(0,0,0)
            ),
            new Item(
                3,
                "name3",
                "desc3",
                new CharacterStats(0,0,0)
            ),
            new Item(
                4,
                "name4",
                "desc4",
                new CharacterStats(0,0,0)
            ),
            new Item(
                5,
                "name5",
                "desc5",
                new CharacterStats(0,0,0)
            ),
        };

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

            LeaderboardManager.WriteNewLeaderboardsToFile(newLeaderboardEntries);

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
        }
    }
}
