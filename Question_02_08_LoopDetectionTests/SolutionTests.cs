using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Question_02_08_LoopDetection.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void DetectNoLoopTest()
        {
            LinkedList<int> inputLinkedList = new LinkedList<int>();
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                inputLinkedList.InsertAtTail(random.Next(1, 10));
            }

            inputLinkedList.Print();

            Solution<int> solution = new Solution<int>();
            var loopStart = solution.DetectLoop(inputLinkedList);

            Assert.IsTrue(loopStart == null);
        }

        [TestMethod()]
        public void DetectWithLoopTest()
        {
            LinkedList<int> inputLinkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                inputLinkedList.InsertAtTail(i);
            }

            for (int i = 0; i < 10; i++)
            {
                TestLoop(inputLinkedList, i);
            }
        }

        private static void TestLoop(LinkedList<int> inputLinkedList, int loopStartIndex)
        {
            inputLinkedList.Tail.Next = inputLinkedList[loopStartIndex];

            Solution<int> solution = new Solution<int>();
            var loopStart = solution.DetectLoop(inputLinkedList);

            Assert.IsTrue(loopStart == inputLinkedList[loopStartIndex]);
        }
    }
}