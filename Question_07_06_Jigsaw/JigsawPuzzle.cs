using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_06_Jigsaw
{
    public class JigsawPuzzle
    {
        public enum EdgeType
        {
            Inner = 1,
            Outer,
            Flat
        }

        public enum EdgeRestriction
        {
            None = 0,
            Inner,
            Outer,
            Flat
        }

        public class Edge
        {
            public Edge(EdgeType type)
            {
                Type = type;
            }

            public EdgeType Type
            {
                get;
                set;
            }
        }

        public class Piece
        {
            // Always ordered in Left, Top, Bottom, Right 
            protected List<Edge> orderedEdges;

            public Piece()
            {               
                orderedEdges = new List<Edge>();
            }

            public Piece(int data, List<Edge> edges)
            {
                if (edges.Count != 4) throw new ArgumentException();
                orderedEdges = edges;
                this.LeftEdge = orderedEdges[0];
                this.TopEdge = orderedEdges[1];
                this.RightEdge = orderedEdges[2];
                this.BottomEdge = orderedEdges[3];

                Data = data;

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

        public class VirtualPiece : Piece
        {
            public VirtualPiece()
            {
                this.orderedEdges.Add(new Edge(EdgeType.Flat)); // left
                this.orderedEdges.Add(new Edge(EdgeType.Flat)); // top
                this.orderedEdges.Add(new Edge(EdgeType.Flat)); //right
                this.orderedEdges.Add(new Edge(EdgeType.Flat)); // bottom

                this.LeftEdge = orderedEdges[0];
                this.TopEdge = orderedEdges[1];
                this.RightEdge = orderedEdges[2];
                this.BottomEdge = orderedEdges[3];
            }
        }
        
        private int numberOfRows, numberOfColumns;

        public JigsawPuzzle(int numberOfRows, int numberOfColumns, List<Piece> pieces)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
            this.Pieces = pieces;
        }

        public List<Tuple<Edge, Edge>> FittedEdges
        {
            get;
            private set;
        }

        public List<Piece> Pieces
        {
            get;
            set;
        }

        public Piece[,] Solve()
        {
            var solution = new Piece[numberOfRows, numberOfColumns];

            // Bottom row
            for (int i = 0; i < numberOfColumns; i++)
            {
                // Surounding pieces in the order of Left, Top, Bottom, Right
                // VirtualPiece if not exists, null if not known yet
                List<Piece> surroundingPieces = GetSurroundingPieces(solution, 0, i); 
                List<EdgeRestriction> edgeRestriction = GetEdgeRestrictions(surroundingPieces);
                
                Piece piece = GetPiece(edgeRestriction, surroundingPieces);
                if (piece == null) throw new Exception("Could not find a solution");
          
                solution[0, i]  = piece;
                Pieces.Remove(piece);
            }

            // Rightmost column
            for (int i = 1; i < numberOfRows; i++)
            {
                // Surounding pieces in the order of Left, Top, Bottom, Right
                // VirtualPiece if not exists, null if not known yet
                List<Piece> surroundingPieces = GetSurroundingPieces(solution, i, numberOfColumns - 1);
                List<EdgeRestriction> edgeRestriction = GetEdgeRestrictions(surroundingPieces);

                Piece piece = GetPiece(edgeRestriction, surroundingPieces);
                if (piece == null) throw new Exception("Could not find a solution");

                solution[i, numberOfColumns - 1] = piece;
                Pieces.Remove(piece);
            }

            // Top row
            for (int i = numberOfColumns - 2; i >=0; i--)
            {
                // Surounding pieces in the order of Left, Top, Bottom, Right
                // VirtualPiece if not exists, null if not known yet
                List<Piece> surroundingPieces = GetSurroundingPieces(solution, numberOfRows - 1, i);
                List<EdgeRestriction> edgeRestriction = GetEdgeRestrictions(surroundingPieces);

                Piece piece = GetPiece(edgeRestriction, surroundingPieces);
                if (piece == null) throw new Exception("Could not find a solution");

                solution[numberOfRows - 1, i] = piece;
                Pieces.Remove(piece);
            }

            // Leftmost columns
            for (int i = numberOfRows -2; i > 0; i--)
            {
                // Surounding pieces in the order of Left, Top, Bottom, Right
                // VirtualPiece if not exists, null if not known yet
                List<Piece> surroundingPieces = GetSurroundingPieces(solution, i, 0);
                List<EdgeRestriction> edgeRestriction = GetEdgeRestrictions(surroundingPieces);

                Piece piece = GetPiece(edgeRestriction, surroundingPieces);
                if (piece == null) throw new Exception("Could not find a solution");

                solution[i, 0] = piece;
                Pieces.Remove(piece);
            }

            // Inner pieces
            for (int i = 1; i < numberOfRows - 1; i++)
            {
                for (int j = 1; j < numberOfColumns - 1; j++)
                {
                    // Surounding pieces in the order of Left, Top, Bottom, Right
                    // VirtualPiece if not exists, null if not known yet
                    List<Piece> surroundingPieces = GetSurroundingPieces(solution, i, j);
                    List<EdgeRestriction> edgeRestriction = GetEdgeRestrictions(surroundingPieces);

                    Piece piece = GetPiece(edgeRestriction, surroundingPieces);
                    if (piece == null) throw new Exception("Could not find a solution");

                    solution[i, j] = piece;
                    Pieces.Remove(piece);
                }
            }

            return solution;
        }

        private List<EdgeRestriction> GetEdgeRestrictions(List<Piece> surroundingPieces)
        {
            // Should return list of size 4
            List<EdgeRestriction> edgeRestrictions = new List<EdgeRestriction>();

            // Left restriction
            AddEdgeRestriction(surroundingPieces[0],
                surroundingPieces[0] == null ? null : surroundingPieces[0].RightEdge, edgeRestrictions);

            // Top restriction
            AddEdgeRestriction(surroundingPieces[1],
                surroundingPieces[1] == null ? null : surroundingPieces[1].BottomEdge, edgeRestrictions);

            // Right restriction
            AddEdgeRestriction(surroundingPieces[2],
                surroundingPieces[2] == null ? null : surroundingPieces[2].LeftEdge, edgeRestrictions);

            // Bottom restriction
            AddEdgeRestriction(surroundingPieces[3],
                surroundingPieces[3] == null ? null : surroundingPieces[3].TopEdge, edgeRestrictions);

            return edgeRestrictions;
        }

        private void AddEdgeRestriction(Piece adjacentPiece, Edge adjacentEdge, List<EdgeRestriction> edgeRestrictions)
        {
            if (adjacentPiece == null)
            {
                edgeRestrictions.Add(EdgeRestriction.None);
                return;
            }

            switch(adjacentEdge.Type)
            {
                case EdgeType.Flat:
                    edgeRestrictions.Add(EdgeRestriction.Flat);
                    break;
                case EdgeType.Inner:
                    edgeRestrictions.Add(EdgeRestriction.Outer);
                    break;
                case EdgeType.Outer:
                    edgeRestrictions.Add(EdgeRestriction.Inner);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// TODO: Alternatively solution matrix can be surrounded with VirtualPieces, which would simplify this method
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentColumn"></param>
        /// <returns></returns>
        private List<Piece> GetSurroundingPieces(Piece[,] solution, int currentRow, int currentColumn)
        {
            // Should return list of size 4
            List<Piece> surroundingPieces = new List<Piece>();
            // To the left
            if (currentColumn == 0)
            {
                surroundingPieces.Add(new VirtualPiece());
            }
            else
            {
                surroundingPieces.Add(solution[currentRow, currentColumn - 1]);
            }

            // To the top
            if (currentRow == this.numberOfRows - 1)
            {
                surroundingPieces.Add(new VirtualPiece());
            }
            else
            {
                surroundingPieces.Add(solution[currentRow + 1, currentColumn]);
            }

            // To the right
            if (currentColumn == this.numberOfColumns - 1)
            {
                surroundingPieces.Add(new VirtualPiece());
            }
            else
            {
                surroundingPieces.Add(solution[currentRow, currentColumn + 1]); // can be null, which is ok
            }

            // To the bottom
            if (currentRow == 0)
            {
                surroundingPieces.Add(new VirtualPiece());
            }
            else
            {
                surroundingPieces.Add(solution[currentRow - 1, currentColumn]);
            }

            return surroundingPieces;
        }

        private Piece GetPiece(List<EdgeRestriction> edgeRestriction, List<Piece> surroundingPieces)
        {
            Piece foundPiece = null;
            int rotationCounter = 0;
            bool fits = false;
            while (rotationCounter < 4 && !fits)
            {
                foreach(Piece piece in Pieces)
                {
                    if (rotationCounter > 0)
                    {
                        piece.Rotate();
                    }

                    fits = edgeRestriction[0] == EdgeRestriction.None ? true : piece.LeftEdge.Type == (EdgeType)edgeRestriction[0];
                    if (!fits) continue;

                    fits = edgeRestriction[1] == EdgeRestriction.None ? true : piece.TopEdge.Type == (EdgeType)edgeRestriction[1];
                    if (!fits) continue;

                    fits = edgeRestriction[2] == EdgeRestriction.None ? true : piece.RightEdge.Type == (EdgeType)edgeRestriction[2];
                    if (!fits) continue;

                    fits = edgeRestriction[3] == EdgeRestriction.None ? true : piece.BottomEdge.Type == (EdgeType)edgeRestriction[3];
                    if (!fits) continue;

                    // Check left
                    fits = surroundingPieces[0] == null ? true : FitsWith(surroundingPieces[0].RightEdge, piece.LeftEdge);
                    if (!fits) continue;

                    // Check top
                    fits = surroundingPieces[1] == null ? true : FitsWith(surroundingPieces[1].BottomEdge, piece.TopEdge);
                    if (!fits) continue;

                    // Check right
                    fits = surroundingPieces[2] == null ? true : FitsWith(surroundingPieces[2].LeftEdge, piece.RightEdge);
                    if (!fits) continue;

                    // Check bottom
                    fits = surroundingPieces[3] == null ? true : FitsWith(surroundingPieces[3].TopEdge, piece.BottomEdge);
                    if (!fits) continue;

                    if (fits)
                    {
                        foundPiece = piece;
                        break;
                    }
                }

                rotationCounter++;
            }

            return foundPiece;
        }

        public void SetFittedEdges(List<Tuple<Edge, Edge>> edges)
        {
            FittedEdges = edges;
        }

        bool FitsWith(Edge edge1, Edge edge2)
        {
            if (edge1.Type == EdgeType.Flat && edge2.Type == EdgeType.Flat)
            {
                return true;
            }

            return FittedEdges.Contains(new Tuple<Edge, Edge>(edge1, edge2)) ||
                FittedEdges.Contains(new Tuple<Edge, Edge>(edge2, edge1));
        }
    }
}
