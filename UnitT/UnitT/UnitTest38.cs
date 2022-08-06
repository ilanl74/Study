using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest38
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "11")]
        [InlineData(4, "1211")]
        public void TestCountAndSay(int n, string expected)
        {
            Solution sol = new();
            Assert.Equal(expected, sol.CountAndSay(n));
        }
        public class Solution
        {
            public string CountAndSay(int n)
            {
                if (n == 1)
                    return "1";
                var str = CountAndSay(n - 1);
                var tmp = 'a';
                var count = 0;
                string ans = string.Empty;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != tmp)
                    {
                        if (tmp != 'a')
                            ans += $"{count}{int.Parse(tmp.ToString())}";
                        tmp = str[i];
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }
                ans += $"{count}{int.Parse( tmp.ToString())}";
                return ans;
            }
        }
    }
}
