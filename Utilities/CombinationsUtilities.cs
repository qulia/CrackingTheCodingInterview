using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public class CombinationsUtilities
    {
        public static List<List<int>> GetKCombinationsOfN(int n, int k)
        {
            if (k == 1)
            {
                var list = new List<List<int>>();
                for (int i = 0; i < n; i++)
                {
                    var innerList = new List<int>();
                    innerList.Add(i);
                    list.Add(innerList);
                }

                return list;
            }

            var prev = GetKCombinationsOfN(n, k - 1);
            List<List<int>> result = new List<List<int>>();
            foreach (var list in prev)
            {
                // Copy from only the last index to prevent duplicates
                var last = list.Last();
                for (int i = last + 1; i < n; i++)
                {
                    var newList = new List<int>();
                    for (int j = 0; j < list.Count; j++)
                    {
                        newList.Add(list[j]);
                    }

                    newList.Add(i);
                    result.Add(newList);
                }
            }

            return result;
        }
    }
}
