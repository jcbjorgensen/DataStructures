using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.CrackingTheCode
{
    public static class PracticeProblems1
    {
        public static void AllUniqueTest()
        {
            var s0 = "abcdefg";
            var r0 = AllUniqueVersion3(s0);

            var s1 = "aabbccdd";
            var r1 = AllUniqueVersion3(s1);
        }

        /// <summary>
        /// Practice problem 1.1 version 1
        /// Run time: O(n) 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AllUnique(String s)
        {
            var uniqueChars = new HashSet<Char>();

            var len = s.Length;

            for (int i = 0; i < len; i++)
            {
                if (uniqueChars.Contains(s[i]))
                    return false;
                uniqueChars.Add(s[i]);
            }
            return true;
        }

        /// <summary>
        /// Practice problem 1.1 version 2
        /// Time: O(n^2), Space: O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AllUniqueVersion2(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                for (int j = 0; j < i; j++)
                {
                    var d = s[i];
                    if (c == d)
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Practice problem 1.1 version 2
        /// Time: O(n^2), Space: O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AllUniqueVersion3(String s)
        {
            bool[] hasChar = new bool[256];

            for (int i = 0; i < s.Length; i++)
            {
                var k = Convert.ToInt32(s[i]);
                if (hasChar[k]) return false;
                hasChar[k] = true;
            }
            return true;
        }
    }
}
