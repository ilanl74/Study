using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class CountConstructTabulation
    {
        [Theory]
        [InlineData("ilankfdkajdshfk adsh fh fh sadffhakljsdhfkj ashdfkhdskhfdsah jfhdkjshfaweitiywtvncrnihncrty8yngf dyfg hk hguygibrety iuhfgudyg erwteiu bfdsg seguyrtige ythgieryt5i4t7w8e t78wfvejkmhjdkh kfhdsfhdsahfkjhheruytuiyewitkfg bvmj cvhgfdjgahfkah khdsfkhasdk hfkjhadsjfhdjskahfjkdashkjfhdsjkahfkjadshf hfn843756t84375kfdhjfkjhdgxjixc nke56t c346hw5o liy3ow8c843567f clmtredyujfml cie7fjdl mcde65 546jm lcw98elm jfkity83647hfp09345m cslo59345 dc9x68 u8g954m 98y6 i",
       new string[] { "il", "lab", "sr", "au", "op", "ant", "lab", "sr2", "au3", "opy", "anty", "il3", "lab3", "sr3", "au3", "op3", "ant3", "lab3", "sr23", "au33", "opy3", "anty3" }, false, 0)]
        [InlineData("ilan", new string[] { "ilr", "n", "ila", "i", "la", "vi", "ant" }, true, 2)]
        [InlineData("ilan", new string[] { "ilan" }, true, 1)]
        [InlineData("ilan", new string[] { "il", "an" }, true, 1)]
        [InlineData("ilan", new string[] { "il", "an","i","l","n","a" }, true, 4)]
        public void Test(string input, string[] candidates, bool expected, int numOfCombinations)
        {
            Assert.Equal(numOfCombinations, Calculate(input, candidates));
        }

        private int Calculate(string input, string[] wordbank)
        {
            var res = new int[input.Length+1];
            
            foreach(var r in res)
                res[r] = 0;
            res[0] = 1;
            for(var i=0; i<res.Length; i++)
            {
                if (res[i] == 0)
                    continue;
                foreach (var word in wordbank)
                    if ((i + word.Length < res.Length)&& input.Substring(i, word.Length) == word)
                        res[i + word.Length]+= res[i];
            }
            return res[input.Length];
        }
    }
}
