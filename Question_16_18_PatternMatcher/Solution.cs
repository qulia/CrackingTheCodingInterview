using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Question_16_18_PatternMatcher
{
    public class Solution
    {
        // Note that you can pass pattern of any number of distinct chars
        // not just a,b
        public bool IsAPatternOf(string input, string pattern)
        {
            // Only one char in pattern left?
            if (pattern.Distinct().Count() == 1)
            {               
                if (input.Length == 0)
                {
                    return false;
                }

                int remainingLength = input.Length;
                int patternLength = pattern.Length;

                if (remainingLength % patternLength != 0)
                {
                    return false;
                }

                int sectionLength = remainingLength / patternLength;
                var repeatString = input.Substring(0, sectionLength);

                StringBuilder finalString = new StringBuilder();
                for (int i = 0; i < patternLength; i++)
                {
                    finalString.Append(repeatString);
                }

                return finalString.ToString().Equals(input);
            }

            // Pick a match for the first pattern letter
            // Removed as many pattern char from the string that are match string
            // Recursively check for match
            char firstPatternChar = pattern[0];
            string matchFirst;
            for (int i = 1; i <= input.Length; i++)
            {
                matchFirst = input.Substring(0, i);
                var removedPatternCount = 0;

                string removedPattern = RemoveAll(pattern, firstPatternChar, out removedPatternCount);
                var afterRemovedList = RemoveAsCount(input, matchFirst, removedPatternCount);
                // Try all possibilities, if any of it is a match return true,
                // Otherwise try other possibilites
                foreach (var possibleRemoved in afterRemovedList)
                {
                    if (IsAPatternOf(possibleRemoved, removedPattern))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string RemoveAll(string original, char removeChar, out int removedCount)
        {
            string newString = string.Empty;
            foreach (char value in original)
            {
                if (value != removeChar)
                {
                    newString += value;
                }
            }

            removedCount = original.Length - newString.Length;
            return newString;
        }

        private IEnumerable<string> RemoveAsCount(string original, string removeString, int removeCount)
        {
            string newString = original;
            List<int> occurences = new List<int>();

            int index;
            do
            {
                index = newString.IndexOf(removeString);
                if (index != -1)
                {
                    occurences.Add(index + occurences.Count * removeString.Length);
                    newString = newString.Remove(index, removeString.Length);
                }
            } while (index != -1);

            if (occurences.Count < removeCount) yield break;

            if (occurences.Count == removeCount)
            {
                yield return newString;
                yield break;
            }

            List<List<int>> combinations = occurences.Combinations(removeCount);
            foreach (var combinationIndex in combinations)
            {
                yield return GetRemovedString(original, combinationIndex, removeString.Length);
            }
        }

        private string GetRemovedString(string original, List<int> combinationIndex, int length)
        {
            string newString = original;
            for (int i = 0; i < combinationIndex.Count; i++)
            {
                int index = combinationIndex[i] - i * length;
                newString = newString.Remove(index, length);
            }
       
            return newString;
        }
    }
}
