using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest22
    {
        [Theory]
        [ClassData(typeof(PData))]
        public void Test(int n, IList<string> expected)
        {
            var sol = new Solution();
            Assert.Equal(expected, sol.GenerateParenthesis(n));
        }

        public class Solution
        {
            List<string> _ans= new List<string>();
            int _numOfChars;
            public IList<string> GenerateParenthesis(int n)
            {
                _numOfChars = n*2;
                var simbols = new short[2] { 1, -1 };
                BackTrack(simbols, new List<short>(), 0);
                return _ans;

            }

            private void BackTrack(short[] simbols, List<short> current, int lastSum)
            {
                if ((lastSum > _numOfChars / 2)||(lastSum<0))
                    return;

                if (_numOfChars == current.Count)
                {
                    if (lastSum == 0)
                        _ans.Add(GetString(current));
                    return;
                }
                for(int i = 0; i < simbols.Length; i++)
                {
                    current.Add(simbols[i]);
                    lastSum += simbols[i];
                    BackTrack(simbols, current, lastSum);
                    lastSum -= simbols[i];
                    current.RemoveAt(current.Count - 1);


                }
                


            }

            private string GetString(List<short> current)
            {
                var sb = new StringBuilder();
                foreach(short s in current)
                {
                    if (s == 1)
                        sb.Append("(");
                    else
                        sb.Append(")");
                }
                return sb.ToString();
            }
        }
        public class PData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var l1 = new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" };
                yield return new object[] { 3, l1 };
                var l2 = new List<string> { "()" };
                yield return new object[] { 1, l2 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        }
    }
}
