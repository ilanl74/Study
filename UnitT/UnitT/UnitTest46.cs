using Combinatorics.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitT
{
    public class UnitTest46
    {
        [Theory]
        [ClassData(typeof(ExampleData))]
        public void TestPermute(int[] nums, IList<IList<int>> expected)
        {
            Solution sol = new();
            Assert.Equal(expected, sol.Permute(nums));
        }

        public class Solution
        {
            IList<IList<int>> _res = new List<IList<int>>();
            HashSet<int> _sets = new HashSet<int>();
            public IList<IList<int>> Permute(int[] nums)
            {
                BackTrack(nums,new List<int>());
                return _res;
            }

            private void BackTrack(int[] nums, IList<int> curr)
            {
                if (curr.Count == nums.Length)
                {
                    _res.Add(new List<int>(curr));
                    return;
                }
                for(int i = 0; i < nums.Length; i++)
                {
                    if (!_sets.Add(nums[i]))
                        continue;
                    curr.Add(nums[i]);
                    BackTrack(nums, curr);
                    curr.RemoveAt(curr.Count-1);
                    _sets.Remove(nums[i]);
                }
            }
        }
        internal class ExampleData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var x = new List<IList<int>>()
                {
                    new List<int> {1,2,3 },
                    new List<int>{ 1, 3, 2 },
                    new List<int>{ 2, 1, 3 },
                    new List<int>{ 2, 3, 1 },
                    new List<int>{ 3, 1, 2 },
                    new List<int>{3,2,1 }
                };
               
                yield return new object[] { new int[] { 1, 2, 3 },x };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
    }


}
