using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {

        static void Main(string[] args)
        {
            //Part 2
            int WaypointX = 10, WaypointY = 1;
            int ShipX = 0, ShipY = 0;

            string[] lines = System.IO.File.ReadAllLines("Data.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0,1) == "N")
                {
                    WaypointY += Convert.ToInt32(lines[i].Substring(1));
                }
                else if (lines[i].Substring(0, 1) == "S")
                {
                    WaypointY -= Convert.ToInt32(lines[i].Substring(1));
                }
                else if (lines[i].Substring(0, 1) == "E")
                {
                    WaypointX += Convert.ToInt32(lines[i].Substring(1));
                }
                else if (lines[i].Substring(0, 1) == "W")
                {
                    WaypointX -= Convert.ToInt32(lines[i].Substring(1));
                }
                else if (lines[i].Substring(0, 1) == "R")
                {
                    double Theta = -Convert.ToInt32(lines[i].Substring(1))* Math.PI / 180;
                    int TempWaypointX = (int)Math.Round( WaypointX * Math.Cos(Theta) - WaypointY * Math.Sin(Theta));
                    WaypointY = (int)Math.Round(WaypointX * Math.Sin(Theta) + WaypointY * Math.Cos(Theta));
                    WaypointX = TempWaypointX;
                }
                else if (lines[i].Substring(0, 1) == "L")
                {
                    double Theta = Convert.ToInt32(lines[i].Substring(1)) * Math.PI / 180;
                    int TempWaypointX = (int)Math.Round(WaypointX * Math.Cos(Theta) - WaypointY * Math.Sin(Theta));
                    WaypointY = (int)Math.Round(WaypointX * Math.Sin(Theta) + WaypointY * Math.Cos(Theta));
                    WaypointX = TempWaypointX;
                }
                else if (lines[i].Substring(0, 1) == "F")
                {
                    int LoopCount = Convert.ToInt32(lines[i].Substring(1));

                    ShipX += WaypointX * LoopCount;
                    ShipY += WaypointY * LoopCount;
                    
                }
               
            }

            Console.WriteLine(Math.Abs(ShipX)+Math.Abs(ShipY));
            Console.ReadLine();
        }
    }
}
