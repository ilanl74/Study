using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest15
    {
        [Theory]
        [ClassData(typeof(ThreeSumData))]
        public void TestTreeSum(int[] nums, IList<IList<int>> expected)
        {
            var sol = new Solution();
            Assert.Equal(expected, sol.ThreeSum(nums));
        }

        public class Solution
        {
            IList<IList<int>> _threeSum = new List<IList<int>>();
            int _target =0;
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var orderedNums = nums.OrderBy(x => x).ToArray();
                for (int i = 0; i < orderedNums.Length; i++)
                {
                    if (i > 0 && orderedNums[i] == orderedNums[i - 1] )
                        continue;
                    int hiPos = orderedNums.Length-1;
                    int loPos = i+1;
                    while(hiPos > loPos)
                    {
                        var curr = orderedNums[i] + orderedNums[loPos] + orderedNums[hiPos];
                        if (curr == _target)
                            { _threeSum.Add(new List<int>() { orderedNums[i], orderedNums[loPos], orderedNums[hiPos] }); loPos++; hiPos--;
                            while (hiPos > loPos && orderedNums[loPos] == orderedNums[loPos - 1])
                                loPos++;
                           }
                        else if (curr < _target)
                            loPos++;
                        else if (curr > _target)
                            hiPos--;
                    }

                    
                }

                return _threeSum;
            }
        }
        //1,1,2,2,3,3,4,4,5,6,7,8,9,10
        class ThreeSumData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var l1 = new List<IList<int>>();
                l1.Add(new List<int>() { -1, -1, 2 });
                l1.Add(new List<int>() { -1, 0, 1 });
                yield return new object[] { new int[] { -1, 0, 1, 2, -1, -4 },l1};

                var l2 = new List<IList<int>>();
                l2.Add(new List<int>() { -2, 0, 2 });
                
                yield return new object[] { new int[] { -2,0,0,2,2},l2};
               //-4-1-1012
            }


            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
