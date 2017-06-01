using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class LinkedList : IList
    {
        private Node cabecera = null;
        public int NumElementos { get; set; }

        public void AñadirPrincipio(Object info) //Añadir por el principio
        {
            Node nuevoNodo = new Node();
            nuevoNodo.Info = info;
            if (NumElementos == 0)
            {
                cabecera = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabecera;
                cabecera = nuevoNodo;
            }
            NumElementos++;
        }
        public void AñadirFinal(Object info) //Añadir por el final
        {
            Node nuevoNodo = new Node();
            nuevoNodo.Info = info;
            if (NumElementos == 0)
            {
                cabecera = nuevoNodo;
            }
            else
            {
                int posicion = NumElementos;
                Node nodoAux = cabecera;
                while (posicion > 1)
                {
                    nodoAux = nodoAux.Siguiente;
                    posicion--;
                }
                nuevoNodo.Siguiente = nodoAux.Siguiente;
                nodoAux.Siguiente = nuevoNodo;
            }
            NumElementos++;
        }
        public void AñadirPosicion(int posicion, Object info) //Añadir por la posicion
        {
            if (posicion > NumElementos || posicion < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node nuevoNodo = new Node();
            nuevoNodo.Info = info;
            if (posicion == 0)//principio
            {
                nuevoNodo.Siguiente = cabecera;
                cabecera = nuevoNodo;
            }
            else
            {
                Node nodoAux = cabecera;
                while (posicion > 1)
                {
                    nodoAux = nodoAux.Siguiente;
                    posicion--;
                }
                nuevoNodo.Siguiente = nodoAux.Siguiente;
                nodoAux.Siguiente = nuevoNodo;
            }
            NumElementos++;
        }
        public Object BorrarPrincipio()
        {
            Node nodoAux = new Node();
            Node nodoAux2 = cabecera;
            nodoAux = cabecera.Siguiente;
            cabecera.Siguiente = null;
            cabecera = nodoAux;
            NumElementos--;
            return nodoAux2.Info;
        }
        public void BorrarFinal()
        {
            int posicion = (NumElementos - 1);
            Node nodoAux = cabecera;
            while (posicion > 1)
            {
                nodoAux = nodoAux.Siguiente;
                posicion--;
            }
            nodoAux.Siguiente = null;
            NumElementos--;
        }

        public void BorrarPosicion(int posicion)
        {
            if (posicion > (NumElementos - 1) || posicion < 0)
            {
                throw new IndexOutOfRangeException();
            }


            if (posicion == 0)//principio
            {
                BorrarPrincipio();
            }
            else if (posicion == (NumElementos - 1))
            {
                BorrarFinal();
            }
            else
            {
                Node nodoAux = cabecera;
                while (posicion > 1)
                {
                    nodoAux = nodoAux.Siguiente;
                    posicion--;
                }
                nodoAux.Siguiente = nodoAux.Siguiente.Siguiente;
                NumElementos--;
            }

        }

        /**
         * Devuelve El nodo en la posicion de index
         */
        private Node getNode(int index)
        {
            if (index < NumElementos && index >= 0)
            {
                Node aux = cabecera;
                for (int i = 0; i < index; i++)
                    aux = aux.Siguiente;
                return aux;
            }
            else
                return null;
        }

        public Object GetElementoPrimero()
        {
            return cabecera.Info;
        }

        public Object GetElementoFinal()
        {
            Node nodoAux = cabecera;
            int posicion = (NumElementos - 1);
            while (posicion > 0)
            {
                nodoAux = nodoAux.Siguiente;
                posicion--;
            }
            return nodoAux.Info;
        }

        public Object GetElementoPosicion(int posicion)
        {
            if (posicion < 0 || posicion > (NumElementos - 1))
            {
                throw new IndexOutOfRangeException();
            }
            Node nodoAux = cabecera;
            while (posicion > 0) //Empieza desde la posicion hacia atrás y cuando llega a 1 es que ha llegado a la posicion que le pasamos
            {
                nodoAux = nodoAux.Siguiente;
                posicion--;
            }
            return nodoAux.Info;
        }

        /*
         * Retorna "true" si lo encuentra y "false" en caso contrario
         * @param info el objeto que le pasamos
         */
        public bool Contiene(Object info)
        {
            Node nodoAux = cabecera;
            for (int i = 0; i < NumElementos; i++)
            {
                if (GetElementoPosicion(i).Equals(info))
                {
                    return true;
                }
            }
            return false;
        }

        public String toString()
        {
            string cadena = "";
            for (int i = 0; i < NumElementos; i++)
            {
                cadena += GetElementoPosicion(i).ToString() + "  ";
            }
            return cadena;
        }


        public void Añadir(int i, object info)
        {
            AñadirPosicion(i, info);
        }

        public void Borrar(int i)
        {
            BorrarPosicion(i);
        }

        public object GetElemento(int i)
        {
            return GetElementoPosicion(i);
        }
    }
}
