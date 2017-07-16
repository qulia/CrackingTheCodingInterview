using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_07_09_CircularArray;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_09_CircularArray.Tests
{
    [TestClass()]
    public class CircularArrayTests
    {
        [TestMethod()]
        public void CircularArrayTest()
        {
            CircularArray<int> intCircularArray = new CircularArray<int>(5);
            intCircularArray[0] = 0;
            intCircularArray[1] = 1;
            intCircularArray[2] = 2;
            intCircularArray[3] = 3;
            intCircularArray[4] = 4;

            intCircularArray.shift(2);

            foreach (int i in intCircularArray)
            {
                Trace.Write(string.Format("{0} ", i));
            }

            Assert.AreEqual(0, intCircularArray[2]);
            Trace.WriteLine("");

            intCircularArray.shift(13);

            foreach (int i in intCircularArray)
            {
                Trace.Write(string.Format("{0} ", i));
            }

            Trace.WriteLine("");

        }
    }
}