using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaExamen
{
    internal class Worker
    {


        private int índiceDesde, índiceHasta;


        private int[] resultado;

        private int[] cadenaPrimos;

     
        internal int[] Resultado
        {
            get { return this.resultado; }
        }

        internal Worker(int[] cadenaPrimos, int índiceDesde, int índiceHasta)
        {
            this.cadenaPrimos = cadenaPrimos;
            this.índiceDesde = índiceDesde;
            this.índiceHasta = índiceHasta;
            this.resultado = new int[cadenaPrimos.Length];
        }

        internal void CalcularPrimos()
        {
            for(int i = this.índiceDesde; i <= this.índiceHasta; i++)
            {
                if (EsPrimo(cadenaPrimos[i]))
                {
                    this.resultado[i] = cadenaPrimos[i];
                }
            }
        }

        internal bool EsPrimo(int n)
        {
            if (n <= 1)
                return false;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
