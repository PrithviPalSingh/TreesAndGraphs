using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class RedBlackTreeNode : Node
    {
        private bool color;
        private RedBlackTreeNode left;
        private RedBlackTreeNode right;

        public RedBlackTreeNode(int key, string value, bool color)
            : base(key, value)
        {
            this.Color = color;
        }

        public bool Color { get => color; set => color = value; }
        internal new RedBlackTreeNode Left { get => left; set => left = value; }
        internal new RedBlackTreeNode Right { get => right; set => right = value; }
    }
}
