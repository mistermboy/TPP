using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaSesion01
{
    public class LinkedList : IList
    {
        private Node cabecera = null;
        public int NumElementos { get; set; }
        public bool Estávacía
        {
            get { return NumElementos > 0;}
        }

        public Object PrimerElemento
        {
           get{ return cabecera.Info; }
        }

        //Objeto bloqueador
        public object bloqueador = new object();

        
        public void Añadir(Object info) //Añadir por el final
        {
            lock (bloqueador)
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

        public String toString()
        {
            string cadena = "";
            for (int i = 0; i < NumElementos; i++)
            {
                cadena += GetElementoPosicion(i).ToString() + "  ";
            }
            return cadena;
        }

    }
}
