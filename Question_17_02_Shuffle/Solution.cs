using System;
using Utilities;

namespace Question_17_02_Shuffle
{
    public class Solution
    {
        private Random random = new Random();

        public int[] ShuffleArray(int[] input)
        {
            return SortingUtilities.MergeSort(input, ProbabilisticComparator);
        }

        private bool DefaultComparator(int value1, int value2)
        {
            return value1 < value2;
        }

        private bool ProbabilisticComparator(int value1, int value2)
        {
            return random.Next(0, 2) == 0;   
        }                
    }
}
