using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Quora
{
    public static class HeapProblems
    {
        public static void KthSmallestElementTest()
        {
            //Problem: Figure out if given x is larger than the kth first elements 
            //Idea: Walk the binary tree in normal order back tracking if elements are 
            //too large. Either you meet k smaller element or you can't go any further
            var lst = new List<int> {9,11,3, 15, 0, 1, 5, 6};
            var heap = new Heap(100);
            heap.Insert(lst.ToArray());
            heap.Print();

            var x = 7;
            var k = 6;
            var isSmaller = HeapCompare(heap, x, k);
            var sortedArr = heap.Sort();
            foreach (var i in sortedArr)
                Console.Write(i + " ");
        }

        public static bool HeapCompare(Heap h, int x, int count)
        {
            return HeapCompare(h, 1, x, count) <= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="h">The heap</param>
        /// <param name="x"></param>
        /// <param name="count">The number of elements less than x we need to find</param>
        /// <returns>The number of elements less than x we need to find</returns>
        public static int HeapCompare(Heap h,int node, int x, int count)
        {
            if (count < 0 || node > h.Size) return count;
            if (x < h.Queue[node]) return count;
            count = HeapCompare(h, h.LeftChild(node), x, count - 1);
            count = HeapCompare(h, h.RightChild(node), x, count);
            return count;
        }
    }
}
