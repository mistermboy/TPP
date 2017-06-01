
using System;

namespace Clases {

    /// <summary>
    /// Ejemplo de clase que ofrece primitivas de ángulos
    /// </summary>
    public class Angulo {

        /// <summary>
        /// Radianes del ángulo
        /// </summary>
        public double Radianes { get; private set; }

        /// <summary>
        /// Devuelve los grados de un ángulo
        /// </summary>
        /// <returns></returns>
        public float Grados {
            get { return (float)(this.Radianes / Math.PI * 180); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radianes">Ángulo en radianes</param>
        public Angulo(double radianes) {
            this.Radianes = radianes;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="grados">Grados sexasegimales</param>
        public Angulo(float grados) {
            this.Radianes = grados / 180.0 * Math.PI;
        }

        /// <summary>
        /// Calcula el seno de un ángulo
        /// </summary>
        /// <returns>El seno del objeto implícito</returns>
        public double Seno() {
            return Math.Sin(this.Radianes);
        }

        /// <summary>
        /// Calcula el coseno de un ángulo
        /// </summary>
        /// <returns>El coseno del ángulo</returns>
        public double Coseno() {
            return Math.Cos(this.Radianes);
        }

        /// <summary>
        /// Calcula la tangente de un ángulo
        /// </summary>
        /// <returns>La tangente del objeto implícito</returns>
        public double Tangente() {
            return Seno() / Coseno();
        }

        public String ToString()
        {         
            return "Grados = " + Grados + " Radianes = " + Radianes;
        }


    }

}