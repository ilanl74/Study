using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitT
{
    public class UnitTest19
    {
        [Theory]
        [ClassData(typeof(ExampleList))]
        public void TestRemoveNthFromEnd(ListNode head, int n, ListNode expected)
        {
            var sol = new Solution();
            Assert.Equal(expected, sol.RemoveNthFromEnd(head, n));
        }
        public class Solution
        {
            ListNode _head;
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                //if ((head.next == null) && (n == 1))
                //    return null;
                _head = head;
                var tmp = head;
                _len = 1;
                while(tmp.next != null)
                {
                    _len++;
                    tmp = tmp.next;
                }
                if (n == _len)
                {
                    _head=head.next;
                    return _head;
                }
                tmp = head;
                for (int i = 0; i < _len-n-1 && tmp.next != null ; i++)
                {
                    tmp = tmp.next;
                }
                tmp.next = tmp.next.next;

               // GetNodeToRemove(head, n,1);
                return _head;
            }
            int _len = -1;
            int _currentPos = -1;
            ListNode _toRemove = null;
            private void GetNodeToRemove(ListNode tmp, int n,int count)
            {
                if (tmp.next == null)
                {
                    _len = count;
                    _currentPos = 1;
                    if (n == _len)
                    {
                        _head = _head.next;
                    }
                    return;
                }
                
                GetNodeToRemove(tmp.next, n,++count);
                //if (n == _len)
                //{
                //    _head = _head.next;
                //}
                _currentPos++;
                if (_currentPos == n + 1)
                {
                    if (n == 1)
                    {
                        tmp.next = null;
                    }
                    else
                    {
                        tmp.next = tmp.next.next;
                        //tmp.next.next = null;
                    }

                }



            }
        }
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
                return this?.val == other?.val;
            }
        }
        public class ExampleList : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var node1 = new ListNode()
                {
                    val = 1,
                    next = new ListNode()
                    {
                        val = 2,
                        next = new ListNode()
                        {
                            val = 3,
                            next = new ListNode()
                            {
                                val = 4,
                                next = new ListNode()
                                {
                                    val = 5,
                                    next = new ListNode()
                                    {
                                        val = 6,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                };

                var node2 = new ListNode()
                {
                    val = 1,
                    next = new ListNode()
                    {
                        val = 2,
                        next = new ListNode()
                        {
                            val = 3,
                            next = new ListNode()
                            {
                                val = 4,
                                next = new ListNode()
                                {
                                    val = 6,
                                    next = null
                                }
                            }
                        }
                    }
                };
                var node3 = new ListNode()
                {
                    val = 1,
                    next = null
                };
                ListNode node4 = null;

                var node5 = new ListNode()
                {
                    val = 1,
                    next = new ListNode()
                    {
                        val=2,
                        next= null
                    }
                };
                var node6 = new ListNode()
                {
                    val = 1
                };
                var node7 = new ListNode()
                {
                    val = 2
                };
                //yield return new object[] { node1, 2, node2 };
                //yield return new object[] { node3, 1, node4 };
                //yield return new object[] { node5, 1, node6 };
                yield return new object[] { node5, 2, node7 };
            }
        

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
    }
}
