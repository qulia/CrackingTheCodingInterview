using System;
using System.Diagnostics;

namespace Question_17_12_BiNode
{
    public class BinarySearchTree<T> where T: IComparable
    {
        public BinarySearchTree(BiNode<T> root)
        {
            Root = root;
        }

        public BiNode<T> Root
        {
            get;
            set;
        }

        public void Insert(T data)
        {
            Root.Insert(data);
        }

        public void Print()
        {
            PrintRecurse(Root);
            Trace.WriteLine("");
        }

        private void PrintRecurse(BiNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PrintRecurse(node.Node1);
            Trace.Write(string.Format("{0} ", node.Data));
            PrintRecurse(node.Node2);
        }
    }
}
