using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Question_17_12_BiNode.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void ConvertFromBinarySearchTreeTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new BiNode<int>(0));
            for (int i = 1; i < 7; i++)
            {
                tree.Insert(i);
            }

            tree.Print();

            var doublyLinkedList = DoublyLinkedList<int>.ConvertFrom(tree);
            doublyLinkedList.Print();

            doublyLinkedList.Print(true); // Print reverse
        }

        [TestMethod()]
        public void ConvertFromBinarySearchTreeTest2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new BiNode<int>(0));
            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                tree.Insert(random.Next(0, 11));
            }

            tree.Print();

            var doublyLinkedList = DoublyLinkedList<int>.ConvertFrom(tree);
            doublyLinkedList.Print();

            doublyLinkedList.Print(true); // Print reverse
        }

        [TestMethod()]
        public void ConvertFromBinarySearchTreeTest3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new BiNode<int>(0));
            int[] input = { 0, 1, 4, 4, 4, 4, 6, 8, 8, 8, 10 };

            for (int i = 1; i < input.Length; i++)
            {
                tree.Insert(input[i]);
            }

            tree.Print();

            var doublyLinkedList = DoublyLinkedList<int>.ConvertFrom(tree);
            doublyLinkedList.Print();

            doublyLinkedList.Print(true); // Print reverse
        }

        [TestMethod]
        public void ConvertFromBinarySearchTreeTest4()
        {
            //     3
            //   /   \
            //  1     5
            // / \   / \
            //0   2  4  6

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new BiNode<int>(3));
            int[] input = { 3, 1, 0, 2, 5, 4, 6 };

            for (int i = 1; i < input.Length; i++)
            {
                tree.Insert(input[i]);
            }

            tree.Print();

            var doublyLinkedList = DoublyLinkedList<int>.ConvertFrom(tree);
            doublyLinkedList.Print();

            doublyLinkedList.Print(true); // Print reverse
        }
    }
}
