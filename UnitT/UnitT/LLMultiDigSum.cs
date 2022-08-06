using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class LLMultiDigSum
    {
        [Theory]
        [ClassData(typeof(LLMultiDigSum.Data))]
        public void Test(LL<int> first, LL<int> second, LL<int> res)
        {
            var (x, y) = Calculate(first, second);
            LL<int> act;
            if (y == 1)
            {
                act = new(1) { Next = x };

            }
            else
                act = x;
            Assert.Equal(res, act);
        }
        private (LL<int>,int) Calculate(LL<int> first, LL<int> second,  bool firsCall = true)
        {
            if (firsCall)
                FixLen(ref first, ref second);


            if ((first == null) && (second == null))
                return (null,0);
            var (x,r) = Calculate(first.Next, second.Next, false);
            var res = first.Val + second.Val +r;
            first.Val = res % 10;
            var remainder = (res > 9) ? 1 : 0;
            return (first,remainder);

        }

        private void FixLen(ref LL<int> first,ref LL<int> second)
        {
            int flen = CountDig(first);
            int slen = CountDig(second);
            var lenDif = flen - slen;
            if (lenDif == 0)
                return;
            if (lenDif > 0)
                PadLeft(ref second, lenDif);
            else
                PadLeft(ref first, lenDif * (-1));
        }

        private void PadLeft(ref LL<int> l, int count)
        {
            LL<int> curr = new(0);
            LL<int> res = null;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    res = curr;
                }
                else
                {
                    curr.Next = new(0);
                    curr = curr.Next;
                }
               
            }
            curr.Next = l;
            l=  res;
        }
        private int CountDig(LL<int> num)
        {
            int i = 0;
            while (num != null)
            {
                i++;
                num = num.Next;
            }
            return i;

        }
        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new LL<int>(1) { Next = new(8) { Next = new(5) } }, new LL<int>(8) { Next = new(7) }, new LL<int>(2) { Next = new(7) { Next = new(2) } } };
                yield return new object[] {  new LL<int>(9) { Next = new(9) },new LL<int>(9) { Next = new(9) { Next = new(9) } },
                new LL<int>(1) { Next = new(0) { Next = new(9){Next=new(8) } } }};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
