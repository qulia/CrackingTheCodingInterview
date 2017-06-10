using System.Diagnostics;
using Utilities;

namespace Question_01_07_RotateMatrix
{
    public class Solution
    {
        public void RotateMatrix(int[,] inputMatrix, int n)
        {
            int top_x, bottom_y, left_x, left_y;
            top_x = bottom_y = left_x = left_y = 0;

            int top_y, right_x, right_y, bottom_x;
            top_y = right_x = right_y = bottom_x = n -1;

            for (int dim = n; dim > 1;)
            {
                Trace.WriteLine(dim);
                Trace.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", top_x, top_y, right_x, right_y, bottom_x, bottom_y, left_x, left_y));

                for (int i=0; i < dim - 1; i++)
                {                   
                    // increment i on x for top
                    // decrement i on y for right
                    // decrement i on x for bottom
                    // increment i on y for left
                    int temp = inputMatrix[top_x + i, top_y];
                    inputMatrix[top_x + i, top_y] = inputMatrix[left_x, left_y + i];
                    inputMatrix[left_x, left_y  + i] = inputMatrix[bottom_x - i, bottom_y];
                    inputMatrix[bottom_x - i, bottom_y] = inputMatrix[right_x, right_y - i];
                    inputMatrix[right_x, right_y - i] = temp;

                    inputMatrix.Print();
                }

                dim = dim / 2;

                // Move diagonally in the corners
                top_x++;
                top_y--;
                right_x--;
                right_y--;
                bottom_x--;
                bottom_y++;
                left_x++;
                left_y++;
            }
        }
    }
}
