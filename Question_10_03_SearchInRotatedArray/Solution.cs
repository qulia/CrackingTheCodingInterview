using System;

namespace Question_10_03_SearchInRotatedArray
{
    public class Solution
    {
        static Func<int[], int, int, bool> isOrdered =
            new Func<int[], int, int, bool>((int[] array, int lowIndex, int highIndex) =>
             { return array[lowIndex] < array[highIndex]; });

        static Func<int[], int, int, int, bool> isInPart =
            new Func<int[], int, int, int, bool>((int[] array, int lowIndex, int highIndex, int value) =>
            { return array[lowIndex] <= value && array[highIndex] >= value; });

        static Func<int[], int, int, int, int> searchPart = 
            new Func<int[], int, int, int, int>((int[] array, int lowIndex, int highIndex, int value) => 
            { return SearchRecurse(array, lowIndex, highIndex, value); });

        public int Search(int[] rotatedArray, int value)
        {
            return SearchRecurse(rotatedArray, 0, rotatedArray.Length - 1, value);
        }

        private static int SearchRecurse(int[] rotatedArray, int low, int high, int value)
        {
            if (low > high)
            {
                return -1;
            }

            var mid = (low + high) / 2;
            if (rotatedArray[mid] == value)
            {
                return mid;
            }

            var isLeftOrdered = new Func<bool>(() => { return isOrdered(rotatedArray, low, mid); });
            var isRightOrdered = new Func<bool>(() => { return isOrdered(rotatedArray, mid, high); });

            var isInLeftPart = new Func<bool>(() => { return isInPart(rotatedArray, low, mid, value); });
            var isInRightPart = new Func<bool>(() => { return isInPart(rotatedArray, mid, high, value); });

            var searchLeftPart = new Func<int>(() => { return searchPart(rotatedArray, low, mid - 1, value); });
            var searchRightPart = new Func<int>(() => { return searchPart(rotatedArray, mid + 1, high, value); });

            if (isLeftOrdered())
            {
                if (isInLeftPart())
                {
                    return searchLeftPart();
                }
                else
                {
                    return searchRightPart();
                }
            }
            else if (isRightOrdered())
            {
                if (isInRightPart())
                {
                    return searchRightPart();
                }
                else
                {
                    return searchLeftPart();
                }
            }
            else if (rotatedArray[mid] == rotatedArray[low])
            {
                // Repeats on left; if high is different
                // then search right
                if (rotatedArray[mid] != rotatedArray[high])
                {
                    return searchRightPart();
                }
                else
                {
                    // value can be at either side, search both sides
                    // e.g. 7,7,7,7,3,4,5,7,7,7,7,7,7,7 or 7,7,7,7,7,7,7,3,4,5,7,7,7,7
                    var result = searchLeftPart();
                    return result == -1 ? searchRightPart() : result;
                }
            }

            return -1;
        }
    }
}
