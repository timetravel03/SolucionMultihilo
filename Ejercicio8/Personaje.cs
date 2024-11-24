using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal abstract class Personaje
    {
        private int[] position;

        
        public bool Alive { get; set; }

        public Personaje()
        {
            Alive = true;
            position = new int[] { 0, 0 };
        }

        public int getX()
        {
            return position[0];
        }

        public int getY()
        {
            return position[1];
        }

        public void setX(int x)
        {
            if (x < 0)
            {
                position[0] = 0;
            }
            else
            {
                position[0] = x;
            }
        }

        public void setY(int y)
        {
            if (y < 0)
            {
                position[1] = 0;
            }
            else
            {
                position[1] = y;
            }
        }
    }
}
