
using System;
namespace TPP.Practicas.OrientacionObjetos.Practica2 {

    /// <summary>
    /// Ejercicio de utilización de parámetros por omisión
    /// </summary>
    class ParametrosOmision {


        /// <summary>
        /// Este método debería filtrar todas las personas que:
        /// - Con un nombre determinado
        /// - Con unos apellidos determinados
        /// - Con un nif que contenga una cadena determinada
        /// La comparación NO será sensible mayúsculas/minúsculas
        /// Devolviendo sólo aquellos que cumplan ese criterio.
        /// </summary>
        /// <param name="personas">La colección original de personas</param>
        /// <param name="nombre">El nombre que tiene que tener la persona para no ser filtrada</param>
        /// <param name="apellido1">El apellido1 que tiene que tener la persona para no ser filtrada</param>
        /// <param name="apellido2">El apellido2 que tiene que tener la persona para no ser filtrada</param>
        /// <param name="nifContiene">Caracteres que tiene que contener el nif</param>
        /// <returns>Una colección con aquellas personas que cumplan esos criterios</returns>
        static Persona[] Filtrar(Persona[] personas, string nombre, string apellido1, string apellido2, string nifContiene) {
            // * Array.Resize cambia el tamaño de un array
        }


        /// <summary>
        /// Crea una lista de personas aleatoriamente
        /// </summary>
        /// <returns></returns>
        static Persona[] CrearPersonas() {
            string[] nombres = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] apellidos = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numeroPersonas = 100;

            Persona[] listado = new Persona[numeroPersonas];
            Random random = new Random();
            for (int i = 0; i < numeroPersonas; i++)
                listado[i] = new Persona(
                    nombres[random.Next(0, nombres.Length)],
                    apellidos[random.Next(0, apellidos.Length)],
                    apellidos[random.Next(0, apellidos.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return listado;
        }

        /// <summary>
        /// Muestra una colección de personas por consola
        /// </summary>
        static void Mostrar(Persona[] personas) {
            foreach (Persona persona in personas) {
                Console.WriteLine(persona);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Complete el siguiente código
        /// </summary>
        static void Main() {
            Persona[] personas = CrearPersonas();
            Console.WriteLine("Personas con nombre María:");
            // * ¿Cómo se haría?

            Console.WriteLine("Personas con los dos apellidos Pérez:");
            // * ¿Cómo se haría?

            Console.WriteLine("Personas cuyo NIF contiene la A");
            // * ¿Cómo se haría?
        }
    }

}
