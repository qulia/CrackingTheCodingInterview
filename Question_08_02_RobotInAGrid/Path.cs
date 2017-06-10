using System.Collections.Generic;
using Utilities;

namespace Question_08_02_RobotInAGrid
{
    public class Path
    {
        List<Cell> cells = new List<Cell>();
        public Path(bool isStuck = false)
        {
            IsStuck = isStuck;
        }

        public bool IsStuck
        {
            get;
        }

        public IEnumerable<Cell> Cells
        {
            get
            {
                return cells;
            }
        }

        internal void Add(Cell cell)
        {
            cells.Insert(0, cell);
        }

        public override string ToString()
        {
            return cells.ToStringExt(true);
        }
    }
}
