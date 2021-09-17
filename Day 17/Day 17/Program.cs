using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    class Program
    {
        static void Main(string[] args)
        {
            /* PART 1
            string[] Lines = System.IO.File.ReadAllLines(@"E:\Advent Code\Day 17\Data.txt");

            string[,,] Input = new string[Lines[0].Length, Lines.Length,1];
            
            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    Input[x, y, 0] = Lines[y].Substring(x, 1);
                }
            }           


            string[,,] CurrentOutput = Input;
            for (int i = 0; i < 6; i++)
            {
                CurrentOutput = Simulate(CurrentOutput);
            }

            int NumberOfActiveCubes = 0;
            for (int z = 0; z < CurrentOutput.GetLength(2); z++)
            {
                for (int y = 0; y < CurrentOutput.GetLength(1); y++)
                {
                    for (int x = 0; x < CurrentOutput.GetLength(0); x++)
                    {
                        if (CurrentOutput[x, y, z] == "#") NumberOfActiveCubes++;
                        Console.Write(CurrentOutput[x, y, z]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine(NumberOfActiveCubes);
            Console.Read();


            string[,,] Simulate(string[,,] InputGrid)
            {
                string[,,] SimulationGrid = new string[InputGrid.GetLength(0) + 2, InputGrid.GetLength(1) + 2, InputGrid.GetLength(2) + 2];
                string[,,] OutputGrid = new string[InputGrid.GetLength(0) + 2, InputGrid.GetLength(1) + 2, InputGrid.GetLength(2) + 2];

                for (int z = 0; z < SimulationGrid.GetLength(2); z++)
                {
                    for (int y = 0; y < SimulationGrid.GetLength(1); y++)
                    {
                        for (int x = 0; x < SimulationGrid.GetLength(0); x++)
                        {
                            if (x == 0 || x == SimulationGrid.GetLength(0)-1 || y == 0 || y == SimulationGrid.GetLength(1) - 1 || z == 0 || z == SimulationGrid.GetLength(2) - 1)
                            {
                                SimulationGrid[x,y,z] = ".";
                            }
                            else
                            {
                                SimulationGrid[x, y, z] = InputGrid[x-1, y-1, z-1];
                            }
                        }
                    }
                }

                //Loop through whole sim grid
                for (int z = 0; z < SimulationGrid.GetLength(2); z++)
                {
                    for (int y = 0; y < SimulationGrid.GetLength(1); y++)
                    {
                        for (int x = 0; x < SimulationGrid.GetLength(0); x++)
                        {
                            //Check cubes around
                            
                            int CubesActiveAround = 0;
                            for (int ScanZ = -1; ScanZ < 2; ScanZ++)
                            {
                                for (int ScanY = -1; ScanY < 2; ScanY++)
                                {
                                    for (int ScanX = -1; ScanX < 2; ScanX++)
                                    {
                                        if (x+ScanX >= 0 && x+ScanX < SimulationGrid.GetLength(0) && y + ScanY >= 0 && y + ScanY < SimulationGrid.GetLength(1) && z + ScanZ >= 0 && z + ScanZ < SimulationGrid.GetLength(2))
                                        {
                                            if (SimulationGrid[x+ScanX, y+ScanY, z+ScanZ] == "#" && !(ScanX==0 && ScanY == 0 && ScanZ == 0)) CubesActiveAround++;
                                        }

                                    }
                                }
                            }

                            if (SimulationGrid[x, y, z] == "#" && (CubesActiveAround != 2 && CubesActiveAround != 3))
                            {
                                OutputGrid[x, y, z] = ".";
                            }
                            else if (SimulationGrid[x, y, z] == "." && CubesActiveAround == 3)
                            {
                                OutputGrid[x,y,z] = "#";
                            }
                            else
                            {
                                OutputGrid[x,y,z] = SimulationGrid[x, y, z];
                            }

                        }
                    }
                }


                return OutputGrid;
                
            }
            */

            //Part 2
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            string[,,,] Input = new string[Lines[0].Length, Lines.Length, 1, 1];

            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    Input[x, y, 0, 0] = Lines[y].Substring(x, 1);
                }
            }


            string[,,,] CurrentOutput = Input;
            for (int i = 0; i < 6; i++)
            {
                CurrentOutput = Simulate(CurrentOutput);
            }

            int NumberOfActiveCubes = 0;
            for (int w = 0; w < CurrentOutput.GetLength(3); w++)
            {
                for (int z = 0; z < CurrentOutput.GetLength(2); z++)
                {
                    for (int y = 0; y < CurrentOutput.GetLength(1); y++)
                    {
                        for (int x = 0; x < CurrentOutput.GetLength(0); x++)
                        {
                            if (CurrentOutput[x, y, z, w] == "#") NumberOfActiveCubes++;
                        }
                    }
                }

            }
            Console.WriteLine(NumberOfActiveCubes);
            Console.Read();


            string[,,,] Simulate(string[,,,] InputGrid)
            {
                string[,,,] SimulationGrid = new string[InputGrid.GetLength(0) + 2, InputGrid.GetLength(1) + 2, InputGrid.GetLength(2) + 2, InputGrid.GetLength(3) + 2];
                string[,,,] OutputGrid = new string[InputGrid.GetLength(0) + 2, InputGrid.GetLength(1) + 2, InputGrid.GetLength(2) + 2, InputGrid.GetLength(3) + 2];

                for (int w = 0; w < SimulationGrid.GetLength(3); w++)
                { 
                    for (int z = 0; z < SimulationGrid.GetLength(2); z++)
                    {
                        for (int y = 0; y < SimulationGrid.GetLength(1); y++)
                        {
                            for (int x = 0; x < SimulationGrid.GetLength(0); x++)
                            {
                                if (x == 0 || x == SimulationGrid.GetLength(0) - 1 || y == 0 || y == SimulationGrid.GetLength(1) - 1 || z == 0 || z == SimulationGrid.GetLength(2) - 1 || w == 0 || w == SimulationGrid.GetLength(3) - 1)
                                {
                                    SimulationGrid[x, y, z, w] = ".";
                                }
                                else
                                {
                                    SimulationGrid[x, y, z, w] = InputGrid[x - 1, y - 1, z - 1, w - 1];
                                }
                            }
                        }
                    }
                }
                //Loop through whole sim grid
                for (int w = 0; w < SimulationGrid.GetLength(3); w++)
                {
                    for (int z = 0; z < SimulationGrid.GetLength(2); z++)
                    {
                        for (int y = 0; y < SimulationGrid.GetLength(1); y++)
                        {
                            for (int x = 0; x < SimulationGrid.GetLength(0); x++)
                            {
                                //Check cubes around

                                int CubesActiveAround = 0;
                                for (int ScanW = -1; ScanW < 2; ScanW++)
                                {
                                    for (int ScanZ = -1; ScanZ < 2; ScanZ++)
                                    {
                                        for (int ScanY = -1; ScanY < 2; ScanY++)
                                        {
                                            for (int ScanX = -1; ScanX < 2; ScanX++)
                                            {
                                                if (x + ScanX >= 0 && x + ScanX < SimulationGrid.GetLength(0) && y + ScanY >= 0 && y + ScanY < SimulationGrid.GetLength(1) && z + ScanZ >= 0 && z + ScanZ < SimulationGrid.GetLength(2) && w + ScanW >= 0 && w + ScanW < SimulationGrid.GetLength(3))
                                                {
                                                    if (SimulationGrid[x + ScanX, y + ScanY, z + ScanZ, w + ScanW] == "#" && !(ScanX == 0 && ScanY == 0 && ScanZ == 0 && ScanW == 0)) CubesActiveAround++;
                                                }

                                            }
                                        }
                                    }
                                }

                                if (SimulationGrid[x, y, z, w] == "#" && (CubesActiveAround != 2 && CubesActiveAround != 3))
                                {
                                    OutputGrid[x, y, z, w] = ".";
                                }
                                else if (SimulationGrid[x, y, z, w] == "." && CubesActiveAround == 3)
                                {
                                    OutputGrid[x, y, z, w] = "#";
                                }
                                else
                                {
                                    OutputGrid[x, y, z, w] = SimulationGrid[x, y, z, w];
                                }

                            }
                        }
                    }
                }

                return OutputGrid;

            }





        }
    }
}
