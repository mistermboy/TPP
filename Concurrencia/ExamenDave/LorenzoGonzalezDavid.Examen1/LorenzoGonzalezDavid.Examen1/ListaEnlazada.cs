using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class ListaEnlazada
    {

        /// <summary>
        /// Primer nodo de la lista
        /// </summary>
        private Nodo head;

        /// <summary>
        /// Número de elementos de la lista
        /// </summary>
        public int numElementos;


        /// <summary>
        /// Devuelve el número de elementos de la lista
        /// </summary>
        /// <returns>Tamaño de la lista</returns>
        public int size()
        {
            return numElementos;
        }

        /// <summary>
        /// Método que devuelve el Nodo de la posición pasada como parámetro
        /// </summary>
        /// <param name="index">Posición del nodo</param>
        /// <returns>Nodo que está en la posición pasada como parámetro</returns>
        public Nodo getElemento(int index)
        {
            if (index == 0)
                return head;

            if (index > 0 && index < size())
            {
                Nodo aux = head;
                for (int i = 0; i < index; i++)
                {
                    aux = aux.next;
                }
                return aux;
            }
            else
                return null;
        }

        /// <summary>
        /// Añade un elemento al final de la lista
        /// </summary>
        /// <param name="value">Elemento a añadir</param>
        public void add(int value)
        {
            if (size() == 0)
                head = new Nodo(null, value);

            else
            {
                Nodo last = getElemento(size() - 1);
                last.next = new Nodo(last.next, value);
            }
            numElementos++;
        }

        /// <summary>
        /// Añade un elemento al principio de la lita
        /// </summary>
        /// <param name="value"></param>
        public void addFirst(int value)
        {
            if (size() == 0)
                head = new Nodo(null, value);

            else
            {
                Nodo primero = new Nodo(head, value);
                head = primero;
                numElementos++;
            }
        }

        /// <summary>
        /// Método que borra el nodo de la posición pasada por parámetro
        /// </summary>
        /// <param name="index">Posición del elemento a borrar</param>
        public void remove(int index)
        {
            if (index < 0 || index > size())
                throw new IndexOutOfRangeException("Índice fuera de rango");

            if (index == 0)
            {
                head = head.next;
            }

            else
            {
                Nodo nodoABorrar = head;
                for (int i = 0; i < (index - 1); i++)
                {
                    nodoABorrar = nodoABorrar.next;
                }
                nodoABorrar.next = nodoABorrar.next.next;
            }
            numElementos--;
        }

        /// <summary>
        /// Método que imprime los elementos de la lista separados por coma
        /// </summary>
        /// <returns>Elementos de la lista</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Nodo nodo1 = head;
            if (size() > 0)
            {
                for (int i = 0; i < (size() - 1); i++)
                {
                    sb.Append(nodo1.value.ToString());
                    nodo1 = nodo1.next;
                    sb.Append(",");
                }
                sb.Append(nodo1.value.ToString());
            }
            return sb.ToString();
        }

    }
}
