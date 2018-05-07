using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        /// <summary>
        /// S, E, A, X, C, R, H, M,
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TestBinarySearchTree();
            Console.Read();
        }

        static void TestFileIndexing()
        {
            FileIndexing f = new FileIndexing();
            f.Indexing();
        }

        static void TestBinarySearchTree()
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
            bs.Put(12, "P"); //5
            bs.Put(6, "L");
            //Console.WriteLine(bs.Size());
            //Console.WriteLine(bs.Rank(5));//2
            //Console.WriteLine(bs.Rank(19));
            Console.WriteLine(bs.RangeCount(5, 18));
            bs.RangeValues(5, 18);
            Console.WriteLine(bs.RangeCount(5, 19));
            bs.RangeValues(5, 19);
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
        }

        static void TestRedBlackTree()
        {
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
                Console.Write(rbs.Get(item) + " ");
            }
            Console.WriteLine();
            rbs.Delete(6);
            a = rbs.Iterator();
            foreach (var item in a)
            {
                Console.Write(rbs.Get(item) + " ");
            }

            Console.WriteLine();
            Console.WriteLine(rbs.Size());
            Console.WriteLine(rbs.Rank(5));
            #endregion
        }

        static void TestHashFunctions()
        {
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
            Console.WriteLine(Math.Abs(str1.GetHashCode()));
            Console.WriteLine(str1.GetHashCode() & 0X7fffffff);
            Console.WriteLine(-2 & 0X7fffffff);
            Console.WriteLine("Done: " + count);

            Console.WriteLine("Aa".GetHashCode());
            Console.WriteLine("BB".GetHashCode());
            #endregion
        }

        static void TestSeperateChaining()
        {
            SeperateChainingHash<string, string> sc = new SeperateChainingHash<string, string>();
            sc.Put("S", "S");
            sc.Put("E", "E");
            sc.Put("A", "A");
            sc.Put("R", "R");
            sc.Put("C", "C");
            sc.Put("H", "H");
            sc.Put("E", "E");
            sc.Put("X", "X");
            sc.Put("A", "A");
            sc.Put("M", "M");
            sc.Put("P", "P");
            sc.Put("L", "L");
            sc.Put("E", "E");
            Console.WriteLine(sc.Get("E"));
        }

        static void TestLinearProbing()
        {
            LinearProbingHash<string, string> lph = new LinearProbingHash<string, string>();
            lph.Put("S", "S");
            lph.Put("E", "E");
            lph.Put("A", "A");
            lph.Put("R", "R");
            lph.Put("C", "C");
            lph.Put("H", "H");
            lph.Put("E", "E");
            lph.Put("X", "X");
            lph.Put("A", "A");
            lph.Put("M", "M");
            lph.Put("P", "P");
            lph.Put("L", "L");
            lph.Put("E", "E");
            Console.WriteLine(lph.Get("P"));
        }
        static void TestSegmentTree()
        {
            int[] arr = { 1, 3, 5, 7, 9, 11 };
            int n = arr.Length;
            SegmentTree st = new SegmentTree();
            var stArray = st.constructST(arr, arr.Length);
            Console.WriteLine(string.Join(" ", stArray));
            Console.WriteLine(st.getSum(stArray, n, 0, 2));
            st.updateValue(arr, stArray, n, 2, 10);
            Console.WriteLine(st.getSum(stArray, n, 0, 2));
            Console.Read();
        }

        ////Sparse vector implementation
        static void TestSparseVector()
        {
            SparseVector[] st = new SparseVector[5];
            st[0] = new SparseVector();
            st[1] = new SparseVector();
            st[2] = new SparseVector();
            st[3] = new SparseVector();
            st[4] = new SparseVector();
            st[0].Put(1, .90);
            st[1].Put(2, .36);
            st[1].Put(3, .36);
            st[1].Put(4, .18);
            st[2].Put(3, .90);
            st[3].Put(0, .90);
            st[4].Put(0, .47);
            st[4].Put(2, .47);

            double[] x = { .05, .04, .36, .37, .19 };
            double[] b = new double[5];

            for (int i = 0; i < 5; i++)
            {
                b[i] = st[i].dot(x);
            }

            foreach (var item in b)
            {
                Console.WriteLine(item);
            }
        }

        static void TestBSTGeneric()
        {
            BinarySearchTreeGeneric<string, string> bs = new BinarySearchTreeGeneric<string, string>();
            bs.Put("S", "S"); //6            
            bs.Put("E", "E"); //2            
            bs.Put("A", "A"); //0            
            bs.Put("R", "R"); ///5
            bs.Put("C", "C"); //1
            bs.Put("H", "H"); //3
            bs.Put("E", "E"); //7
            bs.Put("X", "X"); //4
            bs.Put("A", "A"); //6            
            bs.Put("M", "M"); //2            
            bs.Put("P", "P"); //0            
            bs.Put("L", "L"); ///5
            bs.Put("E", "E"); //1
            var a = bs.Iterator();
            foreach (var item in a)
            {
                Console.Write(bs.Get(item) + " ");
            }

            // bs.Delete("S");
            Console.WriteLine();
            //a = bs.Iterator();
            //foreach (var item in a)
            //{
            //    Console.Write(bs.Get(item) + " ");
            //}
            //Console.WriteLine(bs.Floor("T"));
            //Console.WriteLine(bs.Ceiling("T"));

            //Console.WriteLine(bs.Size());
            //bs.Delete("S");
            //Console.WriteLine(bs.Size());

            //Console.WriteLine(bs.Rank("A"));
            //Console.WriteLine(bs.Rank("C"));
            //Console.WriteLine(bs.Rank("E"));
            //Console.WriteLine(bs.Rank("S"));
            //Console.WriteLine(bs.Rank("X"));
            //bs.Delete("E");
            //Console.WriteLine(bs.Rank("A"));
            //Console.WriteLine(bs.Rank("C"));
            //Console.WriteLine(bs.Rank("E"));
            //Console.WriteLine(bs.Rank("S"));
            //Console.WriteLine(bs.Rank("X"));

            //Console.WriteLine(bs.Min());

            Console.WriteLine(bs.RangeCount("A", "Q"));
            bs.RangeValues("A", "Q");
        }
    }
}
