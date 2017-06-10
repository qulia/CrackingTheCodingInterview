using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Utilities
{
    public static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> list)
        {
            List<T> clone = new List<T>();
            foreach (var item in list)
            {
                clone.Add(item);
            }

            return clone;
        }

        public static List<List<T>> Combinations<T>(this List<T> list, int k)
        {
            List<List<int>> indicesList = CombinationsUtilities.GetKCombinationsOfN(list.Count, k);
            List<List<T>> result = new List<List<T>>();

            foreach (var innerList in indicesList)
            {
                List<T> resultInnerList = new List<T>();
                foreach (var index in innerList)
                {
                    resultInnerList.Add(list[index]);
                }
                result.Add(resultInnerList);
            }

            return result;
        }

        public static void Print<T>(this List<T> list, bool sameLine = false)
        {
            foreach (var item in list)
            {
                if (sameLine)
                {
                    Trace.Write(string.Format("{0} ", item));
                }
                else
                {
                    Trace.WriteLine(item);
                }
            }
        }

        public static string ToStringExt<T>(this List<T> list, bool sameLine = false)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in list)
            {
                if (sameLine)
                {
                    stringBuilder.Append($"{item} ");
                }
                else
                {
                    stringBuilder.Append(item);
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }
    }
}
