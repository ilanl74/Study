using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT;

public class UnitTest29
{
    [Theory]
    [InlineData(10, 3, 3)]
    [InlineData(11, 3, 3)]
    [InlineData(12, 3, 4)]
    [InlineData(7, -3, -2)]
    [InlineData(0, 1, 0)]
    public void Test(int dividend, int divisor, int expected)
    {
        Solution sol = new();
        Assert.Equal(expected, sol.Divide(dividend, divisor));
    }
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            var invert = ShouldInvertSign(dividend, divisor);
            var dividen = MakePositive(dividend);
            var diviso = MakePositive(divisor);
            var div = RecSubtract(dividen, diviso);
            int t;
            if (invert)
                if (int.TryParse($"-{div}", out t))
                    return t;
                else
                    return int.MinValue;
            return div;
        }

        private bool ShouldInvertSign(int dividend, int divisor)
        {
            return (((dividend < 0) && (divisor > 0)) || ((dividend > 0) && (divisor < 0)));

        }
        private int MakePositive(int num)
        {
            if (num >= 0)
                return num;

            var str = num.ToString();
            int res;
            if (int.TryParse(str.Substring(1), out res))
                return res;
            return int.MaxValue;

            //return int.Parse(str.Substring(1));

        }
        private int RecSubtract(int dividend, int divisor)
        {
            int i = 0;
            var div = dividend;
            while (div >= divisor)
            {
                div = div - divisor;
                i++;
            }

            //if (dividend < divisor)
            //    return 0;
            //var div = dividend - divisor;
            //int i = 0;
            //i = 1 + RecSubtract(div, divisor);

            return i;
        }
    }
}

