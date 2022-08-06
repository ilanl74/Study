using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest39
    {
        //try to work with the remainder

        [Theory]
        [ClassData(typeof(CalculatorTestData)) ]
        public void Test1(int[] n, int k,int resCounter)
        {
            var sol = new Solution();
            var res = sol.CombinationSum(n, k);
            Assert.True(res.Count == resCounter);

        }

        
        class CalculatorTestData : IEnumerable<object[]>
        {

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new int[] { 2, 7, 6, 3 }, 7, 2 };
                yield return new object[] { new int[] { 2, 3, 5 }, 8, 3 };

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        }

        class Solution
        {
            IList<IList<int>> output = new List<IList<int>>();
            HashSet<string> outputHashSet = new HashSet<string>();

            private void Backtrack(int[] candidates,int start, List<int> curr, int target)
            {
                var currSum = curr.Sum();
                if (currSum > target)
                    return;
                if (currSum == target)
                {
                    //var hash = GetHash(curr, candidates);
                    //if (outputHashSet.Contains(hash))
                    //    return;
                    //outputHashSet.Add(hash);
                    output.Add(new List<int>(curr));
                    return;
                }
               
                for  (int i =start;i< candidates.Length;i++)
                {
                    if (currSum+ candidates[i] > target)
                        return ;
                    // add i into the current combination
                    curr.Add(candidates[i]);
                    // use next integers to complete the combination
                    Backtrack(candidates,i, curr, target);
                    // backtrack
                    curr.RemoveAt(curr.Count - 1);
                }
            }

            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                List<int> org = new List<int> (candidates);
                candidates = org.OrderBy(x => x).ToArray();

                Backtrack(candidates,0, new List<int>(), target);
                return output;
            }

            

        }

    }
    /*
      class Solution
        {
            IList<IList<int>> output = new List<IList<int>>();
            HashSet<string> outputHashSet = new HashSet<string>();

            private void Backtrack(int[] candidates, List<int> curr, int target)
            {
                var currSum = curr.Sum();
                if (currSum > target)
                    return;
                if (currSum == target)
                {
                    var hash = GetHash(curr, candidates);
                    if (outputHashSet.Contains(hash))
                        return;
                    outputHashSet.Add(hash);
                    output.Add(new List<int>(curr));
                    return;
                }
               
                foreach (int i in candidates)
                {
                    if (currSum+i > target)
                        return ;
                    // add i into the current combination
                    curr.Add(i);
                    // use next integers to complete the combination
                    Backtrack(candidates, curr, target);
                    // backtrack
                    curr.RemoveAt(curr.Count - 1);
                }
            }

            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                List<int> org = new List<int> (candidates);
                candidates = org.OrderBy(x => x).ToArray();

                Backtrack(candidates, new List<int>(), target);
                return output;
            }

            private string GetHash(List<int> list1, int[] candidates)
            {
                string hash=string.Empty;
                foreach(int c in candidates)
                {
                    hash += $"{ list1.Count(z => z == c)},";
                }
                return hash;
            }

        }

    }
     */


}

