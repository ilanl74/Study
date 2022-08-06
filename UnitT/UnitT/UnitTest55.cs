using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT;

public class UnitTest55
{
    [Theory]
    [InlineData(new[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new[] { 3, 2, 1, 0, 4 }, false)]
    public void Test(int[] nums, bool expected)
    {
        Solution sol = new();

        Assert.Equal(expected, sol.CanJump(nums));
    }
    public class Solution
    {
        //public bool CanJump(int[] nums)
        //{
        //    var arr = new bool[nums.Length];
        //    arr[0] = true;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (!arr[i])
        //            continue;
        //        for (int j = 1; j <= nums[i]; j++)
        //            if (j + i < arr.Length)
        //                arr[j + i] = true;

        //    }
        //    return arr[arr.Length - 1];
        //}

        public bool CanJump(int[] nums)
        {
            return RecCanJump(nums, 0);
        }
        public bool RecCanJump(int[] nums, int curr)
        {
            if (curr > nums.Length)
                return false;
            if (curr == nums.Length - 1)
                return true;

            for (int j = 1; j <= nums[curr]; j++)
            {
                if (RecCanJump(nums, curr + j))
                    return true;
            }


            return false;
        }
    }

}


