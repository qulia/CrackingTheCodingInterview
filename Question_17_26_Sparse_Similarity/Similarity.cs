namespace Question_17_26_Sparse_Similarity
{
    internal class Similarity
    {
        internal Similarity()
        {
            Union = 0;
            Intersection = 0;
        }

        internal int Union
        {
            get;
            set;
        }

        internal int Intersection
        {
            get;
            set;
        }

        internal double SparseSimilarity
        {
            get
            {
                return (double)Intersection / Union;
            }
        }
    }
}