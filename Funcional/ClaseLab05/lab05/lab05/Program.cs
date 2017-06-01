using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    class Program
    {
        static void AplicaAccion<T>(IEnumerable<T> e, Action<T> a)
        {
            foreach(T x in e)
            {
                a(x);
            }
        }

        static bool IsEven(int x)
        {
            return x % 2 == 0;
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

        static int Contar<T>(T[] v, Predicate<T> p)
        {
            int contador = 0;
            foreach(T x in v)
            {
                if (p(x))
                {
                    contador++;
                }
            }
            return contador;
        }

        static int PosicionPrimero<T>(T[] v, Predicate<T> p)
        {
            for(int i=0; i < v.Length; i++)
            {
                if (p(v[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        //Ejercicio 5
        static Func<double, double> ComposeDouble (Func<double, double> f, Func<double, double> g)
        {
            return (x) => g(f(x));
        }

        //Ejercicio 6
        static Func<T1, T3> ComposeG<T1,T2,T3>(Func<T1, T2> f, Func<T2, T3> g)
        {
            return (x) => g(f(x));
        }
        //Ejercicio 7
        static bool Existe(List<int> v, Predicate<int> f)
        {
            for(int i =0; i < v.Count; i++) {
                if (f(v[i])) return true;
                
            }
            return false;
            
        }


        static void Main(string[] args)
        {
            //asinh(x) = log(x + sqrt(x^2 + 1))
            Func<double, double> asinh1 = delegate (double x)
               {
                   return Math.Log(x + Math.Sqrt(x * x + 1));
               };
            Console.WriteLine("asinh {0}", asinh1(2.0));
            //Haciendolo con lambda
            Func<double,double> asinh2=(double x) => Math.Log(x + Math.Sqrt(x * x + 1));
            Console.WriteLine("asinh {0}", asinh2(2.0));
            Func<double, double> asinh3 = (x) => Math.Log(x + Math.Sqrt(x * x + 1));
            Console.WriteLine("asinh {0}", asinh3(2.0));

            //acosh(x)=log(x+sqrt(x^2-1))
            Func<double, double> acosh = (x) => Math.Log(x + Math.Sqrt(x * x + 1));
            Console.WriteLine("acosh {0}", acosh(2.0));

            //atanh(x)=(log(1+x)-log(1-x))/2
            Func<double, double> atanh = (x) => (Math.Log(1 + x) - Math.Log(1 - x)) / 2;
            Console.WriteLine("atanh {0}", atanh(0.5));

            Random r = new Random();
            int[] v = new int[10];
            for (int i = 0; i < v.Length; i++)
                v[i] = r.Next(0, 10);
            AplicaAccion(v, (x) => Console.Write("{0}, ", x));

            Console.WriteLine("Numeros pares:{0}", Contar(v, IsEven));
            Console.WriteLine("Numeros pares inline:{0}", Contar(v, (x) => x % 2 == 0));
            Console.WriteLine("Numeros primos:{0}", Contar(v, EsPrimo));
            Console.WriteLine("Numeros primos inline:{0}", Contar(v, (x) => {
                if (x <= 1)
                    return false;
                for (int i = 2; i <= x / 2; i++)
                    if (x % i == 0)
                        return false;
                return true;
            }));

            Console.WriteLine("Primer posicion primo:{0}", PosicionPrimero(v, EsPrimo));
            Console.WriteLine("Primer posicion par:{0}", PosicionPrimero(v, IsEven));

            //Ejercicio 5

            //asignoo la evaluacion del delegado definido más arriba
            Func<double, double> identidad1 = ComposeDouble(Math.Exp, Math.Log); //podria ponerse var
            //invoco el resultado de la evaluacion del delegado
            Console.WriteLine("Identidad: " + identidad1(3.0));

            //Lo anterior con lambda directamente
            Func<Func<double, double>, Func<double, double>, Func<double, double>> ComposeLambda = (f, g) => (x) => (g(f(x)));
            Func<double,double>  identidad2 = ComposeLambda(Math.Exp, Math.Log);
            Console.WriteLine("Identidad2: " + identidad2(3.0));

            //Ejercicio 6
            Func<double, double> identidadG = ComposeG<double, double,double>(Math.Exp, Math.Log);
            Console.WriteLine("ComposeG: " + identidadG(3.0));
            Console.WriteLine("ComposeG: " + ComposeG<double, double, double>(Math.Exp, Math.Log)(3.0));

            //Ejercicio 7
            List<int> e = new List<int>();
            for (int i = 0; i <10; i++)
                e.Add( r.Next(0, 10));
            Console.WriteLine("Hay primo: " + Existe(e,EsPrimo));

        }
    }
}
