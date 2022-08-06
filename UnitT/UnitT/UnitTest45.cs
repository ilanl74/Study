using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest45 
    {
        [Theory]
        [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
        [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
        [InlineData(new int[] { 2 }, 0)]
        [InlineData(new int[] { 2, 0, 2, 2, 0, 6 }, 3)]
        [InlineData(new int[] { 2, 1 }, 1)]
        [InlineData(new int[] { 5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5 }, 5)]
        public void Test45(int[] nums, int jumps)
        {
            var sol = new Solution();
            Assert.Equal(jumps, sol.Jump(nums));
        }
        public class Solution
        {

            public int Jump(int[] nums)
            {
                int biggestJump = 0;
                int currentJumpEnd = 0;
                int jumps = 0;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    biggestJump = Math.Max(biggestJump, i + nums[i]);

                    if (i == currentJumpEnd)
                    {
                        currentJumpEnd = biggestJump;
                        jumps++;
                    }
                }
                return jumps;
            }

        }
    }
}
