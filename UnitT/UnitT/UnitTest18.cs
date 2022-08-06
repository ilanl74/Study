using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest18
    {
        [Theory]
        [ClassData(typeof(TestingData))]
        public void TestFourSum(int[] nums,int target ,IList<IList<int>> expected)
        {
            var sol = new Solution();
            Assert.Equal(expected, sol.FourSum(nums, target));
        }
        public class Solution
        {
            IList<IList<int>> ans = new List<IList<int>>();
            int[] _nums;
            int _target;
            int _len;
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                _nums = nums.OrderBy(a=>a).ToArray();
                _target = target;
                _len = nums.Length;
                for(int i = 0; i < _len-3; i++)
                {
                    for(int j = i+1; j < _len-2; j++)
                    {
                        Search(i, j);
                    }
                }
                return ans;
            }
            private void Search(int p1, int p2)
            {
                var hi = _len - 1;
                var lo = p2 + 1;
                while(lo < hi)
                {
                    var currSum = _nums[p1] + _nums[p2] + _nums[lo] + _nums[hi];
                    if (currSum <_target)
                    {
                        lo++;
                    }
                    else if (currSum >_target)
                    {
                        hi--;
                    }
                    else if (currSum == _target)
                    {
                        ans.Add(new List<int>() { _nums[p1] , _nums[p2] , _nums[lo] , _nums[hi]});
                        if (_nums[lo] == _nums[lo + 1])
                        {
                            lo++;
                        }
                        else if (_nums[hi] == _nums[hi - 1])
                        {
                            hi--;
                        }
                        else
                        {
                            lo++;
                            hi--;
                        }
                    }
                }
            }

        }

        public class TestingData : IEnumerable<object[]>
        {
            //-2,-1,0,0,1,2
            //{ 2, 2, 2, 2 ,8} NOT CLEAR TO ME 
            public IEnumerator<object[]> GetEnumerator()
            {
                //var l1 = new List<int>() { -2, -1, 1, 2 };
                //var l2 = new List<int>() { -2, 0, 0, 2 };
                //var l3= new List<int>() { -1, 0, 0, 1 };
                //var ll1 = new List<IList<int>>() { l1, l2, l3, };
                //yield return new object[] {new int[] { 1, 0, -1, 0, -2, 2 },0,ll1};
                var ll2 = new List<IList<int>>();
                ll2.Add(new int[] { 2, 2, 2, 2 });
                yield return new object[] { new int[] { 2, 2, 2, 2 ,8}, 8,ll2 };

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            
        }
    }
}
