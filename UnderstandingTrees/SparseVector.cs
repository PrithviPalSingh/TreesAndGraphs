using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class SparseVector
    {
        private Dictionary<int, double> v;

        public SparseVector()
        {
            v = new Dictionary<int, double>();
        }

        public void Put(int key, double value)
        {
            v.Add(key, value);
        }

        public double Get(int key)
        {
            double ret = 0.00;
            if (v.TryGetValue(key, out ret))
            {
                return ret;
            }

            return 0.00;
        }
        
        public double dot(double[] numArray)
        {
            double sum = 0.00;
            foreach (var item in v.Keys)
            {
                sum += numArray[item] * Get(item);
            }

            return sum;
        }

    }
}
