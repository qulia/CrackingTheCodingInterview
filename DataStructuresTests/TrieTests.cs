using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataStructures.Tests
{
    [TestClass()]
    public class TrieTests
    {
        [TestMethod()]
        public void TrieTest()
        {
            Trie trie = new Trie();
            trie.Insert("abc");
            trie.Insert("abcd");
            trie.Insert("abce");
            trie.Insert("de");

            foreach (var word in trie)
            {
                Trace.WriteLine(word);
            }

            Trace.WriteLine("With prefix");
            foreach (var wordWithPrefix in trie.StartsWith("abc"))
            {
                Trace.WriteLine(wordWithPrefix);
            }
        }

        [TestMethod()]
        public void TrieTest2()
        {
            Trie trie = new Trie();
            trie.Insert("abcdef");
            trie.Insert("abc");
            trie.Insert("abce");
            trie.Insert("de");
            trie.Insert("def");
            trie.Insert("d");
            trie.Insert("defg");

            foreach (var word in trie)
            {
                Trace.WriteLine(word);
            }

            Trace.WriteLine("With prefix");
            foreach (var wordWithPrefix in trie.StartsWith("d"))
            {
                Trace.WriteLine(wordWithPrefix);
            }
        }
    }
}