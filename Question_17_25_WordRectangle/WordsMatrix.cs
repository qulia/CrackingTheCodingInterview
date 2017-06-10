using System.Collections.Generic;
using System.Text;

namespace Question_17_25_WordRectangle
{
    public class WordsMatrix
    {
        public class Location
        {
            public Location()
            {
                Index = 0;
                Start = 0;
            }

            public Location(Location location)
            {
                Index = location.Index;
                Start = location.Start;
            }

            public int Index
            {
                get;
                set;
            }

            public int Start
            {
                get;
                set;
            }

            internal void Increment()
            {
                Index++;
                Start++;
            }
        }

        private char[,] matrix;
        private int filledRow = 0;
        private int filledColumn = 0;

        public WordsMatrix(int height, int width)
        {
            NumberOfRows = height;
            NumberOfColumns = width;
            matrix = new char[height, width];
        }

        public bool FillRow(Location row, string word)
        {
            for (int i = row.Start; i < NumberOfColumns; i++)
            {
                matrix[row.Index, i] = word[i];
            }

            filledRow = row.Index;

            row.Increment();

            return filledRow == NumberOfRows - 1;
        }

        public bool FillColumn(Location column, string word)
        {
            for (int i = column.Start; i < NumberOfRows; i++)
            {
                matrix[i, column.Index] = word[i];
            }

            filledColumn = column.Index;

            column.Increment();

            return filledColumn == NumberOfColumns - 1;
        }

        internal List<string> GetList()
        {
            List<string> list = new List<string>();
            for (int i = 0; i <= filledRow; i++)
            {
                list.Add(GetRowPrefix(i));
            }

            return list;
        }

        public int Size
        {
            get
            {
                return NumberOfColumns * NumberOfRows;
            }
        }

        public int NumberOfColumns
        {
            get;
            set;
        }

        public int NumberOfRows
        {
            get;
            set;
        }

        public bool IsFull
        {
            get
            {
                return filledRow == NumberOfRows - 1 &&
                    filledColumn == NumberOfColumns - 1;
            }
        }

        internal string GetColumnPrefix(int index)
        {
            StringBuilder columnPrefix = new StringBuilder();
            for (int i = 0; i <= filledRow; i++)
            {
                columnPrefix.Append(matrix[i, index]);
            }

            return columnPrefix.ToString();
        }

        internal string GetLastColumnWord()
        {
            return GetColumnPrefix(NumberOfColumns - 1);
        }

        internal string GetRowPrefix(int index)
        {
            StringBuilder rowPrefix = new StringBuilder();
            for (int i = 0; i <= filledColumn; i++)
            {
                rowPrefix.Append(matrix[index, i]);
            }

            return rowPrefix.ToString();
        }

        internal bool OutOfBoundries(Location row, Location column)
        {
            return row.Index >= NumberOfRows && column.Index >= NumberOfColumns;
        }
    }
}
