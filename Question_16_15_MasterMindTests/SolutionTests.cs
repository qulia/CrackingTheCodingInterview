using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Utilities;

namespace Question_16_15_MasterMind.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetResultTest()
        {
            string solutionStr = "ADYGHH";
            string guessStr = "HHYBCJ";

            var result = GetResult(solutionStr, guessStr);
            Assert.AreEqual(1, result.Hits);
            Assert.AreEqual(2, result.Pseudohits);

            solutionStr = "RGGB";
            guessStr = "YRGB";

            result = GetResult(solutionStr, guessStr);
            Assert.AreEqual(2, result.Hits);
            Assert.AreEqual(1, result.Pseudohits);

            solutionStr = "RGBY";
            guessStr = "GGRR";

            result = GetResult(solutionStr, guessStr);
            Assert.AreEqual(1, result.Hits);
            Assert.AreEqual(1, result.Pseudohits);
        }

        [TestMethod()]
        public void GetResultRandomTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string solutionStr = StringUtilities.CreateLargeString(10);
                string guessStr = StringUtilities.CreateLargeString(10);
                GetResult(solutionStr, guessStr);
            }
        }

        private static Result GetResult(string solutionStr, string guessStr)
        {
            Solution solution = new Solution();
            var result = solution.GetResult(solutionStr, guessStr);

            Trace.WriteLine(solutionStr);
            Trace.WriteLine(guessStr);
            Trace.WriteLine(result.ToString());

            return result;
        }
    }
}