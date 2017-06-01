using System;

namespace Clases
{

    /// <summary>
    /// Clase Persona utilizada en diversos ejemplos
    /// </summary>
    public class Persona {

        public String Nombre { get; private set; }

        public String Apellido1 { get; private set; }

        public String Apellido2 { get; private set; }

        public string Nif { get; private set; }

        public override String ToString() {
            return String.Format("{0} {1} {2} con NIF {3}", Nombre, Apellido1, Apellido2, Nif);
        }

        public Persona(String nombre, String apellido1, String apellido2, string nif) {
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Nif = nif;
        }


    }
}
