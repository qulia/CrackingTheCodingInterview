using DataStructures;

namespace Question_04_08_FirstCommonAncestor
{
    /// <summary>
    /// Assumes parent of a tree node is known
    /// </summary>
    public class Solution1<T> : Solution<T>
    {
        public override Tree<T>.Node GetFirstCommonAncestor(Tree<T>.Node root, Tree<T>.Node p, Tree<T>.Node q)
        {
            if (!root.Covers(p) || !root.Covers(q))
            {
                // At least one of the nodes is not in the tree
                return null;
            }

            if (p.Covers(q))
            {
                return p;
            }

            if (q.Covers(p))
            {
                return q;
            }


            // This is the case where we know both p and q are in the tree and there should be a common ancestor other
            // than either of them

            // Set the current node to p and keep walking up to the parents until a sibling covers q

            var current = p;
            while (current != null)
            {
                if (current.Sibling.Covers(q))
                {
                    return current.Parent;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}
