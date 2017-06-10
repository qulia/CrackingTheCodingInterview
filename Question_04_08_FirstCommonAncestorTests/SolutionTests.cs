using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Question_04_08_FirstCommonAncestor.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetFirstCommonAncestorTest()
        {
            Solution<int> solution1 = new Solution1<int>();
            Solution<int> solution2 = new Solution2<int>();
            var tree = CreateTree();

            
            var p = tree.Root; // Node 50
            var q = tree.Root.Left; // Node 20
            var expectedResult = tree.Root; // Node 50

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            p = tree.Root.Left; // Node 20
            q = tree.Root.Right; // Node 60
            expectedResult = tree.Root; // Node 50

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);
            
            p = tree.Root.Left.Left.Left; // Node 5
            q = tree.Root.Left.Left; // Node 10
            expectedResult = tree.Root.Left.Left; // Node 10

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            p = tree.Root.Left.Left.Left; // Node 5
            q = tree.Root.Left.Right; // Node 25
            expectedResult = tree.Root.Left; // Node 20

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            p = tree.Root.Left.Left.Left; // Node 5
            q = tree.Root.Right.Right.Left; // Node 65
            expectedResult = tree.Root; // Node 50

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            p = tree.Root.Right.Right; // Node 70
            q = tree.Root.Right; // Node 60
            expectedResult = tree.Root.Right; // Node 60

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            p = new Tree<int>.Node(100); // a node that is not in the tree
            q = tree.Root.Left.Left;
            expectedResult = null;

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

            // Same node
            p = tree.Root.Right.Right;
            q = p;
            expectedResult = p;

            RunTest(solution1, tree.Root, p, q, expectedResult);
            RunTest(solution2, tree.Root, p, q, expectedResult);

        }

        private void RunTest(Solution<int> solution, Tree<int>.Node root, Tree<int>.Node p, Tree<int>.Node q, Tree<int>.Node expectedResult)
        {           
            var result = solution.GetFirstCommonAncestor(root, p, q);
            Trace.WriteLine(string.Format("{0} {1} {2}", 
                p == null ? "null" : p.Data.ToString(), q == null ? "null" : q.Data.ToString(), result == null ? "null" : result.Data.ToString()));
            Assert.AreEqual(expectedResult, result);
        }

        public Tree<int> CreateTree()
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

            return inputTree;
        }
    }
}