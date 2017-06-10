using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_13_08_LambdaRandom
{
    public class Solution
    {
        Random random = new Random();

        public List<int> GetRandomSubset(List<int> set)
        {
            var subset = set.Aggregate(new List<int>(), 
                (currentList, currentEntry) =>
                {
                    if (GetBoolean())
                    {
                        currentList.Add(currentEntry);
                    }

                    return currentList;
                });

            return subset;
        }

        private bool GetBoolean()
        {
            return random.Next(0, 2) == 0;
        }

        public List<int> GetRandomSubsetWithPredicate(List<int> set)
        {
            Func<List<int>, int, List<int>> addEntryPredicate = (currentList, currentEntry) =>
                {
                    if (GetBoolean())
                    {
                        currentList.Add(currentEntry);
                    }

                    return currentList;
                };

            return set.Aggregate(new List<int>(), addEntryPredicate);
        }
    }
}
