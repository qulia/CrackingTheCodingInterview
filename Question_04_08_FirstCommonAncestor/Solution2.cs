using DataStructures;

namespace Question_04_08_FirstCommonAncestor
{
    /// <summary>
    /// This solution assumes parent of a tree node is not accessible
    /// It uses a recursive approach to keep track of if p and q covered by the node at each recursive level
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Solution2<T> : Solution<T>
    {
        public override Tree<T>.Node GetFirstCommonAncestor(Tree<T>.Node root, Tree<T>.Node p, Tree<T>.Node q)
        {
            var result = GetFirstCommonAncestorRecurse(root, p, q);

            // In the case one of the nodes is not in the tree we might get a result but it is actually not an ancestor
            return result.CoversBoth ? result.Node : null;
        }

        private Result<T> GetFirstCommonAncestorRecurse(Tree<T>.Node node, Tree<T>.Node p, Tree<T>.Node q)
        {
            if (node == null)
            {
                return new Result<T>();
            }

            var resultLeft = GetFirstCommonAncestorRecurse(node.Left, p, q);
            if (resultLeft.CoversBoth)
            {
                return resultLeft;
            }

            // Need to check if the current node changes the result before branching to the right node
            var result = new Result<T>(resultLeft, node, p, q);
            if (result.CoversBoth)
            {
                return result;
            }

            var resultRight = GetFirstCommonAncestorRecurse(node.Right, p, q);
            if (resultRight.CoversBoth)
            {
                return resultRight;
            }

            result = new Result<T>(resultLeft, resultRight, node, p, q);
            return result;
        }
    }
}
