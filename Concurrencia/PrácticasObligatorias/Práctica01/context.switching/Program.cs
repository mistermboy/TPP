using System;
using System.IO;

namespace TPP.Practicas.Concurrente.Practica1 {

    class Program
    {

        static void Main(string[] args)
        {
            const int maxNumberOfThreads = 50;
            char[] cadenaAdn = CrearVectorAleatorioADN(1000000);
            char[] gen = new char[] { 'G', 'T', 'A' };

            MostrarLinea(Console.Out, "Numer of Threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++)
            {
                Master master = new Master(cadenaAdn, gen, numberOfThreads);
                DateTime before = DateTime.Now;
                double result = master.CalcularModulo();
                DateTime after = DateTime.Now;
                MostrarLinea(Console.Out, numberOfThreads, (after - before).Ticks, result);
                GC.Collect(); // The garbage collector is run
                GC.WaitForFullGCComplete();
            }
        }

        private const string SEPARADOR_CSV = ";";

        static void MostrarLinea(TextWriter flujo, string tituloNumeroHilos, string tituloTicks, string tituloResultado)
        {
            flujo.WriteLine("{0}{3}{1}{3}{2}{3}", tituloNumeroHilos, tituloTicks, tituloResultado, SEPARADOR_CSV);
        }

        static void MostrarLinea(TextWriter flujo, int numeroHilos, long ticks, double resultado)
        {
            flujo.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numeroHilos, ticks, resultado, SEPARADOR_CSV);
        }

        public static char[] CrearVectorAleatorioADN(int numeroElementos)
        {
            char[] vector = new char[numeroElementos];
            var bases = new char[] { 'A', 'T', 'C', 'G' };
            Random random = new Random();
            for (int i = 0; i < numeroElementos; i++)
            {
                vector[i] = bases[random.Next(0, 4)];
            }
            return vector;
        }
    }
}
