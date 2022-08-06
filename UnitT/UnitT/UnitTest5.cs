using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest5
    {

        [Theory]
        [InlineData("babad", "aba")]
        [InlineData("ac", "a")]
        public void GetLongestPalindrome(string s,string pal)
        {
            var sol = new Solution();
            var res = sol.LongestPalindrome(s);
            Assert.Equal(pal, res); 
        }
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                if (s.Length==1)
                    return s;
                string ans=string.Empty;
                int max  = 0;
                for(int i=0; i+1<s.Length; i++)
                { 
                    var sing = PalindromeSize(s,i,i);
                    
                    var doub = PalindromeSize(s, i, i+1);
                    if (max > doub.size && max > sing.size)
                        continue;
                    if (doub.size > sing.size)
                    {
                        max = doub.size;
                        ans = doub.pal;
                    }
                    else
                    {
                        max = sing.size;
                        ans = sing.pal;
                    }
                        

                    

                }
                return ans;        
            }

            private (int size,string pal) PalindromeSize(string s,int right , int left )
            {
                string ans = string.Empty;
                int len = right-left+1;
                int oldRight = 0;
                while (right >=0 && left<s.Length)
                {
                    if (right == left)
                    {
                        len = 1;
                        ans = s[right].ToString();
                       
                    }
                    else if (s[right] == s[left])
                    {
                        len += 2;
                        oldRight = right;
                    }
                    else
                        break;
                    right--;
                    left++;
                }

                ans = s.Substring(oldRight, len);
                return (len,ans);
            }
        }

    }
}
