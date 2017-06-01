using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    interface IList
    { 
        void Añadir(int index, Object value);
        Object Borrar(Object value);
        Object GetElemento(int index);
        bool Contiene(Object value);

    }
}
