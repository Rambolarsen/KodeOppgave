using FluentAssertions;

namespace KodeOppgaveSolve
{
    public class IslandSolverTests
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
}