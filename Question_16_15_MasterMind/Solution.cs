using System.Collections.Generic;

namespace Question_16_15_MasterMind
{
    public class Solution
    {
        public Result GetResult(string solution, string guess)
        {
            Result result = new Result();

            if (solution.Length != guess.Length)
            {
                return result;
            }

            Dictionary<char, int> solutionMap = new Dictionary<char, int>();
            Dictionary<char, int> guessMap = new Dictionary<char, int>();

            solution = solution.ToLower();
            guess = guess.ToLower();

            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == guess[i])
                {
                    result.AddHit();
                }
                else
                {
                    UpdateMap(guess[i], solutionMap, guessMap, result);
                    UpdateMap(solution[i], guessMap, solutionMap, result);
                }
            }

            return result;
        }

        private static void UpdateMap(char currentChar, 
            Dictionary<char, int> searchMap, Dictionary<char, int> destinationMap, Result result)
        {
            if (searchMap.ContainsKey(currentChar))
            {
                result.AddPseudohit();
                var count = searchMap[currentChar];
                if (count == 1)
                {
                    searchMap.Remove(currentChar);
                }
                else
                {
                    searchMap[currentChar] = --count;
                }
            }
            else
            {
                if (destinationMap.ContainsKey(currentChar))
                {
                    destinationMap[currentChar]++;
                }
                else
                {
                    destinationMap.Add(currentChar, 1);
                }
            }
        }
    }
}
