using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest16
    {
        [Theory]
        [InlineData(new int[] { -1, 2, 1, -4 }, 1, 2)]
        [InlineData(new int[] { 0, 0, 0 }, 1, 0)]
        [InlineData(new int[] { 0, 2, 1, -3 }, 1, 0)]
       

        public void TestClosestSum(int[] nums, int target,int espected)
        {
            var sol = new Solution();
            Assert.Equal(espected, sol.ThreeSumClosest(nums, target));

        }
        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                int? closest = null;
                var orderNums = nums.OrderBy(n=>n).ToArray();
                int bestRemainder = int.MaxValue;
                for(int i = 0; i < orderNums.Length; i++)
                {
                    int hi = orderNums.Length-1;
                    int lo = i + 1;
                    
                    while(hi > lo)
                    {
                        var sum = orderNums[hi] + orderNums[lo] + orderNums[i];
                        var remainder = Math.Abs(target - sum);
                        
                        if (bestRemainder > remainder)
                        {
                            bestRemainder = remainder;
                            closest = sum;
                        }
                        if (bestRemainder == 0)
                            return closest.Value;
                        if (sum < target)
                        {
                            lo++;
                        }
                        else
                        {
                            hi--;
                        }
                    }
                }
                return closest.Value;
            }
        }
    }
}
