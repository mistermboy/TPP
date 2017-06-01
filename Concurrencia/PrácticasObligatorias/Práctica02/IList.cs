using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaSesion01
{
    interface IList
    {
        void Añadir(int i,object info);
        void Borrar(int i);
        bool Contiene(object info);
        object GetElemento(int i);
    }
}
