using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio7
{
    internal class Program
    {
        static object l = new object();
        static Random random = new Random();
        static int numero1;
        static int numero2;
        //static bool p1Stop = false;
        //static bool p2Stop = false;
        static bool dStop = false;
        static bool win = false;
        static int contador = 0;
        static char[] simbolos = { '|', '/', '-', '\\' };
        static void Main(string[] args)
        {
            int[] pos1 = { 0, 0 };
            int[] pos2 = { 5, 0 };
            numero1 = 0;
            numero2 = 0;
            Thread player1 = new Thread(() => { Player(ref numero1, pos1); });
            Thread player2 = new Thread(() => { Player(ref numero2, pos2); });
            Thread display = new Thread(Display);

            player1.Start();
            player2.Start();
            display.Start();


            while (!win)
            {
                lock (l)
                {
                    if (numero2 == 5 || numero2 == 7)
                    {
                        if (dStop)
                        {
                            contador -= 5;
                        }
                        else
                        {
                            contador--;
                        }
                        
                        dStop = false;
                        Monitor.Pulse(l);
                    }

                    if (numero1 == 5 || numero1 == 7)
                    {
                        if (!dStop)
                        {
                            contador++;
                        }
                        else
                        {
                            contador += 5;
                        }
                        dStop = true;
                    }

                    Console.SetCursorPosition(15, 0);
                    Console.Write("   ");
                    Console.SetCursorPosition(15, 0);
                    Console.Write(contador);

                    if (contador >= 20)
                    {
                        win = true;
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine("Ha ganado J1");
                    }
                    else if (contador <= -20)
                    {
                        win = true;
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine("Ha ganado J2");
                    }
                }
            }
            Console.ReadLine();
        }

        public static void Player(ref int numero, int[] position)
        {
            while (!win)
            {
                lock (l)
                {
                    if (!win)
                    {
                        int r = random.Next(1, 10);
                        Thread.Sleep(20 * r);
                        numero = r;
                        Console.SetCursorPosition(position[0], position[1]);
                        Console.Write(r);
                    }
                }
            }
        }

        public static void Display()
        {
            int c = 0;
            while (!win)
            {
                lock (l)
                {
                    if (!win)
                    {
                        Console.SetCursorPosition(10, 0);
                        Console.Write(simbolos[c]);
                        if (dStop)
                        {
                            Monitor.Wait(l);
                        }
                    }
                }
                Thread.Sleep(200);
                if (c >= 3)
                {
                    c = 0;
                }
                else
                {
                    c++;
                }
            }
        }
    }
}
