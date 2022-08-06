using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class LLFindTargetcs
    {
        [Theory]
        [ClassData(typeof(LLFindTargetcs.Data))]
        public void Test(LL<int> head,int target,bool shoulFind)
        {
            Assert.Equal(shoulFind, Calculate(head, target));
        }

        private bool Calculate(LL<int> head, int target)
        {
            if (head == null)
                return false;
            if (target == head.Val)
                return true;
            return Calculate(head.Next, target);
        }
        
        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new LL<int>(0) { Next = new(44) { Next = new(99) { Next = new(12) } } } ,88,false};
                yield return new object[] { new LL<int>(0) { Next = new(88) { Next = new(99) { Next = new(12) } } }, 88 ,true};
                yield return new object[] { new LL<int>(0) { Next = new(44) { Next = new(99) { Next = new(88) } } }, 88 ,true};
                yield return new object[] { new LL<int>(0) { Next = new(44) { Next = new(99) { Next = new(44) } } }, 88 ,false};
                yield return new object[] { new LL<int>(0) { Next = new(44) { Next = new(99) { Next = new(0) } } }, 88 ,false};
            }

            IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
        }
    }
}
