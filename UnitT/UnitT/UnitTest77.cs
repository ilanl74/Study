using System;
using System.Collections.Generic;
using Xunit;

namespace UnitT
{
    public class UnitTest77
    {
        [Theory]
        [InlineData(4, 2,6)]
        public void Test1(int n ,int k,int countRes)
        {
            var sol = new Solution();
            var res = sol.Combine(n, k);
            Assert.True(res.Count == countRes);

        }

        public class Solution
        {
            IList<IList<int>> output = new List<IList<int>>();
            int n;
            int k;

            public void Backtrack(int first, List<int> curr)
            {

                // if the combination is done
                if (curr.Count == k)
                {
                    output.Add(new List<int>(curr));
                    return;
                }
                for (int i = first; i < n + 1; ++i)
                {
                    // add i into the current combination
                    curr.Add(i);
                    // use next integers to complete the combination
                    Backtrack(i + 1, curr);
                    // backtrack
                    curr.RemoveAt(curr.Count - 1);
                }
            }

            public IList<IList<int>> Combine(int n, int k)
            {
                this.n = n;
                this.k = k;
                Backtrack(1, new List<int>());
                return output;
            }
        }

    }


    
}