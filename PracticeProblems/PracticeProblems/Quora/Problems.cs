using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Quora
{
    public static class SegregatePositiveAndNegative
    {
        public static void Solve()
        {
            var a = new int[] {9, -3, 5, -2, 8, -6, 1, 3};

            var firstPos = a.Count(x => x < 0);
            var posIdx = -1;
            var negIdx = firstPos-1;

            while (true)
            {
                //First out of place neg int. 
                negIdx = NextNegInt(negIdx,firstPos, a);
                posIdx = NextPosInt(posIdx,firstPos,a);

                if (negIdx >= a.Length || posIdx >= firstPos)
                {
                    break;
                }
                //Swap elements 
                var tmp = a[posIdx];
                a[posIdx] = a[negIdx];
                a[negIdx] = tmp;
            }
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }  
        }

        public static int NextNegInt(int negIdx ,int firstPos,int[] a)
        {
            for (int i = negIdx+1; i < a.Length; i++)
            {
                if (a[i] < 0) return i;
            }
            return a.Length;
        }

        public static int NextPosInt(int posIdx, int firstPos, int[] a)
        {
            for (int i = posIdx+1; i < firstPos; i++)
            {
                if (a[i] > 0) return i;
            }
            return firstPos;
        }
    }


    public static class BinaryArrayProblem
    {
        public static void Solve()
        {
            var a = new int[] {0, 0, 1, 1, 1};
            var b = new int[] {0, 1, 1, 0, 1};

            var scanA = new int[a.Length+1]; 
            var scanB = new int[b.Length+1];

            for (int i = 1; i < a.Length+1; i++)
            {
                scanA[i] = scanA[i-1] + a[i-1];
                scanB[i] = scanB[i-1] + b[i-1];
            } 
            var diff = new int[scanA.Length];
            for (int i = 0; i < diff.Length; i++)
            {
                diff[i] = scanA[i] - scanB[i];
            }

            var lookup = new Dictionary<int,Tuple<int,int>>();

            for (int index = 0; index < diff.Length; index++)
            {
                var d = diff[index];
                if (lookup.ContainsKey(d))
                {
                    lookup[d] = new Tuple<int, int>(lookup[d].Item1,index);
                    continue;
                }
                lookup[d] = new Tuple<int, int>(index,index);
            }

            //Maks 
            var iBest = 0;
            var lenghtBest = 0;
            foreach (var item in lookup)
            {
                var len = item.Value.Item2 - item.Value.Item1;
                if (len <= lenghtBest) continue;
                iBest = item.Value.Item1;
                lenghtBest = len;
            }

            //Sanity check: Print best 
            var sumA = 0;
            var sumB = 0;
            for (int i = 0; i < lenghtBest; i++)
            {
                sumA += a[i + iBest];
                sumB += b[i + iBest];
            }

            Console.WriteLine(sumA);
            Console.WriteLine(sumB);
        }
    }
}
