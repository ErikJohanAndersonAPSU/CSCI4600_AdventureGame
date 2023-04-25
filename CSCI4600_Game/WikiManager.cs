using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSCI4600_Game
{
    public static class WikiManager
    {
        //private static string _dir = System.IO.Path.Combine(Environment.CurrentDirectory, @"Wiki\");
        private static string _dir = "../../../Resources/Wiki/";

        public static WikiEntry[] ReadWikiEntryFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            WikiEntry[] wikiEntries = new WikiEntry[fileEntries.Length];

            int i = 0;

            foreach (string entry in fileEntries)
            {
                String name, desc;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    name = sr.ReadLine();

                    desc = sr.ReadLine();

                    sr.Close();

                    wikiEntries[i] = new WikiEntry(name, desc);
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

            return wikiEntries;
        }

        /*public static void ShowWikiEntry()
        {

        }*/
    }
}
