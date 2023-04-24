using FluentAssertions;
using System.Drawing;

namespace KodeOppgaveSolve
{
    public class UnitTest1
    {
        private IslandSolver? _sut = null;
        [Theory]
        [MemberData(nameof(GetGrids))]
        public void GetIslands_ShouldReturnCorrect(string[,] grid, int expectedIslands)
        {
            _sut = new IslandSolver();
            var islands = _sut.GetIslands(grid);
            islands.Should().Be(expectedIslands);
        }

        public static IEnumerable<object[]> GetGrids()
        {
            yield return new object[] { new string[,] { { "1", "1", "1", "1", "0" }, { "1", "1", "0", "1", "0" }, { "1", "1", "0", "0", "0" }, { "0", "0", "0", "0", "0" } }, 1 };
            yield return new object[] { new string[,] { { "1", "1", "0", "0", "0" }, { "1", "1", "0", "0", "0" }, { "0", "0", "1", "0", "0" }, { "0", "0", "0", "1", "1" } }, 3 };
            yield return new object[] { new string[,] { { "1", "0", "0", "1", "0" }, { "1", "1", "0", "0", "0" }, { "0", "0", "1", "0", "0" }, { "0", "0", "0", "1", "1" } }, 4 };
        }
    }

    public class IslandSolver
    {
        public int GetIslands(string[,] grid)
        {
            var islands = new List<HashSet<Point>>();
                       
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    var current = int.Parse(grid[i, j]);
                    if (current == 0)
                        continue;
                    
                    int top = 0, bottom = 0, left = 0, right = 0;

                    if (i > 0)
                        top = int.Parse(grid[i - 1, j]);
                    if (i < grid.GetLength(0) - 1)
                        bottom = int.Parse(grid[i + 1, j]);
                    if (j > 0)
                        left = int.Parse(grid[i, j-1]);
                    if (j < grid.GetLength(1) - 1)
                        right = int.Parse(grid[i, j+1]);

                    var found = false;
                    foreach (var island in islands)
                    {
                        if (top == 1)
                        {
                            if (island.Contains(new Point(i - 1, j)))
                            {
                                island.Add(new Point(i, j));
                                found = true;
                                break;
                            }
                        }
                        if (bottom == 1)
                        {
                            if (island.Contains(new Point(i + 1, j)))
                            {
                                island.Add(new Point(i, j));
                                found = true;
                                break;
                            }
                        }
                        if (left == 1)
                        {
                            if (island.Contains(new Point(i, j - 1)))
                            {
                                island.Add(new Point(i, j));
                                found = true;
                                break;
                            }
                        }
                        if (right == 1)
                        {
                            if (island.Contains(new Point(i, j + 1)))
                            {
                                island.Add(new Point(i, j));
                                found = true;   
                                break;
                            }
                        }
                    }
                    if (!found)
                        islands.Add(new HashSet<Point> { new Point(i, j) });
                }
            }
            return islands.Count;
        }
    }
}