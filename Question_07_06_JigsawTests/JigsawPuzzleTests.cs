using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_07_06_Jigsaw.Tests
{
    [TestClass()]
    public class JigsawPuzzleTests
    {
        [TestMethod()]
        public void JigsawPuzzleTest()
        {
            List<Piece> pieces;
            List<Tuple<Edge, Edge>> fittedEdges;
            Setup(out pieces, out fittedEdges);

            JigsawPuzzle puzzle = new JigsawPuzzle(4, 4, pieces);
            puzzle.SetFittedEdges(fittedEdges);

            var solution = puzzle.Solve();
            Print(solution);
        }

        [TestMethod()]
        public void JigsawPuzzleTest2()
        {
            List<Piece> pieces;
            List<Tuple<Edge, Edge>> fittedEdges;
            Setup(out pieces, out fittedEdges);

            JigsawPuzzle2 puzzle2 = new JigsawPuzzle2(4, 4, pieces);
            puzzle2.SetFittedEdges(fittedEdges);

            var solution2 = puzzle2.Solve();
            Print(solution2);
        }

        private static void Setup(out List<Piece> pieces, out List<Tuple<Edge, Edge>> fittedEdges)
        {
            pieces = new List<Piece>();
            fittedEdges = new List<Tuple<Edge, Edge>>();
            Edge edge12Left = new Edge(EdgeType.Flat);
            Edge edge12Top = new Edge(EdgeType.Outer);
            Edge edge12Right = new Edge(EdgeType.Inner);
            Edge edge12Bottom = new Edge(EdgeType.Flat);

            List<Edge> edges12 = new List<Edge>();
            edges12.Add(edge12Left);
            edges12.Add(edge12Top);
            edges12.Add(edge12Right);
            edges12.Add(edge12Bottom);

            Piece piece12 = new Piece(12, edges12);
            pieces.Add(piece12);

            Edge edge11Left = new Edge(EdgeType.Outer);
            Edge edge11Top = new Edge(EdgeType.Inner);
            Edge edge11Right = new Edge(EdgeType.Outer);
            Edge edge11Bottom = new Edge(EdgeType.Flat);

            List<Edge> edges11 = new List<Edge>();
            edges11.Add(edge11Left);
            edges11.Add(edge11Top);
            edges11.Add(edge11Right);
            edges11.Add(edge11Bottom);

            Piece piece11 = new Piece(11, edges11);
            pieces.Add(piece11);

            Edge edge13Left = new Edge(EdgeType.Inner);
            Edge edge13Top = new Edge(EdgeType.Outer);
            Edge edge13Right = new Edge(EdgeType.Inner);
            Edge edge13Bottom = new Edge(EdgeType.Flat);

            List<Edge> edges13 = new List<Edge>();
            edges13.Add(edge13Left);
            edges13.Add(edge13Top);
            edges13.Add(edge13Right);
            edges13.Add(edge13Bottom);

            Piece piece13 = new Piece(13, edges13);
            piece13.Rotate(); // Add this piece after rotating
            pieces.Add(piece13);

            Edge edge14Left = new Edge(EdgeType.Outer);
            Edge edge14Top = new Edge(EdgeType.Outer);
            Edge edge14Right = new Edge(EdgeType.Flat);
            Edge edge14Bottom = new Edge(EdgeType.Flat);

            List<Edge> edges14 = new List<Edge>();
            edges14.Add(edge14Left);
            edges14.Add(edge14Top);
            edges14.Add(edge14Right);
            edges14.Add(edge14Bottom);

            Piece piece14 = new Piece(14, edges14);
            piece14.Rotate(); // Add this piece after rotating
            pieces.Add(piece14);

            fittedEdges.Add(new Tuple<Edge, Edge>(edge12Right, edge11Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge11Right, edge13Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge13Right, edge14Left));


            Edge edge0Left = new Edge(EdgeType.Flat);
            Edge edge0Top = new Edge(EdgeType.Outer);
            Edge edge0Right = new Edge(EdgeType.Inner);
            Edge edge0Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges0 = new List<Edge>();
            edges0.Add(edge0Left);
            edges0.Add(edge0Top);
            edges0.Add(edge0Right);
            edges0.Add(edge0Bottom);

            Piece piece0 = new Piece(0, edges0);
            pieces.Add(piece0);

            Edge edge1Left = new Edge(EdgeType.Outer);
            Edge edge1Top = new Edge(EdgeType.Outer);
            Edge edge1Right = new Edge(EdgeType.Outer);
            Edge edge1Bottom = new Edge(EdgeType.Outer);

            List<Edge> edges1 = new List<Edge>();
            edges1.Add(edge1Left);
            edges1.Add(edge1Top);
            edges1.Add(edge1Right);
            edges1.Add(edge1Bottom);

            Piece piece1 = new Piece(1, edges1);
            pieces.Add(piece1);

            Edge edge10Left = new Edge(EdgeType.Inner);
            Edge edge10Top = new Edge(EdgeType.Inner);
            Edge edge10Right = new Edge(EdgeType.Inner);
            Edge edge10Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges10 = new List<Edge>();
            edges10.Add(edge10Left);
            edges10.Add(edge10Top);
            edges10.Add(edge10Right);
            edges10.Add(edge10Bottom);

            Piece piece10 = new Piece(10, edges10);
            pieces.Add(piece10);

            Edge edge15Left = new Edge(EdgeType.Outer);
            Edge edge15Top = new Edge(EdgeType.Outer);
            Edge edge15Right = new Edge(EdgeType.Flat);
            Edge edge15Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges15 = new List<Edge>();
            edges15.Add(edge15Left);
            edges15.Add(edge15Top);
            edges15.Add(edge15Right);
            edges15.Add(edge15Bottom);

            Piece piece15 = new Piece(15, edges15);
            pieces.Add(piece15);

            fittedEdges.Add(new Tuple<Edge, Edge>(edge0Bottom, edge12Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge1Bottom, edge11Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge10Bottom, edge13Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge15Bottom, edge14Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge0Right, edge1Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge1Right, edge10Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge10Right, edge15Left));

            Edge edge6Left = new Edge(EdgeType.Flat);
            Edge edge6Top = new Edge(EdgeType.Outer);
            Edge edge6Right = new Edge(EdgeType.Inner);
            Edge edge6Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges6 = new List<Edge>();
            edges6.Add(edge6Left);
            edges6.Add(edge6Top);
            edges6.Add(edge6Right);
            edges6.Add(edge6Bottom);

            Piece piece6 = new Piece(6, edges6);
            pieces.Add(piece6);

            Edge edge5Left = new Edge(EdgeType.Outer);
            Edge edge5Top = new Edge(EdgeType.Inner);
            Edge edge5Right = new Edge(EdgeType.Outer);
            Edge edge5Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges5 = new List<Edge>();
            edges5.Add(edge5Left);
            edges5.Add(edge5Top);
            edges5.Add(edge5Right);
            edges5.Add(edge5Bottom);

            Piece piece5 = new Piece(5, edges5);
            pieces.Add(piece5);

            Edge edge2Left = new Edge(EdgeType.Inner);
            Edge edge2Top = new Edge(EdgeType.Inner);
            Edge edge2Right = new Edge(EdgeType.Inner);
            Edge edge2Bottom = new Edge(EdgeType.Outer);

            List<Edge> edges2 = new List<Edge>();
            edges2.Add(edge2Left);
            edges2.Add(edge2Top);
            edges2.Add(edge2Right);
            edges2.Add(edge2Bottom);

            Piece piece2 = new Piece(2, edges2);
            pieces.Add(piece2);

            Edge edge9Left = new Edge(EdgeType.Outer);
            Edge edge9Top = new Edge(EdgeType.Outer);
            Edge edge9Right = new Edge(EdgeType.Flat);
            Edge edge9Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges9 = new List<Edge>();
            edges9.Add(edge9Left);
            edges9.Add(edge9Top);
            edges9.Add(edge9Right);
            edges9.Add(edge9Bottom);

            Piece piece9 = new Piece(9, edges9);
            pieces.Add(piece9);

            fittedEdges.Add(new Tuple<Edge, Edge>(edge6Bottom, edge0Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge5Bottom, edge1Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge2Bottom, edge10Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge9Bottom, edge15Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge6Right, edge5Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge5Right, edge2Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge2Right, edge9Left));

            Edge edge4Left = new Edge(EdgeType.Flat);
            Edge edge4Top = new Edge(EdgeType.Flat);
            Edge edge4Right = new Edge(EdgeType.Inner);
            Edge edge4Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges4 = new List<Edge>();
            edges4.Add(edge4Left);
            edges4.Add(edge4Top);
            edges4.Add(edge4Right);
            edges4.Add(edge4Bottom);

            Piece piece4 = new Piece(4, edges4);
            pieces.Add(piece4);

            Edge edge3Left = new Edge(EdgeType.Outer);
            Edge edge3Top = new Edge(EdgeType.Flat);
            Edge edge3Right = new Edge(EdgeType.Outer);
            Edge edge3Bottom = new Edge(EdgeType.Outer);

            List<Edge> edges3 = new List<Edge>();
            edges3.Add(edge3Left);
            edges3.Add(edge3Top);
            edges3.Add(edge3Right);
            edges3.Add(edge3Bottom);

            Piece piece3 = new Piece(3, edges3);
            pieces.Add(piece3);

            Edge edge7Left = new Edge(EdgeType.Inner);
            Edge edge7Top = new Edge(EdgeType.Flat);
            Edge edge7Right = new Edge(EdgeType.Inner);
            Edge edge7Bottom = new Edge(EdgeType.Outer);

            List<Edge> edges7 = new List<Edge>();
            edges7.Add(edge7Left);
            edges7.Add(edge7Top);
            edges7.Add(edge7Right);
            edges7.Add(edge7Bottom);

            Piece piece7 = new Piece(7, edges7);
            pieces.Add(piece7);

            Edge edge8Left = new Edge(EdgeType.Outer);
            Edge edge8Top = new Edge(EdgeType.Flat);
            Edge edge8Right = new Edge(EdgeType.Flat);
            Edge edge8Bottom = new Edge(EdgeType.Inner);

            List<Edge> edges8 = new List<Edge>();
            edges8.Add(edge8Left);
            edges8.Add(edge8Top);
            edges8.Add(edge8Right);
            edges8.Add(edge8Bottom);

            Piece piece8 = new Piece(8, edges8);
            pieces.Add(piece8);

            fittedEdges.Add(new Tuple<Edge, Edge>(edge4Bottom, edge6Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge3Bottom, edge5Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge7Bottom, edge2Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge8Bottom, edge9Top));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge4Right, edge3Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge3Right, edge7Left));
            fittedEdges.Add(new Tuple<Edge, Edge>(edge7Right, edge8Left));
        }

        private static void Print(Piece[,] solution)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Trace.Write(solution[i, j].Data.ToString());
                    Trace.Write(" ");
                }

                Trace.WriteLine("");
            }
        }
    }
}