using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest33
    {
        [Theory]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1, 5)]
        [InlineData(new int[] { 4, 5, 6, 7, 9, 10, 12 }, 10, 5)]
        [InlineData(new int[] { 4, 5, 6, 7, 9, 10, 12 }, 5, 1)]
        [InlineData(new int[] { 1 }, 0, -1)]
        [InlineData(new int[] { 1, 3 }, 0, -1)]
        [InlineData(new int[] { 3, 1 }, 3, 0)]
        [InlineData(new int[] { 3, 5, 1, 2 }, 1, 2)]
        [InlineData(new int[] { 5, 9, 0, 1, 2 }, 9, 1)]
        [InlineData(new int[] { 5, 1, 3 }, 1, 1)]

        public void Test(int[] nums, int target, int expected)
        {
            Solution sol = new();
            Assert.Equal(expected, sol.Search(nums, target));
        }
        public class Solution
        {
            public int Search(int[] nums, int target)
            {

                return RecSearch(nums, 0, nums.Length - 1, target);

            }

            private int RecSearch(int[] nums, int start, int end, int target)
            {
                if ((start < 0) || (end > nums.Length - 1))
                    return -1;
                if (start == end)
                {
                    if (nums[start] == target)
                        return start;
                    return -1;
                }
                var mid = start + (end - start) / 2;
                if (nums[start] > nums[mid])
                {
                    if (target > nums[start])
                        return RecSearch(nums, mid + 1, end, target);
                    else
                        return RecSearch(nums, start, mid, target);
                }
                else//normal path
                {
                    if (target < nums[end])
                        return RecSearch(nums, mid + 1, end, target);
                    else
                        return RecSearch(nums, start, mid, target);

                }


            }

        }
    }
}
