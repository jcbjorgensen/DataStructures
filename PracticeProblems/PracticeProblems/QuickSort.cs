using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public static class QuickSort
    {
        public static void Test()
        {
            var lst = new[] { 3, 5, 8, 4, -2, 1, 9 };
            var trueSortedList = new[] { -2, 1, 3, 4, 5, 8, 9 };
            Sort(lst);

            //Compare result with sorted 
            var success = true;
            for (var i = 0; i < lst.Length; i++)
                success &= lst[i] == trueSortedList[i];
            if (!success)
                Console.Write("Dammit");
        }

        public static void Sort(int[] lst)
        {
            Sort(lst,0,lst.Length);
        }

        public static void Sort(int[] lst, int lo, int hi)
        {
            if (hi-lo <= 1) return;
            var pivot = hi - 1;

            //Debugging: 
            var pivotValue = lst[pivot];
            var median = PartitionHoare(lst,pivot,lo,hi);
            
            //Debugging:
            for (int i = 0; i < lst.Length; i++)
                Console.Write(lst[i]+ " ");
            Console.Write(" pivot: " + pivotValue);
            Console.Write(Environment.NewLine);

            Sort(lst,lo,median);
            Sort(lst,median,hi);
        }

        private static int Partition(int[] lst, int pivot, int lo, int hi)
        {
            var firstHi = lo;
            for (var i =lo; i < hi; i++)
            {
                //Flip firstHi with smaller element
                if (lst[i]<lst[pivot])
                {
                    Swap(ref lst[i], ref lst[firstHi]);
                    firstHi++;
                }       
            }
            Swap(ref lst[firstHi],ref lst[pivot]);
            return firstHi;
        }

        private static int PartitionHoare(int[] lst, int pivot, int lo, int hi)
        {
            var loSwap = lo;
            var hiSwap = hi-1;
            while (loSwap<hiSwap)
            {
                if (lst[loSwap]<=lst[pivot])
                {
                    loSwap++;
                    continue;
                }
                if (lst[hiSwap] > lst[pivot])
                {
                    hiSwap--;
                    continue;
                }
                Swap(ref lst[loSwap++],ref lst[hiSwap--]);
            }
            return loSwap;
        }


        private static void Swap(ref int x, ref int y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }
    }
}
