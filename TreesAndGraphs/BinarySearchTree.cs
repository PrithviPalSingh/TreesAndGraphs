using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class BinarySearchTree
    {
        private Node Root;

        public void Put(int key, string value)
        {
            Root = Put(Root, key, value);
        }

        public string Get(int key)
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

        public void DeleteMinimum()
        {
            DeleteMinimum(Root);
        }

        /// <summary>
        /// Hibbard deletion
        /// </summary>
        /// <param name="key"></param>
        public void Delete(int key)
        {
            Delete(key, Root);
        }

        public Node Min()
        {
            return Min(Root);
        }

        public int? Floor(int key)
        {
            Node x = Floor(Root, key);
            if (x == null)
                return null;

            return x.Key;
        }

        public int? Ceiling(int key)
        {
            Node x = Ceiling(Root, key);
            if (x == null)
                return null;

            return x.Key;
        }

        public IEnumerable<int?> Iterator()
        {
            Queue<int?> q = new Queue<int?>();
            InOrder(Root, q);
            return q;
        }

        public int Size()
        {
            return Size(Root);
        }

        public int? Rank(int key)
        {
            return Rank(key, Root);
        }

        private Node Put(Node node, int key, string value)
        {
            if (node == null)
            {
                var a= new Node(key, value);
                a.Count += 1;
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

        private int? Rank(int key, Node x)
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
