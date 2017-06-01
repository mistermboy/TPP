using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLab6
{
    class Program
    {
        public static object Fibonacci { get; private set; }

        static Predicate<int> ContieneDivisores(IEnumerable<int> e)
        {
            return element =>
            {
                foreach (int el in e)
                    if ((element % el).Equals(0))
                        return true;
                return false;
            };
        }


        static void RepeatUntilLoop(Action body, Func<bool> condition)
        {
            body();
            if (condition())
            {
                RepeatUntilLoop(body, condition);
            }
        }

        //PROBAR
        static void RepeatUntilLoop2(Func<bool> condition, Action body)
        {
            if (!condition())
            {
                body();
                RepeatUntilLoop2(condition, body);
            }
        }

        static Func<int> ReturnFibonacci()
        {
            int fib = 1;
            int ant = -1;
            int save;
            return () =>
            {
                save = fib;
                fib = fib + ant;
                ant = save;
                return fib;
            };
        }

        static bool EsPrimo(int n)
        {
            if (n <= 1)
                return false;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        static internal IEnumerable<int> InfinitePrime(int terminoMaximo)
        {
            int first = 1, cont = 0, termino = 1;
            bool change;
            while (true)
            {
                yield return first;
                change = false;
                while (!change)
                {
                    cont++;
                    if (EsPrimo(cont))
                    {
                        first = cont;
                        change = true;
                    }
                }
                if (termino++ == terminoMaximo)
                    yield break;
            }
        }
 


            static void Main(string[] args)
        {
            //ContieneDivisores

            int[] integers = {2,3,5};
            var containsDivisores = ContieneDivisores(integers);

            Console.WriteLine(containsDivisores(10));
            Console.WriteLine(containsDivisores(11));
            Console.WriteLine(containsDivisores(6));
            Console.WriteLine(containsDivisores(3));
            Console.WriteLine(containsDivisores(17));
            Console.WriteLine("\n");

            Console.WriteLine("RepeatUntilLoop \n");
            //RepeatUntilLoop
            int value = 1;
            Func<bool> condition = () => value != 10;

            Action act = () =>
            {
                Console.WriteLine(value);
                value += 1;
            };

            RepeatUntilLoop(act,condition);

            Console.WriteLine("FIBONACCI \n");
            //Fibonacci
            var fibo = ReturnFibonacci();
            for(int i = 0; i < 10; i++)
            {
               Console.WriteLine(fibo());
                //          Console.WriteLine(ReturnCounter()()); Si hiciésemos esto la
                //    salida por pantalla sería siempre 1 1 1 1 ya que se llama a la función y todo el rato el contador 
                //    se pone a 0. En cambio de la otra forma estamos llamando a la función lambda
            }

            Console.WriteLine("############");

            foreach (int valor in InfinitePrime(10))
                Console.WriteLine(valor);


        }
    }
}
