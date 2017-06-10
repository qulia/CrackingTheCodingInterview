using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_04_12_CountPathsWithSum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_04_12_CountPathsWithSum.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void CountPathsWithSumTest()
        {
            //          10
            //          /\
            //         5 -3
            //        /\   \
            //       3  2  11
            //      /\   \
            //     3 -2   1
            Tree<int> tree = new Tree<int>(new Tree<int>.Node(10, null, null));
            var node5 = tree.Root.Left = new Tree<int>.Node(5, null, null);
            var node3 = node5.Left = new Tree<int>.Node(3, null, null);
            node3.Left = new Tree<int>.Node(3, null, null);
            node3.Right = new Tree<int>.Node(-2, null, null);
            var node2 = node5.Right = new Tree<int>.Node(2, null, null);
            node2.Right = new Tree<int>.Node(1, null, null);

            var nodeminus3 = tree.Root.Right = new Tree<int>.Node(-3, null, null);
            nodeminus3.Right = new Tree<int>.Node(11, null, null);

            Solution solution = new Solution();
            var result = solution.CountPathsWithSum(tree, 8);
            Assert.AreEqual(3, result);
        }


        [TestMethod()]
        public void CountPathsWithSumTest2()
        {
            //          10
            //          /\
            //         5 -3
            //        /\   \
            //       3  2  11
            //      /\   \
            //     3 -2   1
            //             \
            //              7
            //               \
            //               -7
            Tree<int> tree = new Tree<int>(new Tree<int>.Node(10, null, null));
            var node5 = tree.Root.Left = new Tree<int>.Node(5, null, null);
            var node3 = node5.Left = new Tree<int>.Node(3, null, null);
            node3.Left = new Tree<int>.Node(3, null, null);
            node3.Right = new Tree<int>.Node(-2, null, null);
            var node2 = node5.Right = new Tree<int>.Node(2, null, null);
            var node1 = node2.Right = new Tree<int>.Node(1, null, null);
            var node7 = node1.Right = new Tree<int>.Node(7, null, null);
            node7.Right = new Tree<int>.Node(-7, null, null);

            var nodeminus3 = tree.Root.Right = new Tree<int>.Node(-3, null, null);
            nodeminus3.Right = new Tree<int>.Node(11, null, null);

            Solution solution = new Solution();
            var result = solution.CountPathsWithSum(tree, 8);
            Assert.AreEqual(5, result);
        }
    }
} 