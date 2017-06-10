using DataStructures;
using System;
using System.Collections.Generic;

namespace Question_17_25_WordRectangle
{
    public class WordsMap
    {
        public class LargerComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x > y ? -1 : (x < y) ? 1 : 0;
            }
        }

        private SortedList<int, Trie> wordsMapByLength = new SortedList<int, Trie>(new LargerComparer());

        public WordsMap(List<string> words)
        {
            foreach (var word in words)
            {
                if (!wordsMapByLength.ContainsKey(word.Length))
                {
                    wordsMapByLength.Add(word.Length, new Trie());
                }

                wordsMapByLength[word.Length].Insert(word);
            }
        }

        internal bool Get(int lengthIndex, out int length, out Trie words)
        {
            length = Int32.MaxValue;
            words = null;

            if (wordsMapByLength.Count > lengthIndex)
            {
                length = wordsMapByLength.Keys[lengthIndex];
                words = wordsMapByLength[length];
                return true;
            }

            return false;
        }
    }
}
