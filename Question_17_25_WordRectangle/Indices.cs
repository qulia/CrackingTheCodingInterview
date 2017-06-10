namespace Question_17_25_WordRectangle
{
    public class Indices
    {
        public Indices()
        {
            RowLengthIndex = 0;
            ColumnLengthIndex = 0;
        }

        public int RowLengthIndex
        {
            get;
            set;
        }

        public int ColumnLengthIndex
        {
            get;
            set;
        }

        public void IncrementRow()
        {
            RowLengthIndex++;
        }

        public void IncrementColumn()
        {
            ColumnLengthIndex++;
        }

        public void ResetColumn()
        {
            ColumnLengthIndex = 0;
        }
    }
}
