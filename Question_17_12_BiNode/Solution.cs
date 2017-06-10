using System;

namespace Question_17_12_BiNode
{
    public class Solution<T> where T : IComparable
    {
        public DoublyLinkedList<T> ConvertFromBinarySearchTree(BinarySearchTree<T> tree)
        {
            return DoublyLinkedList<T>.ConvertFrom(tree);
        }
    }
}
