using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesLab03
{
    public class Intervalo
    {
        public double? extIzdo { get; set; }
        public double? extDcho { get; set; }

        public Intervalo()
        {
            this.extDcho = 0.0;
            this.extIzdo = 0.0;
        }
        public Intervalo(double? eI, double? eD)
        {
            if (eI > eD || (eI == null && eD != null) || (eI == null && eD != null))
            {
                throw new ArgumentException("Valores Inválidos en el constructor del intervalo");
            }
            this.extIzdo = eI;
            this.extDcho = eD;
        }


        protected bool Check()
        {
            if ((this.extIzdo == null && this.extDcho != null) || (this.extIzdo == null && this.extDcho != null))
            {
                return false;
            }
            else
            {
                if (this.extIzdo != null && this.extDcho != null && this.extIzdo < this.extDcho)
                {
                    return true;
                }
                if (this.extIzdo == null && this.extDcho == null)
                {
                    return true;
                }

                return false;
            }
        }

        public String toString()
        {
            return ("[" + this.extIzdo + ";" + this.extDcho + "]");
        }


        public  double? Tamaño()
        {
            if (this.extIzdo != null && this.extDcho != null)
            {
                return this.extDcho - this.extIzdo;
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            Intervalo tmp = obj as Intervalo;
            if (tmp == null)
            {
                return false;
            }
            else
            {
                return this.extIzdo == tmp.extIzdo && this.extDcho == tmp.extDcho;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }



        public static Intervalo operator *(Intervalo a, Intervalo b)
        {
            Intervalo vacio = new Intervalo(), resultado;

            //uno de ellos vacio

            if (a.Equals(vacio) || b.Equals(vacio))

            {

                resultado = vacio;

            }

            else

            {

                //disjuntos

                if (a.extDcho < b.extIzdo || a.extIzdo > b.extDcho)

                    resultado = vacio;

                else

                    //inclusion de a en b

                    if (a.extIzdo > b.extIzdo && a.extIzdo < b.extDcho)

                    resultado = new Intervalo(a.extIzdo, a.extDcho);

                else

                        //inclusion de b en a

                        if (b.extIzdo > a.extIzdo && b.extDcho < a.extDcho)

                    resultado = new Intervalo(b.extIzdo, b.extDcho);

                else

                            //se muerden, b delante de a

                            if (b.extIzdo > a.extIzdo && a.extDcho < b.extDcho)

                    resultado = new Intervalo(b.extIzdo, a.extDcho);

                //a delante de b

                else

                    resultado = new Intervalo(a.extIzdo, b.extDcho);

            }

            return resultado;

        }
    }
}
