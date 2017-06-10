using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_08_13_StackOfBoxes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_08_13_StackOfBoxes.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void BuildMaxHeightStackTest()
        {
            var boxes = new List<Box>();

            boxes.Add(new Box(9.4, 4.18, 2.67));
            boxes.Add(new Box(6.14, 1.55, 7.17));
            boxes.Add(new Box(5.41, 6.29, 5.43));
            boxes.Add(new Box(5.23, 4.66, 3.41));
            boxes.Add(new Box(2.39, 2.19, 0.82));

            Solution solution = new Solution();
            var tallestStack = solution.BuildMaxHeightStack(boxes);
            Trace.WriteLine(tallestStack);
        }

        [TestMethod()]
        public void BuildMaxHeightStackTest2()
        {
            var boxes = CreateListOfBoxes(5);
            Solution solution = new Solution();
            var tallestStack = solution.BuildMaxHeightStack(boxes);
            Trace.WriteLine(tallestStack);
        }

        [TestMethod()]
        public void BuildMaxHeightStackLargeTest2()
        {
            var boxes = CreateListOfBoxes(1000);
            Solution solution = new Solution();
            var tallestStack = solution.BuildMaxHeightStack(boxes);
            Trace.WriteLine(tallestStack);
        }

        private List<Box> CreateListOfBoxes(int count)
        {
            Random random = new Random();
            List<Box> boxes = new List<Box>();
            for (int i = 0; i < count; i++)
            {
                double height = Math.Round(random.NextDouble() * 10, 2);
                double width = Math.Round(random.NextDouble() * 10, 2);
                double depth = Math.Round(random.NextDouble() * 10, 2);

                Box box = new Box(height, width, depth);
                boxes.Add(box);
            }

            return boxes;
        }
    }
}