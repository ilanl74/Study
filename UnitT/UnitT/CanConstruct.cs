using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class CanConstruct
    {
        [Theory]
        //[InlineData("ilankfdkajdshfk adsh fh fh sadffhakljsdhfkj ashdfkhdskhfdsah jfhdkjshfaweitiywtvncrnihncrty8yngf dyfg hk hguygibrety iuhfgudyg erwteiu bfdsg seguyrtige ythgieryt5i4t7w8e t78wfvejkmhjdkh kfhdsfhdsahfkjhheruytuiyewitkfg bvmj cvhgfdjgahfkah khdsfkhasdk hfkjhadsjfhdjskahfjkdashkjfhdsjkahfkjadshf hfn843756t84375kfdhjfkjhdgxjixc nke56t c346hw5o liy3ow8c843567f clmtredyujfml cie7fjdl mcde65 546jm lcw98elm jfkity83647hfp09345m cslo59345 dc9x68 u8g954m 98y6 i",
        //   new string[] { "il", "lab", "sr", "au", "op", "ant", "lab", "sr2", "au3", "opy", "anty", "il3", "lab3", "sr3", "au3", "op3", "ant3", "lab3", "sr23", "au33", "opy3", "anty3" }, false, 0)]
        [InlineData("ilan", new string[] { "ilr", "n", "ila", "i", "la", "vi", "ant" }, true, 2)]
        [InlineData("ilan", new string[] { "ilan" }, true, 1)]
        [InlineData("ilan", new string[] { "il", "an" }, true, 1)]
        public void Test(string input, string[] candidates, bool expected, int numOfCombinations)
        {
            //Assert.Equal(expected, Calc(input, candidates));
            //Assert.Equal(expected, CalcMemo(input, candidates));
            //_memo.Clear();
            //Assert.Equal(expected, Calcbetter(input, candidates));
            _memo.Clear();
            //_ = ;
            int c = 0;
            //Assert.Equal(numOfCombinations, CalcNum(input, candidates));
            var ans = CalcAll(input, candidates);

            Assert.NotNull(ans);
        }
        public bool Calc(string input, string[] candidates)
        {

            foreach (var str in candidates)
            {
                if (str == input)
                    return true;
            }
            if (input.Length <= 1)
                return false;
            var c = false;
            for (int i = 0; i < input.Length - 1; i++)
            {
                c = Calc(input.Substring(0, i + 1), candidates) && Calc(input.Substring(i + 1, input.Length - i - 1), candidates);
                if (c)
                    return c;
            }
            return c;

        }

        Dictionary<string, bool> _memo = new Dictionary<string, bool>();
        Dictionary<string, int> _memoC = new Dictionary<string, int>();

        public bool CalcMemo(string input, string[] candidates)
        {
            if (_memo.ContainsKey(input))
                return _memo[input];
            foreach (var str in candidates)
            {
                if (str == input)
                {
                    if (!_memo.ContainsKey(input))
                        _memo.Add(input, true);
                    return _memo[input];
                }

            }

            if (input.Length <= 1)
            {
                if (!_memo.ContainsKey(input))
                    _memo.Add(input, false);
                return _memo[input];
            }

            var c = false;
            for (int i = 0; i < input.Length - 1; i++)
            {
                c = CalcMemo(input.Substring(0, i + 1), candidates) && CalcMemo(input.Substring(i + 1, input.Length - i - 1), candidates);
                if (c)
                {
                    if (!_memo.ContainsKey(input))
                        _memo.Add(input, c);
                    return _memo[input];
                }

            }
            if (!_memo.ContainsKey(input))
                _memo.Add(input, c);
            return _memo[input];

        }

        public bool Calcbetter(string input, string[] candidates)
        {
            if (_memo.ContainsKey(input))
                return _memo[input];
            if (input == String.Empty)
                return true;
            var curr = false;
            foreach (var str in candidates)
            {
                if (input.StartsWith(str))
                {
                    curr = Calcbetter(input.Remove(0, str.Length), candidates);

                }

            }

            _memo.Add(input, curr);
            return _memo[input];
        }

        int _andCalcNum = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="candidates"></param>
        /// <returns>the number of ways the input can be constructed using the candidats</returns>
        public int CalcNum(string input, string[] candidates)
        {
            if (_memo.ContainsKey(input))
                return _memoC[input];
            if (input == string.Empty)
            {
                return 1;
            }
            int total = 0;
            foreach (var str in candidates)
            {
                if (input.StartsWith(str))
                {

                    total += CalcNum(input.Remove(0, str.Length), candidates);
                    if (!_memoC.ContainsKey(input))
                        _memoC.Add(input, total);
                }


            }
            if (!_memoC.ContainsKey(input))
                _memoC.Add(input, total);
            return total;
        }


        Dictionary<string, List<string>> _memoRes = new Dictionary<string, List<string>>();

        public List<List<string>> CalcAll(string input, string[] candidates)
        {
            if (_memoRes.ContainsKey(input))
            {
                var x = new List<List<string>>();
                x.Add(new List<string>(_memoRes[input]));
                return x;
            }
                
            if (input == string.Empty)
            {
                var ret = new List<List<string>>();
                ret.Add(new List<string>());
                return ret;
            }
            List<List<string>> res = new();// List<List<string>>();
            foreach (var str in candidates)
            {
                if (input.StartsWith(str))
                {
                    var sub = CalcAll(input.Remove(0, str.Length), candidates);
                    sub.ForEach(item => item.Insert(0, str));

                    sub.ForEach(l =>
                    {
                        res.Add(l);
                        if (!_memoRes.ContainsKey(input))
                            _memoRes.Add(input,new List<string>( l));
                    });


                }

            }

            return res;



        }
    }
}
