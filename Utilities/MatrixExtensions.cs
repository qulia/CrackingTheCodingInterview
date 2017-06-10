using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MatrixExtensions
    {
        public static int[,] CloneMatrix(this int[,] inputMatrix)
        {
            int m, n;
            inputMatrix.GetDimensions(out m, out n);
            var clone = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    clone[i, j] = inputMatrix[i, j];
                }
            }

            return clone;
        }

        public static void PopulateSequential(this int[,] inputMatrix)
        {
            int counter = 0;
            int m, n;
            inputMatrix.GetDimensions(out m, out n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inputMatrix[i, j] = counter++;
                }
            }
        }

        public static void PopulateRandom(this int[,] inputMatrix)
        {
            int m, n;
            Random random = new Random();
            inputMatrix.GetDimensions(out m, out n);
            int maxValue = m * n;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inputMatrix[i, j] = random.Next(0, maxValue);
                }
            }
        }

        public static void Print(this int[,] inputMatrix)
        {
            int m, n;
            inputMatrix.GetDimensions(out m, out n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Trace.Write(inputMatrix[i, j]);
                    Trace.Write(" ");
                }
                Trace.WriteLine(string.Empty);
            }
            Trace.WriteLine(string.Empty);
        }


        public static void GetDimensions(this int[,] inputMatrix, out int m, out int n)
        {
            // Get number of rows and columns
            m = inputMatrix.GetLength(0);
            n = inputMatrix.GetLength(1);
            //  dimension 1
        }
    }
}
