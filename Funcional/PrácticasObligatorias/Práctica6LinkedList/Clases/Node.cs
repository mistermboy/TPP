using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Node
    {
        public Object value;
        public Node next;
        public Node(Object value, Node next)
        {
            this.value = value;
            this.next = next;


        }
    }
}
