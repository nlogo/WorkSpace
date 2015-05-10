using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerGuessing
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random random = new Random();

                Console.Clear();
                Console.Write("選擇您要出的拳 1(剪刀) 2(石頭) 3(布) :");
                string MyChoice = Console.ReadLine();

                int PcChoice = random.Next(1, 3);

                Console.WriteLine("你選擇{0}，電腦選擇{1}，餘數為{2}", MyChoice, PcChoice.ToString(), PcChoice - int.Parse(MyChoice));

                if (PcChoice == int.Parse(MyChoice))
                {
                    Console.WriteLine("平手");
                }
                else if ((PcChoice - int.Parse(MyChoice)) >= -1 && (PcChoice - int.Parse(MyChoice)) != 1)
                {
                    Console.WriteLine("你贏了");
                }
                else
                {
                    Console.WriteLine("你輸了");
                }

                Console.Write("還要再玩一次?(Y/N):");
            }while(Console.ReadKey().Key == ConsoleKey.Y);

        }
    }
}
