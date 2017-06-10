
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Question_02_02_KthToLast.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void KthToLastTest()
        {
            Solution<int> solution = new Solution<int>();
            LinkedList<int> inputLinkedList = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                inputLinkedList.InsertAtTail(i);
            }

            inputLinkedList.Print();
            int answer = solution.KthToLast(inputLinkedList, 0);
            Assert.AreEqual(5, answer);

            answer = solution.KthToLast(inputLinkedList, 1);
            Assert.AreEqual(4, answer);

            answer = solution.KthToLast(inputLinkedList, 2);
            Assert.AreEqual(3, answer);

            answer = solution.KthToLast(inputLinkedList, 3);
            Assert.AreEqual(2, answer);

            answer = solution.KthToLast(inputLinkedList, 4);
            Assert.AreEqual(1, answer);

            // TODO handle passing by the head case
            //answer = solution.KthToLast(inputLinkedList, 5);
            //Assert.AreEqual(-1, answer);
        }
    }
}