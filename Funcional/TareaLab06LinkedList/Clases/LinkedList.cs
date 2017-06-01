using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class LinkedList<Object> : IEnumerable<Object>
    {
        public int numberOfElements { get; set; }
        public Node head { get; set; }

        public LinkedList()
        {
            this.numberOfElements = 0;
            this.head = null;
        }

        /**
         * Añade al final de la lista el elemento especificado 
         * @param value Elemento que se añade a la lista
         */
        public void addFinal(Object value)
        {
            if (isEmpty())
            {
                head = new Node(value, null);
                this.numberOfElements++;
            }
            else
            {
                Node lastNode = getNode(size() - 1);
                lastNode.next = new Node(value, null);
                this.numberOfElements++;
            }


        }

        /**
	 * Inserta el elemento en la posición indicada en la lista.
	 * Desplaza el elemento actualmente en esa posición (si existe) y los elementos posteriores
     * a la derecha (añade uno a sus índices). 
	 * @param index Posicion donde se desea insertar el elemento
	 * @param value Elemento que se inserta 
	 */
        public void addPosicion(int index, Object value)
        {
            if (value == null || index < 0 || index > this.numberOfElements)
            {
                throw new System.ArgumentException("Parámetro incorrecto");
            }
            if (isEmpty())
            {
                head = new Node(value, null);
                this.numberOfElements++;
            }
            else if (index == 0)
            {
                Node newNode = new Node(value, head);
                head = newNode;
                this.numberOfElements++;
            }
            else
            {
                Node antNode = getNode(index - 1);
                Node newNode = new Node(value, antNode.next);
                antNode.next = newNode;
                this.numberOfElements++;
            }
        }

        /**
        * Devuelve el nodo localizado en la posicion indicada por el parametro index
        * @param int index posicion que quiero localizar
        * @return Node nodo localizado
        */
        private Node getNode(int index)
        {
            if (index < size() && index >= 0)
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
         * @param El elemento que se quiere borrar
         * @return El elemento de la collección. Null si no se encuentra en la colección
         */
        public Object remove(Object value)
        {
            int index = -1;
            for (int i = 0; i < this.size(); i++)
            {
                if (this.getElemento(i).Equals(value))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                Node nodeToRemove = getNode(index);
                if (index == 0)
                    head = nodeToRemove.next;
                else
                {
                    getNode(index - 1).next = nodeToRemove.next;
                }
                this.numberOfElements--;
                return (Object)nodeToRemove.value;
            }
            else
            {
                throw new System.ArgumentException("Elemento inexistente");
            }

        }

        /**
         * Devuelve el número de elementos que hay en la colección
         * @return El número de elementos de la colección
         */

        public int size()
        {
            return this.numberOfElements;
        }


        /**
         *  Indica si la colección contiene o no elementos
         * @return Devuelve <tt>true</tt> si la colección no contiene elementos <tt>false</tt> en caso contrario
         */

        public bool isEmpty()
        {
            return (size() == 0);
        }



        /**
         * Devuelve el elemento que se encuentra en la posición indicada de la lista. 
         * @param index Índice del elemento a recuperar
         * @return El elemento que se encuentra en la posición indicada de la lista  
         */
        public Object getElemento(int index)
        {
            if (index >= 0 && index <= this.numberOfElements && !this.isEmpty())
            {
                return (Object)getNode(index).value;
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
                if (getElemento(i).Equals(value))
                {
                    contenido = true;
                }
            }
            return contenido;
        }


        /**
         * Metodo toString que muestra la información de la lista
         */

        public String toString()
        {
            String cadena = "";
            for (int i = 0; i < this.size(); i++)
            {
                if (i == 0)
                {
                    cadena = cadena + this.getElemento(i).ToString();
                }
                else
                {
                    cadena = cadena + ", " + this.getElemento(i).ToString();
                }
            }
            return "[" + cadena + "]";
        }

        public IEnumerator<Object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
}



