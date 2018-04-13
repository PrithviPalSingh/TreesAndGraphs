using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class LinearProbingHash<Key, Value>
    {
        private static int M = 1001;

        private Value[] vals = new Value[M];

        private Key[] keys = new Key[M];

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0X7fffffff) % M;
        }

        public void Put(Key key, Value value)
        {
            int i;

            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    break;
                }
            }

            keys[i] = key;
            vals[i] = value;
        }

        public Value Get(Key key)
        {
            int i;

            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    return vals[i];
                }
            }

            return default(Value);
        }
    }
}
