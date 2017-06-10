namespace Question_16_15_MasterMind
{
    public class Result
    {
        public Result()
        {
            Hits = 0;
            Pseudohits = 0;
        }

        public int Hits
        {
            get;
            private set;
        }

        public int Pseudohits
        {
            get;
            private set;
        }

        public void AddHit()
        {
            Hits++;
        }

        public void AddPseudohit()
        {
            Pseudohits++;
        }

        public override string ToString()
        {
            return string.Format("Hits: {0}, Pseudohits: {1}", Hits, Pseudohits);
        }
    }
}
