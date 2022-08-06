using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest6
    {
        [Theory]
        //[InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        //[InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("AB", 1, "AB")]

        public void Atoi(string input,int rows,string expect)
        {
            var sol = new Solution();
            Assert.Equal(expect, sol.Convert(input,rows));
        }
        public class Solution
        {
            List<IList<char>> _lines;
            int _len = 0;
            public string Convert(string s, int numRows)
            {
                _lines = new List<IList<char>>(numRows);
                _len = s.Length;
                for(int i = 0; i < numRows; i++)
                {
                    _lines.Add(new List<char>(_len));
                }
                int lineNum = 0;
                int direction = 1;
                foreach(char c in s)
                {
                    
                    _lines[lineNum].Add(c);
                    if (numRows == 1)
                        continue;
                    if (lineNum == numRows - 1) 
                        direction = -1;
                    else if (lineNum == 0)
                        direction = 1;
                    lineNum += direction;
                    
                }
                return ReadStringOutOfLine();
            }

            private string ReadStringOutOfLine()
            {
                var sb = new StringBuilder(_len);
                foreach(List<char> line in _lines)
                {
                    sb.Append(line.ToArray());
                }
                return sb.ToString();
            }
        }
    }
}
