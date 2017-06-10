namespace Question_06_10_Poison
{
    public class Bottle
    {
        public Bottle(int id, bool poisoned = false)
        {
            Id = id;
            IsPoisoned = poisoned;
        }

        public int Id
        {
            get;
            private set;
        }

        public bool IsPoisoned
        {
            get;
            private set;
        }

        internal void AddDropTo(TestStrip[] testStrips)
        {
            foreach (var testStrip in testStrips)
            {
                if (((1 << testStrip.Id) & Id) != 0)
                {
                    testStrip.DropFrom(this);
                }
            }
        }
    }
}
