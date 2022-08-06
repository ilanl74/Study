using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UnitT;

public class CanConstructTabulation
{
    [Theory]
    [InlineData("ilankfdkajdshfk adsh fh fh sadffhakljsdhfkj ashdfkhdskhfdsah jfhdkjshfaweitiywtvncrnihncrty8yngf dyfg hk hguygibrety iuhfgudyg erwteiu bfdsg seguyrtige ythgieryt5i4t7w8e t78wfvejkmhjdkh kfhdsfhdsahfkjhheruytuiyewitkfg bvmj cvhgfdjgahfkah khdsfkhasdk hfkjhadsjfhdjskahfjkdashkjfhdsjkahfkjadshf hfn843756t84375kfdhjfkjhdgxjixc nke56t c346hw5o liy3ow8c843567f clmtredyujfml cie7fjdl mcde65 546jm lcw98elm jfkity83647hfp09345m cslo59345 dc9x68 u8g954m 98y6 i",
        new string[] { "il", "lab", "sr", "au", "op", "ant", "lab", "sr2", "au3", "opy", "anty", "il3", "lab3", "sr3", "au3", "op3", "ant3", "lab3", "sr23", "au33", "opy3", "anty3" }, false, 0)]
    [InlineData("ilan", new string[] { "ilr", "n", "ila", "i", "la", "vi", "ant" }, true, 2)]
    [InlineData("ilan", new string[] { "ilan" }, true, 1)]
    [InlineData("ilan", new string[] { "il", "an" }, true, 1)]
    public void Test(string input, string[] candidates, bool expected, int numOfCombinations)
    {
        Assert.Equal(expected, Calculate(input, candidates));
    }
    public bool Calculate(string input,string[] wordbank)
    {
        var res = new bool[input.Length+1];
        res[0] = true;
        var len = res.Length;
        for (var i = 0; i < len; i++)
        {
            if (res[i] )
                foreach(var word in wordbank)
                    if ((i + word.Length < len)&& input.Substring(i, word.Length) == word)
                        res[i + word.Length] = true;
                    
        }
        return res[input.Length];

    }
}
