using System;

namespace DataStructures
{
    public class MinHeap<T> : Heap<T> where T : IComparable
    {
        public override bool Compare(T data1, T data2)
        {
            return data1.CompareTo(data2) < 0;
        }
    }
}
