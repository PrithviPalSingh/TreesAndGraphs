﻿using System;
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
            bs.Put(18, "S"); //6            
            bs.Put(5, "E"); //2            
            bs.Put(3, "A"); //0            
            bs.Put(15, "R"); ///5
            bs.Put(4, "C"); //1
            bs.Put(9, "H"); //3
            bs.Put(23, "X"); //7
            bs.Put(10, "M"); //4
            //bs.Put(12, "P"); //5
            //bs.Put(6, "L");
            //Console.WriteLine(bs.Size());
            //Console.WriteLine(bs.Rank(5));//2
            //Console.WriteLine(bs.Rank(19));
            //Console.WriteLine(bs.RangeCount(5, 18));
            //bs.RangeValues(5, 18);
            //Console.WriteLine(bs.RangeCount(5, 19));
            //bs.RangeValues(5, 19);
            //Console.WriteLine(bs.RangeCount(6, 18));
            //bs.RangeValues(6, 18);
            //Console.WriteLine(bs.RangeCount(6, 19));
            //bs.RangeValues(6, 19);
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

            //#region -- RBT test area
            //RedBlackSearchTree rbs = new RedBlackSearchTree();
            //rbs.Put(18, "S");
            //rbs.Put(5, "E");
            //rbs.Put(3, "A");
            //rbs.Put(15, "R");
            //rbs.Put(4, "C");
            //rbs.Put(9, "H");
            //rbs.Put(23, "X");
            //rbs.Put(10, "M");
            //rbs.Put(12, "P");
            //rbs.Put(6, "L");

            ////var a = rbs.Iterator();
            ////foreach (var item in a)
            ////{
            ////    Console.WriteLine(rbs.Get(item));
            ////}

            //Console.WriteLine(rbs.Size());
            //Console.WriteLine(rbs.Rank(5));
            //#endregion

            #region - Hash Functions Understanding
            string str1 = "polygenelubricant";
            int count = 0;
            for (int i = 0; i < 10000; i++)
            {
                str1 = str1 + i;
                //var abc = str1.GetHashCode() % 8;
                //var abc = Math.Abs(str1.GetHashCode()) % 8;
                var abc = (str1.GetHashCode() & 0X7fffffff) % 8;
                if (abc < 0)
                {
                    count++;
                }
            }
            //Console.WriteLine(Math.Abs(str1.GetHashCode()));
            //Console.WriteLine(str1.GetHashCode() & 0X7fffffff);
            //Console.WriteLine(-2 & 0X7fffffff);
            Console.WriteLine("Done: " + count);
            #endregion
            Console.Read();
        }
    }
}
