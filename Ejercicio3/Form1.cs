using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            Process[] processArray = Process.GetProcesses();
            String cabecera = String.Format("{0,-10}{1,-25}{2,-25}\r\n", "PID", "Nombre", "Título");
            Array.ForEach(processArray, (prc) =>
            {
                int processId = prc.Id;
                String processName = prc.ProcessName;
                String windowTitle = prc.MainWindowTitle;
                if (processName.Length > 15)
                {
                    processName = processName.Substring(0, 15) + "...";
                }
                if (windowTitle.Length > 15)
                {
                    windowTitle = windowTitle.Substring(0, 15) + "...";
                }
                cabecera += String.Format("{0,-10}{1,-25}{2,-25}\r\n", processId, processName, windowTitle);
            });


            textProcesses.Text = cabecera;
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            String cabecera = "";
            if (int.TryParse(textBox2.Text.Trim(), out int id))
            {
                try
                {
                    Process prc = Process.GetProcessById(id);

                    int processId = prc.Id;
                    String processName = prc.ProcessName;
                    String windowTitle = prc.MainWindowTitle;
                    ProcessThreadCollection threads = prc.Threads;
                    DateTime horaInicio = prc.StartTime;
                    ProcessModuleCollection modules = prc.Modules;

                    String pid = String.Format("PID:\r\n{0}\r\n\r\n", processId);
                    String nombre = String.Format("Nombre:\r\n{0}\r\n\r\n", processName);
                    String titulo = String.Format("Título de ventana:\r\n{0}\r\n\r\n", windowTitle);
                    String hora = String.Format("Hora de inicio:\r\n{0}\r\n\r\n", horaInicio.ToString());

                    String subprocesos = String.Format("Subprocesos:\r\n");
                    foreach (ProcessThread pt in threads)
                    {
                        subprocesos += String.Format("ID: {0,5} StartTime:{1, 15}\r\n", pt.Id, pt.StartTime);
                    }

                    String modulos = String.Format("Modulos:\r\n");
                    foreach (ProcessModule module in modules)
                    {
                        modulos += String.Format("Nombre: {0}\r\nArchivo: {1}\r\n\r\n", module.ModuleName, module.FileName);
                    }

                    cabecera += pid + nombre + titulo + hora + subprocesos + "\r\n" + modulos;
                    textProcesses.Text = cabecera;
                }
                catch (Exception)
                {
                    textProcesses.Text = "Error: El proceso no existe o no tienes permisos suficientes";
                }
            }
            else
            {
                textProcesses.Text = "Error: PID inválido";
            }


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text.Trim(), out int pid))
            {
                try
                {
                    Process prc = Process.GetProcessById(pid);
                    String nombre = prc.ProcessName;
                    if (prc.CloseMainWindow())
                    {
                        textProcesses.Text = String.Format("El proceso {0} ({1}) se ha cerrado correctamente", pid, nombre);
                    }
                    else
                    {
                        textProcesses.Text = String.Format("El proceso {0} ({1}) no se ha podido cerrar", pid, nombre);
                    }
                }
                catch (Exception)
                {
                    textProcesses.Text = "Error: El proceso no existe o no tienes permisos suficientes";
                }
            }
            else
            {
                textProcesses.Text = "Error: PID inválido";
            }
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text.Trim(), out int pid))
            {
                try
                {
                    Process prc = Process.GetProcessById(pid);
                    String nombre = prc.ProcessName;
                    prc.Kill();
                    textProcesses.Text = String.Format("El proceso {0} ({1}) ha terminado", pid, nombre);
                }
                catch (Exception)
                {
                    textProcesses.Text = "Error: El proceso no existe o no tienes permisos suficientes";
                }
            }
            else
            {
                textProcesses.Text = "Error: PID inválido";
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process newProcess = Process.Start(textBox2.Text);
                if (newProcess != null)
                {
                    textProcesses.Text = String.Format("Se ha iniciado {0} con PID {1}", newProcess.ProcessName, newProcess.Id);
                }
                else
                {
                    textProcesses.Text = String.Format("No se ha iniciado ningún proceso");
                }
            }
            catch (Exception)
            {
                textProcesses.Text = String.Format("No se ha podido inciar el proceso");
            }

        }

        private void startsButton_Click(object sender, EventArgs e)
        {
            Process[] processArray = Process.GetProcesses();
            String argumento = textBox2.Text.Trim();
            int longitud = argumento.Length;
            if (longitud > 0)
            {
                String cabecera = String.Format("{0,-10}{1,-25}{2,-25}\r\n", "PID", "Nombre", "Título");
                int longitud_cabecera = cabecera.Length;
                Array.ForEach(processArray, process =>
                {
                    if (process.ProcessName.Length >= longitud && process.ProcessName.Substring(0, longitud).Equals(argumento))
                    {
                        cabecera += String.Format("{0,-10}{1,-25}{2,-25}\r\n", process.Id, process.ProcessName, process.MainWindowTitle);
                    }
                });
                if (cabecera.Length == longitud_cabecera)
                {
                    textProcesses.Text = "No hay ningún proceso";
                }
                else
                {
                    textProcesses.Text = cabecera;
                }
            }
            else
            {
                textProcesses.Text = "Argumento vacío";
            }
        }
    }
}
