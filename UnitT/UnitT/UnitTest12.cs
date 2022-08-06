using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest12
    {

        [Theory]
        [InlineData(3998, "MMMCMXCVIII")]
        [InlineData(1, "I")]
        public void TestRome(int num, string expected)
        {
            var Sol = new Solution();
            Assert.Equal(expected, Sol.IntToRoman(num));
        }
        public class Solution
        {
            (int x, int y)[] coords = new (int, int)[] { (1, 3), (5, 1), (8, 9) };


            private (int num,string sim )[] _rome = new (int , string )[]
            {
                (1000,"M" ),(900,"CM" ),(500,"D" ),(400,"CD" ),( 100,"C" ),(90,"XC"),( 50 ,"L"),(40,"XL" ),( 10,"X"  ),(9,"IX" ) ,(5,"V" ) ,(4,"IV" ),(  1,"I" )
            };
                
            public string IntToRoman(int num)
            {
                string _ans = string.Empty;
                int rest = num;
                int i = 0;
                while( rest > 0)
                {
                    while(rest - _rome[i].num <0)
                    {
                        i++;
                    }
                    _ans += _rome[i].sim;
                    rest-= _rome[i].num;
                    continue;
                }
                return _ans;
            }
        }
    }
}
