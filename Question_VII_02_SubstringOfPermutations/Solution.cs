using System.Collections.Generic;
using Utilities;

namespace Question_VII_02_SubstringOfPermutations
{
    public class Solution
    {
        /// <summary>
        /// Returns the list of start locations of the permutations of the search string 
        /// within the source string
        /// </summary>
        /// <returns></returns>
        public List<int> FindSubstringsOfPermutations(string source, string search)
        {
            int currentIndex = 0;
            int numberOfChars = 0;
            int leftBoundry = 0;

            List<int> matchIndices = new List<int>();
            Dictionary<char, int> targetCountMap = GetCountMap(search);

            Dictionary<char, int> currentCountMap = new Dictionary<char, int>();

            // To include the last 4 char match use <=
            while (currentIndex <= source.Length)
            {
                if (numberOfChars == search.Length)
                {
                    if (Compare(targetCountMap, currentCountMap))
                    {
                        matchIndices.Add(currentIndex - search.Length);

                        // Shorcut: if there is a match just check the next char if it is the same as
                        // first char of the previous iteration 
                        // then just add it as match and increment currentIndex
                        while (currentIndex < source.Length)
                        {
                            if (source[currentIndex] == source[currentIndex - search.Length])
                            {
                                currentIndex++;
                                matchIndices.Add(currentIndex - search.Length);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                // Advance and continue
                Advance(source, 
                    targetCountMap, currentCountMap, search.Length, 
                    ref numberOfChars, ref currentIndex, ref leftBoundry);
            }

            return matchIndices;
        }

        private void Advance(string source, Dictionary<char, int> targetCountMap,
            Dictionary<char, int> currentCountMap, int searchLength, 
            ref int numberOfChars, ref int currentIndex, ref int leftBoundry)
        {
            // Shortcut: if we find a char in source string that is not in search string,
            // reset the current count map and leftBoundry
            while (currentIndex < source.Length
                && !targetCountMap.ContainsKey(source[currentIndex]))
            {
                currentIndex++;
                numberOfChars = 0;
                currentCountMap.Clear();
                leftBoundry = currentIndex;
            }

            if (currentIndex < source.Length)
            {
                currentCountMap.AddOrIncrement(source[currentIndex]);
                numberOfChars++;
            }

            if (currentIndex - searchLength >= leftBoundry)
            {
                currentCountMap.RemoveOrDecrement(source[currentIndex - searchLength]);
                numberOfChars--;
            }

            currentIndex++;
        }

        private bool Compare(Dictionary<char, int> targetCountMap, Dictionary<char, int> currentCountMap)
        {
            foreach (var keyValuePair in targetCountMap)
            {
                if (!currentCountMap.ContainsKey(keyValuePair.Key) || 
                    currentCountMap[keyValuePair.Key] != keyValuePair.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static Dictionary<char, int> GetCountMap(string input)
        {
            Dictionary<char, int> countMap = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                countMap.AddOrIncrement(input[i]);
            }

            return countMap;
        }
    }
}
