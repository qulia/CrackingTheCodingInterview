using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_17_26_Sparse_Similarity.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetSimilarityTest()
        {
            string[] doc1Content = { "14", "15", "100", "9", "3" };
            string[] doc2Content = { "32", "1", "9", "3", "5" };
            string[] doc3Content = { "15", "29", "2", "6", "8", "7" };
            string[] doc4Content = { "7", "10" };

            List<Document> documents = new List<Document>();
            documents.Add(GetDocument(13, doc1Content));
            documents.Add(GetDocument(24, doc4Content));
            documents.Add(GetDocument(16, doc2Content));
            documents.Add(GetDocument(19, doc3Content));

            Solution solution = new Solution();
            var result = solution.GetSimilarity(documents);

            PrintResult(result);
        }

        [TestMethod()]
        public void GetSimilarityTestWithDuplicateWords()
        {
            string[] doc1Content = { "14", "15", "100", "9", "3", "3"};
            string[] doc2Content = { "32", "1", "9", "3", "5" };
            string[] doc3Content = { "15", "29", "2", "6", "8", "7" };
            string[] doc4Content = { "7", "10" };

            List<Document> documents = new List<Document>();
            documents.Add(GetDocument(13, doc1Content));
            documents.Add(GetDocument(24, doc4Content));
            documents.Add(GetDocument(16, doc2Content));
            documents.Add(GetDocument(19, doc3Content));

            Solution solution = new Solution();
            var result = solution.GetSimilarity(documents);

            PrintResult(result);
        }

        [TestMethod()]
        public void GetSimilarityTestWithDuplicateWords2()
        {
            string[] doc1Content = { "14", "15", "15", "100", "9", "3", "3" };
            string[] doc2Content = { "32", "1", "9", "9", "3", "5" };
            string[] doc3Content = { "15", "15", "29", "2", "6", "8", "7", "7" };
            string[] doc4Content = { "7", "7", "10" };

            List<Document> documents = new List<Document>();
            documents.Add(GetDocument(13, doc1Content));
            documents.Add(GetDocument(24, doc4Content));
            documents.Add(GetDocument(16, doc2Content));
            documents.Add(GetDocument(19, doc3Content));

            Solution solution = new Solution();
            var result = solution.GetSimilarity(documents);

            PrintResult(result);
        }
        private void PrintResult(Dictionary<int, Dictionary<int, double>> result)
        {
            foreach (var document in result)
            {
                foreach (var pair in document.Value)
                {
                    Trace.WriteLine(string.Format("{0}, {1}: {2}", document.Key, pair.Key, pair.Value));
                }
            }
        }

        private Document GetDocument(int docId, string[] docContent)
        {
            Document document = new Document(docId);
            for (int i = 0; i < docContent.Length; i++)
            {
                document.Content.Add(docContent[i]);
            }

            return document;
        }
    }
}