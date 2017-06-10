using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilities;

namespace Question_VII_02_SubstringOfPermutations.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void FindSubstringsOfPermutationsTest()
        {
            string search = "abbc";
            string source = "cbabadcbbabbcbabaabccbabc";

            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(6);
            expected.Add(9);
            expected.Add(11);
            expected.Add(12);
            expected.Add(20);
            expected.Add(21);

            var actual = new Solution().FindSubstringsOfPermutations(source, search);

            actual.Print();
            Assert.IsTrue(Compare(expected, actual));
        }

        [TestMethod()]
        public void FindSubstringsOfPermutationsTest2()
        {
            string search = "abbc";
            string source = "cbabadcbbabbcddbabcbabddccbabc";

            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(6);
            expected.Add(9);
            expected.Add(15);
            expected.Add(16);
            expected.Add(17);
            expected.Add(18);
            expected.Add(25);
            expected.Add(26);
      
            var actual = new Solution().FindSubstringsOfPermutations(source, search);

            actual.Print();
            Assert.IsTrue(Compare(expected, actual));
        }

        private bool Compare(List<int> expected, List<int> actual)
        {
            if (expected.Count != actual.Count) return false;

            foreach (var value in expected)
            {
                if (!actual.Contains(value)) return false;
            }

            return true;
        }
    }
}