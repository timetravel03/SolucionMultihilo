﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    internal class Program
    {
        static int counter = 0;
        static void increment()
        {
            counter++;
            Console.WriteLine(counter);
        }
        static void Main(string[] args)
        {
            MyTimer t = new MyTimer(increment);
            t.Interval = 1000;
            string op = "";
            do
            {
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();
                t.Run();
                Console.WriteLine("Press any key to pause.");
                Console.ReadKey();
                t.Pause();
                Console.WriteLine("Press 1 to contiue or Enter to end.");
                op = Console.ReadLine();
            } while (op == "1");
        }
    }
}
