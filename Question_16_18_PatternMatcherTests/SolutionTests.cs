using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Question_16_18_PatternMatcher.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void IsAPatternOfTest()
        {
            Solution solution = new Solution();
            string input = "catcatgocat";
            string pattern = "aaba";
            var result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(true, result);

            pattern = "ab";
            result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(true, result);

            input = "catcatgocatwent";
            pattern = "aabac";
            result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void IsAPatternOfTest2()
        {
            Solution solution = new Solution();
            string input = "catcatgocat";
            string pattern = "aabab";
            var result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(false, result);

            input = "catcatgocatwent";
            pattern = "aabab";
            result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsAPatternOfTest3()
        {
            Solution solution = new Solution();
            string input = "gotgotgogot";
            string pattern = "aaba";
            var result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(true, result);

            input = "gogogotgo";
            pattern = "aaba";
            result = solution.IsAPatternOf(input, pattern);
            Assert.AreEqual(true, result);
        }
    }
}