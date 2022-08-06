using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest14
    {
        [Theory]
        [InlineData(new string[] {"abc","aba","abt","abr"},"ab")]
        [InlineData(new string[] { "abc", "a", "at" }, "a")]
        [InlineData(new string[] { "gabc", "a", "at" },"")]
        public void TestLCP(string[] input ,string prefix)
        {
            var sol = new Solution();
            Assert.Equal(prefix,sol.LongestCommonPrefix(input));
        }
        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                var ans = string.Empty;
                var pos = 0;
                var looping = true;
                char? curr = null;
                while (looping)
                {
                    curr = null;
                    foreach (var str in strs)
                    {
                        if (str.Length <= pos)
                        {
                            looping = false;
                            break;
                        }
                        else if (curr == null)
                        {
                            curr = str[pos];
                            continue;
                        }
                        else if (str[pos] != curr)
                        {
                            looping = false;
                            break;
                        }
                    }
                    
                    if (looping)
                    {
                        ans += curr;
                        pos++;
                    }
                    
                }
                return ans;
            }
        }
    }
}
