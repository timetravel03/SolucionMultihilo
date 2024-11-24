using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Program
    {
        static Thread[] hilos;
        static Caballo[] caballos;
        static Random rn;
        static int contador;
        static int caballo_apuesta;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            contador = 1;
            bool win = false;
            Object testigo = new Object();
            caballos = new Caballo[] { new Caballo("John", 1), new Caballo("Arthur", 2), new Caballo("Charles", 3), new Caballo("Sadie", 4), new Caballo("Dutch", 5) };
            hilos = new Thread[caballos.Length];
            Apostar();
            Console.Clear();
            for (int i = 0; i < caballos.Length; i++)
            {
                int valor = i;
                hilos[i] = new Thread(() =>
                {
                    caballos[valor].Correr(testigo, ref win);
                });
            }
            for (int i = 0; i < hilos.Length; i++)
            {
                hilos[i].Start();
            }
            for (int i = 0; i < hilos.Length; i++)
            {
                hilos[i].Join();
            }

            int ganador = 0;
            for (int i = 0; i < caballos.Length; i++)
            {
                if (caballos[i].Tiempo.TotalSeconds < caballos[ganador].Tiempo.TotalSeconds)
                {
                    ganador = i;
                }
            }

            Console.SetCursorPosition(0, caballos.Length + 1);
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.SetCursorPosition(0, caballos.Length + 2);
            for (int i = 0; i < caballos.Length; i++)
            {
                Console.Write("{0} : {1}", caballos[i].Nombre, caballos[i].Tiempo.TotalSeconds);
                if (i == ganador)
                {
                    Console.Write(" <-- Ganador\n");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            if (caballo_apuesta == ganador)
            {
                Console.WriteLine("Has ganado");
            }
            else
            {
                Console.WriteLine("Has perdido");
            }
            Console.ReadLine();
        }

        public static void Apostar()
        {
            String opcion = "";
            bool salir = false;
            do
            {
                foreach (var caballo in caballos)
                {
                    Console.WriteLine("{0} : {1}", caballo.Posicion, caballo.Nombre);
                }
                Console.WriteLine("Elije un caballo para apostar");
                opcion = Console.ReadLine();
                if (int.TryParse(opcion, out int parsed) && parsed < caballos.Length && parsed >= 0) // TODO acabar este if
                {
                    caballo_apuesta = parsed;
                    salir = true;
                }
                else
                {
                    Console.WriteLine("Parámetro no válido");
                }
            }
            while (!salir);
        }

    }
}
