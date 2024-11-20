using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

    internal class Program
    {
        // Validado
        public delegate void MyDelegate();
        static bool MenuGenerator(String[] v, MyDelegate[] myDelegates)//Index en 1 para usu. Comprobaciones null. op salir. Rango (frontera)
        {
            String option = "";
            bool valido = true;
            if (myDelegates != null && v != null && v.Length != 0 && myDelegates.Length != 0 && v.Length == myDelegates.Length)
            {
                for (int i = 0; i < v.Length; i++)
                {
                    if (v[i] == null)
                    {
                        valido = false;
                    }
                }
                for (int i = 0; i < myDelegates.Length; i++)
                {
                    if (myDelegates[i] == null)
                    {
                        valido = false;
                    }
                }
            }
            else
            {
                valido = false;
            }

            if (valido)
            {
                do
                {
                    for (int i = 0; i < v.Length; i++)
                    {
                        Console.WriteLine("{0}-{1}", i + 1, v[i]);
                    }
                    Console.WriteLine(v.Length + 1 + "-Salir");
                    Console.WriteLine("Select an option:");

                    option = Console.ReadLine();
                    if (int.TryParse(option, out int j) && (j <= v.Length) && (j > 0))
                    {
                        myDelegates[j - 1]();
                    }
                    else if (j == v.Length + 1)
                    {
                        Console.WriteLine("Saliendo...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }
                }
                while (!option.Equals((v.Length + 1) + ""));
            }

            return valido;

        }
        static void Main(string[] args)
        {
            bool valido;
            valido = MenuGenerator(new string[] { "Op1", "Op2", "Op3", "op4" }, new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"), () => Console.WriteLine("D") });
            if (!valido)
            {
                Console.WriteLine("Error en la creacion de menu");
                Console.ReadLine();
            }

        }
    }

}

