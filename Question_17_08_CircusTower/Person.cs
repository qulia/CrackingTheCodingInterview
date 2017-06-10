using System;

namespace Question_17_08_CircusTower
{
    public class Person : IComparable<Person>
    {
        public Person(double height, double weight)
        {
            Height = height;
            Weight = weight;
        }

        public double Height
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }

        public int CompareTo(Person other)
        {
            return other.Height.CompareTo(Height);
        }

        public static bool operator >(Person left, Person right)
        {
            return left.Height.CompareTo(right.Height) > 0 && 
                left.Weight.CompareTo(right.Weight) > 0;
        }

        public static bool operator <(Person left, Person right)
        {
            return right > left;
        }

        public bool IsSmalerFrom(Person other)
        {
            return other.Height > Height && other.Weight > Weight;
        }

        public override string ToString()
        {
            return string.Format("W: {0} H: {1}", Weight, Height);
        }
    }
}
