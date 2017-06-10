using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_08_11_Coins
{
    public class Solution : ISolution
    {
        public int MakeChange(int amount)
        {
            Dictionary<int, int> numberOfInstances = new Dictionary<int, int>();
            numberOfInstances.Add(25, 0);
            numberOfInstances.Add(10, 0);
            numberOfInstances.Add(1, 0);

            Dictionary<int, List<Tuple<int, int, int>>> history = new Dictionary<int, List<Tuple<int, int, int>>>();
            var result = MakeChangeRecurse(amount, numberOfInstances, history);

            //history entries with remaining amount of 0, will have the different ways
            foreach (var way in history[0])
            {
                Trace.Write(way.Item1.ToString());
                Trace.Write(" ");
                Trace.Write(way.Item2.ToString());
                Trace.Write(" ");
                Trace.Write(way.Item3.ToString());
                Trace.Write(" ");

                Trace.WriteLine("");
            }

            Debug.Assert(result == history[0].Count);

            return result;
        }

        private int MakeChangeRecurse(
            int amount, 
            Dictionary<int, int> numberOfInstances, 
            Dictionary<int, List<Tuple<int, int, int>>> history)
        {
            // Create a tuple for the number of instances in the order #of 1s, # of 10s, # of 25s
            Tuple<int, int, int> currentInstances = new Tuple<int, int, int>(
                numberOfInstances[1], numberOfInstances[10], numberOfInstances[25]);

            // Keep a history for the remaining amount to current number of instances tuple
            // If at any point of recursion if there is an entry with the same remaining amount and
            // the tuple stop recursion and return 0
            if (history.ContainsKey(amount))
            {
                if (history[amount].Contains(currentInstances))
                {
                    return 0;
                }

                history[amount].Add(currentInstances);
            }
            else
            {
                var list = new List<Tuple<int, int, int>>();
                list.Add(currentInstances);
                history.Add(amount, list);
            }

            if (amount == 0)
            {
                return 1;
            }

            int result = 0;
            if (amount >= 25)
            {
                // Branching to -25, add 1 to numberOfInstances for 25
                Dictionary<int, int> newNumberOfInstances = new Dictionary<int, int>();
                newNumberOfInstances[1] = numberOfInstances[1];
                newNumberOfInstances[10] = numberOfInstances[10];
                newNumberOfInstances[25] = numberOfInstances[25] + 1;
                result += MakeChangeRecurse(amount - 25, newNumberOfInstances, history);
            }

            if (amount >= 10)
            {
                // Branching to -10, add 1 to numberOfInstances for 10
                Dictionary<int, int> newNumberOfInstances = new Dictionary<int, int>();
                newNumberOfInstances[1] = numberOfInstances[1];
                newNumberOfInstances[10] = numberOfInstances[10] + 1;
                newNumberOfInstances[25] = numberOfInstances[25];
                result += MakeChangeRecurse(amount - 10, newNumberOfInstances, history);
            }

            if (amount >= 1)
            {
                // Branching to -1, add 1 to numberOfInstances for 1
                Dictionary<int, int> newNumberOfInstances = new Dictionary<int, int>();
                newNumberOfInstances[1] = numberOfInstances[1] + 1;
                newNumberOfInstances[10] = numberOfInstances[10];
                newNumberOfInstances[25] = numberOfInstances[25];
                result += MakeChangeRecurse(amount - 1, newNumberOfInstances, history);
            }

            return result;
        }
    }
}
