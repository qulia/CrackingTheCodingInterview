using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedList<T>
    {
        public class Node
        {
            public T Data
            {
                get;
                set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Previous
            {
                get;
                set;
            }
        }

        public class Iterator
        {
            Node currentNode;
            int iterationSpeed;

            public Node Current
            {
                get
                {
                    return currentNode;
                }
            }

            public Iterator(Node startNode, int speed)
            {
                currentNode = startNode;
                iterationSpeed = speed;
            }

            public Node Next()
            {
                if (currentNode == null)
                {
                    return null;
                }

                int counter = 0;
                while (counter < iterationSpeed && currentNode != null)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

                return currentNode;
            }
        }

        public Node Head
        {
            get;
            private set;
        }

        public Node Tail
        {
            get;
            private set;
        }

        public Node this[int index]
        {
            get
            {
                Node current = Head;
                int counter = 0;
                while (counter < index && current != null)
                {
                    current = current.Next;
                    counter++;
                }

                return current;
            }
        }

        public void InsertAtTail(T data)
        {
            var newNode = new Node() { Data = data };
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.Next = newNode;
            Tail = newNode;
        }

        public void InsertAtTail(Node node)
        {
        }

        public void InsertAtNode(Node insertAtNode, Node newNode)
        {
            if (insertAtNode == null)
            {
                // Insert as head
                newNode.Next = Head;
                Head = newNode;
                return;
            }
            
            var current = Head;
            while (current != null)
            {
                if (current == insertAtNode)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;

                    if (current == Tail)
                    {
                        Tail = current;
                    }

                    return;
                }

                current = current.Next;
            }

            throw new Exception("Cannot find the node");
        }

        /// <summary>
        /// Removes first occurence of data
        /// </summary>
        /// <param name="data"></param>
        public void RemoveFirst(T data)
        {
            
        }

        /// <summary>
        /// Removes all occurences of data
        /// </summary>
        /// <param name="data"></param>
        public void RemoveAll(T data)
        {
        }

        public Node Remove(Node node)
        {
            if (Head == null) throw new InvalidOperationException("Trying to remove from empty linked list");

            var current = Head;
            Node previous = Head;
            while (current != null)
            {
                if (current == node)
                {
                    // Are we removing from tail
                    if (Tail == node)
                    {
                        // Removing tail
                        Tail = previous;
                        Tail.Next = null;
                    }
                    else if (node == Head)
                    {
                        Head = Head.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    node.Next = null;
                    return node;
                }

                previous = current;
                current = current.Next;
            }

            throw new InvalidOperationException("Could not find the node to remove");
        }

        public void Print()
        {
            if (Head == null) return;

            var current = Head;
            while (current != null)
            {
                Trace.Write(string.Format("{0} ", current.Data));
                current = current.Next;
            }

            Trace.WriteLine("");
        }
    }
}
