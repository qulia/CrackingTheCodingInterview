using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pamukcu.Interviews.CTCI.Question_01_01_IsUnique;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Pamukcu.Interviews.CTCI.Question_01_01_IsUnique.Tests
{
    [TestClass()]
    public class BruteForceSolutionTests
    {
        [TestMethod()]
        public void IsUnique_SmallInput_Unique_Test()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();

            var inputString = "ghjyer";
            bool expectedAllCharactersUnique = true;
            bool actualAllCharactersUnique = bruteForceSolution.IsUnique(inputString);

            Assert.AreEqual(expectedAllCharactersUnique, actualAllCharactersUnique);
        }

        [TestMethod()]
        public void IsUnique_SmallInput_NotUnique_Test_1()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();

            var inputString = "ghjyerg";
            bool expectedAllCharactersUnique = false;
            bool actualAllCharactersUnique = bruteForceSolution.IsUnique(inputString);

            Assert.AreEqual(expectedAllCharactersUnique, actualAllCharactersUnique);
        }

        [TestMethod()]
        public void IsUnique_SmallInput_NotUnique_Test_2()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();

            var inputString = "ghjgyer";
            bool expectedAllCharactersUnique = false;
            bool actualAllCharactersUnique = bruteForceSolution.IsUnique(inputString);

            Assert.AreEqual(expectedAllCharactersUnique, actualAllCharactersUnique);
        }

        [TestMethod()]
        public void IsUnique_SmallInput_NotUnique_Test_3()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();

            var inputString = "gghjyer";
            bool expectedAllCharactersUnique = false;
            bool actualAllCharactersUnique = bruteForceSolution.IsUnique(inputString);

            Assert.AreEqual(expectedAllCharactersUnique, actualAllCharactersUnique);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void IsUnique_EmptyString_Test()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();
            var inputString = string.Empty;
            bool actual = bruteForceSolution.IsUnique(inputString);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsUnique_LargeInput_Test()
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();

            var inputString = StringUtilities.CreateLargeString();
            bool actual = bruteForceSolution.IsUnique(inputString);

            Trace.WriteLine(inputString);
            Trace.WriteLine(actual);
        }
    }
}