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
        private bool estaActivo;
        private bool estaPausado;
        private Funcion fun;
        private Thread hiloEjecucion;
        private Object testigo;

        public MyTimer(Funcion funcion)
        {
            testigo = new object();
            fun = funcion;
            hiloEjecucion = new Thread(BucleTrabajo);
            estaActivo = false;
            estaPausado = false;
        }

        public void BucleTrabajo()
        {
            while (estaActivo)
            {
                lock (testigo)
                {
                    if (estaPausado)
                    {
                        Monitor.Wait(testigo);
                    }
                    else
                    {
                        fun();
                    }
                }
                Thread.Sleep(Interval);
            }
        }

        public void Run()
        {
            lock (testigo)
            {
                if (!estaActivo && !estaPausado)
                {
                    hiloEjecucion.Start();
                    estaActivo = true;
                }
                else
                {
                    Monitor.Pulse(testigo);
                }
                estaPausado = false;
            }
        }

        public void Pause()
        {
            lock (testigo)
            {
                estaPausado = true;
            }
        }
    }
}
