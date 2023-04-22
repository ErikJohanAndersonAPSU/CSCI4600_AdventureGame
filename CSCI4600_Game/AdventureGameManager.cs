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
            /*WikiManager.ReadWikiEntryFromFile();*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading leaderboard
            /*LeaderboardEntry[] testLB1 = LeaderboardManager.ReadLeaderboardsFromFile();
            Account testAcc = new Account(0, "Bob", "montecarlo", 100, 12, new int[0], 1);

            LeaderboardEntry[] testLB2 = LeaderboardManager.GetGlobalLeaderboardsSorted(testLB1);
            foreach (LeaderboardEntry entry in testLB2)
            {
                Trace.WriteLine(entry.AccountName);
                Trace.WriteLine(entry.CharacterName);
                Trace.WriteLine(entry.Desc);
                Trace.WriteLine(entry.Score);
                Trace.WriteLine(entry.Id);
                Trace.WriteLine("");
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test writing leaderboard
            /*LeaderboardEntry[] newLeaderboardEntries = new LeaderboardEntry[1];
            newLeaderboardEntries[0] = new LeaderboardEntry("kate", "kate", "", 450, 22);

            LeaderboardManager.WriteNewLeaderboardsToFile(newLeaderboardEntries);*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test reading accounts
            Account[] accounts = AccountManager.ReadAccountsFromFile();

            Debug.WriteLine("Testing ReadAccountsFromFile()");
            /*foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }
            Debug.WriteLine("");*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test writing accounts
            Debug.WriteLine("Testing WriteAccountsToFile()");

            List<Account> accountList = accounts.ToList();
            accountList.Add(new Account(21, "bobby", "", 1, 1, new int[] { 0 }, 1));
            accountList.Add(new Account(32, "nana", "horker", 555, 4, new int[] { 1, 2, 3, 5, 6, 7, 8, 9 }, 22));
            accountList.Add(new Account(81, "bobithy", "", 0, 0, new int[] { 0 }, 0));
            accounts = accountList.ToArray();

            AccountManager.WriteAccountsToFile(accounts);

            /*accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account add
            Debug.WriteLine("Testing AddAccount");

            Account testAccount1 = new Account(828, "whover", "password", 1000, 3, new int[] { 22, 23, 24, 27, 8 }, 22);
            AccountManager.AddAccount(testAccount1);

            /*accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account modify
            Debug.WriteLine("Testing ModifyAccount");

            Account testAccount2 = new Account(828, "whover", "betterPassword", 1000, 5, new int[] { 22, 23, 24, 27, 8, 99 }, 27);
            AccountManager.ModifyAccount(testAccount2);

            /*accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------



            //-------------------------------------------------------------------------------------------------------------------------------------
            // Test account delete
            Debug.WriteLine("Testing DeleteAccount");

            AccountManager.DeleteAccount(testAccount2);

            /*accounts = AccountManager.ReadAccountsFromFile();
            foreach (Account account in accounts)
            {
                Debug.WriteLine(account);
            }*/
            //-------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
