using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_13_08_LambdaRandom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_13_08_LambdaRandom.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetRandomSubsetTest()
        {
            Solution solution = new Solution();
            List<int> input = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                input.Add(i);
            }

            var result = solution.GetRandomSubset(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            result = solution.GetRandomSubset(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            result = solution.GetRandomSubset(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            result = solution.GetRandomSubset(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            result = solution.GetRandomSubsetWithPredicate(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            result = solution.GetRandomSubsetWithPredicate(input);

            foreach (var entry in result)
            {
                Trace.Write(entry.ToString());
                Trace.Write(" ");
            }

            Trace.WriteLine("");
        }
    }
}