namespace Question_08_02_RobotInAGrid
{
    public class Solution
    {
        public Path FindPath(Grid grid)
        {
            var path = FindPathRecurse(grid, grid.Start);

            return path;
        }

        private Path FindPathRecurse(Grid grid, Cell currentCell)
        {
            if (currentCell == null || currentCell.IsBlocked)
            {
                return new Path(true);
            }

            if (currentCell == grid.End)
            {
                // Reached to the end, can go up the stack to create the path
                var path = new Path();
                path.Add(currentCell);

                return path;
            }

            var resultPath = FindPathRecurse(grid, currentCell.Right);
            if (resultPath.IsStuck)
            {
                resultPath = FindPathRecurse(grid, currentCell.Down);                
            }

            resultPath.Add(currentCell);
            return resultPath;
        }
    }
}
