using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_07_06_Jigsaw
{
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

}
