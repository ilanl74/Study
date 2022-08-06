using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class AllSumTabulation
    {
        [Theory]
        [ClassData(typeof(AllSumTabulation.Mock))]
        public void Test(int target, int[] candidates, List<List<int>> expected)
        {
            Assert.Equal(expected, Calculate(target, candidates));
        }
        private List<List<int>> Calculate(int target, int[] candidates)
        {

            List<List<int>>[] res = new List<List<int>>[target + 1];
            res[0] = new List<List<int>>();
            res[0].Add(new List<int>());
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] == null)
                    continue;
                for (int j = 0; j < candidates.Length && candidates[j] + i < res.Length; j++)
                {
                    foreach (var l in res[i])
                    {
                        if (res[i + candidates[j]] == null)
                            res[i + candidates[j]] = new List<List<int>>();
                        var tmp = new List<int>(l);
                        tmp.Add(candidates[j]);
                        res[i + candidates[j]].Add(tmp);
                    }


                }
            }

            return res[target];
        }
        private class Mock : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                List<int> list1 = new List<int>() { 4, 4 };
                List<int> list2 = new List<int>() { 3, 5 };
                List<List<int>> res = new List<List<int>>();
                res.Add(list1);
                res.Add(list2);
                yield return new object[] { 8, new int[] { 3, 4, 5 }, res };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
    }
}
