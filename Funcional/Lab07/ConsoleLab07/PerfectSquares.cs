using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab07
{
    static internal class PerfectSquares
    {


        private static bool IsPerfectSquare(int n, char letra)
        {
            Console.Write(letra);
            bool isPerfect = false;
            if (Math.Sqrt(n) % 1 == 0)
            {
                isPerfect = true;
            }
            return isPerfect;
        }



        static internal IEnumerable<int> EagerPerfectSquareNumbers(int from, int numberOfNumbers)
        {
            int n = 1, counter = 0;
            while (counter < from)
            {
                if (IsPerfectSquare(n, 'E'))
                    counter++;
                n++;
            }
            IList<int> result = new List<int>();
            counter = 0;
            while (counter < numberOfNumbers)
            {
                if (IsPerfectSquare(n, 'E'))
                {
                    counter++;
                    result.Add(n);
                }
                n++;
            }
            return result;
        }


        static private IEnumerable<int> LazyPerfectSquareNumbersGenerator()
        {
            int n = 1;
            while (true)
            {
                if (IsPerfectSquare(n, 'L'))
                    yield return n;
                n++;
            }
        }

        static internal IEnumerable<int> LazyPerfectSquareNumbers(int from, int numberOfNumbers)
        {
            return LazyPerfectSquareNumbersGenerator().Skip(from).Take(numberOfNumbers);
        }


        static internal void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action, int? maximumNumberOfElements = null)
        {
            int counter = 0;
            foreach (T item in enumerable)
            {
                if (maximumNumberOfElements.HasValue && maximumNumberOfElements.Value < counter++)
                    break;
                action(item);
            }


        }
    }
}
