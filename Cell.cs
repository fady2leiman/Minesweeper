using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Cell
    {
        public int Row { get; }
        public int Col { get; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int AdjacentMines { get; set; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
            IsMine = false;
            IsRevealed = false;
            IsFlagged = false;
            AdjacentMines = 0;
        }

        public override string ToString()
        {
            if (IsFlagged)
                return "F";
            if (!IsRevealed)
                return "□";
            if (IsMine)
                return "*";
            return AdjacentMines > 0 ? AdjacentMines.ToString() : " ";
        }
    }
}
