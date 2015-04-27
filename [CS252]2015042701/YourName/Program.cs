using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入您的姓名:");
            string Name = Console.ReadLine();
            Console.Write("請輸入您的性別:(Ex:Boy or Girl)");
            string Sex = Console.ReadLine();

            Console.WriteLine("{0}您好!!", Name);
            Console.WriteLine("我猜{0}您一定是{1}", Name, Sex);

            Console.ReadKey();
        }
    }
}
