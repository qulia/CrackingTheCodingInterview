using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Question_15_07_FizzBuz.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void PrintFizzBuzzTest()
        {
            Solution solution = new Solution();
            solution.PrintFizzBuzz(20, Print);
        }

        private void Print(string word)
        {
            Trace.WriteLine(word);
        }
    }
}