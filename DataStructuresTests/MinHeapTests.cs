using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace DataStructures.Tests
{
    [TestClass()]
    public class MinHeapTests
    {
        [TestMethod()]
        public void BasicInsertExctractTest()
        {
            MinHeap<int> minHeap = new MinHeap<int>();

            Random random = new Random();
            for (int i = 10; i >= 1; i--)
            {
                minHeap.Insert(i);
            }

            int result = 0;
            while ((result = minHeap.Extract()) != 0)
            {
                Trace.Write(string.Format("{0} ", result));
            }

            Trace.WriteLine("");
        }
    }
}