using System.Collections.Generic;
using System.Text;

namespace Question_17_08_CircusTower
{
    public class Tower
    {
        List<Person> people = new List<Person>();

        public Tower()
        {
            Height = 0;
        }

        public double Height
        {
            get;
            private set;
        }

        public void AddBottom(Person person)
        {
            people.Insert(0, person);
            Height += person.Height;
        }

        public static bool operator >(Tower left, Tower right)
        {
            return left.Height.CompareTo(right.Height) > 0;
        }

        public static bool operator <(Tower left, Tower right)
        {
            return right > left;
        }

        internal void Merge(Tower other)
        {
            foreach (var person in other.people)
            {
                AddTop(person);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Height: {0}", Height));
            foreach (var person in people)
            {
                builder.AppendLine(person.ToString());
            }

            return builder.ToString();
        }

        public Tower Clone()
        {
            Tower clone = new Tower();
            foreach (Person person in people)
            {
                clone.AddTop(person);
            }

            return clone;
        }

        private void AddTop(Person person)
        {
            people.Add(person);
            Height += person.Height;
        }
    }
}
