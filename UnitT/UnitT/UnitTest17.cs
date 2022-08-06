using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest17
    {
        [Theory]
        [ClassData(typeof(SolutionData))]
        public void TestLetterCombinations(string d,IList<string> expect)
        {
            var sol = new Solution();
            Assert.Equal(expect, sol.LetterCombinations(d)  );
        }

        public class Solution
        {
            List<string> ans = new List<string>();
            
            public Solution()
            {

                can = new Dictionary<char, char[]>();
                can.Add('2', new char[] { 'a', 'b', 'c' });
                can.Add('3', new char[] { 'd', 'e', 'f' });
                can.Add('4', new char[] { 'g', 'h', 'i' });
                can.Add('5', new char[] { 'j', 'k', 'l' });
                can.Add('6', new char[] { 'm', 'n', 'o' });
                can.Add('7', new char[] { 'p', 'q', 'r', 's' });
                can.Add('8', new char[] { 't', 'u', 'v' });
                can.Add('9', new char[] { 'w', 'x', 'y', 'z' });
               
            }
            public IList<string> LetterCombinations(string digits)
            {
                
                Backtrack(digits, 0,  new StringBuilder(4));
                return ans;
            }

            private readonly Dictionary<char,char[]> can;
            
            private void Backtrack(string digits, int start, StringBuilder curr)
            {
                if (string.IsNullOrEmpty(digits))
                    return;
                if (curr.Length == digits.Length )
                {
                    ans.Add(new string( curr.ToString()));
                    return;
                }
                
                foreach(char c in can[digits[start]])
                {
                    curr.Append(c);
                    Backtrack(digits, start + 1, curr);
                    curr.Remove(curr.Length - 1,1);
                }
            } 
        }

        public class SolutionData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "23", new List<string>() { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            
        }

    }
}
