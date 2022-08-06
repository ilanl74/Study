using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class GminimumIsland
    {
        [Theory]
        [ClassData(typeof(GminimumIsland.Data))]
        public void Test(char[,] board, int? expected)
        {
            Assert.Equal(expected, Calculate(board));
        }

        private int? Calculate(char[,] board)
        {
            int? size = null;
            HashSet<(int x, int y)> visited = new();
            for (int x = 0; x < board.GetLength(0); x++)
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (visited.Contains((x, y)))
                        continue;
                    if (board[x, y] == 'L')
                    {
                        HashSet<(int x, int y)> island = new();
                        ExploreNewIsland(board, x, y, island);

                        if (size is null || size > island.Count)
                            size = island.Count;
                        visited.Union(island);
                    }
                }
            return size;

        }

        private void ExploreNewIsland(char[,] board, int x, int y, HashSet<(int x, int y)> visited)
        {
            if (x < 0 || y < 0 || (x > board.GetLength(0)-1) || (y > board.GetLength(1)-1))
                return;
            if (visited.Contains((x, y)))
                return;
            if (board[x, y] == 'W')
                return;
            visited.Add((x, y));
            ExploreNewIsland(board, x + 1, y, visited);
            ExploreNewIsland(board, x - 1, y, visited);
            ExploreNewIsland(board, x, y + 1, visited);
            ExploreNewIsland(board, x, y - 1, visited);


        }



        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                char[,] b1 = new char[8, 8];
                b1[0, 0] = 'W';
                b1[0, 1] = 'L';
                b1[0, 2] = 'W';
                b1[0, 3] = 'W';
                b1[0, 4] = 'W';
                b1[0, 5] = 'W';
                b1[0, 6] = 'W';
                b1[0, 7] = 'W';
                //-------------------
                b1[1, 0] = 'W';
                b1[1, 1] = 'L';
                b1[1, 2] = 'W';
                b1[1, 3] = 'W';
                b1[1, 4] = 'W';
                b1[1, 5] = 'W';
                b1[1, 6] = 'W';
                b1[1, 7] = 'W';
                //-------------------
                b1[2, 0] = 'W';
                b1[2, 1] = 'W';
                b1[2, 2] = 'L';
                b1[2, 3] = 'L';
                b1[2, 4] = 'L';
                b1[2, 5] = 'L';
                b1[2, 6] = 'W';
                b1[2, 7] = 'W';
                //-------------------
                b1[3, 0] = 'W';
                b1[3, 1] = 'L';
                b1[3, 2] = 'L';
                b1[3, 3] = 'W';
                b1[3, 4] = 'W';
                b1[3, 5] = 'W';
                b1[3, 6] = 'W';
                b1[3, 7] = 'W';
                //-------------------
                b1[4, 0] = 'W';
                b1[4, 1] = 'W';
                b1[4, 2] = 'W';
                b1[4, 3] = 'W';
                b1[4, 4] = 'W';
                b1[4, 5] = 'L';
                b1[4, 6] = 'L';
                b1[4, 7] = 'W';
                //-------------------
                b1[5, 0] = 'W';
                b1[5, 1] = 'W';
                b1[5, 2] = 'W';
                b1[5, 3] = 'W';
                b1[5, 4] = 'W';
                b1[5, 5] = 'L';
                b1[5, 6] = 'L';
                b1[5, 7] = 'W';
                //-------------------
                b1[6, 0] = 'W';
                b1[6, 1] = 'W';
                b1[6, 2] = 'W';
                b1[6, 3] = 'W';
                b1[6, 4] = 'W';
                b1[6, 5] = 'W';
                b1[6, 6] = 'W';
                b1[6, 7] = 'W';
                //-------------------
                b1[7, 0] = 'W';
                b1[7, 1] = 'W';
                b1[7, 2] = 'W';
                b1[7, 3] = 'W';
                b1[7, 4] = 'W';
                b1[7, 5] = 'L';
                b1[7, 6] = 'L';
                b1[7, 7] = 'W';
                //-------------------

                yield return new object[] { b1, 2 };
            }


            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
    }
}
