using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Nuevo
{
    internal class Program
    {   
        // Validado
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, grade =>
            {
                Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {grade,3}.");
                Console.ResetColor();
            });
            int res = Array.FindIndex(v, n => (n >= 5));
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");
            Console.WriteLine(Array.Exists(v, n => (n >= 5)) ? "There is at least one passing grade" : "There are no passing grades");
            int i = Array.FindLastIndex(v, n => (n >= 5));
            Console.WriteLine("Last passing grade is at index {0}", i);
            Array.ForEach(v, grade => Console.WriteLine("1/{0}", grade));
            Console.ReadKey();


        }
    }
}
