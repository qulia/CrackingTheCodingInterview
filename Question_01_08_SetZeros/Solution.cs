using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Question_01_08_SetZeros
{
    public class Solution
    {
        // mxn matrix
        public void SetZeros(int[,] inputMatrix)
        {
            int m, n; // Get number of rows and columns
            inputMatrix.GetDimensions(out m, out n);

            List<int> zeroedRows = new List<int>();
            List<int> zeroedColumns = new List<int>();
            for (int i = 0; i < m; i++)
            {
                // Already marked to be zeroed
                if (zeroedRows.Contains(i)) continue;
                for (int j = 0; j < n; j++)
                {
                    if (zeroedColumns.Contains(j)) continue;
                    if (inputMatrix[i, j] == 0)
                    {
                        zeroedRows.Add(i);
                        zeroedColumns.Add(j);
                    }
                }
            }

            // Now set the entries to zero
            foreach (int row in zeroedRows)
            {
                for (int j = 0; j < m; j++)
                {
                    inputMatrix[row, j] = 0;
                }
            }

            foreach (int column in zeroedColumns)
            {
                for (int i = 0; i < n; i++)
                {
                    inputMatrix[i, column] = 0;
                }
            }
        }
    }
}
