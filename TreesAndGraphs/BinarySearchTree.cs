using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
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
    /// </summary>
    class BinarySearchTree
    {
        private Node Root;
        
        /// <summary>
        /// Insret item into a BST
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(int key, string value)
        {
            Root = Put(Root, key, value);
        }


        /// <summary>
        /// Fetch an item from BST
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(int? key)
        {
            Node x = Root;
            while (x != null)
            {
                if (key > x.Key)
                {
                    x = x.Right;
                }
                else if (key < x.Key)
                {
                    x = x.Left;
                }
                else
                {
                    return x.Value;
                }
            }

            return null;
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
        public void Delete(int key)
        {
            Delete(key, Root);
        }

        /// <summary>
        /// Find minimum in BST
        /// </summary>
        /// <returns></returns>
        public Node Min()
        {
            return Min(Root);
        }

        /// <summary>
        /// Get floor value in BST i.e. immediate lower value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int? Floor(int key)
        {
            Node x = Floor(Root, key);
            if (x == null)
                return null;

            return x.Key;
        }

        /// <summary>
        /// Get ceiling value i.e. immediate upper value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int? Ceiling(int key)
        {
            Node x = Ceiling(Root, key);
            if (x == null)
                return null;

            return x.Key;
        }

        /// <summary>
        /// form an iterator for BST
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int?> Iterator()
        {
            Queue<int?> q = new Queue<int?>();
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
        public int? Rank(int? key)
        {
            return Rank(key, Root);
        }

        public int? RangeCount(int low, int high)
        {
            return !string.IsNullOrWhiteSpace(Get(high)) ? 1 + Rank(high) - Rank(low) : Rank(high) - Rank(low);
        }

        public void RangeValues(int low, int high)
        {
            Queue<int?> q = new Queue<int?>();
            var a = Iterator();
            foreach (var i in a)
            {
                if (i >= low && i <= high)
                {
                    q.Enqueue(i);
                }
            }

            foreach (int i in q)
            {
                Console.Write(Get(i) + " ");
            }

            Console.WriteLine();

            q = new Queue<int?>();
            var item = Root;
            ProcessRangeValues(item, low, high, q);
            foreach (int i in q)
            {
                Console.Write(Get(i) + " ");
            }

            Console.WriteLine();
        }

        private void ProcessRangeValues(Node item, int low, int high, Queue<int?> q)
        {
            if (item == null)
            {
                return;
            }

            if (item.Key >= low && item.Key <= high)
            {
                q.Enqueue(item.Key);
                ProcessRangeValues(item.Left, low, high, q);
                ProcessRangeValues(item.Right, low, high, q);
            }
        }

        ////TODO: Understand count
        private Node Put(Node node, int key, string value)
        {
            if (node == null)
            {
                var a = new Node(key, value);
                a.Count = 1;
                return a;
            }

            if (key > node.Key)
                node.Right = Put(node.Right, key, value);
            else if (key < node.Key)
                node.Left = Put(node.Left, key, value);
            else
                node.Value = value;

            node.Count = 1 + Size(node.Left) + Size(node.Right);

            return node;
        }

        private void InOrder(Node x, Queue<int?> q)
        {
            if (x == null)
                return;

            InOrder(x.Left, q);
            q.Enqueue(x.Key);
            InOrder(x.Right, q);
        }

        private Node Floor(Node x, int key)
        {
            if (x == null)
                return null;

            if (key == x.Key)
                return x;

            if (key < x.Key)
                return Floor(x.Left, key);

            Node t = Floor(x.Right, key);
            if (t != null)
                return t;

            return x;
        }

        private Node Ceiling(Node x, int? key)
        {
            if (x == null)
                return null;

            if (key == x.Key)
                return x;

            if (key > x.Key)
            {
                return Ceiling(x.Right, key);
            }

            Node t = Ceiling(x.Left, key);
            if (t != null)
                return t;

            return x;
        }

        private int Size(Node x)
        {
            if (x == null)
                return 0;

            return x.Count;
        }

        private int? Rank(int? key, Node x)
        {
            if (x == null)
                return 0;

            if (key < x.Key)
                return Rank(key, x.Left);
            else if (key > x.Key)
                return 1 + Size(x.Left) + Rank(key, x.Right);
            else
                return Size(x.Left);
        }

        private Node DeleteMinimum(Node x)
        {
            if (x.Left == null)
                return x.Right;

            x.Left = DeleteMinimum(x.Left);
            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private Node Delete(int key, Node x)
        {
            if (x == null)
                return null;

            if (key < x.Key)
            {
                x.Left = Delete(key, x.Left);
            }
            else if (key > x.Key)
            {
                x.Right = Delete(key, x.Right);
            }
            else
            {
                if (x.Right == null)
                    return x.Left;

                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMinimum(t.Right);
                x.Left = t.Left;
            }

            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private Node Min(Node x)
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