using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class LLZipper
    {
        [Theory]
        [ClassData(typeof(LLZipper.Data))]
        public void Test(LL<string> first,LL<string> second,LL<string>expected ) 
        {
           // _ = Zip(first, second);
            Assert.Equal(expected, Zip(first, second));
        }

        private LL<string> Zip(LL<string> first,LL<string> second)
        {
            if (first == null)
                return second;
            if (second == null)
                return first;
            var fNext = first.Next;
            var sNext = second.Next;
            first.Next = second;
            second.Next = fNext;
            _ = Zip(fNext,sNext);
            return first;
        }

        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new LL<string>("ab") { Next = new("c") { Next = new("d") { Next = new("ef")  } } },
                    new LL<string>("1") { Next = new("23") { Next = new("4") { Next = new("5"){Next= new("o"){Next=new("r")} } } } },
                    new LL<string>("ab") { Next = new("1") { Next = new("c") { Next = new("23"){Next=new("d"){Next=new("4"){Next = new("ef"){Next=new("5"){Next=new("o"){Next=new("r") } } } } } } } } }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
