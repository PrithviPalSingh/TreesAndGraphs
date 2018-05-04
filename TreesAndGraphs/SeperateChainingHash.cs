using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class SeperateChainingHash<Key, Value>
    {
        private static int M = 4;
        private SCNode[] st = new SCNode[M];

        private class SCNode
        {
            private object key = null;
            private object value = null;
            private SCNode next = null;

            public SCNode(Key key, Value value, SCNode next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
            }

            public object Key { get => key; set => key = value; }
            public object Value { get => value; set => this.value = value; }
            public SCNode Next { get => next; set => next = value; }
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0X7fffffff) % M;
        }

        public Value Get(Key key)
        {
            int i = Hash(key);
            for (SCNode x = st[i]; x != null; x = x.Next)
            {
                if (key.Equals(x.Key))
                    return (Value)x.Value;
            }

            return default(Value);
        }

        public void Put(Key key, Value value)
        {
            int i = Hash(key);
            for (SCNode x = st[i]; x != null; x = x.Next)
            {
                if (key.Equals(x.Key))
                {
                    x.Value = value;
                    return;
                }
            }

            st[i] = new SCNode(key, value, st[i]);
        }
    }
}
