using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest11
    {
        [Theory]
        [InlineData(new int[] {1,4,3,6,5,22,7},20)]
        [InlineData(new int[] { 1, 4, 3, 6, 5, 22, 21 }, 21)]
        [InlineData(new int[] { 10, 4, 3, 6, 5, 22, 21 }, 60)]

        public void CalculateMaxErea(int[] h,int res)
        {
            //var sol = new Solution();
            //Assert.Equal(res, sol.MaxArea(h));
            var bsol = new BetterSolution();
            Assert.Equal(res, bsol.MaxArea(h));
        }   
        public class Solution
        {

            public int MaxArea(int[] height)
            {
                int max = 0;

                for(int i = 0; i < height.Length; i++)
                    for(int j = i+1; j < height.Length; j++)
                    {
                        int minHight  = Math.Min( height[j],height[i]);
                        int curr = minHight* (j-i);
                        max = Math.Max(max, curr);
                    }
                return max;
            }
        }
        /// <summary>
        /// the solution is based on 2 pointers o(n) and the consept is that each step we choose to stick with the heighst bar 
        /// because choosing the lower bar will not bring better result on this step and each step is taking us to worst place 
        /// </summary>
        public class BetterSolution
        {

            public int MaxArea(int[] height)
            {
                int max = 0;
                int right = height.Length-1;
                int left = 0;
                while (right > left)
                {
                    if (height[right] > height[left])
                    {
                        var curr = height[left] * (right- left);
                        max = Math.Max(max, curr);
                        left++;
                    }
                    else
                    {
                        var curr = height[right] * (right - left);
                        max = Math.Max(max, curr);
                        right--;
                    }
                }
                    
                
                        
                return max;
            }
        }

    }
}
