using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaMultihilo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(charA);
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            //char B
            int i = 1;
            while (i < 1000)
            {
                Console.Write('B');
                i++;
            }
            Console.ReadKey();
        }
        static void charA()
        {
            int i = 1;
            while (i < 1000)
            {
                Console.Write('A');
                i++;
            }
        }
    }
}
