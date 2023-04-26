using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSCI4600_Game
{
    public static class SaveManager
    {
        private static string _dir = "../../../Resources/Save/";

        public static List<SaveGameState> ReadSavesFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            List<SaveGameState> saves = new List<SaveGameState>();

            foreach (string entry in fileEntries)
            {
                int accountID = -1, saveID = -1, currentMapNode = -1;
                string charName, charDesc, charClassStr;
                DateTime saveDateTime;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    string[] idStrArr = Path.GetFileNameWithoutExtension(entry).Split("_");

                    accountID = int.Parse(idStrArr[0]);
                    saveID = int.Parse(idStrArr[1]);

                    currentMapNode = int.Parse(sr.ReadLine());

                    saveDateTime = DateTime.Parse(sr.ReadLine());

                    charName = sr.ReadLine();
                    charDesc = sr.ReadLine();

                    charClassStr = sr.ReadLine() ?? "default";
                    CharacterClass charClass = AdventureGameManager.charClasses.Find(x => x.ClassName.Equals(charClassStr));

                    string[] charStatArr = (sr.ReadLine() ?? "0,0,0").Split(",");
                    CharacterStats charStats = new CharacterStats(charStatArr);

                    Inventory charInventory = new Inventory();
                    string[] charItemIDArr = (sr.ReadLine() ?? "").Split(",");
                    foreach (string charItemID in charItemIDArr)
                    {
                        int itemID = int.Parse(charItemID);
                        charInventory.AddItem(AdventureGameManager.items.Find(x => x.ID == itemID));
                    }


                    sr.Close();

                    saves.Add(new SaveGameState(accountID, saveID, saveDateTime, currentMapNode, new Character(charName, charDesc, charClass, charStats, charInventory)));
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



            return saves;
        }

        public static List<SaveGameState> LoadAccountSaves(Account account, List<SaveGameState> saves)
        {
            return saves.FindAll(x => x.AccountID == account.ID);
        }

        public static void WriteSavesToFile(List<SaveGameState> saves)
        {
            foreach (SaveGameState save in saves)
            {
                string filepath = GetFilepath(save);

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(save.CurrentMapNode.ToString());
                sb.AppendLine(save.SaveDateTime.ToString());

                sb.AppendLine(save.CurrentCharacter.Name);
                sb.AppendLine(save.CurrentCharacter.Desc);
                sb.AppendLine(save.CurrentCharacter.CharClass.ClassName);

                sb.Append(save.CurrentCharacter.CharStats.Health + ",");
                sb.Append(save.CurrentCharacter.CharStats.Attack + ",");
                sb.AppendLine(save.CurrentCharacter.CharStats.Defense.ToString());

                List<Item> items = save.CurrentCharacter.CharInventory.Items;
                int bound = save.CurrentCharacter.CharInventory.Items.Count;
                for (int i = 0; i < bound; i++)
                {
                    sb.Append(items[i].ID.ToString());
                    if (i != bound - 1)
                    {
                        sb.Append(',');
                    }
                }
                //sb.AppendLine(" ");

                File.WriteAllText(filepath, sb.ToString());
            }
        }
        public static void DeleteSave(SaveGameState save)
        {
            string filepath = GetFilepath(save);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        /*public static void CreateSave(SaveGameState saveGameState, List<SaveGameState> saves)
        {

        }*/

        /*public static void PlaySave(SaveGameState save)
        {

        }*/

        private static string GetFilepath(SaveGameState save)
        {
            string filename = save.AccountID + "_" + save.SaveID + ".txt";
            string filepath = Path.Combine(_dir, filename);

            return filepath;
        }
    }
}
