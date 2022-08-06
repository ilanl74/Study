using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT;

public class UnitTest53
{
    [Theory]
    //[InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    //[InlineData(new int[] { -2, -3, 223, -4, -1, -2, -1, -5, -4 }, 223)]
    [InlineData(new int[] { -1 }, 0)]

    public void Test(int []nums,int expectedSum)
    {
        Solution sol = new();

        Assert.Equal(expectedSum,sol.MaxSubArray(nums));
    }
}
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int currSubArrSum = 0;
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            currSubArrSum = Math.Max(nums[i] , currSubArrSum + nums[i] );
            max = Math.Max(max, currSubArrSum);
        }
        return max;
    }
}

