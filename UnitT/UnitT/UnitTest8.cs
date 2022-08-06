using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest8
    {
        [Theory]
        [InlineData("  -98 abc", -98)]
        [InlineData("  -0098 abc", -98)]
        [InlineData("  -ac98 abc", 0)]
        [InlineData("  98 abc", 98)]
        [InlineData("  0098 abc", 98)]
        [InlineData("  -9a8 abc", -9)]
        [InlineData("2147483648", int.MaxValue)]
        [InlineData("-2147483648", int.MinValue)]
        [InlineData("-214748364455", int.MinValue)]
        [InlineData("-000000000000001",-1)]
        [InlineData("00000-42a1234", 0)]
        public void Atoi(string input,int expect)
        {
            var sol = new Solution();
            Assert.Equal(expect, sol.MyAtoi(input));
        }
        public class Solution
        {
            public int MyAtoi(string s)
            {
               
                int ans =0;
                int? firstValid = null;
                int? sign = null;
                int? lastValid =null;
                bool leadingZero = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        if (firstValid == null)
                            continue;
                        else
                        {
                            lastValid = i-1;
                            break;
                        }
                            
                    }
                    else if (s[i] == '+' || s[i] == '-')
                    {
                        if (firstValid == null && !leadingZero)
                        {
                            firstValid = i;
                            sign = (s[i] == '+') ? 1 : 0 ;
                        }
                        else
                        {
                            lastValid = i-1 ;
                            break;
                        }
                    }
                    else if (char.IsDigit(s[i]) )
                    {
                        if (firstValid == null)
                        {
                            if (s[i] == '0')
                            {
                                leadingZero = true;
                                continue;
                            }
                               
                            firstValid = i;
                        }
                        
                    }
                    else
                    {
                        if (firstValid == null)
                        {
                            break;
                        }
                        else
                        {
                            lastValid = i-1;
                            break;
                        }
                    }

                }
                if ((!lastValid.HasValue)&& (firstValid.HasValue))
                {
                    lastValid = s.Length - 1;
                }
                if (firstValid.HasValue && lastValid.HasValue)
                {
                    var len = lastValid.Value - firstValid.Value+1;
                    if ((len > 11 && sign.HasValue)|| (len >10 && sign.HasValue))
                        if (sign == 1)
                            ans = int.MaxValue;
                        else
                            ans = int.MinValue;

                    if ((len > 0 && !sign.HasValue) ||(len >1 && sign.HasValue))
                    {
                        var l = long.Parse(s.Substring(firstValid.Value, len));
                        if (l > int.MaxValue)
                            ans = int.MaxValue;
                        if (l < int.MinValue)
                            ans = int.MinValue;
                        if (ans == 0)
                            ans = int.Parse(s.Substring(firstValid.Value, len));
                    }
                }
                   
                return ans;
            }
        }
    }
}
