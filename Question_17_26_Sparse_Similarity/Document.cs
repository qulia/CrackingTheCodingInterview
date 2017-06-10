using System.Collections.Generic;

namespace Question_17_26_Sparse_Similarity
{
    public class Document
    {
        public Document(int id)
        {
            Id = id;
            Content = new List<string>();
        }

        public int Id
        {
            get;
            set;
        }

        public List<string> Content
        {
            get;
            set;
        }

        internal int Index
        {
            get;
            set;
        }
    }
}