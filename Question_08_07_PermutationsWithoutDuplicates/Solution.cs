using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_08_07_PermutationsWithoutDuplicates
{
    public class Solution
    {
        /// <summary>
        /// Assume input does not have duplicate chars
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<string> GetPermutations(string input)
        {
            return GetPermutationsRecurse(input, input.Length - 1);
        }

        private List<string> GetPermutationsRecurse(string input, int index)
        {
            if (index == 0)
            {
                var list = new List<string>();
                list.Add(input[0].ToString());
                return list;
            }

            List<string> currentPerms = GetPermutationsRecurse(input, index - 1);

            List<string> newPerms = new List<string>();

            // foreach Readonly collection
            foreach (string existingString in currentPerms)
            {
                AddPerms(existingString, input[index], newPerms);
            }

            return newPerms;
        }

        private void AddPerms(string existingString, char charToAdd, List<string> perms)
        {
            for (int i = 0; i < existingString.Length; i++)
            {
                var stringToAdd = existingString.Insert(i, charToAdd.ToString());
                perms.Add(stringToAdd);
            }

            perms.Add(existingString + charToAdd.ToString());
        }
    }
}
