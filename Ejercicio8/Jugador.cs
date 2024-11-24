using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal class Jugador : Personaje
    {
        public char personaje = 'P';
        public void Move()
        {
            ConsoleKey teclaPulsada = Console.ReadKey().Key;
            if (teclaPulsada == ConsoleKey.UpArrow)
            {
                setY(getY() - 1);
            }
            if (teclaPulsada == ConsoleKey.DownArrow)
            {
                setY(getY() + 1);
            }
            if (teclaPulsada == ConsoleKey.RightArrow)
            {
                setX(getX() + 1);
            }
            if (teclaPulsada == ConsoleKey.LeftArrow)
            {
                setX(getX() - 1);
            }
        }
    }
}
