using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaSesion01
{
    public class Pila : IPila
    {

        private LinkedList pila = new LinkedList();
        private uint numeroMaxElementos = 0;

        public bool estaVacia
        {
            get
            {
                return pila.NumElementos == 0;
            }
        }

        public bool estaLlena
        {
            get
            {
                return pila.NumElementos == numeroMaxElementos;
            }
        }

        public Pila(uint numeroMaxElementos)
        {
            this.numeroMaxElementos = numeroMaxElementos;
        }

        public void Push(Object info)
        {
            pilaLLena();
            if (info == null)
                throw new ArgumentException("El valor del parametro info es incorrecto");
            pila.AñadirPrincipio(info);
        }

        public object Pop()
        {
            pilaVacia();
            return pila.BorrarPrincipio();
        }

        private void pilaLLena()
        {
            if (estaLlena == true)
                throw new InvalidOperationException("La invariante pila está en una situación incorrecta");
        }

        private void pilaVacia()
        {
            if (estaVacia == true)
                throw new InvalidOperationException("La invariante pila está en una situación incorrecta");
        }
    }
}
