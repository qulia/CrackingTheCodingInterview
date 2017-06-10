using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Question_17_25_WordRectangle.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetMaxWordsRectangleTest()
        {
            List<string> dictionary = InitializeDictionary();

            Trace.WriteLine("Input:");
            PrintList(dictionary);

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }

        private static void PrintList(List<string> dictionary)
        {
            Trace.WriteLine("");
            foreach (var word in dictionary)
            {
                Trace.WriteLine(word);
            }
        }

        private static List<string> InitializeDictionary()
        {
            List<string> dictionary = new List<string>();
            dictionary.Add("abc");
            dictionary.Add("def");
            dictionary.Add("ghi");
            dictionary.Add("adg");
            dictionary.Add("beh");
            dictionary.Add("cfi");
            return dictionary;
        }

        [TestMethod()]
        public void GetMaxWordsRectangleTest2()
        {
            List<string> dictionary = InitializeDictionary();
            AddRandomStrings(dictionary, 5, new Tuple<int, int>(3, 3));

            Trace.WriteLine("Input:");
            foreach (var word in dictionary)
            {
                Trace.WriteLine(word);
            }

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }

        private void AddRandomStrings(List<string> dictionary, int numberOfStrings, Tuple<int, int> wordLengthRange)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfStrings; i++)
            {
                int length = (wordLengthRange.Item1 == wordLengthRange.Item2) ? 
                    wordLengthRange.Item1 : random.Next(wordLengthRange.Item1, wordLengthRange.Item2);

                string value = GetRandomString(random, length);
                dictionary.Insert(random.Next(0, dictionary.Count), value);
            }
        }

        private string GetRandomString(Random random, int length)
        {
            int chara = 'a';
            int charz = 'z';

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char current = (char)random.Next(chara, charz + 1);
                builder.Append(current);
            }

            return builder.ToString();
        }

        [TestMethod()]
        public void GetMaxWordsRectangleTest3()
        {
            List<string> dictionary = new List<string>();
            dictionary.Add("abc");
            dictionary.Add("bde");
            dictionary.Add("cfg");
            dictionary.Add("bdf");
            dictionary.Add("ceg");
            dictionary.Add("dbe");
            dictionary.Add("fcg");
            dictionary.Add("adf");
            dictionary.Add("bbc");

            Trace.WriteLine("Input:");
            PrintList(dictionary);

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }

        [TestMethod()]
        public void GetMaxWordsRectangleFailedTestInput()
        {
            List<string> dictionary = new List<string>();
            dictionary.Add("p");
            dictionary.Add("r");
            dictionary.Add("abc");
            dictionary.Add("fqm");
            dictionary.Add("zlhcl");
            dictionary.Add("no");
            dictionary.Add("zsmx");
            dictionary.Add("def");
            dictionary.Add("ei");
            dictionary.Add("z");
            dictionary.Add("pyc");
            dictionary.Add("d");
            dictionary.Add("ghi");
            dictionary.Add("qj");
            dictionary.Add("o");
            dictionary.Add("h");
            dictionary.Add("olnd");
            dictionary.Add("zjzvm");
            dictionary.Add("ddbv");
            dictionary.Add("murt");
            dictionary.Add("adg");
            dictionary.Add("x");
            dictionary.Add("h");
            dictionary.Add("fjqmv");
            dictionary.Add("beh");
            dictionary.Add("cfi");

            Trace.WriteLine("Input:");
            PrintList(dictionary);

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }

        [TestMethod()]
        public void GetMaxWordsRectangleTest4()
        {
            List<string> dictionary = InitializeDictionary();
            AddRandomStrings(dictionary, 5, new Tuple<int, int>(1, 6));

            Trace.WriteLine("Input:");
            PrintList(dictionary);

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }

        [TestMethod()]
        public void GetMaxWordsRectangleTest5()
        {
            List<string> dictionary = InitializeDictionary();
            AddRandomStrings(dictionary, 20, new Tuple<int, int>(1, 6));

            Trace.WriteLine("Input:");
            PrintList(dictionary);

            var solution = new Solution();
            var result = solution.GetMaxWordsRectangle(dictionary);
            if (result != null)
            {
                Trace.WriteLine("Result:");
                Trace.WriteLine(result.Size);
                PrintList(result.List);
            }
            else
            {
                Trace.WriteLine("not found");
            }
        }
    }
}