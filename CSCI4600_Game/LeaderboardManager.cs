using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    internal class LeaderboardManager
    {
        private static string _dir = Path.Combine(Environment.CurrentDirectory, @"Leaderboard\");

        public static LeaderboardEntry[] ReadLeaderboardsFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            LeaderboardEntry[] leaderboardEntries = new LeaderboardEntry[fileEntries.Length];

            int i = 0;



            foreach (string entry in fileEntries)
            {
                String accountName, characterName, desc;
                int score, id;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    accountName = sr.ReadLine() ?? "ERROR";
                    if (accountName.Length == 0)
                        accountName = "ERROR";

                    characterName = sr.ReadLine() ?? "ERROR";
                    if (characterName.Length == 0)
                        characterName = "ERROR";

                    desc = sr.ReadLine() ?? "";

                    score = Int32.Parse(sr.ReadLine() ?? "-1");

                    id = Int32.Parse(sr.ReadLine() ?? "-1");

                    sr.Close();

                    leaderboardEntries[i] = new LeaderboardEntry(accountName, characterName, desc, score, id);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Debug.WriteLine("Executing finally block.");
                }

                i++;
            }



            return leaderboardEntries;
        }

        public static LeaderboardEntry[] GetGlobalLeaderboardsSorted(LeaderboardEntry[] leaderboardEntries)
        {
            Array.Sort(leaderboardEntries);

            return leaderboardEntries;
        }

        public static LeaderboardEntry[] GetAccountLeaderboardsSorted(Account account, LeaderboardEntry[] leaderboardEntries)
        {
            List<LeaderboardEntry> accountLeaderboardEntries = new List<LeaderboardEntry>();

            foreach (LeaderboardEntry entry in leaderboardEntries)
            {
                if (entry.AccountName.Equals(account.Name))
                {
                    accountLeaderboardEntries.Add(entry);
                }
            }



            LeaderboardEntry[] accountLeaderboardEntriesArr = accountLeaderboardEntries.ToArray();

            Array.Sort(accountLeaderboardEntriesArr);

            return accountLeaderboardEntriesArr;
        }

        public static void WriteNewLeaderboardsToFile(LeaderboardEntry[] newEntries)
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            LeaderboardEntry[] currEntries = ReadLeaderboardsFromFile();

            int max = fileEntries.Length;
            int result = 0;

            foreach (string entry in fileEntries)
            {
                if (Int32.TryParse(Path.GetFileNameWithoutExtension(entry), out result) && result > max)
                {
                    max = result;
                }
            }

            foreach (LeaderboardEntry entry in newEntries)
            {
                max++;
                string fileName = max + ".txt";

                string newFileEntry = Path.Combine(_dir, fileName);
                Debug.WriteLine(newFileEntry);

                StreamWriter sw = new StreamWriter(newFileEntry);

                sw.WriteLine(entry.AccountName);
                sw.WriteLine(entry.CharacterName);
                sw.WriteLine(entry.Desc);
                sw.WriteLine(entry.Score);
                sw.WriteLine(entry.Id);
                sw.Close();
            }
        }
    }
}
