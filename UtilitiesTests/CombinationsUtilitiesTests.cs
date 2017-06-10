using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Utilities.Tests
{
    [TestClass()]
    public class CombinationsUtilitiesTests
    {
        [TestMethod()]
        public void GetKCombinationsOfNTest()
        {
            RunTest(4, 2);
            RunTest(10, 3);
        }

        private static void RunTest(int n1, int k1)
        {
            var expectedCount =
                            new Func<int, int, int>((n, k) => Math.Factorial(n) / Math.Factorial(n - k) / Math.Factorial(k));

            var result = CombinationsUtilities.GetKCombinationsOfN(n1, k1);
            foreach (var list in result)
            {
                list.Print(true);
                Trace.WriteLine("");
            }
            Assert.AreEqual(expectedCount(n1, k1), result.Count);
        }
    }
}