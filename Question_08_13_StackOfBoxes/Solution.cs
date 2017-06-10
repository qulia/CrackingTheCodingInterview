using System.Collections.Generic;
using Utilities;

namespace Question_08_13_StackOfBoxes
{
    public class Solution
    {
        public StackOfBoxes BuildMaxHeightStack(List<Box> boxes)
        {
            boxes.Sort();
            boxes.Print();

            // Map from bottom index to max height stack of boxes
            Dictionary<int, StackOfBoxes> maxStackMap = new Dictionary<int, StackOfBoxes>();
            StackOfBoxes tallestStack = new StackOfBoxes();
            for (int i = 0; i < boxes.Count; i++)
            {
                var currentTallestStack = BuildMaxHeightStackRecurse(boxes, i, maxStackMap);
                if (tallestStack < currentTallestStack)
                {
                    tallestStack = currentTallestStack;
                }
            }

            return tallestStack;
        }

        private StackOfBoxes BuildMaxHeightStackRecurse(
            List<Box> boxes, int index, Dictionary<int, StackOfBoxes> maxStackMap)
        {
            if (maxStackMap.ContainsKey(index))
            {
                return maxStackMap[index];
            }

            StackOfBoxes stackWithBottomIndex = new StackOfBoxes();
            stackWithBottomIndex.AddBottom(boxes[index]);

            StackOfBoxes tallestStackWithBottomIndex = stackWithBottomIndex.Clone();

            for (int i = index + 1; i < boxes.Count; i++)
            {
                var currentStack = stackWithBottomIndex.Clone();
                if (boxes[i] < boxes[index])
                {
                    var aboveStack = BuildMaxHeightStackRecurse(boxes, i, maxStackMap);
                    currentStack.Merge(aboveStack);


                    if (tallestStackWithBottomIndex < currentStack)
                    {
                        tallestStackWithBottomIndex = currentStack;
                    }
                 }
            }

            maxStackMap[index] = tallestStackWithBottomIndex;
            return tallestStackWithBottomIndex;
        }
    }
}
