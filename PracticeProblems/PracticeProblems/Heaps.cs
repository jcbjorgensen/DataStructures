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
            }

            heap.Sort();
            heap.Print();

            var heap2 = new Heap(100);
            heap2.Insert(lst.ToArray());
            heap2.Print();

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

        public int Parent(int j)
        {
           return j/2;
        }

        public int LeftChild(int j)
        {
            return 2*j;
        }

        public int RightChild(int j)
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

        public void Insert(int[] arr)
        {
            Queue = new int[arr.Length+1];
            Array.Copy(arr,0,Queue,1,arr.Length);
            Size = arr.Length;

            var n = Size / 2;
            for (var i = n; i > 0; i--)
            {
                BubbleDown(i);
                //Print(); 
            }
        }

        public void Print()
        {
            for (int i = 1; i <= Size; i++)
                Console.Write(Queue[i] + " ");
            Console.Write(Environment.NewLine);
        }

        public int[] Sort()
        {
            var tmp = new int[Queue.Length];
            Array.Copy(Queue,tmp,Queue.Length);

            var sortedArr = new int[Size];
            var n = Size;
            for (var i = 0; i < sortedArr.Length; i++)
                sortedArr[i] = ExtractMin();

            Queue = tmp;
            Size = n;
            return sortedArr;
        }

        public void SortInplace()
        {
            var n = Size;
            for (var i = 0; i < n; i++)
            {
                var siz = Size;
                var min = ExtractMin();
                Queue[siz] = min;
            }
            Size = n;

            //Reverse array
            for (var i = 1; i <= n/2; i++)
            {
                var tmp = Queue[i];
                Queue[i] = Queue[n - i + 1];
                Queue[n - i + 1] = tmp;
            }
        }
    }
}
