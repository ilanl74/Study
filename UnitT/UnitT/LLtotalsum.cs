using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{

    public class LLtotalsum
    {//return a sum of link list iterative and recursive 
        [Theory]
        [ClassData(typeof(LLtotalsum.Data))]
        public void Test(LL<int> head, int sum)
        {
            Assert.Equal(Calculate(head), sum);
            Assert.Equal(CalculateRec(head), sum);
        }

        private int Calculate(LL<int> head)
        {
            var sum = 0;
            var current = head;
            while (current != null)
            {
                sum += current.Val;
                current = current.Next;
            }
            return sum;
        }

        private int CalculateRec(LL<int> head,int sum=0)
        {
            if (head == null)
                return 0;
            return head.Val + CalculateRec(head.Next);
        }

        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                LL<int> head = new(3)
                {
                    Next = new(7)
                    {
                        Next = new(9)
                        {
                            Next = new(5)
                        }
                    }
                };



                yield return new object[] { head, 24 };
                yield return new object[] { new LL<int>(8) { Next = new(7) { Next = new(5) { Next = new(5) } } }, 25 };
                yield return new object[] { new LL<int>(8) { Next = new(7) { Next = new(0) { Next = new(5) } } }, 20 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
    public class LL<T> :IEquatable<LL<T>>
    {
        public T Val { get; set; }
        public LL<T>? Next { get; set; } = null;
        public LL(T val)
        {
            Val = val;
        }

        public bool Equals(LL<T>? other)
        {
            var ans = other?.Val.Equals(Val);
            if (ans.HasValue)
                return ans.Value;
            return (this == null);
        }
        public override bool Equals(object? obj) => Equals(obj as LL<T>);
        
        public override int GetHashCode()
        {
            return Val.GetHashCode();
        }
    }
}
