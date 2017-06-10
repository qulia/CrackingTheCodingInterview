using System;
using System.Collections.Generic;

namespace Question_17_11_WordDistance
{
    public class Solution
    {
        public int GetMinDistance_Part1(List<string> words, string word1, string word2)
        {
            int counter1 = 0;
            int counter2 = 0;
            int minDistance = Int32.MaxValue;
            bool lookingFor1 = false;
            bool lookingFor2 = false;
            foreach (var word in words)
            {
                if (word == word1 || word == word2)
                {
                    if (!lookingFor1 && !lookingFor2)
                    {
                        // Not looking for any matching pair yet
                        lookingFor1 = word == word2;
                        lookingFor2 = word == word1;
                        counter1 = lookingFor1 ? 0 : counter1;
                        counter2 = lookingFor2 ? 0 : counter2;
                    }
                    else
                    {
                        if (word == word1)
                        {
                            if (lookingFor1)
                            {
                                // Found a pair update distance if necessary
                                UpdateDistance(ref counter1, ref minDistance, ref lookingFor1);
                            }

                            // reset counter now looking for word2
                            // even if we have been looking for word2 this will be closer
                            lookingFor2 = true;
                            counter2 = 0;
                        }
                        else if (word == word2)
                        {
                            if (lookingFor2)
                            {
                                UpdateDistance(ref counter2, ref minDistance, ref lookingFor2);
                            }

                            lookingFor1 = true;
                            counter1 = 0;
                        }
                    }
                }

                counter1++;
                counter2++;
            }

            return minDistance;
        }

        private static void UpdateDistance(ref int counter, ref int minDistance, ref bool lookingFor)
        {
            // found matching pair
            if (counter < minDistance)
            {
                minDistance = counter;
            }

            counter = 0;
            lookingFor = false;
        }
    }
}
