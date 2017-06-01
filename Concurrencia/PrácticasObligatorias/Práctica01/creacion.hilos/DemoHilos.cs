using System;
using System.Threading;
using System.Text;

namespace TPP.Practicas.Concurrente.Practica1 {

    class DemoHilo {

        static void Main(string[] args) {
            if (args.Length > 0) {
                int numeroHilos = Convert.ToInt32(args[0]);
                Hilo[] objeto = new Hilo[numeroHilos];
                for (int i = 0; i < numeroHilos; i++) 
                    new Thread(new Hilo().EjecuciónHilo).Start();
            }
            new Hilo().EjecuciónHilo();
        }

    }
}
