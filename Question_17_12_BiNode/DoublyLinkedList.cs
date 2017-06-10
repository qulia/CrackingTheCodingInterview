using System;
using System.Diagnostics;

namespace Question_17_12_BiNode
{
    public class DoublyLinkedList<T> where T :  IComparable
    {
        public DoublyLinkedList(BiNode<T> head, BiNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public BiNode<T> Head
        {
            get;
            set;
        }

        public BiNode<T> Tail
        {
            get;
            set;
        }

        public static DoublyLinkedList<T> ConvertFrom(BinarySearchTree<T> treeNode)
        {
            BiNode<T> root = treeNode.Root;

            return ConvertFromRecurse(root);
        }

        private static DoublyLinkedList<T> ConvertFromRecurse(BiNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return null;
            }

            var left = ConvertFromRecurse(treeNode.Node1);
            var right = ConvertFromRecurse(treeNode.Node2);

            return Merge(left, treeNode, right);
        }

        private static DoublyLinkedList<T> Merge(DoublyLinkedList<T> left, BiNode<T> parent, DoublyLinkedList<T> right)
        {
            // Doubly Linked List from left becomes the beginning of the new doubly linked list
            // parent goes to the middle
            // Doubly linked list from right becomes the end of the new doubly linked list
            if (left != null)
            {
                left.Tail.Node2 = parent;
                parent.Node1 = left.Tail;
            }
            else
            {
                parent.Node1 = null;
            }

            if (right != null)
            {
                right.Head.Node1 = parent;
                parent.Node2 = right.Head;
            }
            else
            {
                parent.Node2 = null;
            }

            return new DoublyLinkedList<T>(left == null ? parent : left.Head, right == null ? parent : right.Tail);
        }

        public void Print(bool reverse = false)
        {
            var current = reverse ? Tail : Head;
            while (current != null)
            {
                Trace.Write(string.Format("{0} ", current.Data));

                current = reverse ? current.Node1 : current.Node2;
            }

            Trace.WriteLine("");
        }
    }
}
