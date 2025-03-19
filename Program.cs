namespace TicTacToe
{
    internal class Program
    {
        static char[,] board =
   {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };
        static char currentPlayer = 'X';
        static Random random = new Random();

        static void Main()
        {
            Console.Write("Do you want to play against the computer? (y/n): ");
            bool againstComputer = Console.ReadLine().Trim().ToLower() == "y";

            int moves = 0;
            bool gameRunning = true;

            while (gameRunning && moves < 9)
            {
                Console.Clear();
                PrintBoard();

                if (currentPlayer == 'X' || !againstComputer)
                {
                    Console.WriteLine($"Player {currentPlayer}, choose a position: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
                    {
                        if (PlaceMarker(position))
                        {
                            moves++;
                            if (CheckWin())
                            {
                                Console.Clear();
                                PrintBoard();
                                Console.WriteLine($"Player {currentPlayer} wins!");
                                gameRunning = false;
                            }
                            else
                            {
                                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Position already taken, try again.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Computer is making a move...");
                    Thread.Sleep(1000);
                    ComputerMove();
                    moves++;
                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("Computer wins!");
                        gameRunning = false;
                    }
                    else
                    {
                        currentPlayer = 'X';
                    }
                }
            }

            if (moves == 9 && gameRunning)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("It's a draw!");
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("\n  {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  {0} | {1} | {2} \n", board[2, 0], board[2, 1], board[2, 2]);
        }

        static bool PlaceMarker(int position)
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

        static bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    return true;
            }

            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                return true;

            return false;
        }

        static void ComputerMove()
        {
            int position;
            do
            {
                position = random.Next(1, 10);
            } while (!PlaceMarker(position));
        }
    }
}
