using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            List<int> Adapters = new List<int>();

            for (int i = 0; i< Lines.Length; i++)
            {
                Adapters.Add(Convert.ToInt32(Lines[i]));
            }
            Adapters.Add(0);
            Adapters.Sort();
            Adapters.Add(Adapters[Adapters.Count-1]+3);

            int DiffOf1 = 0;
            int DiffOf3 = 0;

            for (int i = 0; i< Adapters.Count-1; i++)
            {
                if (Adapters[i+1] - Adapters[i] == 1) DiffOf1++;
                if (Adapters[i+1] - Adapters[i] == 3) DiffOf3++;
            }

            Console.WriteLine(DiffOf1*DiffOf3);
            Console.ReadKey();


        }
    }
}
