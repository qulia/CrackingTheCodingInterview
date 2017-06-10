using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_16_23_Rand7FromRand5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_16_23_Rand7FromRand5.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void Rand7Test()
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            Solution solution = new Solution();
            for (int i = 0; i < 1000; i++)
            {
                var rand7 = solution.Rand7();
                if (!counts.ContainsKey(rand7))
                {
                    counts.Add(rand7, 1);
                }
                else
                {
                    counts[rand7]++;
                }
            }

            var orderedCounts = counts.OrderBy((count) => count.Key);
            foreach (var entry in orderedCounts)
            {
                Trace.Write(string.Format("{0} {1}", entry.Key, entry.Value));
                Trace.WriteLine("");
            }
        }
    }
}