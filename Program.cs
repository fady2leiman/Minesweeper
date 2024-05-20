using Minesweeper;
 

class Program
{
    static void Main(string[] args)
    {
        var game = new MinesweeperGame(size: 5, numMines: 5);

        while (!game._gameOver)
        {
            Console.Clear();
            Console.WriteLine(game);
            game.PrintStatus();
            Console.Write("Enter 'r' to reveal or 'f' to flag, followed by row and column: ");
            var input = Console.ReadLine().Split();
            if (input[0] == "r")
            {
                game.RevealCell(int.Parse(input[1]), int.Parse(input[2]));
            }
            else if (input[0] == "f")
            {
                game.FlagCell(int.Parse(input[1]), int.Parse(input[2]));
            }
        }
        Console.Clear();
        Console.WriteLine(game);
        game.PrintStatus();
    }
}