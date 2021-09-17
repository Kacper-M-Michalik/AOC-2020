using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {       
        
        struct BagStorage
        {
            public BagStorage(string CB, int NOB)
            {
                BagName = CB;
                NumberOfBag = NOB;
            }

            public string BagName;
            public int NumberOfBag;
        }

        
        static void Main(string[] args)
        {
            Dictionary<string, List<BagStorage>> AllBags = new Dictionary<string, List<BagStorage>>();
            
            bool ContainsGoldBag(List<BagStorage> Bags)
            {

                foreach (BagStorage Bag in Bags)
                {
                    if (Bag.BagName == "shiny gold")
                    {
                        return true;
                    }
                    else
                    {
                        if (ContainsGoldBag(AllBags[Bag.BagName]))
                        {
                            return true;
                        }

                    }
                }

                return false;
            }


            string[] lines = System.IO.File.ReadAllLines("Data.txt");
            
            foreach (string line in lines)
            {
                int Index = line.IndexOf(" bags contain ");
                string Name = line.Substring(0,Index);

                List<BagStorage> TempBags = new List<BagStorage>();

                if (line.IndexOf(" no other bags.") == -1)
                {

                    int StartIndex = Index + 14;
                    while (StartIndex < line.Length && line.IndexOf("bag", StartIndex) != -1)
                    {
                        int NextBagPos = line.IndexOf("bag", StartIndex);

                        
                        string HoldableBagData = line.Substring(StartIndex, NextBagPos - StartIndex - 1);
                        int HoldableBagCount = Convert.ToInt32(HoldableBagData.Substring(0, 1));
                        string HoldableBagName = HoldableBagData.Substring(2);

                        if (line.IndexOf("bags", StartIndex) == line.IndexOf("bag", StartIndex))
                        {
                            StartIndex = NextBagPos + 6;
                        }
                        else
                        {
                            StartIndex = NextBagPos + 5;
                        }

                        TempBags.Add(new BagStorage(HoldableBagName, HoldableBagCount));

                    }
                }

                AllBags.Add(Name,TempBags);

            }

            int BagsWithGold = 0;
            foreach (KeyValuePair<string, List<BagStorage>> Bag in AllBags)
            {

                if (ContainsGoldBag(Bag.Value))
                {
                    BagsWithGold++;
                }

            }
            Console.WriteLine(BagsWithGold);
            Console.Read();
        }
    }
}
