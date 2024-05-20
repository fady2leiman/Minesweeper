 
namespace Minesweeper
{
    class MinesweeperGame
    {
        private Board _board;
        public bool _gameOver;
        private bool _win;

        public MinesweeperGame(int size = 10, int numMines = 10)
        {
            _board = new Board(size, numMines);
            _gameOver = false;
            _win = false;
        }

        public void RevealCell(int row, int col)
        {
            if (_gameOver)
                return;
            _board.RevealCell(row, col);
            var cell = _board.Grid[row, col];
            if (cell.IsMine)
            {
                _gameOver = true;
                _win = false;
            }
            else
            {
                CheckWinCondition();
            }
        }

        public void FlagCell(int row, int col)
        {
            if (!_gameOver)
            {
                _board.FlagCell(row, col);
            }
        }

        private void CheckWinCondition()
        {
            foreach (var cell in _board.Grid)
            {
                if (!cell.IsRevealed && !cell.IsMine)
                {
                    return;
                }
            }
            _gameOver = true;
            _win = true;
        }

        public override string ToString()
        {
            return _board.ToString();
        }

        public void PrintStatus()
        {
            if (_gameOver)
            {
                Console.WriteLine(_win ? "Congratulations! You've won!" : "Game Over! You hit a mine!");
            }
            else
            {
                Console.WriteLine("Game in progress...");
            }
        }
    }
}
