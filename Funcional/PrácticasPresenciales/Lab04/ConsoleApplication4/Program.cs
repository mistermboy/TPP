using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("-----------CHAR------------");

            Par<char>[] v = new Par<char>[6];

            Clases.Par<char> par0 = new Clases.Par<char>('a', 'x');
            Clases.Par<char> par1 = new Clases.Par<char>('b', 'c');
            Clases.Par<char> par2 = new Clases.Par<char>('y', 'a');
            Clases.Par<char> par3 = new Clases.Par<char>('y', 'b');
            Clases.Par<char> par4 = new Clases.Par<char>('m', 'c');
            Clases.Par<char> par5 = new Clases.Par<char>('g', 'm');


            v[0] = par0;
            v[1] = par1;
            v[2] = par2;
            v[3] = par3;
            v[4] = par4;
            v[5] = par5;

            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine(v[i].toString());
            }

            Console.WriteLine("-----------ORDENADO------------");

            Algorithms.Sort(v);

            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine(v[i].toString());
            }

            Console.WriteLine("-----------MAYOR------------");
            Console.WriteLine(Algorithms.Max(v).toString());



            Console.WriteLine("\n");
            Console.WriteLine("-----------INT------------");

            Par<int>[] v2 = new Par<int>[6];

            Clases.Par<int> p0 = new Clases.Par<int>(0, 1);
            Clases.Par<int> p1 = new Clases.Par<int>(5, 6);
            Clases.Par<int> p2 = new Clases.Par<int>(1, 8);
            Clases.Par<int> p3 = new Clases.Par<int>(1, 3);
            Clases.Par<int> p4 = new Clases.Par<int>(4, 2);
            Clases.Par<int> p5 = new Clases.Par<int>(8, 10);

            v2[0] = p0;
            v2[1] = p1;
            v2[2] = p2;
            v2[3] = p3;
            v2[4] = p4;
            v2[5] = p5;


            for (int i = 0; i < v2.Length; i++)
            {
                Console.WriteLine(v2[i].toString());
            }

            Console.WriteLine("-----------ORDENADO------------");

            Algorithms.Sort(v2);

            for (int i = 0; i < v2.Length; i++)
            {
                Console.WriteLine(v2[i].toString());
            }

            Console.WriteLine("-----------MAYOR------------");
            Console.WriteLine(Algorithms.Max(v2).toString());

        }
    }
    }
