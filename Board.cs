using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Board
    {
        public int Size { get; }
        public int NumMines { get; }
        public Cell[,] Grid { get; }

        public Board(int size, int numMines)
        {
            Size = size;
            NumMines = numMines;
            Grid = new Cell[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Grid[row, col] = new Cell(row, col);
                }
            }

            PlaceMines();
            CalculateAdjacentMines();
        }

        private void PlaceMines()
        {
            var rand = new Random();
            int minesPlaced = 0;
            while (minesPlaced < NumMines)
            {
                int row = rand.Next(Size);
                int col = rand.Next(Size);
                var cell = Grid[row, col];
                if (!cell.IsMine)
                {
                    cell.IsMine = true;
                    minesPlaced++;
                }
            }
        }

        private void CalculateAdjacentMines()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (!Grid[row, col].IsMine)
                    {
                        Grid[row, col].AdjacentMines = CountAdjacentMines(row, col);
                    }
                }
            }
        }

        private int CountAdjacentMines(int row, int col)
        {
            int count = 0;
            for (int r = Math.Max(0, row - 1); r <= Math.Min(Size - 1, row + 1); r++)
            {
                for (int c = Math.Max(0, col - 1); c <= Math.Min(Size - 1, col + 1); c++)
                {
                    if (Grid[r, c].IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void RevealCell(int row, int col)
        {
            var cell = Grid[row, col];
            if (cell.IsRevealed || cell.IsFlagged)
                return;
            cell.IsRevealed = true;
            if (cell.AdjacentMines == 0 && !cell.IsMine)
            {
                RevealAdjacentCells(row, col);
            }
        }

        private void RevealAdjacentCells(int row, int col)
        {
            for (int r = Math.Max(0, row - 1); r <= Math.Min(Size - 1, row + 1); r++)
            {
                for (int c = Math.Max(0, col - 1); c <= Math.Min(Size - 1, col + 1); c++)
                {
                    if (!Grid[r, c].IsRevealed)
                    {
                        RevealCell(r, c);
                    }
                }
            }
        }

        public void FlagCell(int row, int col)
        {
            var cell = Grid[row, col];
            if (!cell.IsRevealed)
            {
                cell.IsFlagged = !cell.IsFlagged;
            }
        }

        public override string ToString()
        {
            var boardStr = "";
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    boardStr += Grid[row, col] + " ";
                }
                boardStr += Environment.NewLine;
            }
            return boardStr;
        }
    }
}
