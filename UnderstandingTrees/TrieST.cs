using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TrieST<V>
    {
        private const int R = 256;

        private Node Root = new Node();

        private class Node
        {
            public V value;
            public Node[] next = new Node[R];
        }

        public void Put(string key, V value)
        {
            Root = put(Root, key, value, 0);
        }

        public V Get(string key)
        {
            Node x = get(Root, key, 0);
            if (x == null)
                return default(V);

            return x.value;
        }

        public bool Contains(string key)
        {
            return Get(key) != null;
        }

        private Node put(Node x, string key, V value, int d)
        {
            if (x == null)
                x = new Node();

            if (d == key.Length)
            {
                x.value = value;
                return x;
            }

            char c = key[d];

            x.next[c] = put(x.next[c], key, value, d + 1);
            return x;
        }

        private Node get(Node x, string key, int d)
        {
            if (x == null)
                return null;

            if (d == key.Length)
                return x;

            char c = key[d];

            return get(x.next[c], key, d + 1);
        }
    }
}
