using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Question_17_26_Sparse_Similarity
{
    public class Solution
    {
        /// <summary>
        /// Note this implementation supports duplicates in the document
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public Dictionary<int, Dictionary<int, double>> GetSimilarity(List<Document> documents)
        {
            // sort by ID
            SortedList<int, Document> sortedDocuments = GetSortedByIdDocuments(documents);

            Dictionary<int, Dictionary<int, Similarity>> similarityMap = CreateIndicesSimilarityMap(sortedDocuments);

            // docIds would be sorted in the HasSet as the documents are sorted by Id
            Dictionary<string, HashSet<int>> wordsMap = GetWordsMap(sortedDocuments, similarityMap);

            Dictionary<int, Dictionary<int, double>> result = GetIdsSimilarityMap(similarityMap, sortedDocuments);

            return result;
        }

        private Dictionary<int, Dictionary<int, double>> GetIdsSimilarityMap(
            Dictionary<int, Dictionary<int, Similarity>> similarityMap, SortedList<int, Document> documents)
        {
            Dictionary<int, Dictionary<int, double>> similarityValues = 
                new Dictionary<int, Dictionary<int, double>>();
            foreach (var indexEntry in similarityMap)
            {
                bool foundPair = false;
                Dictionary<int, double> pairsWithIds = new Dictionary<int, double>();
                foreach (var pairEntry in indexEntry.Value)
                {
                    Trace.WriteLine(string.Format(
                        "Id1: {0} Id2:{1} Intersection:{2} Union:{3} Similarity:{4}",
                        documents.ElementAt(indexEntry.Key).Value.Id,
                        documents.ElementAt(pairEntry.Key).Value.Id,
                        pairEntry.Value.Intersection,
                        pairEntry.Value.Union,
                        pairEntry.Value.SparseSimilarity));

                    if (pairEntry.Value.SparseSimilarity > 0)
                    {
                        pairsWithIds.Add(documents.ElementAt(pairEntry.Key).Value.Id, 
                            pairEntry.Value.SparseSimilarity);

                        foundPair = true;
                    }
                }

                if (foundPair)
                {
                    similarityValues.Add(documents.ElementAt(indexEntry.Key).Value.Id, pairsWithIds);
                }
            }

            return similarityValues;
        }

        private void SetIntersections(Dictionary<string, HashSet<int>> wordsMap, 
            Dictionary<int, Dictionary<int, Similarity>> similarityMap)
        {
            foreach (var word1 in wordsMap.Keys)
            {
                List<Tuple<int, int>> docPairs = GetDocumentPairs(wordsMap[word1]);
                foreach (var docPair in docPairs)
                {
                    similarityMap[docPair.Item1][docPair.Item2].Intersection++;
                }
            }
        }

        private List<Tuple<int, int>> GetDocumentPairs(HashSet<int> hashSet)
        {
            var count = hashSet.Count();
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
            for (int index1 = 0; index1 < count; index1++)
            {
                for (int index2 = 0; index2 < count; index2++)
                {
                    pairs.Add(new Tuple<int, int>(hashSet.ElementAt(index1), hashSet.ElementAt(index2)));
                }
            }

            return pairs;
        }

        private SortedList<int, Document> GetSortedByIdDocuments(List<Document> documents)
        {
            SortedList<int, Document> sortedDocuments = new SortedList<int, Document>();
            foreach (var document in documents)
            {
                if (document.Content.Count > 0)
                {
                    sortedDocuments.Add(document.Id, document);
                }
            }

            return sortedDocuments;
        }

        private Dictionary<string, HashSet<int>> GetWordsMap(
            SortedList<int, Document> documents, Dictionary<int, Dictionary<int, Similarity>> similarityMap)
        {
            Dictionary<string, HashSet<int>> wordsMap = new Dictionary<string, HashSet<int>>();

            int index = 0;
            foreach (var document in documents)
            {
                document.Value.Index = index++;
                foreach (var word in document.Value.Content)
                {
                    if (!wordsMap.ContainsKey(word))
                    {
                        // New word 
                        wordsMap.Add(word, new HashSet<int>());
                        UpdateSimilarityMap(similarityMap, document.Value.Index);
                    }
                    else
                    {
                        // Seen this word before
                        var documentsWithCurrentWord = wordsMap[word];
                        if (documentsWithCurrentWord.Contains(document.Value.Index))
                        {
                            // Seen this word before in the current document, duplicate, ignore
                            continue;
                        }

                        UpdateSimilarityMap(similarityMap, document.Value.Index, documentsWithCurrentWord);
                    }

                    wordsMap[word].Add(document.Value.Index);
                }
            }

            return wordsMap;
        }

        private void UpdateSimilarityMap(Dictionary<int, Dictionary<int, Similarity>> similarityMap,
            int documentIndex)
        {
            // This is the case where we found a word that was not seen in other docs yet

            // Indices in similarity map looks like
            // 0: 1, 2, 3
            // 1: 2, 3
            // 2: 3

            // Upto documentIndex update inner entry Union value
            // At documentIndex update all inner entries Union value except for last index

            for (int i = 0; i < documentIndex; i++)
            {
                similarityMap[i][documentIndex].Union++;
            }

            if (documentIndex == similarityMap.Count)
            {
                // Last index, 3 in the example
                return;
            }

            foreach (var entry in similarityMap[documentIndex])
            {
                entry.Value.Union++;
            }
        }

        private void UpdateSimilarityMap(Dictionary<int, Dictionary<int, Similarity>> similarityMap,
            int documentIndex, 
            HashSet<int> pairs)
        {
            // This is the case where we found a word that seen in other docs as well

            // Indices in similarity map looks like
            // 0: 1, 2, 3
            // 1: 2, 3
            // 2: 3

            // Update Unions
            UpdateSimilarityMap(similarityMap, documentIndex);

            // Update intersections
            // If documentIndex > pairIndex find the entry at similarityMap[pairIndex][documentIndex]
            // Else find the entry at similarityMap[documentIndex][pairIndex]

            // TODO check since we iterate on increasing index documentIndex > pairIndex
            foreach (var pairIndex in pairs)
            {
                // Common word increment intersection
                // Decrement union
                similarityMap[pairIndex][documentIndex].Intersection++;
                similarityMap[pairIndex][documentIndex].Union--;
            }                    
        }
        
        private Dictionary<int, Dictionary<int, Similarity>> CreateIndicesSimilarityMap(
            SortedList<int, Document> documents)
        {
            Dictionary<int, Dictionary<int, Similarity>> similarity = new Dictionary<int, Dictionary<int, Similarity>>();
            var numberOfDocuments = documents.Count();
            for (int index1 = 0; index1 < numberOfDocuments - 1; index1++)
            {
                similarity.Add(index1, new Dictionary<int, Similarity>());
                for (int index2 = index1 + 1; index2 < numberOfDocuments; index2++)
                {
                    similarity[index1].Add(index2, new Similarity());
                }
            }

            return similarity;
        }
    }
}
