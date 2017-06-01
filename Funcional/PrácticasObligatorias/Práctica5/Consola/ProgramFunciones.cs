using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
      static class FuncionesDeOrdenSuperior
    {
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

        public static IEnumerable<T> Filtrar2<T>(this IEnumerable<T> enumerable, Predicate<T> funcion)
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


        public  static IEnumerable<R> Map<T, R>(this IEnumerable<T> en, Func<T, R> f)
        {
            var temp = new List<R>();
            foreach (var e in en)
            {
                temp.Add(f(e));
            }
            return temp;
        }

    }


       static class ProgramFunciones
       {
          static void Main(string[] args)
          {

            //Funciones de orden superior propias

            var ints = new int[] { 1, 2, 3, 4, 5 };
            var m = ints.Map(n => n * 2);
            var r = ints.Filtrar2(n => n % 2 == 0).Map(n => n * 2).Reducir<int, int>((sum, n) => sum + n,20);
            var h = ints.Filtrar2((n => n % 2 == 0));
            

            foreach(var i in m)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("##########");
            Console.WriteLine(r);



            //LINQ

            var x = ints.Aggregate((sum, n) => sum - n);
            var y = ints.Select(n => n * 2);
            var z = ints.Where(n => n % 2 == 0);

            Console.WriteLine(x);


            Console.WriteLine("##########");
            foreach (var i in y)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("##########");
            foreach (var i in z)
            {
                Console.WriteLine(i);
            }

            var ang = new Angulo((float)90);
            var ang1 = new Angulo((float)30);
            var ang2 = new Angulo((float)60);
            var ang3 = new Angulo((float)40);
            var ang4 = new Angulo((float)180);

            var angulos = new Angulo[] { ang, ang1, ang2, ang3, ang4 };

            var g = angulos.Select((n) => {
                if (n.Grados >= 0 && n.Grados <= 90) return "Primer cuadrante";
                if (n.Grados > 90 && n.Grados <= 180) return "Segundo Cuadrante";
                if (n.Grados > 180 && n.Grados <= 270) return "Tercer Cuadrante";
                if (n.Grados > 270 && n.Grados <= 360) return "Cuarto Cuadrante";
                return "";
            });

            foreach(var i in g)
            {
                Console.WriteLine(i);
            }
        }
    }
}
