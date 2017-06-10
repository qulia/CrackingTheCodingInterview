using DataStructures;

namespace Question_04_08_FirstCommonAncestor
{
    public class Result<T>
    {
        public Result()
        {
        }

        public Result(Result<T> resultLeft, Result<T> resultRight, Tree<T>.Node node, Tree<T>.Node p, Tree<T>.Node q)
        {
            CoversP = resultLeft.CoversP || resultRight.CoversP || node == p;
            CoversQ = resultLeft.CoversQ || resultRight.CoversQ || node == q;
            Node = node;
        }

        public Result(Result<T> other,Tree<T>.Node node, Tree<T>.Node p, Tree<T>.Node q)
        {
            CoversP = other.CoversP || other.CoversP || node == p;
            CoversQ = other.CoversQ || other.CoversQ || node == q;
            Node = node;
        }

        public bool CoversP
        {
            get;
            set;
        }

        public bool CoversQ
        {
            get;
            set;
        }

        public bool CoversBoth
        {
            get
            {
                return CoversP && CoversQ;
            }
        }

        public Tree<T>.Node Node
        {
            get;
            set;
        }
    }
}