using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Par<T> : IComparable<Par<T>> where T : IComparable<T>
    {
        private char v1;
        private char v2;

        T first { get; set; }
        T second { get; set; }

        public Par(T f, T s)
        {
            this.first = f;
            this.second = s;
        }


        public int CompareTo(Par<T> other)
        {
            if(this.first.CompareTo(other.first) < 0)
            {
                return -1;
            }
            if (this.first.CompareTo(other.first) > 0)
            {
                return 1;
            }
            else
            {
                if (this.second.CompareTo(other.second) < 0)
                {
                    return -1;
                }
                if (this.second.CompareTo(other.second) > 0){
                    return 1;
                }
                return 0;
            }
                
            }


        public String toString()
        {
            return ("[" + first.ToString() + "," + second.ToString() + "]");
        }
        }
    }

