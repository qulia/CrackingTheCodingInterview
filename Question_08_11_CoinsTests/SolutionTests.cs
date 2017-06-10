using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_08_11_Coins.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        List<ISolution> solutions;

        [TestInitialize]
        public void Initialize()
        {
            solutions = new List<ISolution>();
            solutions.Add(new Solution());
            solutions.Add(new Solution2());
        }

        [TestMethod()]
        public void MakeChangeTest()
        {
            RunTest(solutions, 25);
        }

        [TestMethod()]
        public void MakeChangeTest1()
        {
            RunTest(solutions, 37);
        }


        [TestMethod()]
        public void MakeChangeTest2()
        {
            RunTest(solutions, 100);
        }

        [TestMethod()]
        public void MakeChangeTest3()
        {
            RunTest(solutions, 217);
        }

        private static void RunTest(List<ISolution> solutions, int amount)
        {
            int? result = null;
            foreach (var solution in solutions)
            {
                var currentResult = solution.MakeChange(amount);
                if (result.HasValue)
                {
                    Assert.AreEqual(result.Value, currentResult);
                }

                result = currentResult;
                Trace.WriteLine(result);
            }
        }
    }
}