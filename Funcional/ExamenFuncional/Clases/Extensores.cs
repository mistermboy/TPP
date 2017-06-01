using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class Extensores
    {

        //EJERCICIO3

        public static R ReducirDos<T, R>(this IEnumerable<T> enumerable, IEnumerable<T> enumerable2, Func<R, T, R> funcion, R semilla = default(R))
        {
            R aux = semilla;
            foreach (var elemento in enumerable)
            {
                aux = funcion(aux, elemento);
            }

            foreach (var elemento in enumerable2)
            {
                aux = funcion(aux, elemento);
            }
            return aux;
        }

        public static T Buscar<T>(this IEnumerable<T> enumerable, Predicate<T> funcion)
        {
            foreach (var elemento in enumerable)
            {
                if (funcion(elemento))
                {
                    return elemento;
                }
            }
            return default(T);
        }

        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> enumerable, Predicate<T> funcion)
        {
            var lista = new List<T>();
            foreach (var elemento in enumerable)
            {
                if (funcion(elemento))
                {
                    lista.Add(elemento);
                }
            }
            return lista;
        }


        public static IEnumerable<T> FiltrarPro<T>(this IEnumerable<T> enumerable, Predicate<T> funcion)
        {
            foreach (var elemento in enumerable) if (funcion(elemento)) yield return elemento;
        }


        public static R Reducir<T, R>(this IEnumerable<T> enumerable, Func<R, T, R> funcion, R semilla = default(R))
        {
            R aux = semilla;
            foreach (var elemento in enumerable)
            {
                aux = funcion(aux, elemento);
            }
            return aux;
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, R> funcion)
        {
            var lista = new List<R>();
            foreach (var elemento in enumerable)
            {

                lista.Add(funcion(elemento));

            }
            return lista;
        }



    }
}
