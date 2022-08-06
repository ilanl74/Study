using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class LLFindIndex
    {
        [Theory]
        [ClassData(typeof(LLFindIndex.Data))]
        public void Test(LL<int> head,int index,int? val)
        {
            Assert.Equal(val,FindIndex(head,index));
        }

        private int? FindIndex(LL<int>head,int index)
        {
            if (index<0)
                return null;
            if (head == null)
                return null;
            if (index == 0)
                return head.Val;
            return FindIndex(head.Next,index-1);

        }

        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, 3, 18 };
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, 0, 0 };
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, 4, null };
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, -10, null };
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, 2, 9 };
                yield return new object[] { new LL<int>(0) { Next = new(4) { Next = new(9) { Next = new(18) } } }, 100, null };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
