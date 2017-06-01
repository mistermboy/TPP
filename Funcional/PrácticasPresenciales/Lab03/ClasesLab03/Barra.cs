using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesLab03
{
    public class Barra: Intervalo
    {
       
        double? alto;
        public Barra(double? a, double? b, double? alto) : base(a, b)
        {
            this.alto = alto;
        }

        public Barra() : base()
        {
            this.alto = 0;
        }
        private new bool Check()
        {
            return base.Check() && this.alto >= 0;
        }

        public  double? tamaño()
        {
            return base.Tamaño() * alto;
        }

        public String toString()
        {
            return ("[" + this.extIzdo + ";" + this.extDcho + ":" + this.alto+"]");
        }

        public override bool Equals(object obj)
        {
            Barra tmp = obj as Barra;
            if (tmp == null)
            {
                return false;
            }
            else
            {
                return this.extIzdo == tmp.extIzdo && this.extDcho == tmp.extDcho && this.alto == tmp.alto;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public static Barra operator *(Barra a, Barra b)
        {
            Barra nula = new Barra();
            Barra resultado;
            if (a == null || b == null || a.Equals(nula) || b.Equals(nula)) return nula;
            else
            {
                Intervalo intervaloResultado = new Intervalo(a.extIzdo, a.extDcho) * new Intervalo(b.extIzdo, b.extDcho);
                double altoResultado = Math.Min(a.alto, b.alto);
                if (intervaloResultado.extIzdo != null && intervaloResultado.extDcho != null)
                    resultado = new Barra(intervaloResultado.extIzdo, intervaloResultado.extDcho, altoResultado);
                else
                    resultado = nula;
            }
            //a.alto = -1
         //   Debug.Asset(a.Check() && b.Check());
            return resultado;

        }
    }
}
