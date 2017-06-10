using System.Collections.Generic;
using System.Text;

namespace Question_08_13_StackOfBoxes
{
    public class StackOfBoxes
    {
        List<Box> boxes = new List<Box>();

        public StackOfBoxes()
        {
            Height = 0;
        }

        public double Height
        {
            get;
            private set;
        }

        public void AddBottom(Box box)
        {
            boxes.Insert(0, box);
            Height += box.Height;
        }

        public static bool operator >(StackOfBoxes left, StackOfBoxes right)
        {
            return left.Height.CompareTo(right.Height) > 0;
        }

        public static bool operator <(StackOfBoxes left, StackOfBoxes right)
        {
            return right > left;
        }

        private void AddTop(Box box)
        {
            boxes.Add(box);
            Height += box.Height;
        }

        internal void Merge(StackOfBoxes other)
        {
            foreach (var box in other.boxes)
            {
                AddTop(box);
            }
        }
        
        public StackOfBoxes Clone()
        {
            StackOfBoxes clone = new StackOfBoxes();
            foreach (Box box in boxes)
            {
                clone.AddTop(box);
            }

            return clone;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Height: {0}", Height));
            foreach (var box in boxes)
            {
                builder.AppendLine(box.ToString());
            }

            return builder.ToString();
        }
    }
}
