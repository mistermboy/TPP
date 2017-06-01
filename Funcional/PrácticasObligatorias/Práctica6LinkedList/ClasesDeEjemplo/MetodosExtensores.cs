using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.OrientacionObjetos.Sobrecarga {

    class Program {

        static void Main(string[] args) {
            string párrafo = @"
                Si la misión del W3C es guiar la Web hacia su máximo potencial, 
                la nuestra es formar a los profesionales e investigadores 
                capaces de llevarlo a cabo, 
                integrando aplicaciones de Internet, 
                construyendo arquitecturas orientadas a servicios, 
                administrando servidores de información y creando sitios web usables, 
                accesibles y que cumplan con los estándares.
        ";
            Console.WriteLine("Palabras del párrafo: {0}.", párrafo.ContarPalabras());
        }
    }


}
