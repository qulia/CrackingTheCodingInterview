using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_04_09_BSTSequences;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_04_09_BSTSequences.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void BSTSequencesFromTreeTest()
        {
            //      2
            //     / \
            //    1   3 
            //

            Tree<int> inputTree = new Tree<int>(new Tree<int>.Node(2));
            inputTree.Root.Left = new Tree<int>.Node(1);
            inputTree.Root.Right = new Tree<int>.Node(3);

            Solution<int> solution = new Solution<int>();
            List<List<int>> result = solution.BSTSequencesFromTree(inputTree);

            Print(result);
        }

        [TestMethod()]
        public void BSTSequencesFromTreeTest2()
        {
            //      50
            //     / \
            //    20   60 
            //    /\    \
            //   10 25   70
            //   /\      /\
            //  5  15  65  80
            // 
            Tree<int> inputTree = new Tree<int>(new Tree<int>.Node(50));
            var node20 = inputTree.Root.Left = new Tree<int>.Node(20);
            var node60 = inputTree.Root.Right = new Tree<int>.Node(60);
            var node10 = node20.Left = new Tree<int>.Node(10);
            node20.Right = new Tree<int>.Node(25);
            node10.Left = new Tree<int>.Node(5);
            node10.Right = new Tree<int>.Node(15);
            var node70 = node60.Right = new Tree<int>.Node(70);
            node70.Left = new Tree<int>.Node(65);
            node70.Right = new Tree<int>.Node(80);

            Solution<int> solution = new Solution<int>();
            List<List<int>> result = solution.BSTSequencesFromTree(inputTree);
            Print(result);
        }

        private static void Print(List<List<int>> result)
        {
            foreach (List<int> innerResult in result)
            {
                foreach (int data in innerResult)
                {
                    Trace.Write(data);
                    Trace.Write(" ");
                }

                Trace.WriteLine("");
            }
        }

        [TestMethod]
        public void BSTSequencesFromTreeTest3()
        {
            //     3
            //   /   \
            //  1     5
            // / \   / \
            //0   2  4  6
            // To be used as input to Question_17_12
            Tree<int> inputTree = new Tree<int>(new Tree<int>.Node(3));
            var node1 = inputTree.Root.Left = new Tree<int>.Node(1);
            var node5 = inputTree.Root.Right = new Tree<int>.Node(5);
            node1.Left = new Tree<int>.Node(0);
            node1.Right = new Tree<int>.Node(2);
            node5.Left = new Tree<int>.Node(4);
            node5.Right = new Tree<int>.Node(6);

            Solution<int> solution = new Solution<int>();
            var result = solution.BSTSequencesFromTree(inputTree);
            Print(result);
        }
    }
}