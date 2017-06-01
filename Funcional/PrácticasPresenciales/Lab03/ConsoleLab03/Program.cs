using ClasesLab03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Intervalo intervalo = new Intervalo(1.0, 3.0);
            Console.WriteLine(intervalo.toString());
            Console.WriteLine(intervalo.GetHashCode());

            Barra barra = new Barra(5.0, 9.0, 4.0);
            Console.WriteLine(barra.toString());



            //e1.Message ( Mensaje excepción)
        }
    }
}
