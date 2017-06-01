using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public interface ILista<T> : IList<T>, IEnumerable<T>
    {
        void SafeCopyTo(ref T[] array, int arrayIndex);
    }
}
