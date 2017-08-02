using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public static class MergeSort
    {
        public static void Test()
        {
            var lst = new int[] {38,27,43,3,9,82,10 };
            var trueSortedList = new int[] { 3,9,10,27,38,43,82 };
            Sort(lst);

            //Compare result with sorted 
            var success = true;
            for (var i = 0; i < lst.Length; i++)
            {
                success &= lst[i] == trueSortedList[i];
            }
            if (!success)
            {
                Console.Write("Dammit");
            }
        }
        private static void Sort(int[] arr)
        {
            var aux = new int[arr.Length];
            Sort(arr,aux,0,arr.Length);
        }

        private static void Sort(int[] arr,int[] aux,int low,int hi)
        {
            if (low == hi-1) return;
            
            //Split into two lists
            var mid = (hi + low + 1) / 2;
            Sort(arr,aux,low,mid);
            Sort(arr,aux,mid,hi);
            Merge(arr,aux,low,mid,hi);
        }

        private static void Merge(int[] arr,int[] aux, int low,int mid, int hi)
        {
            var i0 = low;
            var i1 = mid;
            var iCount = low;

            while (true)
            {
                if (i0 == mid && i1 == hi) break;
                if (i0 < mid && (i1 == hi || arr[i0] < arr[i1]))
                    aux[iCount++] = arr[i0++];
                else
                    aux[iCount++] = arr[i1++];
            }
            for (var i = low; i < hi; i++)
                arr[i] = aux[i];
        }
    }
}
