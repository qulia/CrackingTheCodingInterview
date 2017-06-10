using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Question_16_07_Number_Max.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetMaxTest()
        {
            Solution solution = new Solution();
            int number1 = 13;
            int number2 = 15;

            int result = solution.GetMax(number1, number2);
            Assert.AreEqual(number2, result);

            number1 = -13;
            number2 = 13;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number2, result);

            number1 = Int32.MaxValue - 2;
            number2 = -15;

            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number1, result);

            number1 = -13;
            number2 = - 15;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number1, result);

            number1 = -13;
            number2 = -13;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number1, result);

            number1 = 13;
            number2 = 13;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number1, result);

            number1 = 0;
            number2 = 13;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number2, result);

            number1 = 0;
            number2 = -13;
            result = solution.GetMax(number1, number2);
            Assert.AreEqual(number1, result);
        }
    }
}