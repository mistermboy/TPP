using System;
using System.IO;

namespace TPP.Practicas.Concurrente.Practica1 {

    public class ProgramModuloVector
    {

        static void Main(string[] args)
        {
            char[] cadenaAdn = CrearVectorAleatorioADN(1000000);


            char[] gen = new char[] { 'G', 'T', 'A' };


            // 1 HILO
            Master master = new Master(cadenaAdn, gen, 1);
            DateTime antes = DateTime.Now;
            double resultado = master.CalcularModulo();
            DateTime despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con un hilo: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks);

            Console.WriteLine();
            Console.WriteLine();

            // 4 HILOS
            master = new Master(cadenaAdn, gen, 4);
            antes = DateTime.Now;
            resultado = master.CalcularModulo();
            despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con 4 hilos: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks);

            Console.WriteLine();
            Console.WriteLine();

            // 10 HILOS
            master = new Master(cadenaAdn, gen, 10);
            antes = DateTime.Now;
            resultado = master.CalcularModulo();
            despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con 10 hilos: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks);


            Console.WriteLine();
            Console.WriteLine();

            //50 HILOS
            master = new Master(cadenaAdn, gen, 50);
            antes = DateTime.Now;
            resultado = master.CalcularModulo();
            despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con 50 hilos: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks);

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
