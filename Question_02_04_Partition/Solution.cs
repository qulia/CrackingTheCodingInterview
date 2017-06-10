
using DataStructures;
using System;

namespace Question_02_04_Partition
{
    public class Solution<T> 
    {
        public void Partition(LinkedList<T> list, T partitionValue)
        {
            LinkedList<T>.Node partitionBorderNode = null;
            var currentNode = list.Head;

            while (currentNode != null)
            {
                if (System.Collections.Generic.Comparer<T>.Default.Compare(currentNode.Data, partitionValue) < 0)
                {
                    // Move currentNode to partition border
                    list.Remove(currentNode);
                    list.InsertAtNode(partitionBorderNode, currentNode);
                    partitionBorderNode = currentNode;
                }

                currentNode = currentNode.Next;
            }
        }
    }
}
