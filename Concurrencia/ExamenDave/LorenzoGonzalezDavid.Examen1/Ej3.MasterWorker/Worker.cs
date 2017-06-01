using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorenzoGonzalezDavid.Examen1
{
    public class Worker
    {
        private int[] vector;

        private int fromIndex, toIndex;

        private long result;

        internal long Result
        {
            get { return this.result; }
        }

        internal Worker(int[] vector, int fromIndex, int toIndex)
        {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void NumVeces()
        {
            int num1 = vector[0];
            int num2 = vector[1];
            this.result = 0;
            for (int i = this.fromIndex; i <= this.toIndex - 1; i++)
            {
                if (vector[i].Equals(num1) && vector[i + 1].Equals(num2))
                    this.result++;
            }
        }
    }
}
