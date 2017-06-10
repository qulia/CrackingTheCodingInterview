using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Question_16_08_EnglishInt.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void ToEnglishTest()
        {
            PrintInt(0);

            PrintInt(12);
            PrintInt(123);
            PrintInt(1234);
            PrintInt(1230);
            PrintInt(2058818540);
            PrintInt(-1234);
            PrintInt(int.MaxValue);
        }

        [TestMethod()]
        public void ToEnglishRandomTest()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                PrintInt(random.Next(0, int.MaxValue));
            }
        }

        private static void PrintInt(int value)
        {
            Trace.WriteLine(string.Format("{0} {1}", value, value.ToEnglish()));
        }
    }
}