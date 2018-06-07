using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class OneDIntervalSearchNode<TKey>
    {
        private TKey lowerKey;
        private TKey upperKey;
        private string value;
        private OneDIntervalSearchNode<TKey> leftNode;
        private OneDIntervalSearchNode<TKey> rightNode;
        private TKey maximumEndPoint;

        public OneDIntervalSearchNode(TKey lowerKey, TKey upperKey)
        {
            this.lowerKey = lowerKey;
            this.upperKey = upperKey;
            this.Value = string.Concat(lowerKey.ToString(),"," , upperKey.ToString());
            this.maximumEndPoint = upperKey;
        }

        public TKey LowerKey { get => lowerKey; set => lowerKey = value; }
        public TKey UpperKey { get => upperKey; set => upperKey = value; }
        public TKey MaximumEndPoint { get => maximumEndPoint; set => maximumEndPoint = value; }
        public string Value { get => value; set => this.value = value; }
        internal OneDIntervalSearchNode<TKey> LeftNode { get => leftNode; set => leftNode = value; }
        internal OneDIntervalSearchNode<TKey> RightNode { get => rightNode; set => rightNode = value; }
    }
}
