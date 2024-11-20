using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio6
{
    internal class MyTimer
    {
        public int Interval { get; set; }
        public delegate void Funcion();
        Thread thread;

        public MyTimer(Funcion fn)
        {
            thread = new Thread(fn.Invoke);
            thread.Start();
        }

        public void Run()
        {
           
        }
    }
}
