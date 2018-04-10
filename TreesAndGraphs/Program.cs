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
            //Console.WriteLine(bs.Size());
            //var a = bs.Iterator();
            //foreach (var item in a)
            //{
            //    Console.WriteLine(bs.Get(item));
            //}

            //Console.WriteLine(bs.Get(5));
            //bs.DeleteMinimum();
            //Console.WriteLine((bs.Min()).Value);
            //bs.DeleteMinimum();
            //Console.WriteLine((bs.Min()).Value);
            //Console.WriteLine(bs.Get(10));

            ///Console.WriteLine(bs.Rank(12));

            #region -- RBT test area
            RedBlackSearchTree rbs = new RedBlackSearchTree();
            rbs.Put(18, "S");
            rbs.Put(5, "E");
            rbs.Put(3, "A");
            rbs.Put(15, "R");
            rbs.Put(4, "C");
            rbs.Put(9, "H");
            rbs.Put(23, "X");
            rbs.Put(10, "M");
            rbs.Put(12, "P");
            rbs.Put(6, "L");

            var a = rbs.Iterator();
            foreach (var item in a)
            {
                Console.WriteLine(rbs.Get(item));
            }

            Console.WriteLine(rbs.Size());
            #endregion



            Console.Read();
        }
    }
}
