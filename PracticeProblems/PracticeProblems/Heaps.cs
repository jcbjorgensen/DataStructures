using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProblems
{
    /// <summary>
    /// Test methods for heaps 
    /// </summary>
    public static class HeapTests
    {
        public static void Test()
        {
            var lst = new List<int>{7,6,9,3,4,0,1,5,2};
            var heap = new Heap(100);
            for (var i = 0; i < lst.Count; i++)
            {
                heap.Insert(lst[i]);
                heap.Print();
            }

            var n = heap.Size;
            for (var i = 0; i < n; i++)
            {
                Console.Write(heap.ExtractMin());
            }
        }
    }

    /// <summary>
    /// Implementation of a priority queue
    /// </summary>
    public class Heap
    {
        public int[] Queue;
        public int Size;

        public Heap(int capacity)
        {
            Queue = new int[capacity+1];
            Size = 0;
        }

        public void Insert(int i)
        {
            Size++;
            Queue[Size] = i;
            BubbleUp(Size); 
        }

        private int Parent(int j)
        {
           return j/2;
        }

        private int LeftChild(int j)
        {
            return 2*j;
        }

        private int RightChild(int j)
        {
            return 2 * j+1;
        }

        public int ExtractMin()
        {
            var min = Queue[1];
            Queue[1] = Queue[Size];
            Queue[Size--] = 0;
            BubbleDown(1);
            return min;
        }

        private void BubbleDown(int p)
        {
            if (p==Size) return;

            var l = LeftChild(p);
            var r = RightChild(p);
            int c;

            if (l>Size) return;
            if (r>Size)
            {
                c = l;
            }
            else
            {
                c = Queue[l] < Queue[r] ? l : r;
            }
            if (Queue[c] >= Queue[p]) return;

            var tmp = Queue[c];
            Queue[c] = Queue[p];
            Queue[p] = tmp;
            BubbleDown(c);
        }

        private void BubbleUp(int n)
        {
            if(n==0) return;
            var p = Parent(n);
            if (Queue[p] > Queue[n])
            {
                var tmp = Queue[n];
                Queue[n] = Queue[p];
                Queue[p] = tmp;
            }
            BubbleUp(p);
        }

        public void Print()
        {
            for (int i = 1; i <= Size; i++)
                Console.Write(Queue[i]);
            Console.Write(Environment.NewLine);
        }
    }
}
