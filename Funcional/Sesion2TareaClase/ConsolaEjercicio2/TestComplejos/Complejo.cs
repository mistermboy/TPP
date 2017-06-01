using System;

namespace TestComplejos
{
    internal class Complejo
    {
        private double pr;//parte real
        private double pi;//parte imaginaria


        public Complejo(double v1, double v2)
        {
            this.pr = v1;
            this.pi = v2;
        }

        internal double Modulo()
        {
            return Math.Sqrt(pr*pr + pi + pi);
        }

    }
}