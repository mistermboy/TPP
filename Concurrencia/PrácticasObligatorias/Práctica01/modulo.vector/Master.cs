using System;
using System.Threading;

namespace TPP.Practicas.Concurrente.Practica1 {

    public class Master {

        private char[] cadenaAdn;
        private char[] gen;

        private int numeroHilos;

        public Master(char[] cadenaAdn, char[] gen,int numeroHilos) {
            if (numeroHilos < 1 || numeroHilos > cadenaAdn.Length)
                throw new ArgumentException("El número de hilos ha de ser menor o igual que los elementos del vector.");
            this.cadenaAdn = cadenaAdn;
            this.gen = gen;
            this.numeroHilos = numeroHilos;
        }

        public double CalcularModulo() {
            Worker[] workers = new Worker[this.numeroHilos];
            int elementosPorHilo = this.cadenaAdn.Length/numeroHilos;
            for(int i=0; i < this.numeroHilos; i++)
                workers[i] = new Worker(this.cadenaAdn,gen,
                    i*elementosPorHilo, 
                    (i<this.numeroHilos-1) ? (i+1)*elementosPorHilo: this.cadenaAdn.Length-1 // último
                    , cadenaAdn.Length-1);

            Thread[] hilos = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                hilos[i] = new Thread(workers[i].CalcularNUmerodDeApariciones); 
                hilos[i].Name = "Worker Vector Módulo " + (i+1); 
                hilos[i].Priority = ThreadPriority.BelowNormal; 
                hilos[i].Start();  
            }

            foreach (var x in hilos)
            {
                x.Join();
            }

            long resultado = 0;
            foreach (Worker worker in workers)
                resultado += worker.Resultado;
            return resultado;
        }

    }

}
