using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_06_Jigsaw
{
    public class Piece
    {
        // Always ordered in Left, Top, Bottom, Right 
        protected List<Edge> orderedEdges;
        int numberOfFlatEdges = 0;

        public Piece()
        {
            orderedEdges = new List<Edge>();
        }

        public Piece(int data, List<Edge> edges)
        {
            if (edges.Count != 4) throw new ArgumentException();
            orderedEdges = edges;
            LeftEdge = CheckEdge(orderedEdges[0]);
            TopEdge = CheckEdge(orderedEdges[1]);
            RightEdge = CheckEdge(orderedEdges[2]);
            BottomEdge = CheckEdge(orderedEdges[3]);

            Data = data;

        }

        private Edge CheckEdge(Edge value)
        {
            if (value.Type == EdgeType.Flat)
            {
                numberOfFlatEdges++;
            }

            return value;
        }

        public int Data
        {
            get;
            protected set;
        }

        public Edge LeftEdge
        {
            get;
            protected set;
        }

        public Edge TopEdge
        {
            get;
            protected set;
        }

        public Edge RightEdge
        {
            get;
            protected set;
        }

        public Edge BottomEdge
        {
            get;
            protected set;
        }
        public bool IsCorner
        {
            get
            {
                return numberOfFlatEdges == 2;
            }
        }

        public bool Rotate()
        {
            var temp = BottomEdge;
            BottomEdge = RightEdge;
            RightEdge = TopEdge;
            TopEdge = LeftEdge;
            LeftEdge = temp;

            return true;
        }
    }
}
