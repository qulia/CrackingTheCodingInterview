using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Question_13_07_LambdaExpressions.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void GetPopulationTest()
        {
            Solution solution = new Solution();
            var result = solution.GetPopulation(GetCountries(), "continent2");
            Assert.AreEqual(152, result);
        }

        [TestMethod()]
        public void GetPopulationApproach2Test()
        {
            Solution solution = new Solution();
            var result = solution.GetPopulationApproach2(GetCountries(), "continent2");
            Assert.AreEqual(152, result);
        }

        private List<Country> GetCountries()
        {
            List<Country> list = new List<Country>();
            list.Add(new Country(10, "continent1"));
            list.Add(new Country(11, "continent2"));
            list.Add(new Country(121, "continent3"));
            list.Add(new Country(311, "continent1"));
            list.Add(new Country(141, "continent2"));
            list.Add(new Country(111, "continent3"));

            return list;
        }
    }
}