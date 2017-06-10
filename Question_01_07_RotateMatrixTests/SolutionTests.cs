using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Question_01_07_RotateMatrix.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void RotateMatrixTest()
        {
            Solution solution = new Solution();
            int[,] inputMatrix = new int[4, 4];

            inputMatrix.PopulateSequential();

            inputMatrix.Print();
            solution.RotateMatrix(inputMatrix, 4);
            inputMatrix.Print();
        }
    }
}