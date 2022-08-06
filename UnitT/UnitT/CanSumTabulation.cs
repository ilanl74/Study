using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class CanSumTabulation
    {
        [Theory]
        [InlineData(8, new int[] { 5, 3, 7 }, true)]
        [InlineData(17, new int[] {  7 ,9}, false)]
        public void Test(int target,int[] candidats,bool can)
        {
            Assert.Equal(can,Calculate(target,candidats));
        }
        private bool Calculate(int target,int[] candidats)
        {
            var res = new bool[target +1]  ;
            res[0]  = true ;
            var len = res.Length ;
            for(int i=0;i< len; i++)
            {
                if (!res[i])
                    continue ;
                foreach (var candidat in candidats)
                {
                    if (i+candidat<len)
                    {
                        res[i+candidat] = true ;
                    }
                }
                   
            }
            

            return res[target];
        }
    }
}
