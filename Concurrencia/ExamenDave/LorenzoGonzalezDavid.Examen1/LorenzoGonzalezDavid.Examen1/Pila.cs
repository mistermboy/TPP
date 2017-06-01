using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class Pila
    {
        // Semaforo
        private object bloqueador = new object();

        private ListaEnlazada lista = new ListaEnlazada();

        private int numeroDeElementos;

        /// <summary>
        /// Número de elementos de la pila
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            lock (bloqueador)
            {
                return numeroDeElementos;
            }
        }

        /// <summary>
        /// Añade el elemento x pasado como parámetro
        /// en la última posición de la pila
        /// </summary>
        public void Push(int x)
        {
            lock (bloqueador)
            {
                lista.add(x);
                numeroDeElementos++;
            }
        }

        /// <summary>
        /// Borra el último elemento de la pila
        /// </summary>
        public void Pop()
        {
            lock (bloqueador)
            {
                if (lista.size() <= 0)
                    throw new IndexOutOfRangeException();

                else
                {
                    lista.remove(lista.size() - 1);
                    numeroDeElementos--;
                }
            }
        }

        /// <summary>
        /// Devuelve el valor del elemento que está en la posición
        /// pasada como parámetro
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int getElemento(int index)
        {
            lock (bloqueador)
            {
                if (index >= 0 && index < lista.size())
                    return lista.getElemento(index).value;
                return -1;
            }
        }


        /// <summary>
        /// Retornará true si la pila no contiene ningún elemento
        /// o sino false si contiene al menos un elemento
        /// </summary>
        /// <returns>True si está vacía la pila
        /// False en caso contrario</returns>
        public bool isEmpty()
        {
            lock (bloqueador)
            {
                if (lista.size() == 0)
                    return true;

                else
                    return false;
            }
        }

        /// <summary>
        ///  Método que imprime los elementos de la lista separados por coma
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            lock (bloqueador)
            {
                return lista.ToString();
            }
        }

        /// <summary>
        /// Método para añadir los números contenido en un fichero
        /// El nombre de este fichero es pasado como parámetro
        /// </summary>
        /// <param name="nombreFichero"></param>
        public void addDesdeFichero(string nombreFichero)
        {
            lock (bloqueador)
            {
                using (StreamReader stream = File.OpenText(nombreFichero))
                {
                    StringBuilder texto = new StringBuilder();
                    string linea;
                    while ((linea = stream.ReadLine()) != null)
                    {
                        string[] caracteres = PartirEnPalabras(linea);
                        for (int i = 0; i < caracteres.Length; i++)
                        {
                            lista.add(Convert.ToInt32(caracteres[i]));
                            numeroDeElementos++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método para añadir todos los números contenidos en los ficheros de un
        /// directorio cuyo nombre es pasado como parámetro
        /// Utiliza el método addDesdeFichero hecho anterior
        /// </summary>
        /// <param name="nombreDirectorio"></param>
        public void addDesdeDirectorio(string nombreDirectorio)
        {
            string[] ficheros = Directory.GetFiles(nombreDirectorio);

            lock (bloqueador)
            {
                for (int i = 0; i < ficheros.Length; i++)
                {
                    if (ficheros[i].Contains(".txt"))
                    {
                        Parallel.Invoke(() => addDesdeFichero(ficheros[i]));
                    }
                }
            }
        }

        /// <summary>
        /// Método auxiliar para separar los números por cualquier separador
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private static string[] PartirEnPalabras(String texto)
        {
            return texto.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
