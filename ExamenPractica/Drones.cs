using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamenPractica
{
    internal class Drones
    {
        public delegate void MyDelegate();
        public object testigo = new object();
        public bool enPuerta = false;
        public bool acabado = false;
        public bool pausa = false;
        public bool[] kill = new bool[] { false, false };
        public Random rn;

        public Drones()
        {
            rn = new Random();
            Console.SetCursorPosition(30, 0);
            Console.Write("|");
            Console.SetCursorPosition(20, 0);
            Console.Write("|");
            Thread drone1 = new Thread(() => { GestionDron(1); });
            Thread drone2 = new Thread(() => { GestionDron(2); });
            Thread control = new Thread(Control);
            drone1.Start();
            drone2.Start();
            control.Start();
        }

        public void RandomInfo()
        {
            Random rn = new Random();
            Process[] procesos = Process.GetProcesses();
            int numeroAleatorio = rn.Next(procesos.Length);
            Process procesoAleatorio = procesos[numeroAleatorio];

            Console.SetCursorPosition(1, 10);
            Console.Write("{0,1000}", "");
            Console.SetCursorPosition(1, 10);

            Console.WriteLine(procesoAleatorio.ProcessName);
            int c = 0;
            using (StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("userprofile") + "\\randominfo.txt"))
            {
                sw.WriteLine(procesoAleatorio.ProcessName);
                while (c < procesoAleatorio.Modules.Count && c <= 10)
                {
                    Console.WriteLine(procesoAleatorio.Modules[c].ModuleName);
                    sw.WriteLine(procesoAleatorio.Modules[c].ModuleName);
                    c++;
                }
            }
        }

        public void ExceptionControl(MyDelegate delegado)
        {
            try
            {
                delegado();
            }
            catch (Exception e)
            {
                Console.WriteLine("Panic Error!! " + e.Message);
            }
        }

        public void GestionDron(int posicion)
        {
            bool acabado = false;
            int contador = 1;
            int espera = rn.Next(100, 200);
            while (!acabado)
            {
                lock (testigo)
                {
                    if (contador < 20 && enPuerta)
                    {
                        Console.SetCursorPosition(contador - 1, posicion);
                        Console.Write(" ");
                        Console.SetCursorPosition(contador, posicion);
                        Console.Write('*');
                        Monitor.Wait(testigo);
                    }
                    else
                    {
                        Console.SetCursorPosition(contador - 1, posicion);
                        Console.Write(" ");
                        Console.SetCursorPosition(contador, posicion);
                        Console.Write(posicion);
                    }
                    if (contador >= 20 && contador < 30)
                    {
                        enPuerta = true;
                    }
                    if (contador == 31)
                    {
                        acabado = true;
                        enPuerta = false;
                        Monitor.Pulse(testigo);
                    }
                    if (pausa)
                    {
                        Monitor.Wait(testigo);
                    }
                    if (kill[posicion - 1])
                    {
                        acabado = true;
                    }
                }
                Thread.Sleep(espera);
                contador++;
            }
        }

        public void Control()
        {
            bool exit = false;
            while (!exit)
            {
                if (Console.KeyAvailable) //if there’s a key in keyboard’s buffer
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'p': //pause drones
                            lock (testigo)
                            {
                                pausa = true;
                            }
                            break;
                        case 'c': //continue drones
                            lock (testigo)
                            {
                                pausa = false;
                                Monitor.PulseAll(testigo);
                            }
                            break;
                        case '1': //finalize drone 1
                            lock (testigo)
                            {
                                kill[0] = true;
                            }
                            break;
                        case '2': //finalize drone 2
                            lock (testigo)
                            {
                                kill[1] = true;
                            }
                            break;
                        case 'o': //control off
                            exit = true;
                            break;
                        case 'i': //system information
                            ExceptionControl(RandomInfo);
                            break;
                    }
                }
            }
        }
    }
}
