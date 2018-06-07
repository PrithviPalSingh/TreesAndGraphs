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

        public IEnumerable<string> Keys()
        {
            Queue<string> queue = new Queue<string>();
            Collect(Root, "", queue);
            return queue;
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            Queue<string> queue = new Queue<string>();
            Node prefixRoot = get(Root, prefix, 0);
            Collect(prefixRoot, prefix, queue);
            return queue;
        }

        public string LongestPrefix(string query)
        {
            int length = SearchLongestPrefixValue(Root, query, 0, 0);
            return query.Substring(0, length);
        }

        private int SearchLongestPrefixValue(Node x, string query, int d, int length)
        {
            if (x == null)
                return length;

            if (x.value != null)
                length = d;

            if (d == query.Length)
                return length;

            char c = query[d];

            return SearchLongestPrefixValue(x.next[c], query, d + 1, length);
        }

        private void Collect(Node x, string prefix, Queue<string> q)
        {
            if (x == null)
                return;

            if (x.value != null)
                q.Enqueue(prefix);

            for (char c = (char)0; c < R; c++)
            {
                Collect(x.next[c], prefix + c, q);
            }
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
