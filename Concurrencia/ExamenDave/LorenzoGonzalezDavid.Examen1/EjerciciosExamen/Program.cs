using LorenzoGonzalezDavid.Examen1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    /// <summary>
    /// David Lorenzo González (L7)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Pila pila = new Pila();

            Console.WriteLine("Ejercicios 1 y 2. Añadiendo a la pila desde el directorio:");
            // Llamada al método para leer el contenido de un directorio
            // y para aquellos de tipo texto llamada al método del
            // ejercicio 1 hecho en la clase Pila
            pila.addDesdeDirectorio(@"..\..\..\ficheros");
            Console.WriteLine(pila.ToString());

            // Vector de enteros a partir de la pila
            int[] vector = new int[pila.size()];
            for (int i = 0; i < pila.size(); i++)
            {
                vector[i] = pila.getElemento(i);
            }

            Console.WriteLine("\nEjercicio 3. Número de veces consecutivas de " +
                vector[0] + " y " + vector[1] + ":");
            // Llamada al Master/Worker hecho para el ejercicio 3
            // En este caso con 4 hilos para el vector dado
            int numeroDeHilos = 4;
            Master master = new Master(vector, numeroDeHilos);
            Console.WriteLine(master.NumVecesConsecutivas());


            // Llamada al método del ejercicio 4 que determina la
            // suma de todos los números mayores que el pasado como
            // parámetro. En este ejemplo, la suma será de los 
            // números mayores de 11 (15+12+19)
            int num = 11;
            Console.WriteLine("Ejercicio 4. Suma de los números mayores que " +
                num + ":");
            Console.WriteLine(PLINQ.SumaMayoresQue(vector, num));

        }
    }
}
