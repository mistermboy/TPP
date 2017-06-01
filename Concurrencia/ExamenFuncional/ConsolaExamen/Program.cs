using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolaExamen
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ejercicio 1

            Console.WriteLine("### EJERCICIO 1 ###");

            int[] enteros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8,7};

            Master master = new Master(enteros, 2);
            List<int> resultado = master.CalcularModulo();

            foreach (var y in resultado)
            {
                Console.Write(y);
            }

            Console.WriteLine();

            //Ejercicio2

            Console.WriteLine("### EJERCICIO 2 ###");
            char[] secuenciaAdn = new char[] { 'G', 'T', 'A', 'G', 'C', 'A' };

            foreach(var x in secuenciaAdn)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            char[] secuenciaComplementaria = Complementar(secuenciaAdn);

            foreach (var x in secuenciaComplementaria)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            //Ejercicio 3

            Console.WriteLine("### EJERCICIO 3 ###");

            double[] vector1 = new double[] { 1.0, 3.0, 5.0};
            double[] vector2 = new double[] { 2.0, 4.0, 6.0 };

            Console.WriteLine(ProductoEscalar(vector1, vector2));

            Console.WriteLine();


            //Ejercicio 4

            Console.WriteLine("### EJERCICIO 4 ###");
            var secuenciaAdn1 = new char[] { 'G', 'T', 'A', 'A', 'C', 'A' };

            var secuenciaAdn2 = CrearVectorAleatorioADN(1000);

            Console.WriteLine(BaseMasRepetida(secuenciaAdn1));

            Console.WriteLine();

            Console.WriteLine(BaseMasRepetida(secuenciaAdn1));
        }


        //Ejercicio 2

        public static char[] Complementar(char[] cadena)
        {

            char[] cadenaComplementaria = new char[cadena.Length];
            Parallel.Invoke(

                () =>
                {
                    for (int i = 0; i < cadena.Length; i += 2)
                    {
                        char baseNitrogenada = cadena[i];
                        if (baseNitrogenada == 'A')
                        {
                            cadenaComplementaria[i] = 'T';
                        }
                        if (baseNitrogenada == 'C')
                        {
                            cadenaComplementaria[i] = 'G';
                        }
                        if (baseNitrogenada == 'G')
                        {
                            cadenaComplementaria[i] = 'C';
                        }
                        if (baseNitrogenada == 'T')
                        {
                            cadenaComplementaria[i] = 'A';
                        }
                    }
                },
                 () =>
                 {
                     for (int i = 1; i < cadena.Length; i += 2)
                     {
                         char baseNitrogenada = cadena[i];
                         if (baseNitrogenada == 'A')
                         {
                             cadenaComplementaria[i] = 'T';
                         }
                         if (baseNitrogenada == 'C')
                         {
                             cadenaComplementaria[i] = 'G';
                         }
                         if (baseNitrogenada == 'G')
                         {
                             cadenaComplementaria[i] = 'C';
                         }
                         if (baseNitrogenada == 'T')
                         {
                             cadenaComplementaria[i] = 'A';
                         }
                     }
                 });
            return cadenaComplementaria;
        }

        //Ejercicio 3

        public static double ProductoEscalar(double[] vector1, double[] vector2)
        {
            double[] acumulator = new double[vector1.Length];
            Parallel.For(0, vector1.Length, (i) =>
               {
                   acumulator[i] = vector1[i] * vector2[i];
               });

            //Agregate aunque se te olvidó ponerlo ;)
            return acumulator.AsParallel().Aggregate((acc,x) => acc + x);
        }



        //Ejercicio 4

        static char BaseMasRepetida(char[] baseNitrogenada)
        {
            IDictionary<char, int> d = new Dictionary<char, int>();
            int contador = 0;
            Parallel.ForEach(baseNitrogenada, (x) =>
            {
                    if (d.Keys.Contains(baseNitrogenada[contador]))
                    {
                        d[baseNitrogenada[contador]]++;
                    }
                    else
                    {
                        d.Add(baseNitrogenada[contador], 1);
                    }

                    contador++;                     
            }
            );

            foreach (var x in d)
            {
                Console.WriteLine(x.Key + "  " + x.Value);
            }

            var MaxApariciones = d.Max((x) => x.Value);
            var maxima = d.Where((x) => x.Value.Equals(MaxApariciones)).Select((y) => y.Key).ToArray();
            return maxima[0];
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
