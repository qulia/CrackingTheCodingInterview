using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Question_10_03_SearchInRotatedArray.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            int[] rotatedArray = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            Solution solution = new Solution();
            var result = solution.Search(rotatedArray, 5);

            Assert.AreEqual(8, result); // index of 5

            result = solution.Search(rotatedArray, 11);
            Assert.AreEqual(-1, result);

            result = solution.Search(rotatedArray, 15);
            Assert.AreEqual(0, result);

            result = solution.Search(rotatedArray, 14);
            Assert.AreEqual(rotatedArray.Length - 1, result);
        }

        [TestMethod()]
        public void SearchTest2()
        {
            int[] rotatedArray = { 7, 7, 7, 7, 7, 7, 7, 3, 4, 5, 7, 7, 7, 7 };
            Solution solution = new Solution();
            var result = solution.Search(rotatedArray, 4);

            Assert.AreEqual(8, result);

            int[] rotatedArray2 = { 7, 7, 7, 7, 3, 4, 5, 7, 7, 7, 7, 7, 7, 7 };
            result = solution.Search(rotatedArray2, 4);
            Assert.AreEqual(5, result);

            int[] rotatedArray3 = { 7, 7, 7, 7, 7, 7, 3, 4, 5, 7, 7, 7, 7 };
            result = solution.Search(rotatedArray3, 4);

            Assert.AreEqual(7, result);

            int[] rotatedArray4 = { 7, 7, 7, 7, 3, 4, 5, 7, 7, 7, 7, 7, 7 };
            result = solution.Search(rotatedArray4, 4);
            Assert.AreEqual(5, result);
        }
    }
}