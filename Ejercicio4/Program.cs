using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{
    using System;
    using System.Threading;
    // Validado
    class Program
    {
        static int contador = 0;
        static object testigo = new Object();
        static bool win = false;
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                while (!win)
                {
                    lock (testigo)
                    {
                        if (!win)
                        {
                            contador++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(contador);
                            if (contador == 500)
                            {
                                win = true;
                            }
                        }
                    }
                }
            });
            Thread thread2 = new Thread(() =>
            {
                while (!win)
                {
                    lock (testigo)
                    {
                        if (!win)
                        {
                            contador--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(contador);
                            if (contador == -500)
                            {
                                win = true;
                            }
                        }
                    }
                }
            });
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            if (contador == 500)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ha ganado el hilo que suma");
            }
            else if (contador == -500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha ganado el hilo que resta");
            }
            Console.ReadLine();
        }
        public static void Decremento()
        {
            while (!win)
            {
                lock (testigo)
                {
                    if (win)
                    {
                        break;
                    }
                    contador++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(contador);
                    if (contador == 500)
                    {
                        win = true;
                    }
                }
            }
        }

        public static void Incremento()
        {
            while (!win)
            {
                lock (testigo)
                {
                    if (win)
                    {
                        break;
                    }
                    contador--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(contador);
                    if (contador == -500)
                    {
                        win = true;
                    }
                }
            }
        }
    }
}
