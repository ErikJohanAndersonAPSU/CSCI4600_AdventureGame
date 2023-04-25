using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public static class MapManager
    {
        private static string _dir = "../../../Resources/MapNodes/";

        public static List<MapNode> ReadNodesFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            List<MapNode> nodes = new List<MapNode>();



            foreach (string entry in fileEntries)
            {
                int id, prev, left, right, unlockItemID;
                MapNodeType mapNodeType;
                bool unlocked;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    int.TryParse(Path.GetFileNameWithoutExtension(entry), out id);

                    mapNodeType = (MapNodeType) Enum.Parse(typeof(MapNodeType), sr.ReadLine());

                    int.TryParse(sr.ReadLine(), out prev);
                    int.TryParse(sr.ReadLine(), out left);
                    int.TryParse(sr.ReadLine(), out right);

                    bool.TryParse(sr.ReadLine(), out unlocked);

                    if (mapNodeType.Equals(MapNodeType.Event) || mapNodeType.Equals(MapNodeType.Combat))
                    {
                        string eventName, eventDesc, leftDescUnlocked, leftDescLocked, rightDescUnlocked, rightDescLocked;

                        eventName = sr.ReadLine();
                        eventDesc = sr.ReadLine();
                        leftDescUnlocked = sr.ReadLine();
                        leftDescLocked = sr.ReadLine();
                        rightDescUnlocked = sr.ReadLine();
                        rightDescLocked = sr.ReadLine();
                        unlockItemID = int.Parse(sr.ReadLine());

                        if (mapNodeType.Equals(MapNodeType.Event))
                        {
                            MapNodeEvent mapNodeEvent = new MapNodeEvent(id, MapNodeType.Event, prev, left, right, unlocked, unlockItemID, eventName, eventDesc, leftDescUnlocked, leftDescLocked, rightDescUnlocked, rightDescLocked);
                        
                            nodes.Add(mapNodeEvent);
                        }
                        else
                        {
                            string[] combatCharStr = sr.ReadLine().Split(",");

                            string enemyCharName = combatCharStr[0];
                            CharacterStats enemyCharStats = new CharacterStats(combatCharStr[1], combatCharStr[2], combatCharStr[3]);

                            Character enemyChar = new Character(enemyCharName, enemyCharStats);

                            bool combatCompleted = bool.Parse(sr.ReadLine());

                            string leftCombatDesc = sr.ReadLine();
                            string rightCombatDesc = sr.ReadLine();

                            MapNodeCombat mapNodeCombat = new MapNodeCombat(id, MapNodeType.Event, prev, left, right, unlocked, unlockItemID, eventName, eventDesc, leftDescUnlocked, leftDescLocked, rightDescUnlocked, rightDescLocked, enemyChar, combatCompleted, leftCombatDesc, rightCombatDesc);

                            nodes.Add(mapNodeCombat);
                        }
                    }

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



            return nodes;
        }

        /*public static void CalculateMap(Account account)
        {

        }*/
    }
}
