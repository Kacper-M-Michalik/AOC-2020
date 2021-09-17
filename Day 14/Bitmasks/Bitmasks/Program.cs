using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmasks
{
    class Program
    {
        static void Main(string[] args)
        {

            string BaseDirectory = AppContext.BaseDirectory;
            string Directory = BaseDirectory.Remove(BaseDirectory.Length - 10);
            string[] Data = System.IO.File.ReadAllLines(Directory + "\\Data.txt");

            UInt64[] Memory = new UInt64[(int)Math.Pow(2,17)];
            UInt64 ToOnemask = 0;
            UInt64 ToZeromask = 0;

            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i].Substring(0, 4) == "mask")
                {
                    string Mask = Data[i].Substring(7, 36);
                    string ToOne = "0000000000000000000000000000" + Mask.Replace("X", "0");
                    string ToZero = "1111111111111111111111111111" + Mask.Replace("X", "1");

                    ToOnemask = Convert.ToUInt64(ToOne, 2);
                    ToZeromask = Convert.ToUInt64(ToZero, 2);

                }
                else
                {
                    int Index = Data[i].IndexOf("=") + 2;
                    string DenaryValueString = Data[i].Substring(Index, Data[i].Length - Index);

                    UInt64 AssignValue = (Convert.ToUInt64(DenaryValueString)|ToOnemask)&ToZeromask;

                    int AddrLength = (Data[i].IndexOf("]") - Data[i].IndexOf("[")) - 1;
                    int MemoryAddress = Convert.ToInt32(Data[i].Substring(Data[i].IndexOf("[") + 1, AddrLength));

                    Memory[MemoryAddress] = AssignValue;

                }
            }

            double Total = 0;

            for (int i = 0; i < Memory.Length; i++)
            {
                Total += Memory[i];
            }

            Console.WriteLine(Total);
            Console.ReadKey();
        }
    }
}
