using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class GridTravelerTabulation
    {
        [Theory]
        [InlineData(3, 3, 6)]
        [InlineData(1, 3, 1)]
        [InlineData(3, 1, 1)]
        [InlineData(2, 3, 3)]
        // [InlineData(18, 18, 2333606220)]
        public void Test(int numOfRows, int numOfcols, long waysToTravel)
        {
            //Assert.Equal(waysToTravel, GridTraveler(numOfRows, numOfcols));

            Assert.Equal(waysToTravel, RecGridTraveler(numOfRows, numOfcols,(0,0)));
            
            
        }
        private long GridTraveler(int posx, int posy)
        {
            var numOfRows = posx + 1;
            var numOfcols = posy + 1;
            var grid = new long[numOfRows, numOfcols];
            for (int i = 0; i < numOfRows; i++)
                for (int j = 0; j < numOfcols; j++)
                    grid[i, j] = 0;
            grid[1, 1] = 1;
            for (int i = 0; i < numOfRows; i++)
                for (int j = 0; j < numOfcols; j++)
                {
                    if (numOfRows > i + 1)
                        grid[i + 1, j] += grid[i, j];
                    if (numOfcols > j + 1)
                        grid[i, j + 1] += grid[i, j];
                }
            return grid[posx, posy];
        }

        private long RecGridTraveler(int posx, int posy,(int x,int y) curr)
        {
            if ((curr.x > posx-1)||(curr.y > posy-1))
                return 0;
            if ((curr.x == posx-1) && (curr.y == posy-1))
                return 1;
            var nextRight = (curr.x+1, curr.y);
            var nextDown = (curr.x, curr.y+1);
            return RecGridTraveler(posx, posy, nextRight)+ RecGridTraveler(posx,posy,nextDown);

        }

    }
}
