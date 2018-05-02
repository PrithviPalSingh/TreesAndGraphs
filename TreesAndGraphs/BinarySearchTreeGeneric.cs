using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    /// <summary>
    /// 1. Left node key is smaller than key of root node and right node key is 
    ///    greater than key of root node.
    /// 2. For red black tree:
    ///    2.1 Larger key of 2-3 tree as root
    ///    2.2 Red link glues nodes within a 3-node.
    ///    2.3 Black link connects 2-nodes and 3-nodes
    ///    2.4 No node has two red link connected to it.
    ///    2.5 Every path from root to null link contains same number of black links
    ///    2.6 All red links lean left
    ///    2.7 Search for RB-BST is same as BST same is the case with Ceiling, Selection
    /// 3. Count- Number of nodes under a certain node x (including x)
    /// 4. Rank- Number of nodes that have keys less than certain node with that key.
    /// </summary>
    class BinarySearchTreeGeneric<TKey, TValue> where TKey : IComparable<TKey>
    {
        private GenericNode Root;

        private class GenericNode
        {
            private TKey key;
            private TValue value;
            private GenericNode left;
            private GenericNode right;
            private int count;

            public GenericNode(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }

            public TKey Key { get => key; set => key = value; }
            public TValue Value { get => value; set => this.value = value; }
            public GenericNode Right { get => right; set => right = value; }
            public GenericNode Left { get => left; set => left = value; }
            public int Count { get => count; set => count = value; }
        }

        /// <summary>
        /// Insret item into a BST
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(TKey key, TValue value)
        {
            Root = Put(Root, key, value);
        }

        /// <summary>
        /// Fetch an item from BST
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Get(TKey key)
        {
            GenericNode x = Root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.Key);
                if (cmp < 0)
                {
                    x = x.Left;
                }
                else if (cmp > 0)
                {
                    x = x.Right;
                }
                else
                {
                    return x.Value;
                }
            }

            return default(TValue);
        }

        /// <summary>
        /// Delete minimum i.e. leftmost item from BST.
        /// </summary>
        public void DeleteMinimum()
        {
            DeleteMinimum(Root);
        }

        /// <summary>
        /// Hibbard deletion - delete any item
        /// </summary>
        /// <param name="key"></param>
        public void Delete(TKey key)
        {
            Root = Delete(key, Root);
        }

        /// <summary>
        /// Find minimum in BST
        /// </summary>
        /// <returns></returns>
        public TKey Min()
        {
            var min = Min(Root);
            return min.Key;
        }

        /// <summary>
        /// Get floor value in BST i.e. immediate lower value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TKey Floor(TKey key)
        {
            GenericNode x = Floor(Root, key);
            if (x == null)
                return default(TKey);

            return x.Key;
        }

        /// <summary>
        /// Get ceiling value i.e. immediate upper value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TKey Ceiling(TKey key)
        {
            GenericNode x = Ceiling(Root, key);
            if (x == null)
                return default(TKey);

            return x.Key;
        }

        /// <summary>
        /// form an iterator for BST
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TKey> Iterator()
        {
            Queue<TKey> q = new Queue<TKey>();
            InOrder(Root, q);
            return q;
        }

        /// <summary>
        /// Get size of BST
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return Size(Root);
        }

        /// <summary>
        /// Get rank of a node
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(TKey key)
        {
            return Rank(key, Root);
        }

        public int RangeCount(TKey low, TKey high)
        {
            return Get(high) != null ? 1 + Rank(high) - Rank(low) : Rank(high) - Rank(low);
        }

        public void RangeValues(TKey low, TKey high)
        {
            Queue<TKey> q = new Queue<TKey>();
            var a = Iterator();
            foreach (var item in a)
            {
                int cmp1 = item.CompareTo(low);
                int cmp2 = item.CompareTo(high);
                if (cmp1 == -1 || cmp2 == 1)
                {
                    continue;
                }

                q.Enqueue(item);
            }

            foreach (var item in q)
            {
                Console.Write(Get(item) + " ");
            }

            Console.WriteLine();
        }

        ////TODO: Understand count
        private GenericNode Put(GenericNode node, TKey key, TValue value)
        {
            if (node == null)
            {
                var a = new GenericNode(key, value);
                a.Count = 1;
                return a;
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                node.Left = Put(node.Left, key, value);
            else if (cmp > 0)
                node.Right = Put(node.Right, key, value);
            else
                node.Value = value;

            node.Count = 1 + Size(node.Left) + Size(node.Right);

            return node;
        }

        private void InOrder(GenericNode x, Queue<TKey> q)
        {
            if (x == null)
                return;

            InOrder(x.Left, q);
            q.Enqueue(x.Key);
            InOrder(x.Right, q);
        }

        private GenericNode Floor(GenericNode x, TKey key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            if (cmp == 0)
                return x;

            if (cmp < 0)
                return Floor(x.Left, key);

            GenericNode t = Floor(x.Right, key);
            if (t != null)
                return t;
            else
                return x;
        }

        private GenericNode Ceiling(GenericNode x, TKey key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;

            if (cmp > 0)
            {
                return Ceiling(x.Right, key);
            }

            GenericNode t = Ceiling(x.Left, key);
            if (t != null)
                return t;
            else
                return x;
        }

        private int Size(GenericNode x)
        {
            if (x == null)
                return 0;

            return x.Count;
        }

        private int Rank(TKey key, GenericNode x)
        {
            if (x == null)
                return 0;

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
                return Rank(key, x.Left);
            else if (cmp > 0)
                return 1 + Size(x.Left) + Rank(key, x.Right);
            else
                return Size(x.Left);
        }

        private GenericNode DeleteMinimum(GenericNode x)
        {
            if (x.Left == null)
                return x.Right;

            x.Left = DeleteMinimum(x.Left);
            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private GenericNode Delete(TKey key, GenericNode x)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            //Search for key
            if (cmp < 0)
            {
                x.Left = Delete(key, x.Left);
            }
            else if (cmp > 0)
            {
                x.Right = Delete(key, x.Right);
            }
            else
            {
                if (x.Right == null)
                    return x.Left;

                GenericNode t = x;
                x = Min(t.Right);
                x.Right = DeleteMinimum(t.Right);
                x.Left = t.Left;
            }

            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private GenericNode Min(GenericNode x)
        {
            if (x == null)
                return null;

            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }

    }
}