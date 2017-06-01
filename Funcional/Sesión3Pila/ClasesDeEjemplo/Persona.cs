using System;

namespace TPP.Practicas.OrientacionObjetos.Practica2 {

    /// <summary>
    /// Clase Persona utilizada en diversos ejemplos
    /// </summary>
    class Persona {

        private String nombre, apellido1, apellido2;

        public String Nombre {
            get { return nombre; }
        }
        public String Apellido1 {
            get { return apellido1; }
        }
        public String Apellido2 {
            get { return apellido2; }
        }

        private string nif;
        public string Nif {
            get { return nif; }
        }

        public override String ToString() {
            return String.Format("{0} {1} {2} con NIF {3}", nombre, apellido1, apellido2, nif);
        }

        public Persona(String nombre, String apellido1, String apellido2, string nif) {
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.nif = nif;
        }
    }
}
