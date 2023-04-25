using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600_Game
{
    public static class MetaShopManager
    {
        private static string _dir = "../../../Resources/Metashop/";

        public static List<MetaShopOffer> ReadMetaShopOffersFromFile()
        {
            string[] fileEntries = Directory.GetFiles(_dir);

            List<MetaShopOffer> metaShopOffers = new List<MetaShopOffer>();



            foreach (string entry in fileEntries)
            {
                int metaShopID = -1, cost = -1, itemID = -1;
                string name, desc;

                try
                {
                    StreamReader sr = new StreamReader(entry);

                    metaShopID = int.Parse(Path.GetFileNameWithoutExtension(entry));

                    name = sr.ReadLine() ?? "ERROR";

                    desc = sr.ReadLine() ?? "ERROR";

                    cost = int.Parse(sr.ReadLine() ?? "-1");

                    itemID = int.Parse(sr.ReadLine() ?? "-1");

                    sr.Close();

                    metaShopOffers.Add(new MetaShopOffer(metaShopID, name, desc, cost, itemID));
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



            return metaShopOffers;
        }

        public static void CalcAvailableMetaShopOffers(Account account, List<MetaShopOffer> metaShopOffers)
        {
            foreach (int metaShopPurchase in account.MetaShopPurchases)
            {
                metaShopOffers.RemoveAll(x => x.MetaShopID == metaShopPurchase);
            }
        }

        public static void PurchaseMetaShopOffer(Account account, int metaShopID, List<MetaShopOffer> metaShopOffers)
        {
            account.MetaShopPurchases.Add(metaShopID);

            CalcAvailableMetaShopOffers(account, metaShopOffers);
        }
    }
}
