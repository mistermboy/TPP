
using modulo.vector;
using System.Linq;

namespace TPP.Practicas.Concurrente.Practica1 {

    internal class Worker {


        private int índiceDesde, índiceHasta;

        private long resultado;

        private char[] cadenaAdn;
        private char[] gen;

        private Index indice;

        internal long Resultado {
            get { return this.resultado; }
        }

        internal Worker(char[] cadenaAdn,char[] gen,Index indice) {
            this.cadenaAdn = cadenaAdn;
            this.gen = gen;
            this.indice= indice;
        }

        internal void CalcularNUmerodDeApariciones() {
            this.resultado = 0;
            //calculamos el número de veces que aparece el gen en la cadena
            for (int i = this.índiceDesde; i <= this.índiceHasta; i++)
            {
             //   if()
            }

        }

    }

}
