using System;

namespace Question_17_12_BiNode
{
    public class BiNode<T> where T : IComparable
    {
        public BiNode(T data)
        {
            Data = data;
        }

        public T Data
        {
            get;
            set;
        }

        public BiNode<T> Node1
        {
            get;
            set;
        }

        public BiNode<T> Node2
        {
            get;
            set;
        }

        public void Insert(T data)
        {
            // TODO balance the tree after x number of entries
            if (data.CompareTo(Data) <= 0)
            {
                if (Node1 != null)
                {
                    Node1.Insert(data);
                }
                else
                {
                    Node1 = new BiNode<T>(data);
                }
            }
            else
            {
                if (Node2 != null)
                {
                    Node2.Insert(data);
                }
                else
                {
                    Node2 = new BiNode<T>(data);
                }
            }
        }
    }
}
