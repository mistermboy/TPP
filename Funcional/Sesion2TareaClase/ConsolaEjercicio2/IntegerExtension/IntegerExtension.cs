using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerExtension
{
    //Las clases extensoras tienen que ser estáticas
    //Los métodos también tienen que ser estáticos
    //Todos los métodos tienen que tener por lo menos un parámetro
    //Si solo tienen un parámetro tiene que llevar this
    public static class IntegerExtension
    {
        public static bool EsPrimo(this int n)
        {
           
            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
               
            }
            return true;
        }
    }
}
