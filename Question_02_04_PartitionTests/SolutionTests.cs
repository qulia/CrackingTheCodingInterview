
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Question_02_04_Partition.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void PartitionTestRandom()
        {
            LinkedList<int> inputLinkedList = new LinkedList<int>();
            Random random = new Random(); 
            for (int i = 1; i <= 5; i++)
            {
                inputLinkedList.InsertAtTail(random.Next(1, 10));
            }

            inputLinkedList.Print();

            Solution<int> solution = new Solution<int>();
            solution.Partition(inputLinkedList, 5);

            inputLinkedList.Print();
        }

        [TestMethod()]
        public void PartitionTestFixed()
        {
            LinkedList<int> inputLinkedList = new LinkedList<int>();

            int[] data = { 3, 5, 8, 5, 10, 2, 1 };
            Random random = new Random();
            for (int i = 0; i <= 6; i++)
            {
                inputLinkedList.InsertAtTail(data[i]);
            }

            inputLinkedList.Print();

            Solution<int> solution = new Solution<int>();
            solution.Partition(inputLinkedList, 5);

            inputLinkedList.Print();
        }


        [TestMethod()]
        public void PartitionTestCornerCase()
        {
            LinkedList<int> inputLinkedList = new LinkedList<int>();

            int[] data = { 5, 5, 8, 3, 10, 2, 1 };
            Random random = new Random();
            for (int i = 0; i <= 6; i++)
            {
                inputLinkedList.InsertAtTail(data[i]);
            }

            inputLinkedList.Print();

            Solution<int> solution = new Solution<int>();
            solution.Partition(inputLinkedList, 5);

            inputLinkedList.Print();
        }
    }
}