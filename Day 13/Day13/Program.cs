using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {

            //NEED TO LEARN CHINESE REMAINDER THEOREM THEN REWRITE
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            /*
            int EarliestTimeToLeave = Convert.ToInt32(Lines[0]);
            int ShortestBusID = 0;
            int ShortestBusTimeDifference = EarliestTimeToLeave;

            string[] PossibleBuses = Lines[1].Split(",".ToCharArray());

            List<int> Buses = new List<int>();
            for (int i = 0; i < PossibleBuses.Length; i++)
            {
                if (PossibleBuses[i] != "x")
                {
                    Buses.Add(Convert.ToInt32(PossibleBuses[i]));
                }
            }

            for (int i = 0; i < Buses.Count; i++)
            {
                int Time = 0;
                while (Time < EarliestTimeToLeave)
                {
                    Time += Buses[i];
                }

                if (Time-EarliestTimeToLeave < ShortestBusTimeDifference)
                {
                    ShortestBusID = Buses[i];
                    ShortestBusTimeDifference = Time - EarliestTimeToLeave;
                }

            }

            Console.WriteLine(ShortestBusID*ShortestBusTimeDifference);
            */

            string[] PossibleBuses = Lines[0].Split(",".ToCharArray());

            List<int> BusSlots = new List<int>();
            for (int i = 0; i < PossibleBuses.Length; i++)
            {
                if (PossibleBuses[i] != "x")
                {
                    BusSlots.Add(Convert.ToInt32(PossibleBuses[i]));
                }
                else
                {
                    BusSlots.Add(1);
                }
            }

            
            int BiggestSkip = 0;
            int SkipOffset = 0;
            for (int i = 0; i < BusSlots.Count; i++)
            {
                if (BusSlots[i] > BiggestSkip)
                {
                    BiggestSkip = BusSlots[i];
                    SkipOffset = i;
                }
            }
            

            bool TimeFound = false;
            long Time = 629787747787534;
            while (!TimeFound)
            {

                long StartTime = Time - SkipOffset;
                if (StartTime % BusSlots[0] == 0)
                {
                    TimeFound = true;

                    for (int i = 1; i < BusSlots.Count; i++)
                    {
                        if ((StartTime + i) % BusSlots[i] != 0)
                        {
                            TimeFound = false;
                        }
                    }
                }

                Time += BiggestSkip;

            }

            Time -= BiggestSkip+SkipOffset;
            Console.WriteLine(Time);
            
            /*
            bool TimeFound = false;
            long Time = 0;
            while (!TimeFound)
            {
                TimeFound = true;
                for (int i = 0; i < BusSlots.Count; i++)
                {
                    if ((Time + i) % BusSlots[i] != 0)
                    {
                        TimeFound = false;
                    }
                }
                Time += BusSlots[0];

            }

            Time -= BusSlots[0];
            Console.WriteLine(Time);
            */

        }
    }
}
