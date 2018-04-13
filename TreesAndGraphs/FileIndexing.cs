using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class FileIndexing
    {
        public void Indexing()
        {
            string[] args = { @"E:\SelfStudy\Programs\InterviewPrep\Algos\TreesAndGraphs\TreesAndGraphs\content\Drinks.txt",
                @"E:\SelfStudy\Programs\InterviewPrep\Algos\TreesAndGraphs\TreesAndGraphs\content\Fruits.txt",
                @"E:\SelfStudy\Programs\InterviewPrep\Algos\TreesAndGraphs\TreesAndGraphs\content\Vegetables.txt" };
            Dictionary<string, HashSet<FileInfo>> st = new Dictionary<string, HashSet<FileInfo>>();

            foreach (var item in args)
            {
                FileInfo f = new FileInfo(item);
                var str = File.ReadAllText(f.FullName).Replace("\r\n", " ");
                var strAyyar = str.Split(' ');
                foreach (var s in strAyyar)
                {
                    if (!st.ContainsKey(s))
                        st.Add(s, new HashSet<FileInfo>());

                    HashSet<FileInfo> set = null;
                    if (st.TryGetValue(s, out set))
                    {
                        set.Add(f);
                    }
                }
            }

            var findkey = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(findkey))
            {
                HashSet<FileInfo> value = null;
                if (st.TryGetValue(findkey, out value))
                {
                    foreach (var item in value)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                findkey = Console.ReadLine();
            }
        }
    }
}
