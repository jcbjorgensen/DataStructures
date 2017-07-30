using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    /// <summary>
    /// Test methods for heaps 
    /// </summary>
    public static class HeapTests
    {
        public static void Test()
        {
            var lst = new List<int>{1,2,3,4,5,6,7,8,9,10};
            var heap = new Heap(lst.ToArray());
        }
    }

    /// <summary>
    /// Implementation of a priority queue
    /// </summary>
    public class Heap
    {
        public Heap(int[] queue)
        {
            Queue = queue;
        }

        public int[] Queue;

        public int N => Queue.Length;

        //public static int Parent(int n)
        //{
        //    if (n == 1) ;
        //};
    }

    public static class HeapOperations
    {

    }
}
