using System;

namespace DataStructures
{
    public abstract class Heap<T> where T : IComparable
    {
        public class Node
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data
            {
                get;
                set;
            }

            public Node Parent
            {
                get;
                set;
            }

            public Node LeftChild
            {
                get;
                set;
            }

            public Node RightChild
            {
                get;
                set;
            }

            public Node RightSibling
            {
                get;
                set;
            }

            public Node LeftSibling
            {
                get;
                set;
            }

            internal void BubbleUpData(Func<T, T, bool> comparator)
            {
                if (Parent == null)
                {
                    return;
                }

                if (comparator(Data, Parent.Data))
                {
                    // Swap
                    T temp = Parent.Data;
                    Parent.Data = Data;
                    Data = temp;

                    Parent.BubbleUpData(comparator);
                }
            }

            internal void BubbleDownData(Func<T, T, bool> compare)
            {
                if (LeftChild == null && RightChild == null)
                {
                    return;
                }

                if (LeftChild != null && !compare(Data, LeftChild.Data))
                {
                    // Swap
                    // TODO into a method
                    T temp = LeftChild.Data;
                    LeftChild.Data = Data;
                    Data = temp;
                    LeftChild.BubbleDownData(compare);
                }
                else if (RightChild != null && !compare(Data, RightChild.Data))
                {
                    // Swap
                    T temp = RightChild.Data;
                    RightChild.Data = Data;
                    Data = temp;
                    RightChild.BubbleDownData(compare);
                }
            }
        }

        public Node Root
        {
            get;
            set;
        }

        public Node InsertAt
        {
            get;
            set;
        }

        public Node SwapAt
        {
            get;
            set;
        }

        public abstract bool Compare(T data1, T data2);

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new Node(data);
                InsertAt = Root;
            }
            else
            {
                if (InsertAt != null)
                {
                    if (InsertAt.LeftChild == null)
                    {
                        SetLeftChild(InsertAt, data);
                        InsertAt.LeftChild.BubbleUpData(Compare);
                        SwapAt = InsertAt.LeftChild;
                    }
                    else
                    {
                        SetRightChild(InsertAt, data);
                        InsertAt.RightChild.BubbleUpData(Compare);
                        SwapAt = InsertAt.RightChild;
                        InsertAt = InsertAt.RightChild.LeftSibling;                                                
                    }
                }
            }
        }

        private void SetLeftChild(Node parent, T data)
        {
            parent.LeftChild = new Node(data);
            parent.LeftChild.Parent = parent;
        }

        private void SetRightChild(Node parent, T data)
        {
            parent.RightChild = new Node(data);
            parent.RightChild.Parent = parent;
            parent.LeftChild.RightSibling = InsertAt.RightChild;
            parent.RightChild.LeftSibling = InsertAt.LeftChild;
        }

        public T Extract()
        {
            if (Root == null)
            {
                return default(T);
            }

            var data = Root.Data;
            Heapify();

            return data;
        }

        private void Heapify()
        {
            if (SwapAt != null)
            {
                Root.Data = SwapAt.Data;
                if (SwapAt.Parent == null)
                {
                    // Last item
                    Root = null;
                    return;
                }

                if (SwapAt.Parent.LeftChild == SwapAt)
                {
                    SwapAt.Parent.LeftChild = null;
                    if (SwapAt.Parent.RightSibling != null)
                    {
                        SwapAt = SwapAt.Parent.RightSibling;
                    }
                    else if (SwapAt.Parent.LeftSibling != null)
                    {
                        SwapAt = SwapAt.Parent.LeftSibling.RightChild;
                    }
                    else
                    {
                        SwapAt = SwapAt.Parent;
                    }
                }
                else
                {
                    SwapAt.Parent.RightChild = null;
                    SwapAt = SwapAt.Parent.LeftChild;
                }
            }

            Root.BubbleDownData(Compare);
        }
    }
}
