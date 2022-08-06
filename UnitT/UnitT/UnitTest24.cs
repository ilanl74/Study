using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class UnitTest24
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void Test(ListNode input, ListNode expected)
        {
            var sol = new Solution();
            ListNode newHead = null;
           // sol.Reverse(input);

            // var c = sol.ReverseR(input);
            var c = sol.SwapPairs(input);
            Assert.NotNull(c);

        }
        
 //Definition for singly-linked list.
        public class ListNode : IEquatable<ListNode> 
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
            public bool Equals(ListNode? other)
            {
                if ((this.next != null) && (other.next != null))
                    return this.next.Equals(other.next);

                if (((other == null)&& (this != null)) ||
                    ((other != null) && (this == null)))
                    return false;
                if (this.val != other.val)
                    return false;
                
                return true;
            }
        }

        public class Solution
        {
            public ListNode reverveHead;
            public ListNode SwapPairs(ListNode head)
            {
                if ((head == null)||(head.next == null))
                    return head;
                var first = head;
                var second = head.next;
                first.next = SwapPairs(second.next);
                second.next = first;
                return second;
            }
            
            public void Reverse(ListNode n)
            {
                //if (n == null)
                //    return;
                if (n.next == null)
                {
                    reverveHead = n;
                    return;
                }
                Reverse(n.next);
                n.next.next = n;
                n.next = null;
                
                
            }

            public ListNode ReverseR(ListNode n)
            {
                
                if (n.next == null)
                {
                    
                    return n;
                }
                // n.next  = Reverse(n.next);
                n.next.next = ReverseR(n.next);
               // n.next = null;
                return ReverseR(n.next);

            }

        }

        public class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var input = new ListNode() { val = 0 };
                var input1 = new ListNode() { val = 1 };
                var input2 = new ListNode() { val = 2 };
                var input3 = new ListNode() { val = 3 };
                var input4 = new ListNode() { val = 4 };
                var input5 = new ListNode() { val = 5 };
                var input6 = new ListNode() { val = 6 };
                input.next = input1;
                input1.next = input2;
                input2.next = input3;
                input3.next = input4;
                input4.next = input5;
                input5.next = input6;

                var output = new ListNode() { val = 1 };
                var output1 = new ListNode() { val = 0 };
                var output2 = new ListNode() { val = 3 };
                var output3 = new ListNode() { val = 2 };
                var output4 = new ListNode() { val = 5 };
                var output5 = new ListNode() { val = 4 };
                var output6 = new ListNode() { val = 6 };
                output.next = output1;
                output1.next = output2;
                output2.next = output3;
                output3.next = output4;
                output4.next = output5;
                output5.next = output6;


                yield return new object[] { input, output };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            
        }
    }
}
