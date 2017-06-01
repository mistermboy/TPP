using System;

namespace TPP.Practicas.Concurrente.Practica1 {
    
    public class ProgramModuloVector {

        static void Main(string[] args) {
            char[] cadenaAdn = CrearVectorAleatorio(1000);

            Master master = new Master(cadenaAdn, 1);
            DateTime antes = DateTime.Now; 
            double resultado = master.CalcularModulo();
            DateTime despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con un hilo: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks );

            master = new Master(cadenaAdn, 4);
            antes = DateTime.Now;
            resultado = master.CalcularModulo();
            despues = DateTime.Now;
            Console.WriteLine("Resultado del cálculo con cuatro hilos: {0:N2}.", resultado);
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
                (despues - antes).Ticks);
        }

        public static char[] CrearVectorAleatorio(int numeroElementos) {
            char[] vector = new char[numeroElementos];
            var bases = new char[] { 'A', 'T', 'C', 'G' };
            Random random = new Random();
            for (int i = 0; i < numeroElementos; i++)
            {
                vector[i] = bases[random.Next(0, 5)];
            }
            return vector;
        }

    }

}
