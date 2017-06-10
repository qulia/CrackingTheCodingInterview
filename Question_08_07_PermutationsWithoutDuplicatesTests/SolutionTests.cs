using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_08_07_PermutationsWithoutDuplicates.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetPermutationsTest()
        {
            string test = "abcd";
            Solution solution = new Solution();
            List<string> result = solution.GetPermutations(test);

            foreach (var perm in result)
            {
                Trace.WriteLine(perm);
            }
        }
    }
}