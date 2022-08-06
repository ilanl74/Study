using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class LLReverse
    {
        [Theory]
        [ClassData(typeof(LLReverse.Data))]
        public void Test(LL<int> head, LL<int> expected)
        {
            //Assert.Equal(expected, Reverse(head));
            Assert.Equal(expected, ReverseRec(head));
        }
        //strat iterate with 3 pointers 
        private LL<int> Reverse(LL<int> head)
        {
            var next = head.Next;
            var current = head;
            LL<int> prev = null;

            while (current != null)
            {
                current.Next = prev;

                prev = current;
                current = next;
                if (next != null)
                    next = next.Next;

            }

                

            return prev;
        }

        private LL<int> ReverseRec(LL<int> head, LL<int> prev = null)
        {
            if (head == null)
                return prev;
            var next = head.Next;
            head.Next = prev;
            return ReverseRec(next, head);
        }
        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {new LL<int>(1) { Next = new(2) { Next = new(3) { Next = new(4) { Next = new(5) { Next = new(6)  } } } } },
                new LL<int>(6) { Next = new(5) { Next = new(4) { Next = new(3) { Next = new(2) { Next = new(1)  } } } } }
               };
                yield return new object[] {new LL<int>(6) { Next = new(5) { Next = new(4) { Next = new(3) { Next = new(2) { Next = new(1)  } } } } },
                    new LL<int>(1) { Next = new(2) { Next = new(3) { Next = new(4) { Next = new(5) { Next = new(6)  } } } } }

               };


            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
