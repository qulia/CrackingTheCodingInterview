using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Question_06_10_Poison.Tests
{
    [TestClass()]
    public class PoisonTestTests
    {
        [TestMethod()]
        public void PoisonTest()
        {
            List<Bottle> bottles = new List<Bottle>();
            int numberOfBottles = 1000;
            int poisonedBottleId = 187;
            int testStripCount = 10;
            AddBottles(bottles, numberOfBottles, poisonedBottleId);

            var test = new PoisonTest(bottles, testStripCount);
            var result = test.Run();
            Assert.AreEqual(poisonedBottleId, result);
        }

        private static void AddBottles(List<Bottle> bottles, int numberOfBottles, int poisonedBottleId)
        {
            for (int i = 0; i < numberOfBottles; i++)
            {
                if (i == poisonedBottleId)
                {
                    bottles.Add(new Bottle(i, true));
                }
                else
                {
                    bottles.Add(new Bottle(i));
                }
            }
        }
    }
}