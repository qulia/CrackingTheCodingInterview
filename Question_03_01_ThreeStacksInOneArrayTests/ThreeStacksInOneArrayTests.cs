using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Question_03_01_ThreeStacksInOneArray.Tests
{
    [TestClass()]
    public class ThreeStacksInOneArrayTests
    {
        [TestMethod()]
        public void ThreeStacksInOneArrayTest()
        {
            ThreeStacksInOneArray<int> threeStacks = new ThreeStacksInOneArray<int>(10);
            threeStacks.Push(1, 1);
            threeStacks.Push(2, 2);
            threeStacks.Push(3, 3);
            threeStacks.Push(1, 4);
            threeStacks.Push(2, 5);
            threeStacks.Push(3, 6);

            var actualValue = threeStacks.Pop(3);
            Assert.AreEqual(6, actualValue);
            actualValue = threeStacks.Pop(2);
            Assert.AreEqual(5, actualValue);
            actualValue = threeStacks.Pop(1);
            Assert.AreEqual(4, actualValue);

            actualValue = threeStacks.Pop(3);
            Assert.AreEqual(3, actualValue);
            actualValue = threeStacks.Pop(2);
            Assert.AreEqual(2, actualValue);
            actualValue = threeStacks.Pop(1);
            Assert.AreEqual(1, actualValue);

            threeStacks.Push(1, 1);
            threeStacks.Push(2, 2);
            threeStacks.Push(3, 3);
            threeStacks.Push(1, 4);
            threeStacks.Push(2, 5);
            threeStacks.Push(3, 6);

            actualValue = threeStacks.Pop(3);
            Assert.AreEqual(6, actualValue);
            actualValue = threeStacks.Pop(2);
            Assert.AreEqual(5, actualValue);
            actualValue = threeStacks.Pop(1);
            Assert.AreEqual(4, actualValue);

            actualValue = threeStacks.Pop(3);
            Assert.AreEqual(3, actualValue);
            actualValue = threeStacks.Pop(2);
            Assert.AreEqual(2, actualValue);
            actualValue = threeStacks.Pop(1);
            Assert.AreEqual(1, actualValue);
        }


        [TestMethod()]
        [ExpectedException(typeof(ThreeStacksInOneArray<int>.StackEmptyException))]
        public void ThreeStacksInOneArrayExceptionTest()
        {
            ThreeStacksInOneArray<int> threeStacks = new ThreeStacksInOneArray<int>(10);
            threeStacks.Push(1, 1);
            threeStacks.Push(2, 2);
            threeStacks.Push(3, 3);
            threeStacks.Push(1, 4);
            threeStacks.Push(2, 5);
            threeStacks.Push(3, 6);

            threeStacks.Pop(1);
            threeStacks.Pop(1);
            threeStacks.Pop(1);
        }
    }
}