using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    class Program
    {

        public struct NumberData
        {
            public long LastLineApperead;
            public bool AppererdMoreThanOnce;

            public NumberData(long LastLine, bool Appeared)
            {
                LastLineApperead = LastLine;
                AppererdMoreThanOnce = Appeared;
            }

        }

        static void Main(string[] args)
        {

           

            string[] Lines = System.IO.File.ReadAllLines("Data.txt")[0].Split(',');

            Dictionary<long, NumberData> TurnWhenNumberLastAppeared = new Dictionary<long, NumberData>();
            List<long> DebugList = new List<long>();

            for (int i = 0; i < Lines.Length; i++)
            {
                TurnWhenNumberLastAppeared.Add(Convert.ToInt64(Lines[i]), new NumberData(i,false));
                DebugList.Add(Convert.ToInt64(Lines[i]));
            }

            long LastNumberSpoken = Convert.ToInt64(Lines[Lines.Length - 1]);
            for (int i = Lines.Length; i < 30000000; i++)
            {
                bool Exists = TurnWhenNumberLastAppeared.TryGetValue(LastNumberSpoken, out NumberData LastSpokenTurn);
                if (Exists && LastSpokenTurn.AppererdMoreThanOnce)
                {
                    long Difference = (i - 1) - LastSpokenTurn.LastLineApperead;
                    TurnWhenNumberLastAppeared[LastNumberSpoken] = new NumberData(i-1,true);
                    LastNumberSpoken = Difference;

                    if (TurnWhenNumberLastAppeared.TryGetValue(Difference,out NumberData Val))
                    {
                        TurnWhenNumberLastAppeared[Difference] = new NumberData(TurnWhenNumberLastAppeared[Difference].LastLineApperead, true);
                    }
                    
                }
                else
                {                    
                    if (Exists)
                    {
                        TurnWhenNumberLastAppeared[LastNumberSpoken] = new NumberData(i - 1, true);
                    }
                    else
                    {
                        TurnWhenNumberLastAppeared.Add(LastNumberSpoken,new NumberData(i - 1, false));
                    }
                    LastNumberSpoken = 0;
                    TurnWhenNumberLastAppeared[0] = new NumberData(TurnWhenNumberLastAppeared[0].LastLineApperead, true);
                }
            }
            

            Console.WriteLine(LastNumberSpoken);
            Console.ReadKey();            
        }
    }
}
