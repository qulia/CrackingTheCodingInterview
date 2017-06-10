using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace DataStructures.Tests
{
    [TestClass()]
    public class MaxHeapTests
    {
        [TestMethod()]
        public void BasicInsertExtractTest()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            for (int i = 1; i < 10; i++)
            {
                maxHeap.Insert(i);
            }

            int result = 0;
            while ((result = maxHeap.Extract()) != 0)
            {
                Trace.Write(string.Format("{0} ", result));
            }

            Trace.WriteLine("");
        }

        [TestMethod()]
        public void RandomNumberInsertExtractTest()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                maxHeap.Insert(random.Next(0, 10));
            }

            int result = 0;
            while ((result = maxHeap.Extract()) != 0)
            {
                Trace.Write(string.Format("{0} ", result));
            }

            Trace.WriteLine("");
        }
    }    
}