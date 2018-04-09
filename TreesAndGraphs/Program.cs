using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class Program
    {
        /// <summary>
        /// S, E, A, X, C, R, H, M,
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BinarySearchTree bs = new BinarySearchTree();
            bs.Put(12, "S");
            bs.Put(5, "E");
            bs.Put(3, "A");
            bs.Put(23, "X");
            bs.Put(4, "C");
            bs.Put(11, "R");
            bs.Put(9, "H");
            bs.Put(10, "M");

            //var a = bs.Iterator();
            //Console.WriteLine(bs.Get(5));
            //bs.DeleteMinimum();
            //Console.WriteLine((bs.Min()).Value);
            //bs.DeleteMinimum();
            //Console.WriteLine((bs.Min()).Value);
            //Console.WriteLine(bs.Get(10));

            Console.WriteLine(bs.Rank(12));
            
            Console.Read();
        }
    }
}
