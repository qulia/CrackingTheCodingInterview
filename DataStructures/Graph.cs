using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Graph<T>
    {
        public class Node
        {
            public T Data
            {
                get;
                set;
            }

            public List<Node> AdjacentNodes
            {
                get;
                set;
            }
        }
    }
}
