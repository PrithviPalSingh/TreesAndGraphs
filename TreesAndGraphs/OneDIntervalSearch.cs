using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class OneDIntervalSearch<TKey, TValue> where TKey : IComparable<TKey>
    {
        private OneDIntervalSearchNode<TKey> Root;


        /// <summary>
        /// Insret item into a BST
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(TKey lowerkey, TKey upperKey)
        {
            Root = Put(Root, lowerkey, upperKey);
        }

        private OneDIntervalSearchNode<TKey> Put(OneDIntervalSearchNode<TKey> node, TKey lowerKey, TKey upperkey)
        {
            if (node == null)
            {
                var a = new OneDIntervalSearchNode<TKey>(lowerKey, upperkey);
                return a;
            }

            int cmp = lowerKey.CompareTo(node.LowerKey);
            if (cmp < 0)
                node.LeftNode = Put(node.LeftNode, lowerKey, upperkey);
            else if (cmp > 0)
                node.RightNode = Put(node.RightNode, lowerKey, upperkey);
            else
                node.Value = string.Concat(lowerKey.ToString(), ",", upperkey.ToString()); ;

            if (node.RightNode != null && node.RightNode.MaximumEndPoint.CompareTo(node.MaximumEndPoint) > 0)
            {
                node.MaximumEndPoint = node.RightNode.MaximumEndPoint;
            }

            return node;
        }

        public string Get(TKey lowerKey, TKey upperKey)
        {
            OneDIntervalSearchNode<TKey> x = Root;

            while (x != null)
            {
                if (Intersect(x.LowerKey, x.UpperKey, lowerKey, upperKey, x.MaximumEndPoint))
                {
                    return x.Value;
                }
                else if (x.LeftNode == null)
                {
                    x = x.RightNode;
                }
                else if (x.LeftNode.MaximumEndPoint.CompareTo(lowerKey) < 0)
                {
                    x = x.RightNode;
                }
                else
                {
                    x = x.LeftNode;
                }
            }

            return "Not Found";
        }

        private bool Intersect(TKey nodeLowerkey, TKey nodeUpperKey, TKey lowerKey, TKey upperKey, TKey maxEndPoint)
        {
            if (nodeLowerkey.CompareTo(lowerKey) <= 0 && nodeUpperKey.CompareTo(upperKey) >= 0)
                return true;
            else if (nodeUpperKey.CompareTo(lowerKey) >= 0 && upperKey.CompareTo(maxEndPoint) > 0)
                return true;

            return false;
        }
    }
}
