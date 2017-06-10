using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter_03_03_StacksOfPlates.Tests
{
    [TestClass()]
    public class MultipleStacksTests
    {
        [TestMethod()]
        public void MultipleStacksCapacity1Test()
        {
            int capacity = 1;
            MultipleStacks<int> multipleStacks = new MultipleStacks<int>(capacity);

            AddSequential(multipleStacks, 10);

            multipleStacks.Print();

            Assert.AreEqual(10, multipleStacks.Pop());

            multipleStacks.Print();

            Assert.AreEqual(5, multipleStacks.PopAt(4));
        }

        [TestMethod()]
        public void MultipleStacksPopAtTest()
        {
            int capacity = 5;
            MultipleStacks<int> multipleStacks = new MultipleStacks<int>(capacity);

            AddSequential(multipleStacks, capacity * 3 + 1);
            // 0: 1 2 3 4 5
            // 1: 6 7 8 9 10
            // 2: 11 12 13 14 15
            // 3: 16
            multipleStacks.Print();

            // 10 should be popped, 11 rolls over to 1, 16 rolls over to 2
            // 0: 1 2 3 4 5
            // 1: 6 7 8 9 11
            // 2: 12 13 14 15 16
            Assert.AreEqual(10, multipleStacks.PopAt(1));
            multipleStacks.Print();

            // 16 should be popped
            // 0: 1 2 3 4 5
            // 1: 6 7 8 9 11
            // 2: 12 13 14 15 
            Assert.AreEqual(16, multipleStacks.PopAt(2));
            multipleStacks.Print();

            // 0: 1 2 3 4 8
            // 1: 9 11 12 13 14
            // 2: 15 
            multipleStacks.PopAt(0);
            multipleStacks.PopAt(0);
            multipleStacks.PopAt(0);

            // 15 should be popped
            Assert.AreEqual(15, multipleStacks.PopAt(2));
            multipleStacks.Print();
        }

        private void AddSequential(MultipleStacks<int> multipleStacks, int numberOfItems)
        {
            for (int i = 1; i <= numberOfItems; i++)
            {
                multipleStacks.Push(i);
            }
        }
    }
}