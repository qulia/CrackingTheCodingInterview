using DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Question_17_25_WordRectangle
{
    public class Solution
    {
        public class Result
        {
            public Result(int size, List<string> list)
            {
                this.Size = size;
                this.List = list;
            }

            public int Size
            {
                get;
                set;
            }

            public List<string> List
            {
                get;
                set;
            }
        }

        public Result GetMaxWordsRectangle(List<string> words)
        {
            Result result = null;
            WordsMap wordsMap = new WordsMap(words);

            int rowLength;
            Indices currentIndices = new Indices();
            Trie columnWords;
            while (wordsMap.Get(currentIndices.RowLengthIndex, out rowLength, out columnWords))
            {
                Indices currentInnerIndices = new Indices();
                currentInnerIndices.RowLengthIndex = currentIndices.RowLengthIndex;

                int columnLength;
                Trie rowWords;
                while (wordsMap.Get(currentInnerIndices.ColumnLengthIndex, out columnLength, out rowWords))
                {
                    WordsMatrix matrix = GetMaxWordsRectangle(wordsMap, rowWords, columnWords, rowLength, columnLength);
                    if (matrix != null)
                    {
                        //Return first result since we start with max length
                        return new Result(matrix.Size, matrix.GetList());
                    }

                    currentInnerIndices.IncrementColumn();
                }

                currentIndices.IncrementRow();
            }

            return result;
        }

        private WordsMatrix GetMaxWordsRectangle(WordsMap wordsMap, Trie rowWords, Trie columnWords, int rowLength, int columnLength)
        {
            foreach (string rowWord in rowWords)
            {
                WordsMatrix wordsRectangle = new WordsMatrix(rowLength, columnLength);
                // Alternate betweem row and column to fill the rectangle
                FillRowInRectangle(wordsRectangle, new WordsMatrix.Location(), new WordsMatrix.Location(), 
                    rowWords, columnWords, rowWord);
                // When returned from recursive calls check the last column
                if (wordsRectangle.IsFull)
                {
                    return wordsRectangle;
                }
            }           

            return null;
        }

        void FillColumnInRectangle(WordsMatrix wordsRectangle, WordsMatrix.Location row, WordsMatrix.Location column,
            Trie rowWords, Trie columnWords, string columnWord)
        {
            if (wordsRectangle.IsFull)
            {
                return;
            }

            if (wordsRectangle.FillColumn(column, columnWord))
            {
                // Finished columns
                return;
            }

            var rowPrefix = wordsRectangle.GetRowPrefix(row.Index);
            foreach (string rowWord in rowWords.StartsWith(wordsRectangle.GetRowPrefix(row.Index)))
            {
                FillRowInRectangle(wordsRectangle, 
                    new WordsMatrix.Location(row), new WordsMatrix.Location(column), rowWords, columnWords, rowWord);
            }
        }

        void FillRowInRectangle(WordsMatrix wordsRectangle, WordsMatrix.Location row, WordsMatrix.Location column,
            Trie rowWords, Trie columnWords, string rowWord)
        {
            if (wordsRectangle.IsFull)
            {
                return;
            }

            if (wordsRectangle.FillRow(row, rowWord))
            {
                // rectangle is full
                string lastColumnWord = wordsRectangle.GetLastColumnWord();
                if (columnWords.Contains(lastColumnWord))
                {
                    wordsRectangle.FillColumn(column, lastColumnWord);
                }

                return;
            }

            var columnPrefix = wordsRectangle.GetColumnPrefix(column.Index);
            foreach (string columnWord in columnWords.StartsWith(columnPrefix))
            {
                FillColumnInRectangle(wordsRectangle,
                    new WordsMatrix.Location(row), new WordsMatrix.Location(column), rowWords, columnWords, columnWord);
            }
        }
    }
}
