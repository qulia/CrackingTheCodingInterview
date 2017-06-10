using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Question_10_08_FindDuplicates.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void FindDuplicatesTest()
        {
            int[] input = { 1, 5, 5, 30000, 32000, 32000 };
            Solution solution = new Solution();
            var duplicates = solution.FindDuplicates(input.ToList(), 32000);

            foreach (var duplicate in duplicates)
            {
                Trace.WriteLine(duplicate);
            }
        }

        [TestMethod()]
        public void FindDuplicatesLargeInputTest()
        {
            var maxIntegerValue = 1 << 16; // 2^16
            var inputList = CreateList(maxIntegerValue, 1000);
            Solution solution = new Solution();
            var duplicates = solution.FindDuplicates(inputList, maxIntegerValue);

            Trace.WriteLine(string.Format("Max integer {0}", maxIntegerValue));
            foreach (var duplicate in duplicates)
            {
                Trace.WriteLine(duplicate);
            }
        }

        private List<int> CreateList(int maxInteger, int size)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                var value = random.Next(1, maxInteger + 1);
                list.Add(value);
                Trace.Write(string.Format("{0} ", value));
            }

            Trace.WriteLine("");

            return list;
        }
    }
}