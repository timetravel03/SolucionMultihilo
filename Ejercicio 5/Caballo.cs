using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Caballo
    {
        private String nombre;
        private int posicion;
        private TimeSpan tiempo;

        public Caballo(string nombre, int posicion)
        {
            this.nombre = nombre;
            this.posicion = posicion;
        }

        public String Nombre
        {
            get { return nombre; }
        }

        public int Posicion
        {
            get { return posicion; }
        }

        public TimeSpan Tiempo
        {
            get { return tiempo; }
        }

        public void Correr(Object testigo, ref bool win)
        {
            //Console.SetCursorPosition(0, posicion);
            string[] anims = { "\"\u00a1==\u00a17·", "\"_==_7·" };
            int i = 0;
            Random rn = new Random();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!win)
            {
                int tiempo_de_sleep = rn.Next(100);
                lock (testigo)
                {
                    if (!win)
                    {
                        Console.SetCursorPosition(0, posicion);
                        Console.Write(nombre);

                        Console.SetCursorPosition(i, posicion);

                        // Borrado del frame anterior
                        for (int j = 1; j <= 6; j++)
                        {
                            Console.SetCursorPosition(i, posicion);
                            Console.Write(new string(' ', 6));
                        }

                        if (i % 2 == 0)
                        {
                            Console.Write(anims[0]);
                            Thread.Sleep(15);
                        }
                        else
                        {
                            Console.Write(anims[1]);
                            Thread.Sleep(15);
                        }
                        if (i == 49)
                        {
                            Console.Write("Finish");
                            win = true;
                            stopwatch.Stop();
                        }
                    }
                }
                i++;
                Thread.Sleep(tiempo_de_sleep);
            }
            tiempo = stopwatch.Elapsed;
        }
    }
}
