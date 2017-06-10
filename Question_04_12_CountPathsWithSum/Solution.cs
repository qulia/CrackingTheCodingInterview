using DataStructures;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Utilities;

namespace Question_04_12_CountPathsWithSum
{
    public class Solution
    {
        public class Result
        {
            private Dictionary<int, int> possibleSums = new Dictionary<int, int>();
            private int targetSum;

            public int TotalCount
            {
                get;
                private set;
            }

            public IReadOnlyDictionary<int, int> Sums
            {
                get
                {
                    return possibleSums;
                }
            }

            public Result(int targetSum)
            {
                this.targetSum = targetSum;
            }

            public Result(Result result1, Result result2, int data, int targetSum)
            {
                this.targetSum = targetSum;
                AddValue(data);
                TotalCount += result1.TotalCount;
                TotalCount += result2.TotalCount;
                UpdateSums(result1, data, targetSum);
                UpdateSums(result2, data, targetSum);
            }

            private void UpdateSums(Result other, int data, int targetSum)
            {
                foreach (var pair in other.Sums)
                {
                    var sum = pair.Key + data;
                    AddValue(sum, pair.Value);
                }
            }

            private void AddValue(int value, int count = 1)
            {
                if (value == targetSum)
                {
                    TotalCount += count;
                }

                possibleSums.AddOrIncrement(value, count);
            }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Format("TotalCount: {0}", TotalCount));

                foreach (var pair in possibleSums)
                {
                    builder.Append(string.Format("{0}: {1}, ", pair.Key, pair.Value));
                }

                builder.AppendLine();
                return builder.ToString();
            } 
        }

        public int CountPathsWithSum(Tree<int> tree, int targetSum)
        {
            var result = CountPathsWithSumRecurse(tree.Root, targetSum);

            return result.TotalCount;
        }

        private Result CountPathsWithSumRecurse(Tree<int>.Node root, int targetSum)
        {
            if (root == null)
            {
                return new Result(targetSum);
            }

            var leftResult = CountPathsWithSumRecurse(root.Left, targetSum);
            var rightResult = CountPathsWithSumRecurse(root.Right, targetSum);

            var result = new Result(leftResult, rightResult, root.Data, targetSum);

            Trace.WriteLine(result);
            return result;

        }
    }
}
