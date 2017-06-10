using DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_04_09_BSTSequences
{
    public class Solution<T>
    {
        public List<List<T>> BSTSequencesFromTree(Tree<T> tree)
        {
            // TODO convert to arrays before returning
            return BSTSequencesRecurse(tree.Root);
        }

        List<List<T>> BSTSequencesRecurse(Tree<T>.Node root)
        {
            if (root == null)
            {
                return new List<List<T>>();
            }

            List<List<T>> leftValues = BSTSequencesRecurse(root.Left);
            List<List<T>> rightValues = BSTSequencesRecurse(root.Right);

            List<List<T>> resultValues = new List<List<T>>();
            if (leftValues.Count == 0 || rightValues.Count == 0)
            {
                AddValues(root.Data, leftValues, rightValues, resultValues);
            }
            else
            {
                AddValues(root.Data, leftValues, rightValues, resultValues);
                AddValues(root.Data, rightValues, leftValues, resultValues);
            }

            return resultValues;
        }

        private void AddValues(T rootData, List<List<T>> values1, List<List<T>> values2, List<List<T>> resultValues)
        {
            if (values1.Count == 0 && values2.Count == 0)
            {
                List<T> list = new List<T>();
                list.Add(rootData);
                resultValues.Add(new List<T>(list));
                return;
            }

            if (values1.Count > 0)
            {
                foreach (List<T> innerList1 in values1)
                {
                    List<T> innerValues1 = new List<T>();
                    innerValues1.Add(rootData);
                    foreach (T data in innerList1)
                    {
                        innerValues1.Add(data);
                    }

                    if (values2.Count == 0)
                    {
                        resultValues.Add(innerValues1);
                    }
                    else
                    {
                        foreach (List<T> innerList2 in values2)
                        {
                            List<T> innerValues2 = new List<T>(innerValues1);
                            foreach (T data in innerList2)
                            {
                                innerValues2.Add(data);
                            }

                            resultValues.Add(innerValues2);
                        }
                    }
                }
            }
            else
            {
                // values1.count = 0
                foreach (List<T> innerList2 in values2)
                {
                    List<T> innerValues2 = new List<T>();
                    innerValues2.Add(rootData);
                    foreach (T data in innerList2)
                    {
                        innerValues2.Add(data);
                    }

                    resultValues.Add(innerValues2);
                }
            }
        }
    }
}
