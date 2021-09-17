using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Data = System.IO.File.ReadAllLines("Data.txt");
                       
            Queue<int> Player1 = new Queue<int>();
            Queue<int> Player2 = new Queue<int>();

            bool AddToPlayer1 = true;
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == "")
                {
                    AddToPlayer1 = false;
                }
                else
                {
                    if (AddToPlayer1)
                    {
                        Player1.Enqueue(Convert.ToInt32(Data[i]));
                    }
                    else
                    {
                        Player2.Enqueue(Convert.ToInt32(Data[i]));
                    }
                }
            }

            bool GameWon = false;
            while (!GameWon)
            {
                int Player1Card = Player1.Dequeue();
                int Player2Card = Player2.Dequeue();

                if (Player1Card > Player2Card)
                {
                    Player1.Enqueue(Player1Card);
                    Player1.Enqueue(Player2Card);
                }
                else
                {
                    Player2.Enqueue(Player2Card);
                    Player2.Enqueue(Player1Card);
                }

                if (Player1.Count == 0 || Player2.Count == 0)
                {
                    GameWon = true;
                }
            }

            int Total = 0;

            if (Player1.Count > 0)
            {
                for (int i = Player1.Count; i > 0; i--)
                {
                    Total += Player1.Dequeue() * i;
                }
            }
            else
            {
                for (int i = Player2.Count; i > 0; i--)
                {
                    Total += Player2.Dequeue() * i;
                }
            }

            Console.WriteLine(Total);
            Console.ReadKey();

        }
    }
}
