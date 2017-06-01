using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
   public   class Recta2d
    {

        public double m { get; set; }
        public double n { get; set; }

        public Recta2d()
        {
            this.m = 0.0;
            this.n = 0.0;
        }

        public Recta2d(double m, double n)
        {
            this.m = m;
            this.n = n;

        }

        public Punto2d interseccionDeRectas(Recta2d recta1)
        {
            double ordenada, abscisa;
            ordenada = ((this.n / this.m) - (recta1.n / recta1.m)) / ((1 / this.m) - (1 / recta1.m));
            abscisa = ((ordenada - recta1.n) / recta1.m);
            return new Punto2d(ordenada, abscisa, Punto2d.Color.Transparente);
        }


        public Recta2d perpendicularPorUnPunto(Punto2d punto1)
        {

            double m1, n1;
            m1 = (-1 / this.m);
            n1 = (punto1.y + (1 / this.m) * punto1.x);
            return new Recta2d(m1, n1);

        }

        public double DistanciaRectaPunto(Punto2d punto1)
        {

            Recta2d perpendicular = this.perpendicularPorUnPunto(punto1);
            Punto2d interseccion = this.interseccionDeRectas(perpendicular);
            double distancia = interseccion.calcularDistanciaEuclidea(punto1);

            return distancia;

        }

        public override string ToString()
        {
            String cad = null;
            if (this.m == 0)
            {
                if (this.n == 0)
                {
                    cad = "y = " + m + "x + " + n;
                }
                cad = "y = " + m + "x ";
            }
            else
                cad = "y = " + n;
            return cad;
        }

    }
}
