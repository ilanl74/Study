using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class FibTabulation
    {
        [Theory]
        [InlineData(6, 8)]
        public void Test(int pos, int value)
        {
            Assert.Equal(value, Fib(pos));
        }

        public int Fib(int pos)
        {

            int[] data = new int[pos + 1];
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 1)
                    data[i] = 1;
                else
                    data[i] = 0;
            }
            for (int i = 0; i < data.Length; i++)
            {
                if (data.Length > i + 1)
                    data[i + 1] += data[i];
                if (data.Length > i + 2)
                    data[i + 2] += data[i];
            }
            return data[pos];
        }
    }
}
