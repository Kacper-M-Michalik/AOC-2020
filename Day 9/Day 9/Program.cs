using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            /*
            List<long> IntsToFind = new List<long>();

            long[] Numbers = new long[Lines.Length];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = Convert.ToInt64(Lines[i]);
                if (i > 24)
                {
                    IntsToFind.Add(Numbers[i]);
                }
            }

            for (int i = 25; i < Numbers.Length; i++)
            {
                for (int j = i - 25; j < i; j++)
                {
                    for (int k = j + 1; k < i; k++)
                    {
                        if (Numbers[j] + Numbers[k] == Numbers[i])
                        {
                            IntsToFind.Remove(Numbers[i]);
                        }
                    }
                }
            }

            Console.WriteLine(IntsToFind);
            Console.Read();
            */
            
            long[] Numbers = new long[Lines.Length];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = Convert.ToInt64(Lines[i]);               
            }

            List<long> SuccessfulChain = null;

            for (int ChainLength = 2; ChainLength < Numbers.Length; ChainLength++)
            {
                for (int i = 0; i + ChainLength < Numbers.Length + 1; i++)
                {
                    List<long> Longs = new List<long>();
                    long Sum = 0;
                    for (int j = i; j < i + ChainLength; j++)
                    {
                        Sum += Numbers[j];
                        Longs.Add(Numbers[j]);
                    }

                    if (Sum == Convert.ToInt64(29221323))
                    {
                        SuccessfulChain = Longs;
                    }

                }
            }

            long Min = SuccessfulChain[0];
            long Max = SuccessfulChain[0];

            for (int i = 0; i < SuccessfulChain.Count; i++)
            {
                if (SuccessfulChain[i] > Max)
                {
                    Max = SuccessfulChain[i];
                }
                if (SuccessfulChain[i] < Min)
                {
                    Min = SuccessfulChain[i];
                }
            }
            Console.WriteLine(Min + Max);
            Console.Read();

        }
    }
}
