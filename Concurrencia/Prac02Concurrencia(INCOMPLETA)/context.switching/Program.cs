using System;
using System.IO;

namespace TPP.Practicas.Concurrente.Practica1 {

    class Program {

        static void Main(string[] args) {
            const int numeroMaximoHilos = 50;
            short[] vector = ProgramModuloVector.CrearVectorAleatorio(100000, -10, 10);
            MostrarLinea(Console.Out, "Numero de Hilos", "Ticks", "Resultado");
            for (int numeroHilos = 1; numeroHilos <= numeroMaximoHilos; numeroHilos++) {
                Master master = new Master(vector, numeroHilos);
                DateTime antes = DateTime.Now;
                double resultado = master.CalcularModulo();
                DateTime despues = DateTime.Now;
                MostrarLinea(Console.Out, numeroHilos, (despues - antes).Ticks, resultado);
                GC.Collect(); // Lanzamos el recolector
                GC.WaitForFullGCComplete();
            }
        }

        private const string SEPARADOR_CSV = ";";

        static void MostrarLinea(TextWriter flujo, string tituloNumeroHilos, string tituloTicks, string tituloResultado) {
            flujo.WriteLine("{0}{3}{1}{3}{2}{3}", tituloNumeroHilos, tituloTicks, tituloResultado, SEPARADOR_CSV);
        }

        static void MostrarLinea(TextWriter flujo, int numeroHilos, long ticks, double resultado) {
            flujo.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numeroHilos, ticks, resultado, SEPARADOR_CSV);
        }
    }

}
