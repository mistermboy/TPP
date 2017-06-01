using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class Nodo
    {
        public Nodo next;
        public int value;

        public Nodo(Nodo next, int value)
        {
            this.next = next;
            this.value = value;
        }

    }
}
