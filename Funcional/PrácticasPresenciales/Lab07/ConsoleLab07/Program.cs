using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab07
{
    class Program
    {

        static void Main(string[] args)
        {

            //EJERCICIO 1 PERFECTSQUARES
            const int from = 0, numberOfNumbers = 100, elementsToBeShown = 10;

            //var EagerNumbers = PerfectSquares.EagerPerfectSquareNumbers(from, numberOfNumbers);
            //Console.Write("{0} elements after the {1}-th element (eager):\n\t", elementsToBeShown, from);
            //PerfectSquares.ForEach(EagerNumbers, item => Console.Write("{0} ", item), elementsToBeShown);
            //Console.WriteLine();


            //var lazyPrimes = PerfectSquares.LazyPerfectSquareNumbers(from, numberOfNumbers);
            //Console.Write("{0} elements after the {1}-th element (lazy):\n\t", elementsToBeShown, from);
            //PerfectSquares.ForEach(lazyPrimes, item => Console.Write("{0} ", item), elementsToBeShown);
            //Console.WriteLine();


            //EJERCICIO 2

            Random r = new Random();
            int[] v = new int[10];
            for (int i = 0; i < v.Length; i++)
                v[i] = r.Next(0, 10);

            Action<int> act = (int o) =>
            {
                Console.WriteLine(o);
            };

            Predicate<int> pred = (int entero) => entero != 1 && 
                entero != 8 && entero != 4 && entero != 2 && entero != 3;


            Console.WriteLine("####### FOREACH ODD ######");
            Ejercicio2.ForEachOdd(v, act);
            Console.WriteLine("####### FOREACH NTH ######");
            Ejercicio2.ForEachNth(v, act, 3);
            Console.WriteLine("####### FOREACH PRED ######");
            Ejercicio2.ForEachPred(v, act,pred);

            Console.WriteLine("####### FOREACH ######");
            Ejercicio2.ForEach(v, act);


            //EJERCICIO 3

            Console.WriteLine("####### EJERCICIO 3 ######");

            int[] list = new int[100];


            for (int i = 0; i < list.Length; i++)
                list[i] = r.Next(0, 100);

           int maximo= list.Aggregate(list[0], (accum, x) => x > accum ? x:accum);

            Console.WriteLine("El máximo es {0}", maximo);

        }
    }
}
