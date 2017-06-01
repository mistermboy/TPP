using System;
using System.Diagnostics;
using System.IO;

namespace TPP.Practicas.Concurrente.Practica1 {

    class DemoProcesosHilos {

        private void MostrarProcesos(Process[] procesos, TextWriter output) {
            foreach (Process proceso in procesos) {
                output.WriteLine("- PID: {0}\tNombre: {1}\tMemoria virtual: {2:N} MB",
                        proceso.Id, proceso.ProcessName, proceso.VirtualMemorySize64 / 1024.0 / 1024
                        );
            }
        }

        private void MostrarProceso(Process proceso, TextWriter output, bool mostrarMemoria) {
            output.Write("- PID: {0}\tNombre: {1}", proceso.Id, proceso.ProcessName);
            if (mostrarMemoria)
                output.Write("\tMemoria virtual: {2:N} MB",proceso.VirtualMemorySize64 / 1024.0 / 1024);
            output.WriteLine(".");
        }

        private void MostrarHilos(ProcessThreadCollection colección, TextWriter output) {
            foreach (ProcessThread thread in colección) 
                output.WriteLine("\t- ThreadId: {0}\tPrioridad: {1}\tEstado: {2}.",
                    thread.Id, thread.CurrentPriority, thread.ThreadState);
        }

        static void Main() {
            DemoProcesosHilos demo = new DemoProcesosHilos();
            var procesos = Process.GetProcesses();
            demo.MostrarProcesos(procesos, Console.Out);
            
            Console.Write("Pulse enter para continuar... ");
            Console.ReadLine();

            foreach (var proceso in procesos) {
                demo.MostrarProceso(proceso, Console.Out, false);
                demo.MostrarHilos(proceso.Threads, Console.Out);
            }
        }

    }
}
