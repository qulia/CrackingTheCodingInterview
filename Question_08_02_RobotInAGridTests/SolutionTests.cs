using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Question_08_02_RobotInAGrid.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void FindPathBasicTest()
        {
            Grid grid = CreateSimpleGrid();

            Trace.WriteLine(grid);

            Solution solution = new Solution();
            var path = solution.FindPath(grid);

            Assert.AreEqual(false, path.IsStuck);
            Trace.WriteLine(path);
        }

        [TestMethod()]
        public void FindPathRandomTest()
        {
            Grid grid = CreateRandomGrid(5, 6, 2);

            Trace.WriteLine(grid);

            Solution solution = new Solution();
            var path = solution.FindPath(grid);

            Trace.WriteLine(path.IsStuck ? "No Path": "Found Path");
            Trace.WriteLine(path);
        }

        [TestMethod()]
        public void FindPathRandomTest2()
        {
            Grid grid = CreateRandomGrid(5, 6, 10);

            Trace.WriteLine(grid);

            Solution solution = new Solution();
            var path = solution.FindPath(grid);

            Trace.WriteLine(path.IsStuck ? "No Path" : "Found Path");
            Trace.WriteLine(path);
        }

        [TestMethod()]
        public void FindPathRandomTest3()
        {
            Grid grid = CreateRandomGrid(10, 10, 10);

            Trace.WriteLine(grid);

            Solution solution = new Solution();
            var path = solution.FindPath(grid);

            Trace.WriteLine(path.IsStuck ? "No Path" : "Found Path");
            Trace.WriteLine(path);
        }

        private Grid CreateRandomGrid(int numberOfRows, int numberOfColumns, int numberOfBlockedCells)
        {
            Grid grid = new Grid(numberOfRows, numberOfColumns);
            var numberOfCells = numberOfRows * numberOfColumns;
            if (numberOfBlockedCells > numberOfCells)
            {
                throw new InvalidOperationException();
            }

            // Set initial numberOfBlockedCells to to be blocked then shuffle the grid
            SetCells(grid, 0, numberOfBlockedCells - 1, (row, column, data) => new Cell(grid, row, column, data, true));
            SetCells(grid, numberOfBlockedCells, numberOfCells - 1, (row, column, data) => new Cell(grid, row, column, data));
            ShuffleGrid(grid);

            return grid;
        }

        private void ShuffleGrid(Grid grid)
        {
            int numberOfCells = grid.NumberOfColumns * grid.NumberOfRows;
            Random random = new Random();
            for (int i = 0; i < numberOfCells; i++)
            {
                var j = i + random.Next(0, numberOfCells - i);
                if (i != j)
                {
                    SwapCells(grid, i, j);
                }
            }
        }

        private void SwapCells(Grid grid, int i, int j)
        {
            var temp = grid[i];
            grid[i] = grid[j];
            grid[j] = temp;

            grid[i].SetIndex(i);
            grid[j].SetIndex(j);
        }

        private void SetCells(Grid grid, int startIndex, int endIndex, Func<int, int, int, Cell> getCell)
        {
            Random random = new Random();
            for (int i = startIndex; i <= endIndex; i++)
            {
                int row, column;
                grid.GetLocationFromIndex(i, out row, out column);
                var data = random.Next(startIndex, endIndex);
                grid[row, column] = getCell(row, column, data);
            }
        }

        // 1 2 B
        // 4 B 6
        // 7 8 9
        private Grid CreateSimpleGrid()
        {
            Grid grid = new Grid(3, 3);
            grid[0, 0] = new Cell(grid, 0, 0, 1);
            grid[0, 1] = new Cell(grid, 0, 1, 2);
            grid[0, 2] = new Cell(grid, 0, 2, -1, true);
            grid[1, 0] = new Cell(grid, 1, 0, 4);
            grid[1, 1] = new Cell(grid, 1, 1, -1, true);
            grid[1, 2] = new Cell(grid, 1, 2, 6);
            grid[2, 0] = new Cell(grid, 2, 0, 7);
            grid[2, 1] = new Cell(grid, 2, 1, 8);
            grid[2, 2] = new Cell(grid, 2, 2, 9);

            return grid;

        }
    }
}