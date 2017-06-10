using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Question_01_08_SetZeros.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void SetZerosTest()
        {
            Solution solution = new Solution();
            int[,] inputMatrix = new int[4, 4];

            inputMatrix.PopulateSequential();
            // Set some zero elements
            inputMatrix[2, 3] = 0;
            inputMatrix[0, 0] = 0;

            inputMatrix.Print();
            solution.SetZeros(inputMatrix);
            inputMatrix.Print();
        }
    }
}