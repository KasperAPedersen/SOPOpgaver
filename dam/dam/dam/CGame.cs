namespace dam;

public class CGame
{
    private CBoard board;
    private CScoreboard scoreboard;
    private bool isPlayer1Turn;
    private List<Player> players = [];

    public CGame(string? player1 = null, string? player2 = null)
    {
        players.Add(new Player(player1 ?? "Player 1"));
        players.Add(new Player(player2 ?? "Player 2"));

        board = new CBoard();
        isPlayer1Turn = true;

        scoreboard = new CScoreboard(players);
    }

    public void Start()
    {
        while (true)
        {
            int playerIndex = isPlayer1Turn ? 0 : 1;

            Console.Clear();
            board.Render();
            Console.SetCursorPosition(50, 4);
            Console.WriteLine(isPlayer1Turn ? $"{players[0].Name}'s turn (Red)" : $"{players[1].Name}'s turn (Green)");

            scoreboard.Render();

            // Get user input
            var move = ParseMove();
            if (move == null)
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Invalid move. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if player is moving their own piece
            var owner = board.GetSquareOwner(move.Value.fromRow, move.Value.fromCol);
            if ((isPlayer1Turn && owner != CBoard.SquareState.Player1) || (!isPlayer1Turn && owner != CBoard.SquareState.Player2))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Not your piece. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the destination square is empty
            if (!board.IsSquareEmpty(move.Value.toRow, move.Value.toCol))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("The destination square is not empty. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the move is a valid one-square move or a valid skip move
            bool isSkipMove = board.IsValidSkipMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol, owner.Value);
            if (!board.IsOneSquareMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol) && !isSkipMove)
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Invalid move. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the move is forward
            if (!IsForwardMove(move.Value.fromRow, move.Value.toRow))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("You can only move forward. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Move the piece
            board.MovePiece(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol);

            // If piece was skipped, remove the piece
            if (isSkipMove)
            {
                int skippedRow = (move.Value.fromRow + move.Value.toRow) / 2;
                int skippedCol = (move.Value.fromCol + move.Value.toCol) / 2;

                players[playerIndex] = players[playerIndex] with { Score = players[playerIndex].Score + 1 };
                board.RemovePiece(skippedRow, skippedCol);

                // Check for additional skips with the same piece
                while (board.HasPossibleSkipMove(move.Value.toRow, move.Value.toCol, owner.Value))
                {
                    Console.Clear();
                    board.Render();
                    scoreboard.Render();

                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine(isPlayer1Turn ? $"{players[0].Name}'s turn (Red)" : $"{players[1].Name}'s turn (Green)");
                    Console.SetCursorPosition(50, 7);

                    // Get user input for the next skip move
                    var nextMove = ParseMove(move.Value.toRow, move.Value.toCol);
                    while(nextMove == null)
                    {
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Invalid move. Press any key to continue...");
                        Console.ReadKey();
                        Console.SetCursorPosition(50, 7);
                        Console.Write(new string(' ', Console.WindowWidth - 50)); // Clear the previous input
                        nextMove = ParseMove(move.Value.toRow, move.Value.toCol);
                    }

                    // Check if the next move is a valid skip move
                    isSkipMove = board.IsValidSkipMove(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol, owner.Value);
                    while(!isSkipMove)
                    {
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Invalid move. Press any key to continue...");
                        Console.ReadKey();
                        Console.SetCursorPosition(50, 7);
                        Console.Write(new string(' ', Console.WindowWidth - 50)); // Clear the previous input
                        nextMove = ParseMove(move.Value.toRow, move.Value.toCol);
                        isSkipMove = board.IsValidSkipMove(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol, owner.Value);
                    }

                    // Move the piece
                    board.MovePiece(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol);

                    // Remove the skipped piece
                    skippedRow = (nextMove.Value.fromRow + nextMove.Value.toRow) / 2;
                    skippedCol = (nextMove.Value.fromCol + nextMove.Value.toCol) / 2;
                    players[playerIndex] = players[playerIndex] with { Score = players[playerIndex].Score + 1 };
                    board.RemovePiece(skippedRow, skippedCol);

                    // Update the move to the new position
                    move = nextMove;
                }
            }

            // Toggle turn
            isPlayer1Turn = !isPlayer1Turn;
        }
    }

    private bool IsForwardMove(int fromRow, int toRow)
    {
        return isPlayer1Turn ? toRow > fromRow : toRow < fromRow;
    }

    private (int fromRow, int fromCol, int toRow, int toCol)? ParseMove(int? initialRow = null, int? initialCol = null)
    {
        var from = initialRow.HasValue && initialCol.HasValue
            ? (initialRow.Value, initialCol.Value)
            : ParsePosition(userInput("Select piece (e.g., A3): "));

        var to = ParsePosition(userInput("Select destination (e.g., A3): "));

        if (from == null || to == null)
        {
            return null;
        }

        return (from.Value.row, from.Value.col, to.Value.row, to.Value.col);
    }

    private string userInput(string text)
    {
        Console.SetCursorPosition(50, 5);
        Console.Write(text);
        string tmp;
        do
        {
            tmp = Console.ReadLine()?.ToUpper();

            if (!(tmp == null || tmp.Length != 2 || tmp[0] < 'A' || tmp[0] > 'H' || tmp[1] < '1' || tmp[1] > '8'))
            {
                break;
            }

            Console.SetCursorPosition(50, 7);
            Console.WriteLine("Invalid input. Please enter a valid square (e.g., A3).");
            Console.SetCursorPosition(50, 5);
            Console.Write(new string(' ', Console.WindowWidth - 50)); // Clear the previous input
            Console.SetCursorPosition(50, 5);
            Console.Write(text);
        } while (true);

        return tmp;
    }

    private (int row, int col)? ParsePosition(string pos)
    {
        if (pos.Length != 2) return null;

        int col = pos[0] - 'A';
        int row = pos[1] - '1';
        if (col < 0 || col >= 8 || row < 0 || row >= 8) return null;

        return (row, col);
    }
}