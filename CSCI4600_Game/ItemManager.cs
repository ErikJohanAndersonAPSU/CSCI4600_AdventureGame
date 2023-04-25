using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public static class ItemManager
    {
        private static string _dir = "../../../Resources/Item/";

        public static List<Item> ReadItemsFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            List<Item> items = new List<Item>();



            foreach (string entry in fileEntries)
            {
                int id = -1;
                string name, desc;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    id = int.Parse(Path.GetFileNameWithoutExtension(entry));

                    name = sr.ReadLine() ?? "ERROR";

                    desc = sr.ReadLine() ?? "ERROR";

                    string[] statModArr = (sr.ReadLine() ?? "0,0,0").Split(",");

                    sr.Close();

                    items.Add(new Item(id, name, desc, new CharacterStats(statModArr)));
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Debug.WriteLine("Executing finally block.");
                }
            }



            return items;
        }
    }
}
