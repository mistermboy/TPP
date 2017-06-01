using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class List : IList
    {
        public int numberOfElements { get; set; }
        public Node head { get; set; }

        public List()
        {
            numberOfElements = 0;
            head = null;
        }



        /**
         * Añade al inicio de la lista el elemento especificado 
        * @param value Elemento que se añade a la lista
         */
        public void AddPrincipio(Object value) //Añadir por el principio
        {
            Node nuevoNodo = new Node(value, null);
            nuevoNodo.value = value;
            if (numberOfElements == 0)
            {
                head = nuevoNodo;
            }
            else
            {
                nuevoNodo.next = head;
                head = nuevoNodo;
            }
            numberOfElements++;
        }



        /**
         * Añade al final de la lista el elemento especificado 
         * @param value Elemento que se añade a la lista
         */
        public void AddFinal(Object value)
        {
            if (IsEmpty())
            {
                head = new Node(value, null);
                numberOfElements++;
            }
            else
            {
                Node lastNode = GetNode(numberOfElements - 1);
                lastNode.next = new Node(value, null);
                numberOfElements++;
            }


        }

        /**
	 * Inserta el elemento en la posición indicada en la lista.
	 * Desplaza el elemento actualmente en esa posición (si existe) y los elementos posteriores
     * a la derecha (añade uno a sus índices). 
	 * @param index Posicion donde se desea insertar el elemento
	 * @param value Elemento que se inserta 
	 */
        public void AddPosicion(int index, Object value)
        {
            if (value == null || index < 0 || index > numberOfElements)
            {
                throw new System.ArgumentException("Parámetro incorrecto");
            }
            if (IsEmpty())
            {
                head = new Node(value, null);
                numberOfElements++;
            }
            else if (index == 0)
            {
                Node newNode = new Node(value, head);
                head = newNode;
                numberOfElements++;
            }
            else
            {
                Node antNode = GetNode(index - 1);
                Node newNode = new Node(value, antNode.next);
                antNode.next = newNode;
                numberOfElements++;
            }
        }

        /**
        * Devuelve el nodo localizado en la posicion indicada por el parametro index
        * @param int index posicion que quiero localizar
        * @return Node nodo localizado
        */
        private Node GetNode(int index)
        {
            if (index < numberOfElements && index >= 0)
            {
                Node aux = head;
                for (int i = 0; i < index; i++)
                    aux = aux.next;
                return aux;
            }
            else
                return null;
        }


        /**
         * Elimina el elemento de la colección que coincida con el parámetro 
         * Devuelve el elemento que fue eliminado de la colección 
         * @param El elemento que se quiere Borrar
         * @return El elemento de la collección. Null si no se encuentra en la colección
         */
        public Object Remove(Object value)
        {
            int index = -1;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (GetElemento(i).Equals(value))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                Node nodeToRemove = GetNode(index);
                if (index == 0)
                    head = nodeToRemove.next;
                else
                {
                    GetNode(index - 1).next = nodeToRemove.next;
                }
                numberOfElements--;
                return (Object)nodeToRemove.value;
            }
            else
            {
                throw new System.ArgumentException("Elemento inexistente");
            }

        }





        /**
         *  Indica si la colección contiene o no elementos
         * @return Devuelve <tt>true</tt> si la colección no contiene elementos <tt>false</tt> en caso contrario
         */

        public bool IsEmpty()
        {
            return (numberOfElements == 0);
        }



        /**
         * Devuelve el elemento que se encuentra en la posición indicada de la lista. 
         * @param index Índice del elemento a recuperar
         * @return El elemento que se encuentra en la posición indicada de la lista  
         */
        public Object GetElemento(int index)
        {
            if (index >= 0 && index <= numberOfElements && !IsEmpty())
            {
                return (Object)GetNode(index).value;
            }
            else
            {
                throw new System.ArgumentException("Indice fuera de los límites");
            }
        }

        /**
         * Método que devuelve true si el elemento está contenido dentro de la lista, false en caso contrario
         * @param Objeto para comprobar de tipo object
         * @return true si está contenido, false en caso contrario
         */
        public bool Contiene(Object value)
        {
            bool contenido = false;
            Node nodoAux = head;
            for (int i = 0; i < numberOfElements; i++)
            {
                if (GetElemento(i).Equals(value))
                {
                    contenido = true;
                }
            }
            return contenido;
        }


        /**
         * Metodo ToString que muestra la información de la lista
         */

        public String ToString()
        {
            String cadena = "";
            for (int i = 0; i < numberOfElements; i++)
            {
                if (i == 0)
                {
                    cadena = cadena + GetElemento(i).ToString();
                }
                else
                {
                    cadena = cadena + ", " + GetElemento(i).ToString();
                }
            }
            return "[" + cadena + "]";
        }

        public void Añadir(int index, object value)
        {
            AddPosicion(index, value);
        }

        public object Borrar(object value)
        {
           return  Remove(value);
        }
    }
}
