using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    class Program
    {
        static void Main(string[] args)
        {            
            string Numbers = System.IO.File.ReadAllLines("Data.txt")[0];

            //Give in cup label, outputs next cup label
            Dictionary<long, long> CupToNextCup = new Dictionary<long, long>();

            //Populates dictionary
            int NumOfCups = 1000000;
            for (int i = 0; i < NumOfCups; i++)
            {
                if (i < Numbers.Length)
                {
                    if (i == Numbers.Length - 1)
                    {
                        if (NumOfCups <= Numbers.Length)
                        {
                            CupToNextCup.Add(Convert.ToInt32(Numbers[i].ToString()), Convert.ToInt32(Numbers[0].ToString()));
                        }
                        else
                        {
                            CupToNextCup.Add(Convert.ToInt32(Numbers[i].ToString()), i + 2);
                        }
                        
                    }
                    else
                    {
                        CupToNextCup.Add(Convert.ToInt32(Numbers[i].ToString()), Convert.ToInt32(Numbers[i+1].ToString()));
                    }
                }
                else
                {
                    if (i == NumOfCups - 1)
                    {
                        CupToNextCup.Add(i + 1, Convert.ToInt32(Numbers[0].ToString()));
                    }
                    else
                    {
                        CupToNextCup.Add(i+1,i+2);
                    }                    
                }
               
            }

            //Main Loop
            long CurrentCupLabel = Convert.ToInt64(Numbers[0].ToString());
            for (int i = 0; i< 10000000; i++)
            {
                //Next Three Cups
                long NextCupLabel1 = CupToNextCup[CurrentCupLabel];
                long NextCupLabel2 = CupToNextCup[NextCupLabel1];
                long NextCupLabel3 = CupToNextCup[NextCupLabel2];

                long DestinationCupLabel = GetDestinationCupLabel(NextCupLabel1,NextCupLabel2,NextCupLabel3);             


                CupToNextCup[CurrentCupLabel] = CupToNextCup[NextCupLabel3];
                CupToNextCup[NextCupLabel3] = CupToNextCup[DestinationCupLabel];
                CupToNextCup[DestinationCupLabel] = NextCupLabel1;

                CurrentCupLabel = CupToNextCup[CurrentCupLabel];
            }

            //Result calculaed here
            long Cup1 = CupToNextCup[1];
            long Cup2 = CupToNextCup[Cup1];
            long Result = Cup1 * Cup2;

            Console.WriteLine(Result);
            Console.Read();

            long GetDestinationCupLabel(long BannedCup1, long BannedCup2, long BannedCup3)
            {
                long i = CurrentCupLabel - 1;
              
                while (true)
                {
                    if (i < 1) i = NumOfCups;
                    if (i != BannedCup1 && i != BannedCup2 && i != BannedCup3) return i;
                    i--;
                }                
            }

        }
    }
}
