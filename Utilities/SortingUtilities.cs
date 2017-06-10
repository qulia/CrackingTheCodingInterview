using System;

namespace Utilities
{
    public class SortingUtilities
    {
        public static int[] MergeSort(int[] input, Func<int, int, bool> comparator)
        {
            IndexData indices = new IndexData();
            indices.StartIndex = 0;
            indices.EndIndex = input.Length - 1;
            return MergeSort(input, indices, comparator);
        }

        public static int[] MergeSort(int[] source, IndexData sourceIndices, Func<int, int, bool> comparator)
        {
            //Trace.WriteLine(string.Format("{0} {1}", sourceIndices.StartIndex, sourceIndices.EndIndex));

            if (sourceIndices.StartIndex == sourceIndices.EndIndex)
            {
                var result = new int[1];
                result[0] = source[sourceIndices.StartIndex];
                return result;
            }

            IndexData leftIndices = new IndexData();
            leftIndices.StartIndex = sourceIndices.StartIndex;
            leftIndices.EndIndex = (sourceIndices.StartIndex + sourceIndices.EndIndex) / 2;
            IndexData rightIndices = new IndexData();
            rightIndices.StartIndex = leftIndices.EndIndex + 1;
            rightIndices.EndIndex = sourceIndices.EndIndex;

            var leftArray = MergeSort(source, leftIndices, comparator);
            var rightArray = MergeSort(source, rightIndices, comparator);

            return Merge(leftArray, rightArray, comparator);
        }


        private static int[] Merge(int[] leftArray, int[] rightArray, Func<int, int, bool> comparator)
        {
            int leftLength = leftArray.Length;
            int rightLength = rightArray.Length;
            int[] mergedArray = new int[leftLength + rightLength];


            int leftCounter = 0;
            int rightCounter = 0;
            int mergeCounter = 0;

            while (leftCounter < leftLength && rightCounter < rightLength)
            {
                if (comparator(leftArray[leftCounter], rightArray[rightCounter]))
                {
                    mergedArray[mergeCounter++] = leftArray[leftCounter++];
                }
                else
                {
                    mergedArray[mergeCounter++] = rightArray[rightCounter++];
                }
            }

            if (leftCounter < leftLength)
            {
                for (int i = leftCounter; i < leftLength; i++)
                {
                    mergedArray[mergeCounter++] = leftArray[i];
                }
            }
            else if (rightCounter < rightLength)
            {
                for (int i = rightCounter; i < rightLength; i++)
                {
                    mergedArray[mergeCounter++] = rightArray[i];
                }
            }

            return mergedArray;
        }
    }
}
