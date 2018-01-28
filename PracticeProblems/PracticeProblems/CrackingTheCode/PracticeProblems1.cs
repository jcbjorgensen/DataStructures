using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.CrackingTheCode
{
    public static class PracticeProblems1
    {
        public static void Tests()
        {
            var s0 = "abcdefg";
            var r0 = AllUniqueVersion3(s0);

            var s1 = "aabbccdd";
            var r1 = AllUniqueVersion3(s1);

            var s2 = "abcde";
            var r2 = Reverse(s2);

            var s3 = "abbcade";
            var c3 = s3.ToCharArray();
            RemoveDuplicate(ref c3);

            var s4 = "aaaaa";
            var c4 = s4.ToCharArray();
            RemoveDuplicate(ref c4);

            var s5 = "aaabbb";
            var c5 = s5.ToCharArray();
            RemoveDuplicate(ref c5);

            var s6 = "ababab";
            var c6 = s5.ToCharArray();
            RemoveDuplicate(ref c6);

            var a = "abbchef";
            var b = "chefaba";
            var areAnagram = AreAnagram(a.ToCharArray(),b.ToCharArray());

            var r = new List<int>() {1};
            var s = r;
            s = new List<int>() {2};

         }

        /// <summary>
        /// Practice problem 1.1 version 1
        /// Run time: O(n) 
        /// </summary>>
        /// <param name="s"</param>
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

        public static string Reverse(string s)
        {
            var b = new StringBuilder();
            for (int i = s.Length-1; i >-1; i--)
            {
                b.Append(s[i]);
            }
            return b.ToString();
        }

        public static string ReverseInPlace(string s)
        {
            var b = new StringBuilder();
            for (int i = s.Length - 1; i > -1; i--)
            {
                b.Append(s[i]);
            }
            return b.ToString();
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

        public static bool AreAnagram(char[] s, char[] t)
        {
            if(s == null || t ==null) return false;
            if (s.Length != t.Length) return false;

            var hist = new int[256];
            
            for (int i = 0; i < s.Length; i++)
            {
                var a = Convert.ToInt32(s[i]);
                var b = Convert.ToInt32(t[i]);

                hist[a]++;
                hist[b]--;
            }

            for (int i = 0; i < hist.Length; i++)
            {
                if (hist[i] != 0) return false;
            }
            return true;
        }


        public static void RemoveDuplicate(ref char[] s)
        {
            if(s == null) return;

            int j = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var isNew = IsNew(s, c, j);
                if(!isNew) continue;
                s[j++] = c;
            }
            Array.Resize(ref s,j);
        }

        public static bool IsNew(char[] s, char c, int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (s[j] == c) return false;
            }
            return true;
        }
    }
}
