using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest647
    {
        [Theory]
        [InlineData("aba",4)]
        [InlineData("abcabbacccx",18)]
        public void CountPalindromic(string s, int res)
        {
            var sol = new Solution();
            Assert.Equal(res,sol.CountSubstrings(s) );
        }


        public class Solution
        {
            private bool IsPalindromic(string s)
            {
                
                int end = s.Length-1;
                int start = 0;
                while (start < end)
                {
                    if (s[start] != s[end])
                        return false;
                    start++;
                    end--;
                }
                return true;
            }
            public int CountSubstrings(string s)
            {
                int ans = 0;
                for(int start = 0; start < s.Length;start++)
                    for(int end= start;end< s.Length;end++)
                        ans += IsPalindromic(s.Substring(start,end-start+1) )? 1 : 0;
                return ans;
            }
        }
    }
}
