using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class Tester
    {
        [Theory]
        [InlineData(new int[] { 3, 7, 5 }, 73, new[] {3, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7})]
        [InlineData(new int[] { 3, 7, 17 }, 17, new[] { 17 })]
        public void TestShortestSum(int[] candidat, int target, int[] expected)
        {
            ShortestSum sol = new();
            // sol.Calculate(candidat, target, new List<int>());
            var x = sol.Calculate(candidat, target);
            Assert.Equal(expected, sol.Calculate(candidat, target)?.ToArray());
        }
    }
    internal class ShortestSum
    {
        

        public List<int> _ans =null;
        bool _canSum = false;
        Dictionary<int,List<int>> _subRes = new Dictionary<int,List<int>>();
        public List<int>  Calculate(int[]candidat,int target)
        {

            if (target < 0) return null;
            if (target == 0) 
                return new List<int>();
            if (_subRes.ContainsKey(target))
            {
                if (_subRes[target] == null)
                    return null;
                return new List<int>(_subRes[target]);
            }
                
            foreach(int i in candidat)
            {
                var nt = target - i;
                
                var curr = Calculate(candidat,nt);
                if (curr != null)
                {

                    var x = new List<int>(curr);
                    x.Add(i);
                    if(_subRes.ContainsKey(target))
                    {
                        if (_subRes[target].Count > x.Count)
                            _subRes[target] = x;
                    }
                    else 
                        _subRes.Add(target,x );
                    //return _subRes[target];
                }
                
            }
            if (_subRes.ContainsKey(target))
                return _subRes[target];
            _subRes.Add(target, null);
            return null;
        }
    }
}
/*
 internal class ShortestSum
    {
        

        public List<int> _ans =null;
        bool _canSum = false;
        Dictionary<int,List<int>> _subRes = new Dictionary<int,List<int>>();
        public void Calculate(int[]candidat,int target,List<int> curr)
        {
            if ((_ans != null) && curr.Count == _ans.Count)
                    return;
            
            if (target == 0)
            {   
                if ((_ans == null) ||(_ans.Count > curr.Count))
                {
                    _ans = new List<int>(curr);
                   
                }
                return;
            }
            
            foreach(int i in candidat)
            {
                var nt = target - i;
                if (nt < 0)
                    continue;
                curr.Add(i);
                Calculate(candidat,nt,curr);
                curr.RemoveAt(curr.Count -1);
            }
        }
    }
*/