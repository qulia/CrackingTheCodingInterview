using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Tree<T>
    {
        public Tree(Node root)
        {
            Root = root;
        }

        public class Node
        {
            Node left, right;

            public Node(T data)
            {
                Data = data;
            }

            public Node(T data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public T Data
            {
                get;
                set;
            }
            public bool IsLeaf
            {
                get
                {
                    return Left == null && Right == null;
                }
            }
            public Node Left
            {
                get
                {
                    return left;
                }

                set
                {
                    left = value;
                    if (left != null)
                    {
                        left.Parent = this;
                    }
                }
            }

            public Node Right
            {
                get
                {
                    return right;
                }

                set
                {
                    right = value;
                    if (right != null)
                    {
                        right.Parent = this;
                    }
                }
            }

            public Node Parent
            {
                get;
                private set;
            }

            public Node Sibling
            {
                get
                {
                    if (Parent == null)
                    {
                        // root node, no sibling
                        return null;
                    }

                    return Parent.Left == this ? Parent.Right : Parent.Left;
                }
            }

            public bool Covers(Node other)
            {
                if (this == other)
                {
                    return true;
                }

                if (Left != null && Left.Covers(other))
                {
                    return true;
                }

                if (Right != null && Right.Covers(other))
                {
                    return true;
                }

                return false;
            }
        }

        public Node Root
        {
            get;
            set;
        }
    }
}
