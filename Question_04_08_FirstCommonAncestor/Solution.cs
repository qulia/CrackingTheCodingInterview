using DataStructures;

namespace Question_04_08_FirstCommonAncestor
{
    public abstract class Solution<T>
    {
        public abstract Tree<T>.Node GetFirstCommonAncestor(Tree<T>.Node root, Tree<T>.Node p, Tree<T>.Node q);
    }
}
