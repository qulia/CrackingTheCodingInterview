using System.Collections.Generic;

namespace Question_06_10_Poison
{
    public class TestStrip
    {
        private List<Bottle> bottles = new List<Bottle>();

        public TestStrip(int id)
        {
            Id = id;
            State = TestResult.Negative;
        }

        public int Id
        {
            get;
            private set;
        }

        public TestResult State
        {
            get;
            private set;
        }

        public void DropFrom(Bottle bottle)
        {
            if (bottle.IsPoisoned)
            {
                State = TestResult.Positive;
            }
        }
    }
}
