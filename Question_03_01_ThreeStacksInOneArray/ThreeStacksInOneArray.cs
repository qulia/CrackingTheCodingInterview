using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_03_01_ThreeStacksInOneArray
{
    /// <summary>
    /// Allowed ids 1, 2, 3
    /// note: not thread safe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreeStacksInOneArray<T>
    {
        [Serializable]
        public class StackEmptyException : Exception
        {
        }

        public class StackNode
        {
            public int Location
            {
                get;
                set;
            }

            public StackNode Next
            {
                get;
                set;
            }
        }

        private T[] baseArray;
        private List<int> emptySpots = new List<int>();
        private Dictionary<int, StackNode> stacks = new Dictionary<int, StackNode>();
        private const int numberOfStacks = 3;

        public ThreeStacksInOneArray(int arraySize)
        {
            baseArray = new T[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                emptySpots.Add(i);
            }

            for (int i = 1; i <= numberOfStacks; i++)
            {
                stacks.Add(i, null);
            }
        }

        public void Push(int stackId, T data)
        {
            CheckId(stackId);
            if (emptySpots.Count == 0)
            {
                throw new InsufficientMemoryException();
            }

            var index = emptySpots.First();

            StackNode newTop = new StackNode(); 
            StackNode top = stacks[stackId];
            newTop.Next = top;
            newTop.Location = index;
            baseArray[index] = data;

            stacks[stackId] = newTop;

            emptySpots.Remove(index);

            Print();
        }

        public T Pop(int stackId)
        {
            CheckId(stackId);

            StackNode top = stacks[stackId];
            
            if (top == null)
            {
                throw new StackEmptyException();
            }

            var data = baseArray[top.Location];
            emptySpots.Add(top.Location);
            top = top.Next;
            stacks[stackId] = top;

            Print();
            return data;
        }

        void CheckId(int id)
        {
            if (id < 1 || id > numberOfStacks)
            {
                throw new InvalidOperationException();
            }
        }

        void Print()
        {
            for (int i = 0; i < baseArray.Length; i++)
            {
                Trace.Write(baseArray[i]);
                Trace.Write(" ");
            }

            Trace.WriteLine("");

            foreach (int index in emptySpots)
            {
                Trace.Write(index);
                Trace.Write(" ");
            }

            Trace.WriteLine("");
        }
    }
}
