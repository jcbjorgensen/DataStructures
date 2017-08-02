using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    //Bubble sort 
    public static class BubbleSort
    {
        public static void BubbleTest()
        {
            var lst = new int[] { 3, 5, 8, 4,-2, 1, 9};
            var trueSortedList = new int[] {-2, 1, 3, 4, 5, 8, 9};
            SortInPlace(lst);

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

        //Implementation of Bubble sort
        public static void SortInPlace(int[] lst)
        {
            var n = lst.Length;
            for (int i = 0; i < n; i++)
            {
                var earlyExit = true;

                //Run pass i. 
                for (int j = 1; j < n-i; j++)
                {
                    if (lst[j - 1] >= lst[j])
                    {
                        earlyExit = false;
                        var tmp = lst[j];
                        lst[j] = lst[j - 1];
                        lst[j - 1] = tmp;
                    }
                }

                if (earlyExit)
                {
                    return;
                }
            }
        }
    }

}
