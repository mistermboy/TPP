
using System;
using System.Linq;

namespace TPP.Practicas.Concurrente.Practica1 {

    internal class Worker {


        private int índiceDesde, índiceHasta;

        private int maxIndice;

        private long resultado;

        private char[] cadenaAdn;
        private char[] gen;

        internal long Resultado {
            get { return this.resultado; }
        }

        internal Worker(char[] cadenaAdn, char[] gen,int índiceDesde, int índiceHasta,int maxIndice) {
            this.cadenaAdn = cadenaAdn;
            this.gen = gen;
            this.índiceDesde = índiceDesde;
            this.índiceHasta = índiceHasta;
            this.maxIndice = maxIndice;
        }

        internal void CalcularNUmerodDeApariciones() {
            int longitud = gen.Length;
            string cadena = "";
            foreach(var x in gen)
            {
                cadena += "" + x;
            }
            this.resultado = 0;
            int j = this.índiceDesde;
            int copiaLongitud = longitud;
            while (j < this.índiceHasta)
            {
                string res = "";
                for(int i = j; i <j+longitud; i++)
                {
                    if (i <= maxIndice)
                    {
                        res += "" + cadenaAdn[i];
                    }
                }
                if (res == cadena)
                  {
                      this.resultado++;
                  }
                j++;
                }
            }
        }

    }
