using System;

namespace Question_08_13_StackOfBoxes
{
    public class Box : IComparable<Box> 
    {

        public Box(double height, double width, double depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }

        public double Height
        {
            get;
            private set;
        }

        public double Width
        {
            get;
            private set;
        }

        public double Depth
        {
            get;
            private set;
        }

        public int CompareTo(Box other)
        {
            // To sort based on height descending
            return other.Height.CompareTo(Height);
        }


        public static bool operator >(Box left, Box right)
        {
            return left.Height.CompareTo(right.Height) > 0 &&
                left.Width.CompareTo(right.Width) > 0 &&
                left.Depth.CompareTo(right.Depth) > 0;
        }

        public static bool operator <(Box left, Box right)
        {
            return right > left;
        }

        public override string ToString()
        {
            return string.Format("H: {0} W: {1} D: {2}", Height, Width, Depth);
        }
    }
}