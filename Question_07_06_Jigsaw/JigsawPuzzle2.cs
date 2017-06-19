using System;
using System.Collections.Generic;
using System.Linq;

namespace Question_07_06_Jigsaw
{
    public class JigsawPuzzle2
    {
        private int numberOfRows, numberOfColumns;

        public JigsawPuzzle2(int numberOfRows, int numberOfColumns, List<Piece> pieces)
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

            // Solution with backtracking
            solution[0,0] = GetACornerPiece();
            Pieces.Remove(solution[0, 0]);
            if (SolveRecurse(solution))
            {
                return solution;
            }

            throw new InvalidOperationException("Solution does not exist");
        }

        private bool SolveRecurse(Piece[,] solution)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (solution[i, j] == null)
                    {
                        for (int index = 0; index < Pieces.Count; index++)
                        {
                            if (IsValidPlacement(solution, Pieces[index], i, j))
                            {
                                solution[i, j] = Pieces[index];
                                Pieces.Remove(Pieces[index]);

                                if (SolveRecurse(solution))
                                {
                                    return true;
                                }

                                // Backtrack
                                Pieces.Add(solution[i, j]);
                                solution[i, j] = null;                                
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValidPlacement(Piece[,] solution, Piece piece, int i, int j)
        {
            // Check left and bottom
            bool fit = false;
            var leftRow = i;
            var leftColumn = j - 1;
            if (InBounds(leftRow, leftColumn))
            {
                var leftPiece = solution[leftRow, leftColumn];
                for (int orientation = 0; orientation < 4; orientation++)
                {
                    if (FitsWith(leftPiece.RightEdge, piece.LeftEdge))
                    {
                        fit = true;
                        break;
                    }
                    piece.Rotate();
                }


                if (!fit) return false;
            }

            var bottomRow = i - 1;
            var bottomColumn = j;
            if (InBounds(bottomRow, bottomColumn))
            {
                var bottomPiece = solution[bottomRow, bottomColumn];
                if (!FitsWith(bottomPiece.TopEdge, piece.BottomEdge))
                    {
                    // This should not happen according to assumptions on the input
                    throw new InvalidOperationException("Invalid input");
                }

                fit = true;
            }

            return fit;
        }

        private bool InBounds(int row, int col)
        {
            return row >= 0 && row < numberOfRows && col >= 0 && col < numberOfColumns;
        }

        private Piece GetACornerPiece()
        {
            var cornerPiece = Pieces.Find((piece) => piece.IsCorner);
            while (cornerPiece.LeftEdge.Type != EdgeType.Flat || cornerPiece.BottomEdge.Type != EdgeType.Flat)
            {
                cornerPiece.Rotate();
            }

            return cornerPiece;
        }

        public void SetFittedEdges(List<Tuple<Edge, Edge>> edges)
        {
            FittedEdges = edges;
        }

        bool FitsWith(Edge edge1, Edge edge2)
        {
            if (edge1.Type == edge2.Type)
            {
                return false;
            }

            return FittedEdges.Contains(new Tuple<Edge, Edge>(edge1, edge2)) ||
                FittedEdges.Contains(new Tuple<Edge, Edge>(edge2, edge1));
        }
    }
}
