using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace TPP.Practicas.Concurrente.Practica3 {

    /// <summary>
    /// Ejemplo de programa secuencial que procesa un fichero con varias tareas en paralelo.
    /// Se paralelizará con TPL para ver la mejora en los tiempos de ejecución.
    /// </summary>
    class Program {


        static void Main(string[] args) {
            String texto = Procesamiento.LeerFicheroTexto(@"..\..\..\clarin.txt");
            string[] palabras = Procesamiento.PartirEnPalabras(texto);

            Stopwatch crono = new Stopwatch();
            crono.Start();
            int signosDePuntuacion = Procesamiento.SignosPuntuación(texto);
            var palabrasMasLargas = Procesamiento.PalabrasMasLargas(palabras);
            var palabrasMasCortas = Procesamiento.PalabrasMasCortas(palabras);
            int numeroMayorAparciones, numeroMenorApariciones;
            var palabrasConMasApariciones = Procesamiento.PalabrasConMasApariciones(palabras, out numeroMayorAparciones);
            var palabrasConMenosApariciones = Procesamiento.PalabrasConMenosApariciones(palabras, out numeroMenorApariciones);
            crono.Stop();

            MostrarResultados(signosDePuntuacion, palabrasMasCortas, palabrasMasLargas, palabrasConMenosApariciones, numeroMenorApariciones,
                palabrasConMasApariciones, numeroMayorAparciones);


            //EJERCICIO PROPUESTO

            //Podemos observar que los mejores resultados se obtienen utilizandon  PLINQ

            Console.WriteLine("\nProcesamiento ejecutado en {0:N} milisegundos.", crono.ElapsedMilliseconds);


            Console.WriteLine("\n APARICIONES POR PALABRA \n");


            Console.WriteLine("SECUENCIAL");
            DateTime antes = DateTime.Now;
            var aparicionesSecuencial = Procesamiento.AparicionesSecuencial(palabras);
            DateTime despues = DateTime.Now;
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
               (despues - antes).Ticks);

            Console.WriteLine();

            Console.WriteLine("TPL");
            antes = DateTime.Now;
            var aparicionesTPL = Procesamiento.AparicionesTPL(palabras);
            despues = DateTime.Now;
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
               (despues - antes).Ticks);

            Console.WriteLine();

            Console.WriteLine("PLINQ");
            antes = DateTime.Now;
            var aparicionesPlinq = Procesamiento.AparicionesPlinq(palabras);
            despues = DateTime.Now;
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
               (despues - antes).Ticks);


        }


        public static void MostrarResultados(int signosDePuntuación, string[] palabrasMasCortas, string[] palabrasMasLargas, string[] palabrasConMenosApariciones,
                                              int numeroMenorApariciones, string[] palabrasConMasApariciones, int numeroMayorApariciones) {
            const int numeroMaximoElementosAMostrar = 20;

            Console.WriteLine("> Aparecieron {0} signos de puntuación. ", signosDePuntuación);

            Console.Write("> {0} palabras más cortas: ", palabrasMasCortas.Count());
            Mostrar(palabrasMasCortas, Console.Out, numeroMaximoElementosAMostrar);
            Console.WriteLine();

            Console.Write("> {0} palabras más largas: ", palabrasMasLargas.Count());
            Mostrar(palabrasMasLargas, Console.Out, numeroMaximoElementosAMostrar);
            Console.WriteLine();

            Console.Write("> {0} palabras con un menor número de apariciones ({1}): ", palabrasConMenosApariciones.Count(), numeroMenorApariciones);
            Mostrar(palabrasConMenosApariciones, Console.Out, numeroMaximoElementosAMostrar);
            Console.WriteLine();

            Console.Write("> {0} palabras con un mayor número de apariciones ({1}): ", palabrasConMasApariciones.Count(), numeroMayorApariciones);
            Mostrar(palabrasConMasApariciones, Console.Out, numeroMaximoElementosAMostrar);
            Console.WriteLine();
        }

        private static void Mostrar<T>(IEnumerable<T> elementos, TextWriter flujo, int numeroMáximoElementos) {
            int i = 0;
            foreach (T elemento in elementos) {
                flujo.Write(elemento);
                i = i + 1;
                if (i == numeroMáximoElementos) {
                    flujo.Write("...");
                    break;
                }
                if (i < elementos.Count())
                    flujo.Write(", ");
            }
        }




    }

}
