using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmasks___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<UInt64, int> Memory = new Dictionary<UInt64, int>();
            void SetMemory(UInt64 Address, int Value)
            {
                if (Memory.ContainsKey(Address))
                {
                    Memory[Address] = Value;
                }
                else
                {
                    Memory.Add(Address, Value);
                }
            }

            string BaseDirectory = AppContext.BaseDirectory;
            string Directory = BaseDirectory.Remove(BaseDirectory.Length - 10);
            string[] Data = System.IO.File.ReadAllLines(Directory + "\\Data.txt");

            //Base value -> turn x's into 0s then turn sequnce into base 64 int
            //save somehow layout of x's

            //in loop iterate over all combos of x's + base value

            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i].Substring(0, 4) == "mask")
                {
                   

                }
                else
                {

                }
            }

            double Total = 0;

            foreach (KeyValuePair<UInt64,int> Address in Memory)
            {
                Total += Address.Value;
            }

            Console.WriteLine(Total);
            Console.ReadKey();

        }        
    }
}
