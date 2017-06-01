using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Punto2d
    {
        public double x { get; set; }
        public double y { get; set; }
        public Color c { get; set; }

        public Punto2d()
        {

            this.x = 0.0;
            this.y = 0.0;
            this.c = Color.Rojo;

        }

        public Punto2d(double x, double y, Color c)
        {
            this.x = x;
            this.y = y;
            this.c = c;

        }
        public Punto2d(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.c = c;

        }

        public enum Color
        {
            ///<sumary>
            ///Color Transparente
            /// <sumary>
            Transparente,
            ///<sumary>
            ///Color Negro
            ///<sumary>
            Negro,
            ///<sumary>
            ///Color Rojo
            /// </sumary>
            Rojo
        };




        public double calcularDistanciaEuclidea(Punto2d a)
        {

            return Math.Sqrt((a.x - this.x) * (a.x - this.x) + (a.y - this.y) * (a.y - this.y));

        }

        public override string ToString()
        {
            return String.Format("({0},{1}):{2}", this.x, this.y, this.c); 
        }

        public string toStringSincolor()
        {
            return String.Format("({0},{1})", this.x, this.y);
        }

    }
}
