using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest3
    {
        [Theory]
        [InlineData("abcdeicfghijk1123457890abcdefgglmnopqrrstuvwxyz", 17)]
        [InlineData("abcdeic", 6)]
        [InlineData("abcabcbb", 3)]
        [InlineData("pwwkew", 3)]
        [InlineData("dvdf",3)]
        public void Test1(string input,int expected )
        {
            var sol = new Solution();
            
            Assert.Equal(expected, sol.LengthOfLongestSubstring(input));
        }
        public class Solution
        {
            int left = 0;
            int right = 0;
            int max  = 0;
            Dictionary<char,int> unique = new Dictionary<char, int>(128);
            public int LengthOfLongestSubstring(string s)
            {
                var c = s.ToArray();
                var len = c.Length;
                int lastUniqueLen = 0;
                while (right < len)
                {
                    if (unique.ContainsKey(c[right]))
                    {
                        var oldLeft = left;
                        if (left < unique[c[right]] +1)
                            left = unique[c[right]]+1;
                        else
                            left++;
                        
                        max = (max < lastUniqueLen) ? lastUniqueLen : max;
                       
                        CleanUnique(c,oldLeft, left);
                        lastUniqueLen = unique.Count();

                    }
                    
                    unique[c[right]] = right;
                    
                    right++;
                    lastUniqueLen++;

                }
                max = (max < lastUniqueLen) ? lastUniqueLen : max;

                return max;
            }
            private void CleanUnique(char[] c,int l,int r)
            {
                for (var i = l; i < r; i++)
                    unique.Remove(c[i]);
            }
        }
    }

    
}
