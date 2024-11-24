using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador p = new Jugador();
            Console.CursorVisible = false;
            p.position = new int[] { 0, 20 };

            while (true)
            {
                p.Move();

                Console.SetCursorPosition(p.getX(),p.getY());
                Console.Write(p.personaje);
                Console.Write(" ");
                Console.SetCursorPosition(p.getX(), p.getY());
            }
        }
    }
}
