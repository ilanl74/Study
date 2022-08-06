using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest7
    {
        [Theory]
        [InlineData(-500,-5)]
        [InlineData(5120,215)]
        public void TestReverse(int num,int expected)
        {
            var sol = new Solution();
            Assert.Equal(expected,sol.Reverse(num));
        }
        public class Solution
        {
            public int Reverse(int x)
            {
                var sign = 1;
                var str = x.ToString();
                if (str[0] == '-')
                {
                    str = str.Substring(1);
                    sign = -1;
                }
                    
                var rev = str.Reverse();
                var l = long.Parse(new string(rev.ToArray()))*sign;
                if (l> int.MaxValue || l< int.MinValue)
                        return 0;
                return (int)l;
            }
        }

    }
}
