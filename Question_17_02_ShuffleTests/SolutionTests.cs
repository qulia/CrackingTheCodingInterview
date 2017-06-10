using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_17_02_Shuffle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_17_02_Shuffle.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void ShuffleArrayTest()
        {
            int[] input = new int[10];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = i;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Trace.Write(string.Format("{0} ", input[i]));
            }

            Trace.WriteLine("");
            Solution solution = new Solution();
            var result = solution.ShuffleArray(input);

            for (int i = 0; i < result.Length; i++)
            {
                Trace.Write(string.Format("{0} ", result[i]));
            }
        }
    }
}