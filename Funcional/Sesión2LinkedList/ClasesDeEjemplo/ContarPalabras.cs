using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.OrientacionObjetos.Sobrecarga {

    /// <summary>
    /// Clase que añade la funcionalidad de contar palabras a String,
    /// mediante la utilización de métodos extensores
    /// </summary>
    static class ExtensoraString {

        /// <summary>
        /// Método extensor
        /// </summary>
        /// <param name="cadena">La cadena de la que vamos a contar palabras</param>
        /// <returns>El número de palabras</returns>
        static public uint ContarPalabras(this string cadena) {
            // * Rompemos la cadena mediante expresiones regulares
            var lineas = Regex.Split(cadena, "\r|\n|[.]|[,]|[ ]");
            uint numeroPalabras = 0;
            foreach (var linea in lineas)
                // * Descartamos los blancos y espacios
                if (!String.IsNullOrEmpty(linea) && !String.IsNullOrWhiteSpace(linea))
                    numeroPalabras++;
            return numeroPalabras;
        }

    }


}
