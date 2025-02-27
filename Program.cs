namespace TicTacToe
{
    internal class Program
    {
        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        static char currentPlayer = 'X';
        static void Main(string[] args)
        {
            int moves = 0;
            bool gameWon = false;
            while (moves < 9 && !gameWon)
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
                {
                    if (MakeMove(position))
                    {
                        moves++;
                        gameWon = CheckWinner();
                        if (!gameWon)
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                    else
                    {
                        Console.WriteLine("That position is already taken! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            }

            PrintBoard();
            Console.WriteLine(gameWon ? $"Player {currentPlayer} wins!" : "It's a draw!");

        }

        static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
        }

        static bool MakeMove(int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;
                return true;
            }
            return false;
        }

        static bool CheckWinner()
        {
            // Rows, Columns, Diagonals
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) return true;
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) return true;
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) return true;
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer) return true;

            return false;
        }
    }
}
