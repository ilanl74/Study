using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class CanSum
    {
        // what numbers on the arr can be use to sum to a target number 

        [Theory]
        [InlineData(new int[] { 0, 1, 5, 3, 7 }, 7, true)]
        [InlineData(new int[] { 1, 5, 3, 7 }, 0, true)]
        [InlineData(new int[] { 33, 17, 9, 7 }, 5, false)]
        [InlineData(new int[] { 9,1, 5, 3, 7 }, 30000, true)]

        public void TestCanSum(int[]nums,int target,bool expected)
        {
            Solution sol = new();
            Assert.Equal(expected, sol.CanSum(nums, target));

        }
        public class Solution
        {
            List<IList<int>> _ans = new List<IList<int>>();
            int _count = 0;
            bool _res = false;
            Dictionary<int, bool> Memo = new();

            public bool CanSum(int[] nums, int target)
            {
                
                return CanSumDP(nums,target);
            }

            public bool CanSumDP(int[] nums, int target)//,IList<int> curr)
            {
                _count ++;
                if (Memo.ContainsKey(target))
                    return Memo[target];
                if (target == 0)
                {
                    Memo[target] = true;
                    //_ans.Add(curr);
                    return Memo[target];
                }
                if(target <0)
                {
                    Memo[target] = false;
                    return Memo[target];
                }
                   

                bool b = false;
                foreach (int i in nums)
                {
                    if (i == 0)
                        continue;
                    //curr.Add(i);
                    if (CanSumDP(nums, target -i))
                    {
                        b = true;
                        break;
                    }
                        
                   
                }
                Memo[target] = b;
                return Memo[target];
               
                    

                
            }
        }
    }
}
