using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class Node
    {
        private int? key;
        private string value;
        private Node left;
        private Node right;
        private int count;

        public Node(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int? Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
        public int Count { get => count; set => count = value; }
        internal Node Left { get => left; set => left = value; }
        internal Node Right { get => right; set => right = value; }
    }
}
