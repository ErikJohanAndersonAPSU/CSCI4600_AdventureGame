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
    internal class AccountManager
    {
        private static string _dir = Path.Combine(Environment.CurrentDirectory, @"Account\");

        public static Account[] ReadAccountsFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            Account[] accounts = new Account[fileEntries.Length];

            int i = 0;



            foreach (string entry in fileEntries)
            {
                string name, pass;
                int id = -1, metaCurrency = -1, numGamesPlayed = -1, numSavesSaved = -1;
                List<int> metaShopPurchases = new List<int>();

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    int.TryParse(Path.GetFileNameWithoutExtension(entry), out id);

                    name = sr.ReadLine() ?? "ERROR";

                    pass = sr.ReadLine() ?? "ERROR";

                    int.TryParse(sr.ReadLine(), out metaCurrency);

                    int.TryParse(sr.ReadLine(), out numGamesPlayed);

                    string[] metashopPurchaseStrArr = sr.ReadLine().Split(",");

                    foreach (string mspEntry in metashopPurchaseStrArr)
                    {
                        metaShopPurchases.Add(int.Parse(mspEntry));
                    }

                    int.TryParse(sr.ReadLine(), out numSavesSaved);

                    sr.Close();

                    accounts[i] = new Account(id, name, pass, metaCurrency, numGamesPlayed, metaShopPurchases.ToArray(), numSavesSaved);
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



            return accounts;
        }

        public static void WriteAccountsToFile(Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                string filepath = getFilepath(account);

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                StreamWriter sw = new StreamWriter(filepath);

                sw.WriteLine(account.Name);
                sw.WriteLine(account.Pass);
                sw.WriteLine(account.MetaCurrency);
                sw.WriteLine(account.NumGamesPlayed);

                for (int i = 0; i < account.MetaShopPurchases.Length; i++)
                {
                    sw.Write(account.MetaShopPurchases[i]);

                    if (i != account.MetaShopPurchases.Length - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
                sw.WriteLine(account.NumSavesSaved);

                sw.Close();
            }
        }

        public static void AddAccount(Account account)
        {
            Account[] accountArr = new Account[] { account };

            WriteAccountsToFile(accountArr);
        }

        public static void DeleteAccount(Account account)
        {
            string filepath = getFilepath(account);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public static void ModifyAccount(Account newAccount)
        {
            Account[] accountArr = new Account[] { newAccount };

            WriteAccountsToFile(accountArr);
        }

        private static string getFilepath(Account account)
        {
            string filename = account.ID + ".txt";
            string filepath = Path.Combine(_dir, filename);

            return filepath;
        }
    }
}
