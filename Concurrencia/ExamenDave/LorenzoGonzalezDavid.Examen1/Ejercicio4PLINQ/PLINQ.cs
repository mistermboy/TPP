using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class PLINQ
    {
        public static int SumaMayoresQue(IEnumerable<int> vector, int num)
        {
            int result = vector.Where(e => e > num).Aggregate((x,y) => x + y);
            return result;
        }

        static void Main(string[] args)
        {

        }
    }
}
