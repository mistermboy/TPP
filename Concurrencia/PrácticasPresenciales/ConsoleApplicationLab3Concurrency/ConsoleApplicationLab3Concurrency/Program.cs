using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplicationLab3Concurrency
{
    class Program
    {
        static IDictionary<int, int> histogramaFor(int[] datos)
        {
            IList<int> threadIds = new List<int>();
            IDictionary<int, int> d = new Dictionary<int, int>();
            Parallel.For(0, datos.Length, (i) =>
            {

                if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    Console.WriteLine("Thread ID = " +
                    Thread.CurrentThread.ManagedThreadId);
                    threadIds.Add(Thread.CurrentThread.ManagedThreadId);
                }
                lock (d)
                    if (d.Keys.Contains(datos[i]))
                    {
                        d[datos[i]]++;
                    }
                    else
                    {
                        d.Add(datos[i], 1);
                    }
            }
            );
            return d;
        }


        static IDictionary<int, int> histogramaForEach(int[] datos)
        {
            IList<int> threadIds = new List<int>();
            IDictionary<int, int> d = new Dictionary<int, int>();
            Parallel.ForEach(datos, (x) =>
            {

                if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    Console.WriteLine("Thread ID = " +
                    Thread.CurrentThread.ManagedThreadId);
                    threadIds.Add(Thread.CurrentThread.ManagedThreadId);
                }
                lock (d)
                    if (d.Keys.Contains(datos[x]))
                    {
                        d[datos[x]]++;
                    }
                    else
                    {
                        d.Add(datos[x], 1);
                    }
            }
            );
            return d;
        }

        static IDictionary<int, int> histogramaAlternativo(int[] datos)
        {
            IDictionary<int, int> d1 = new Dictionary<int, int>();
            IDictionary<int, int> d2 = new Dictionary<int, int>();
            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < datos.Length; i += 2)
                    {
                        if (d1.Keys.Contains(datos[i]))
                        {
                            d1[datos[i]]++;
                        }
                        else
                        {
                            d1.Add(datos[i], 1);
                        }
                    }
                },
                () =>
                {
                    for (int i = 1; i < datos.Length; i += 2)
                    {
                        if (d2.Keys.Contains(datos[i]))
                        {
                            d2[datos[i]]++;
                        }
                        else
                        {
                            d2.Add(datos[i], 1);
                        }
                    }
                }
                );

            IDictionary<int, int> d = new Dictionary<int, int>();
            foreach (var x in d1.Keys)
            {
                if (d2.Keys.Contains(x))
                {
                    d[x] = d1[x] + d2[x];
                }
                else
                {
                    d.Add(x, d1[x]);
                }
            }
            foreach (var x in d2.Keys)
            {
                if (!d.Keys.Contains(x))
                {
                    d.Add(x, d2[x]);
                }
            }
            return d;
        }

        static int[] vectorAleatorio(int n, int min, int max)
        {
            Random r = new Random();  //RANDOM NO ES THREAD SAVE
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                res[i] = r.Next(min, max);
            }
            return res;
        }


        static double varLinq(IEnumerable<int> vector)
        {
            var mean = vector.Aggregate(0.0, (acc, el) => acc + el) /
            vector.Count();
            return vector.Aggregate(0.0, (acc, el) => acc + Math.Pow((el­ - mean), 2.0))/ vector.Count();
        }

        static double varPLinq(IEnumerable<int> vector)
        {
            var mean = vector.AsParallel().Aggregate(0.0, (acc, el) => acc + el) /
            vector.Count();
            return vector.AsParallel().Aggregate(0.0, (acc, el) => acc + Math.Pow((el­ - mean), 2.0)) / vector.Count();
        }


        static double mean(IEnumerable<int> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el) / (double)
            vector.Count();
        }
        static double meanX2(IEnumerable<int> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el * el) /
            (double)vector.Count();
        }


        static double varianzaNormal(IEnumerable<int> vector)
        {
            double media = mean(vector);
            double mediaX2 = meanX2(vector);
            return mediaX2 - (Math.Pow(media, 2));
        }


        static double varianzaInvoke(IEnumerable<int> vector)
        {
            double mean=0;
            double meanX2=0;
            Parallel.Invoke(

                () =>
                {
                    mean = vector.Aggregate(0.0, (acc, el) => acc + el) / (double)vector.Count();
                },

                () =>
                {

                    meanX2 = vector.Aggregate(0.0, (acc, el) => acc + el * el) / (double)vector.Count();
                }
                );

            return meanX2 - (Math.Pow(mean,2));

        }




        static void Main(string[] args)
        {
            int[] datos;
            const int tam = 100000000, min = 0, max = 20;
            datos = vectorAleatorio(tam,min,max);
            IDictionary<int, int> d = new Dictionary<int, int>();

            //          d = histogramaFor(datos);
            //d = histogramaForEach(datos);

            ////foreach(var x in d.Keys)
            ////{
            ////    Console.WriteLine("{0} {1}", x, d[x]);
            ////}
            ////Para que salga ordenado

            //foreach (var x in d.Keys.OrderBy(y=>y))
            //{
            //    Console.WriteLine("{0} {1}", x, d[x]);
            //}
            //Console.WriteLine("Total {0}", d.Aggregate(0, (acc, x) => acc = acc + x.Value));


            //Console.WriteLine("LINQ \n");
            //DateTime antes = DateTime.Now;
            //Console.WriteLine(varLinq(datos));
            //DateTime despues = DateTime.Now;
            //Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
            //   (despues - antes).Ticks);

            //Console.WriteLine();

            //Console.WriteLine("PLINQ \n");
            //antes = DateTime.Now;
            //Console.WriteLine(varPLinq(datos));
            //despues = DateTime.Now;
            //Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
            //   (despues - antes).Ticks);


            Console.WriteLine("Varianza Normal");
            DateTime antes = DateTime.Now;
            Console.WriteLine(varianzaNormal(datos));
            DateTime despues = DateTime.Now;
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
               (despues - antes).Ticks);

            Console.WriteLine();

            Console.WriteLine("Varianza Paralela");
            antes = DateTime.Now;
            Console.WriteLine(varianzaInvoke(datos));
            despues = DateTime.Now;
            Console.WriteLine("Tiempo transcurrido: {0:N0} ticks de reloj.",
               (despues - antes).Ticks);
            


        }
    }
}
