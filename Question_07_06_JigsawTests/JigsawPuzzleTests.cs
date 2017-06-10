using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_07_06_Jigsaw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_06_Jigsaw.Tests
{
    [TestClass()]
    public class JigsawPuzzleTests
    {
        [TestMethod()]
        public void JigsawPuzzleTest()
        {
            List<JigsawPuzzle.Piece> pieces = new List<JigsawPuzzle.Piece>();
            List<Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>> fittedEdges = new List<Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>>();

            JigsawPuzzle.Edge edge12Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge12Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge12Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge12Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);

            List<JigsawPuzzle.Edge> edges12 = new List<JigsawPuzzle.Edge>();
            edges12.Add(edge12Left);
            edges12.Add(edge12Top);
            edges12.Add(edge12Right);
            edges12.Add(edge12Bottom);

            JigsawPuzzle.Piece piece12 = new JigsawPuzzle.Piece(12, edges12);
            pieces.Add(piece12);

            JigsawPuzzle.Edge edge11Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge11Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge11Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge11Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);

            List<JigsawPuzzle.Edge> edges11 = new List<JigsawPuzzle.Edge>();
            edges11.Add(edge11Left);
            edges11.Add(edge11Top);
            edges11.Add(edge11Right);
            edges11.Add(edge11Bottom);

            JigsawPuzzle.Piece piece11 = new JigsawPuzzle.Piece(11, edges11);
            pieces.Add(piece11);

            JigsawPuzzle.Edge edge13Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge13Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge13Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge13Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);

            List<JigsawPuzzle.Edge> edges13 = new List<JigsawPuzzle.Edge>();
            edges13.Add(edge13Left);
            edges13.Add(edge13Top);
            edges13.Add(edge13Right);
            edges13.Add(edge13Bottom);

            JigsawPuzzle.Piece piece13 = new JigsawPuzzle.Piece(13, edges13);
            piece13.Rotate(); // Add this piece after rotating
            pieces.Add(piece13);

            JigsawPuzzle.Edge edge14Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge14Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge14Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge14Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);

            List<JigsawPuzzle.Edge> edges14 = new List<JigsawPuzzle.Edge>();
            edges14.Add(edge14Left);
            edges14.Add(edge14Top);
            edges14.Add(edge14Right);
            edges14.Add(edge14Bottom);

            JigsawPuzzle.Piece piece14 = new JigsawPuzzle.Piece(14, edges14);
            piece14.Rotate(); // Add this piece after rotating
            pieces.Add(piece14);

            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge12Right, edge11Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge11Right, edge13Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge13Right, edge14Left));

            
            JigsawPuzzle.Edge edge0Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge0Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge0Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge0Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges0 = new List<JigsawPuzzle.Edge>();
            edges0.Add(edge0Left);
            edges0.Add(edge0Top);
            edges0.Add(edge0Right);
            edges0.Add(edge0Bottom);

            JigsawPuzzle.Piece piece0 = new JigsawPuzzle.Piece(0, edges0);
            pieces.Add(piece0);
            
            JigsawPuzzle.Edge edge1Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge1Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge1Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge1Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);

            List<JigsawPuzzle.Edge> edges1 = new List<JigsawPuzzle.Edge>();
            edges1.Add(edge1Left);
            edges1.Add(edge1Top);
            edges1.Add(edge1Right);
            edges1.Add(edge1Bottom);

            JigsawPuzzle.Piece piece1 = new JigsawPuzzle.Piece(1, edges1);
            pieces.Add(piece1);
            
            JigsawPuzzle.Edge edge10Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge10Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge10Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge10Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges10 = new List<JigsawPuzzle.Edge>();
            edges10.Add(edge10Left);
            edges10.Add(edge10Top);
            edges10.Add(edge10Right);
            edges10.Add(edge10Bottom);

            JigsawPuzzle.Piece piece10 = new JigsawPuzzle.Piece(10, edges10);
            pieces.Add(piece10);
            
            JigsawPuzzle.Edge edge15Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge15Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge15Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge15Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges15 = new List<JigsawPuzzle.Edge>();
            edges15.Add(edge15Left);
            edges15.Add(edge15Top);
            edges15.Add(edge15Right);
            edges15.Add(edge15Bottom);

            JigsawPuzzle.Piece piece15 = new JigsawPuzzle.Piece(15, edges15);
            pieces.Add(piece15);

            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge0Bottom, edge12Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge1Bottom, edge11Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge10Bottom, edge13Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge15Bottom, edge14Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge0Right, edge1Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge1Right, edge10Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge10Right, edge15Left));

            JigsawPuzzle.Edge edge6Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge6Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge6Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge6Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges6 = new List<JigsawPuzzle.Edge>();
            edges6.Add(edge6Left);
            edges6.Add(edge6Top);
            edges6.Add(edge6Right);
            edges6.Add(edge6Bottom);

            JigsawPuzzle.Piece piece6 = new JigsawPuzzle.Piece(6, edges6);
            pieces.Add(piece6);

            JigsawPuzzle.Edge edge5Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge5Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge5Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge5Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges5 = new List<JigsawPuzzle.Edge>();
            edges5.Add(edge5Left);
            edges5.Add(edge5Top);
            edges5.Add(edge5Right);
            edges5.Add(edge5Bottom);

            JigsawPuzzle.Piece piece5 = new JigsawPuzzle.Piece(5, edges5);
            pieces.Add(piece5);

            JigsawPuzzle.Edge edge2Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge2Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge2Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge2Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);

            List<JigsawPuzzle.Edge> edges2 = new List<JigsawPuzzle.Edge>();
            edges2.Add(edge2Left);
            edges2.Add(edge2Top);
            edges2.Add(edge2Right);
            edges2.Add(edge2Bottom);

            JigsawPuzzle.Piece piece2 = new JigsawPuzzle.Piece(2, edges2);
            pieces.Add(piece2);

            JigsawPuzzle.Edge edge9Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge9Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge9Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge9Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges9 = new List<JigsawPuzzle.Edge>();
            edges9.Add(edge9Left);
            edges9.Add(edge9Top);
            edges9.Add(edge9Right);
            edges9.Add(edge9Bottom);

            JigsawPuzzle.Piece piece9 = new JigsawPuzzle.Piece(9, edges9);
            pieces.Add(piece9);

            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge6Bottom, edge0Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge5Bottom, edge1Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge2Bottom, edge10Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge9Bottom, edge15Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge6Right, edge5Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge5Right, edge2Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge2Right, edge9Left));

            JigsawPuzzle.Edge edge4Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge4Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge4Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge4Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges4 = new List<JigsawPuzzle.Edge>();
            edges4.Add(edge4Left);
            edges4.Add(edge4Top);
            edges4.Add(edge4Right);
            edges4.Add(edge4Bottom);

            JigsawPuzzle.Piece piece4 = new JigsawPuzzle.Piece(4, edges4);
            pieces.Add(piece4);

            JigsawPuzzle.Edge edge3Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge3Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge3Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge3Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);

            List<JigsawPuzzle.Edge> edges3 = new List<JigsawPuzzle.Edge>();
            edges3.Add(edge3Left);
            edges3.Add(edge3Top);
            edges3.Add(edge3Right);
            edges3.Add(edge3Bottom);

            JigsawPuzzle.Piece piece3 = new JigsawPuzzle.Piece(3, edges3);
            pieces.Add(piece3);

            JigsawPuzzle.Edge edge7Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge7Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge7Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);
            JigsawPuzzle.Edge edge7Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);

            List<JigsawPuzzle.Edge> edges7 = new List<JigsawPuzzle.Edge>();
            edges7.Add(edge7Left);
            edges7.Add(edge7Top);
            edges7.Add(edge7Right);
            edges7.Add(edge7Bottom);

            JigsawPuzzle.Piece piece7 = new JigsawPuzzle.Piece(7, edges7);
            pieces.Add(piece7);

            JigsawPuzzle.Edge edge8Left = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Outer);
            JigsawPuzzle.Edge edge8Top = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge8Right = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Flat);
            JigsawPuzzle.Edge edge8Bottom = new JigsawPuzzle.Edge(JigsawPuzzle.EdgeType.Inner);

            List<JigsawPuzzle.Edge> edges8 = new List<JigsawPuzzle.Edge>();
            edges8.Add(edge8Left);
            edges8.Add(edge8Top);
            edges8.Add(edge8Right);
            edges8.Add(edge8Bottom);

            JigsawPuzzle.Piece piece8 = new JigsawPuzzle.Piece(8, edges8);
            pieces.Add(piece8);

            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge4Bottom, edge6Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge3Bottom, edge5Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge7Bottom, edge2Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge8Bottom, edge9Top));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge4Right, edge3Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge3Right, edge7Left));
            fittedEdges.Add(new Tuple<JigsawPuzzle.Edge, JigsawPuzzle.Edge>(edge7Right, edge8Left));

            JigsawPuzzle puzzle = new JigsawPuzzle(4, 4, pieces);
            puzzle.SetFittedEdges(fittedEdges);

            var solution = puzzle.Solve();

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