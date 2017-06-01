using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Pila : IPila

    {
        int numeroMaxElementos;
        private List pila;
        bool EstaVacía
        {
            get
            {
                if (pila.numberOfElements == 0)
                {
                    return true;
                }
                return false;
            }
        }
        bool EstaLLena
        {
            get
            {
                if (pila.numberOfElements == numeroMaxElementos)
                {
                    return true;
                }
                return false;
            }
        }


        public Pila(int num)
        {
            menorQueCero(num);
            pila = new List();
            this.numeroMaxElementos = num;
        }

        public void Push(Object obj)
        {
            ObjectNull(obj);
            PilaLLena();
            pila.AddPosicion(0, obj);
        }

        public Object Pop()
        {
            PilaVacia();
            return pila.Remove(pila.GetElemento(0));
        }



        private void ObjectNull(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("El objeto pasado por parámetro no es válido");
            }
        }

        private void PilaLLena()
        {
            if (Llena())
            {
                throw new InvalidOperationException("La pila está llena");
            }
        }

        private void PilaVacia()
        {
            if (Vacia())
            {
                throw new InvalidOperationException("La pila está vacía");
            }
        }

        private void menorQueCero(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Parámetro incorrecto");
            }
        }

        public bool Vacia()
        {
            return EstaVacía;
        }

        public bool Llena()
        {
            return EstaLLena;
        }
    }
}
