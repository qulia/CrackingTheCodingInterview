using DataStructures;
using System;
using System.Diagnostics;
using System.Linq;

namespace Chapter_03_03_StacksOfPlates
{
    public class MultipleStacks<T>
    {
        int capacityPerStack;
        System.Collections.Generic.List<Stack<T>> stacks = new System.Collections.Generic.List<Stack<T>>();
        public MultipleStacks(int capacityPerStack)
        {
            this.capacityPerStack = capacityPerStack;
        }

        public void Push(T value)
        {
            if (IsEmpty() || stacks.Last().IsFull())
            {
                stacks.Add(new Stack<T>(capacityPerStack));
            }

            var lastStack = stacks.Last();
            lastStack.Push(value);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Stack<T>.StackEmptyException();
            }

            var lastStack = stacks.Last();
            var value = lastStack.Pop();
            if (lastStack.IsEmpty())
            {
                stacks.Remove(lastStack);
            }

            return value;
        }

        public void Print()
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                Trace.Write(string.Format("index {0}: ",i));
                stacks[i].Print();
                Trace.WriteLine("");
            }
        }

        public T PopAt(int index)
        {
            if (index >= stacks.Count)
            {
                throw new ArgumentException(string.Format("Stack with index {0} does not exist", index));
            }

            var stackAtIndex = stacks[index];
            var value = stackAtIndex.Pop();

            // Fill the hole by rolling over from the next stack recursively
            Rollover(index);

            // Check to see if the last one is empty
            // We do not check during rollover becaue if capacity is 1 and stacks in the middle can be empty temporarily
            if (stacks.Last().IsEmpty())
            {
                stacks.Remove(stacks.Last());
            }

            return value;
        }

        private void Rollover(int index)
        {
            int successorStackIndex = index + 1;
            if (successorStackIndex >= stacks.Count)
            {
                return;
            }

            var successorStack = stacks[successorStackIndex];
            var value = stacks[successorStackIndex].RemoveFirst();

            stacks[index].Push(value);

            Rollover(index + 1);
        }

        public bool IsEmpty()
        {
            return stacks.Count == 0;
        }
    }
}
