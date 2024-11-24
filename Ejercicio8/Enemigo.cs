using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal class Enemigo : Personaje
    {
        char enemigo = 'E';
        int[] posPer = new int[] { 0, 30 };

        public void Move()
        {
            if (getX() > posPer[0])
            {
                setX(getX()-1);
            }
        }

        public void Updater(int[] pos)
        {
            posPer = pos;
        }

    }
}
