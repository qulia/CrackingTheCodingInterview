using System;
using System.Collections.Generic;
using System.Linq;

namespace Question_06_10_Poison
{
    public class PoisonTest
    {
        TestStrip[] testStrips;
        List<Bottle> bottles;
        public PoisonTest(List<Bottle> bottles, int testStripCount)
        {
            if (1 << testStripCount < bottles.Count)
            {
                throw new InvalidOperationException("Not enough test strips");
            }

            this.bottles = bottles;
            testStrips = new TestStrip[testStripCount];
            for (int i = 0; i < testStripCount; i++)
            {
                testStrips[i] = new TestStrip(i);
            }
        }

        public int Run()
        { 
            // Drop from each bottle to test strip with id=N if the N'th bit of the bottle Id is 1 
            // e.g. add drop to test strip #0 and #1 from bottle 3

            foreach (var bottle in bottles)
            {
                bottle.AddDropTo(testStrips);
            }

            var poisonedBottleId = testStrips
                .Where((ts) => ts.State == TestResult.Positive)
                .Aggregate(0, (value, ts) =>
                {
                    return value + (1 << ts.Id);
                });

            return poisonedBottleId;
        }
    }
}
