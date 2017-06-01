using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace ConsoleApplicationExam
{
     class Program
    {

        static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body); 
            }
        }

        //Ejercicio1
        private static void FoorLoop(Func<bool> condition,Action body,int actualizacion)
        {
               WhileLoop(condition, body);
        }

        //Ejercicio2
        private static double Ejercicio2<Double>(IEnumerable<double> enum1, IEnumerable<double> enum2)
        {
            var e1 = enum1.Reducir<double,double>((acc, x) => acc * x,1.0);
            var e2 = enum2.Reducir<double, double>((acc, x) => acc * x,1.0);
            return e1*e2;
        }

        static void Main(string[] args)
        {
            int[] ints1 = new int[] { 1, 2, 3 };
            int[] ints2 = new int[] { 4, 5, 6 };

            double[] doubles1 = new double[] { 1.0, 2.0, 3.0 };
            double[] doubles2 = new double[] { 4.0, 5.0, 6.0 };

            //Ejercicio2
            Console.WriteLine("### EJERCICIO 2 ###");
            Console.WriteLine(Ejercicio2<Double>(doubles1, doubles2));

            //Ejercicio3
            Console.WriteLine("### EJERCICIO 3 ###");
            Console.WriteLine(ints1.ReducirDos<int, int>(ints2, (acc, s) => acc + s));

            MovieModel m = new MovieModel();

            //Ejercicio4
            Console.WriteLine("### EJERCICIO 4 ###");
            m.Ej4("HD");
            //Ejercicio5
            Console.WriteLine("### EJERCICIO 5 ###");
            m.Ej5();               
   
        }
    }
}
