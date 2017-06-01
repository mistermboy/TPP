using System;
using System.Threading;
using System.Text;

namespace TPP.Practicas.Concurrente.Practica1 {

    internal class Hilo {

        private static uint numeroHilos = 0;

        internal uint NumeroHilo { get; private set; }

        internal Hilo() {
            this.NumeroHilo = ++numeroHilos;
        }

        private Random random = new Random(DateTime.Now.Millisecond);

        private static string MultiplicaCadena(string cadena, uint numero) {
            StringBuilder sb = new StringBuilder();
            for (uint i = 0; i < numero; i++)
                sb.Append(cadena);
            return sb.ToString();
        }

        internal void EjecuciónHilo() {
            while (true) {
                Thread.Sleep(this.random.Next(500, 2000));
                Console.WriteLine("{0}Hilo {1}, ThreadID {2}.", 
                    MultiplicaCadena("-", this.NumeroHilo),
                    this.NumeroHilo,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }


    }
}
