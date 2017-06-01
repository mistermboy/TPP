using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab07
{
    static class Ejercicio2
    {

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action1, Action<T> action2)
        {
            foreach (T item in collection)
            {
                action1(item);
                action2(item);
            }
        }

        public static void ForEachOdd<T>(this IEnumerable<T> collection, Action<T> action1)
        {
            int contador = 0;
            foreach (T item in collection)
            {
                if (contador % 2 != 0)
                {
                    action1(item);
                }
                contador++;
            }
        }

        public static void ForEachNth<T>(this IEnumerable<T> collection, Action<T> action1, int multiplo)
        {
            int contador = 0;
            foreach (T item in collection)
            {
                if (contador % multiplo == 0)
                {
                    action1(item);
                }
                contador++;
            }
        }

        public static void ForEachPred<T>(this IEnumerable<T> collection, Action<T> action1, Predicate<T> predicado)
        {
            foreach (T item in collection)
            {
                if (predicado(item))
                {
                    action1(item);
                }

            }
        }

    }
}
