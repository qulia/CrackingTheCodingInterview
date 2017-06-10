using DataStructures;
using System.Collections.Generic;

namespace Question_10_08_FindDuplicates
{
    public class Solution
    {
        public List<int> FindDuplicates(List<int> list, int maxIntegerValue)
        {
            List<int> duplicates = new List<int>();
            IntegerToBitSet bitSet = new IntegerToBitSet(maxIntegerValue);
            foreach (var value in list)
            {
                if (bitSet[value])
                {
                    duplicates.Add(value);
                }
                else
                {
                    bitSet[value] = true;
                }
            }

            return duplicates; 
        }
    }
}
