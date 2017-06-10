namespace Question_08_02_RobotInAGrid
{
    public class Cell
    {
        private int row;
        private int column;
        private Grid grid;

        public Cell(Grid grid, int row, int column, int data, bool isBlocked = false)
        {
            this.grid = grid;
            this.row = row;
            this.column = column;
            IsBlocked = isBlocked;
            Data = data;
        }

        public Cell Right => grid[row, column + 1];
        public Cell Down => grid[row + 1, column];
        public bool IsBlocked { get; }
        public int Data { get; }

        public override string ToString()
        {
            if (IsBlocked) return "B";
            return Data.ToString();
        }

        public void SetIndex(int index)
        {
            int row, column;
            grid.GetLocationFromIndex(index, out row, out column);

            this.row = row;
            this.column = column;
        }
    }
}