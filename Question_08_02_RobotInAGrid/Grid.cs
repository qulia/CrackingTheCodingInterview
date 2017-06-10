using System;
using System.Text;

namespace Question_08_02_RobotInAGrid
{
    public class Grid
    {
        Cell[,] cells;

        public Grid(int numberOfRows, int numberOfColumns)
        {
            NumberOfColumns = numberOfColumns;
            NumberOfRows = numberOfRows;
            cells = new Cell[NumberOfRows, NumberOfColumns];
        }

        private bool InBounds(int row, int column)
        {
            return !(row < 0 || row >= NumberOfRows
                     || column < 0 || column >= NumberOfColumns);
        }
        
        public Cell this[int flatIndex]
        {
            get
            {
                int row, column;
                GetLocationFromIndex(flatIndex, out row, out column);

                return this[row, column];
            }
            set
            {
                int row, column;
                GetLocationFromIndex(flatIndex, out row, out column);

                this[row, column] = value;
            }

        }

        public Cell this[int row, int column]
        {
            get
            {
                if (InBounds(row, column))
                {
                    return cells[row, column];
                }

                return null;
            }
            set
            {
                if (InBounds(row, column))
                {
                    cells[row, column] = value;
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }
        }

        public int NumberOfColumns { get; }
        public int NumberOfRows { get; }
        public Cell Start => cells[0, 0];
        public Cell End => cells[NumberOfRows - 1, NumberOfColumns - 1];

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var j = 0; j < NumberOfColumns; j++)
                {
                    stringBuilder.Append($"{cells[i, j]} ");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        public void GetLocationFromIndex(int index, out int row, out int column)
        {
            if (index < 0 || index >= NumberOfColumns * NumberOfRows)
            {
                throw new ArgumentException();
            }

            row = index / NumberOfColumns;

            column = (index - row * NumberOfColumns) % NumberOfColumns;
        }
    }
}