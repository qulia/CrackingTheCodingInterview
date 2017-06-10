using System;
using System.Diagnostics;

namespace DataStructures
{
    public class Stack<T>
    {
        public class StackEmptyException : Exception
        {
        }

        public class StackFullException : Exception
        {
        }

        public class Node
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data
            {
                get;
                private set;
            }

            public Node Predecessor
            {
                get;
                set;
            }

            public Node Successor
            {
                get;
                set;
            }
        }

        public bool IsFull()
        {
            return size == capacity;
        }

        Node first;
        Node last;
        int capacity;
        int size = 0;

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }

            var value = last.Data;
            last = last.Predecessor;
            size--;
            return value;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Print()
        {
            var current = last;
            while (current != null)
            {
                Trace.Write(string.Format("{0} ", current.Data));
                current = current.Predecessor;
            }
        }

        public void Push(T value)
        {
            if (IsFull())
            {
                throw new StackFullException();
            }

            if (IsEmpty())
            {
                last = new Node(value);
                first = last;
            }
            else
            {
                last.Successor = new Node(value);
                last.Successor.Predecessor = last;
                last = last.Successor;
            }

            size++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }

            var value = first.Data;
            if (first.Successor != null)
            {
                // When ther is more than 1 element
                first.Successor.Predecessor = null;
            }

            first = first.Successor;
            size--;

            return value;
        }
    }
}
