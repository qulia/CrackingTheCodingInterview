using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_17_11_WordDistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_17_11_WordDistance.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetMinDistanceTest()
        {
            List<string> words = new List<string>();
            words.Add("word1");
            words.Add("word3");
            words.Add("word4");
            words.Add("word2");
            words.Add("word5");
            words.Add("word1");

            Solution solution = new Solution();
            var result = solution.GetMinDistance_Part1(words, "word1", "word2");
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void GetMinDistanceTest2()
        {
            List<string> words = new List<string>();
            words.Add("word1");
            words.Add("word3");
            words.Add("word4");
            words.Add("word2");
            words.Add("word5");
            words.Add("word1");
            words.Add("word2");

            Solution solution = new Solution();
            var result = solution.GetMinDistance_Part1(words, "word1", "word2");
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void GetMinDistanceTest3()
        {
            List<string> words = new List<string>();
            words.Add("word1");
            words.Add("word3");
            words.Add("word4");
            words.Add("word5");
            words.Add("word2");
            words.Add("word2");
            words.Add("word5");
            words.Add("word1");
            
            Solution solution = new Solution();
            var result = solution.GetMinDistance_Part1(words, "word1", "word2");
            Assert.AreEqual(2, result);
        }
    }
}