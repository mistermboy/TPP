using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolaExamen
{
    public class Master
    {

        private int[] cadenaPrimos;

        private int numeroHilos;

        public Master(int[] cadenaPrimos, int numeroHilos)
        {
            if (numeroHilos < 1 || numeroHilos > cadenaPrimos.Length)
                throw new ArgumentException("El número de hilos ha de ser menor o igual que los elementos del vector.");
            this.cadenaPrimos = cadenaPrimos;
            this.numeroHilos = numeroHilos;
        }

        public List<int> CalcularModulo()
        {
            Worker[] workers = new Worker[this.numeroHilos];
            int elementosPorHilo = this.cadenaPrimos.Length / numeroHilos;
            for (int i = 0; i < this.numeroHilos; i++)
                workers[i] = new Worker(this.cadenaPrimos,
                    i * elementosPorHilo,
                    (i < this.numeroHilos - 1) ? (i + 1) * elementosPorHilo : this.cadenaPrimos.Length - 1);// último

            Thread[] hilos = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                hilos[i] = new Thread(workers[i].CalcularPrimos);
                hilos[i].Name = "Worker Vector Módulo " + (i + 1);
                hilos[i].Priority = ThreadPriority.BelowNormal;
                hilos[i].Start();
            }

            foreach (var x in hilos)
            {
                x.Join();
            }

            List<int> resultado = new List<int>();
            foreach (Worker worker in workers)
            {
                for (int i = 0; i < worker.Resultado.Length; i++)
                {
                    if (worker.Resultado[i] != 0)
                    {
                        if(!Contains(worker.Resultado[i],resultado))
                          resultado.Add(worker.Resultado[i]);
                    }
                    
                 }
            }
            return resultado;
        }

        private bool Contains(int num,List<int> lista)
        {
            foreach(var x in lista)
            {
                if (x == num)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
