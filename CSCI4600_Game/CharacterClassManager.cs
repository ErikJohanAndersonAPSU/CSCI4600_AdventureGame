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
    public static class CharacterClassManager
    {
        private static string _dir = "../../../Resources/CharacterClass/";

        public static List<CharacterClass> ReadCharacterClassFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            List<CharacterClass> characterClasses = new List<CharacterClass>();



            foreach (string entry in fileEntries)
            {
                string className;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    className = Path.GetFileNameWithoutExtension(entry);

                    string[] statModArr = (sr.ReadLine() ?? "0,0,0").Split(",");

                    characterClasses.Add(new CharacterClass(className, new CharacterStats(statModArr)));

                    sr.Close();
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



            return characterClasses;
        }
    }
}
