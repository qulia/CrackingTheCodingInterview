using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_02_01_WeaveLinkedList.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void WeaveLinkedListTest()
        {
            Solution<int> solution = new Solution<int>();
            LinkedList<int> inputLinkedList = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                inputLinkedList.InsertAtTail(i);
            }

            for (int i = 1; i <= 5; i++)
            {
                inputLinkedList.InsertAtTail(-i);
            }

            solution.WeaveLinkedList(inputLinkedList);
        }
    }
}