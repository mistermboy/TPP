using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class Master
    {
        private int[] vector;

        private int numeroDeHilos;

        public Master(int[] vector, int numeroDeHilos)
        {
            if (numeroDeHilos < 1 || numeroDeHilos > vector.Length)
                throw new ArgumentException("El número de hilos debe ser menor o igual al número de elementos del vector");
            this.vector = vector;
            this.numeroDeHilos = numeroDeHilos;
        }

        public double NumVecesConsecutivas()
        {
            Worker[] workers = new Worker[this.numeroDeHilos];
            int elementos = this.vector.Length / numeroDeHilos;
            for (int i = 0; i < this.numeroDeHilos; i++)
                workers[i] = new Worker(this.vector,
                    i * elementos,
                    (i < this.numeroDeHilos - 1) ? (i + 1) * elementos - 1 : this.vector.Length - 1 // last one
                    );

            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                threads[i] = new Thread(workers[i].NumVeces);
                threads[i].Name = "Vector modulus worker " + (i + 1);
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();
            }

            foreach (Thread thread in threads)
                thread.Join();

            long result = 0;
            foreach (Worker worker in workers)
                result += worker.Result;
            return result;
        }
    }
}
