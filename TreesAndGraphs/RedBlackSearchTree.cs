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
    ///    2.8 Set the color for node as RED if it is splitted from a 3-Node.
    ///    2.9 Cases
    ///         2.9.1 Right child red, left child black - LEFT ROTATE
    ///         2.9.2 Right and Left child red - FLIP COLOR
    ///         2.9.3 Left child and left grandchild red - RIGHT ROTATE
    /// 3. For 2-3 tree
    ///    3.1 2-Node: one key, two children
    ///    3.2 3-Node: two keys, three children
    ///    3.3 Every path from root to null node is of same length
    /// </summary>
    class RedBlackSearchTree
    {
        private const bool RED = true;

        private const bool BLACK = false;

        private RedBlackTreeNode Root;

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
            RedBlackTreeNode x = Root;
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
        public RedBlackTreeNode Min()
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
            RedBlackTreeNode x = Floor(Root, key);
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
            RedBlackTreeNode x = Ceiling(Root, key);
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
        public int? Rank(int key)
        {
            return Rank(key, Root);
        }

        /// <summary>
        /// 1. Always mantain 1:1 correspondance to 2-3 trees by applying elementary red-black tree BST operations.
        /// 2. Right child red, left child black - Rotate left
        /// 3. Left child red, left-left grandchlild red - Rotate right
        /// 4. Both child red -  Flip colors
        /// </summary>
        /// <param name="h"></param>
        private RedBlackTreeNode Put(RedBlackTreeNode h, int key, string value)
        {
            if (h == null)
            {
                var a = new RedBlackTreeNode(key, value, RED);                
                return a;
            }

            if (key > h.Key)
                h.Right = Put(h.Right, key, value);
            else if (key < h.Key)
                h.Left = Put(h.Left, key, value);
            else
                h.Value = value;            

            if (IsRedLink(h.Right) && !IsRedLink(h.Left)) // Lean left
                h = LeftRotation(h);

            if (IsRedLink(h.Left) && IsRedLink(h.Left.Left)) // Balance 4-nodes
                h = RightRotation(h);

            if (IsRedLink(h.Left) && IsRedLink(h.Right)) //  split 4-node
                FlipColors(h);

            h.Count = 1 + Size(h.Left) + Size(h.Right);

            return h;
        }

        private void InOrder(RedBlackTreeNode x, Queue<int?> q)
        {
            if (x == null)
                return;

            InOrder(x.Left, q);
            q.Enqueue(x.Key);
            InOrder(x.Right, q);
        }

        private RedBlackTreeNode Floor(RedBlackTreeNode x, int key)
        {
            if (x == null)
                return null;

            if (key == x.Key)
                return x;

            if (key < x.Key)
                return Floor(x.Left, key);

            RedBlackTreeNode t = Floor(x.Right, key);
            if (t != null)
                return t;

            return x;
        }

        private RedBlackTreeNode Ceiling(RedBlackTreeNode x, int? key)
        {
            if (x == null)
                return null;

            if (key == x.Key)
                return x;

            if (key > x.Key)
            {
                return Ceiling(x.Right, key);
            }

            RedBlackTreeNode t = Ceiling(x.Left, key);
            if (t != null)
                return t;

            return x;
        }

        private int Size(RedBlackTreeNode x)
        {
            if (x == null)
                return 0;

            return x.Count;
        }

        private int? Rank(int key, RedBlackTreeNode x)
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

        private RedBlackTreeNode DeleteMinimum(RedBlackTreeNode x)
        {
            if (x.Left == null)
                return x.Right;

            x.Left = DeleteMinimum(x.Left);
            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private RedBlackTreeNode Delete(int key, RedBlackTreeNode x)
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

                RedBlackTreeNode t = x;
                x = Min(t.Right);
                x.Right = DeleteMinimum(t.Right);
                x.Left = t.Left;
            }

            x.Count = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        private RedBlackTreeNode Min(RedBlackTreeNode x)
        {
            if (x == null)
                return null;

            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }

        private bool IsRedLink(RedBlackTreeNode x)
        {
            if (x == null)
                return false;

            return x.Color == RED;
        }

        /// <summary>
        /// Mantains symmetric order and perfect black tree
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackTreeNode LeftRotation(RedBlackTreeNode h)
        {
            RedBlackTreeNode x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            return x;
        }

        private RedBlackTreeNode RightRotation(RedBlackTreeNode h)
        {
            RedBlackTreeNode x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            return x;
        }

        /// <summary>
        /// Re-color to split a temporary 4 node.
        /// </summary>
        /// <param name="h"></param>
        private void FlipColors(RedBlackTreeNode h)
        {
            h.Color = RED;
            h.Left.Color = BLACK;
            h.Right.Color = BLACK;
        }
    }
}
