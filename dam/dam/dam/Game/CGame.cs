namespace dam;

public class CGame
{
    private readonly IBoard _board;
    private readonly IRender _boardRenderer;
    private readonly IMove _moveValidator;
    private readonly IScoreboard _scoreboard;
    private readonly ITurnController _turnController;
    private readonly IInput _inputHandler;

    public CGame(
        IBoard board,
        IRender boardRenderer,
        IMove moveValidator,
        IScoreboard scoreboard,
        ITurnController turnController, 
        IInput inputHandler
    )
    {
        _board = board;
        _boardRenderer = boardRenderer;
        _moveValidator = moveValidator;
        _scoreboard = scoreboard;
        _turnController = turnController;
        _inputHandler = inputHandler;
    }

    public void Start()
    {
        while (true)
        {
            int playerIndex = _turnController.IsPlayer1Turn ? 0 : 1;

            Console.Clear();
            _boardRenderer.Render();
            Console.SetCursorPosition(50, 4);
            Console.WriteLine(_turnController.IsPlayer1Turn ? $"{_scoreboard.GetPlayers()[0].Name}'s turn (Red)" : $"{_scoreboard.GetPlayers()[1].Name}'s turn (Green)");

            _scoreboard.Render();

            // Get user input
            var move = _inputHandler.ParseMove();
            if (move == null)
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Invalid move. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if player is moving their own piece
            var owner = _board.GetSquareOwner(move.Value.fromRow, move.Value.fromCol);
            if ((_turnController.IsPlayer1Turn && owner != Owner.Player1) || (!_turnController.IsPlayer1Turn && owner != Owner.Player2))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Not your piece. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the destination square is empty
            if (!_board.IsSquareEmpty(move.Value.toRow, move.Value.toCol))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("The destination square is not empty. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the move is a valid one-square move or a valid skip move
            bool isSkipMove = _moveValidator.IsValidSkipMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol, owner.Value);
            if (!_moveValidator.IsOneSquareMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol) && !isSkipMove)
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Invalid move. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Check if the move is forward
            if (!_turnController.IsForwardMove(move.Value.fromRow, move.Value.toRow, _board.GetPiece(move.Value.fromRow, move.Value.fromCol)))
            {
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("You can only move forward. Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Move the piece
            _board.MovePiece(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol);

            // If piece was skipped, remove the piece
            if (isSkipMove)
            {
                int skippedRow = (move.Value.fromRow + move.Value.toRow) / 2;
                int skippedCol = (move.Value.fromCol + move.Value.toCol) / 2;

                _scoreboard.GetPlayers()[playerIndex].Score += 1;
                _board.RemovePiece(skippedRow, skippedCol);

                // Check for additional skips with the same piece
                while (_moveValidator.HasPossibleSkipMove(move.Value.toRow, move.Value.toCol, owner.Value))
                {
                    Console.Clear();
                    _boardRenderer.Render();
                    _scoreboard.Render();

                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine(_turnController.IsPlayer1Turn ? $"{_scoreboard.GetPlayers()[0].Name}'s turn (Red)" : $"{_scoreboard.GetPlayers()[1].Name}'s turn (Green)");
                    Console.SetCursorPosition(50, 7);

                    // Get user input for the next skip move
                    var nextMove = _inputHandler.ParseMove(move.Value.toRow, move.Value.toCol);
                    while(nextMove == null)
                    {
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Invalid move. Press any key to continue...");
                        Console.ReadKey();
                        Console.SetCursorPosition(50, 7);
                        Console.Write(new string(' ', Console.WindowWidth - 50));
                        nextMove = _inputHandler.ParseMove(move.Value.toRow, move.Value.toCol);
                    }

                    // Check if the next move is a valid skip move
                    isSkipMove = _moveValidator.IsValidSkipMove(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol, owner.Value);
                    while(!isSkipMove)
                    {
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Invalid move. Press any key to continue...");
                        Console.ReadKey();
                        Console.SetCursorPosition(50, 7);
                        Console.Write(new string(' ', Console.WindowWidth - 50));
                        nextMove = _inputHandler.ParseMove(move.Value.toRow, move.Value.toCol);
                        isSkipMove = _moveValidator.IsValidSkipMove(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol, owner.Value);
                    }

                    // Move the piece
                    _board.MovePiece(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol);

                    // Remove the skipped piece
                    skippedRow = (nextMove.Value.fromRow + nextMove.Value.toRow) / 2;
                    skippedCol = (nextMove.Value.fromCol + nextMove.Value.toCol) / 2;
                    _scoreboard.GetPlayers()[playerIndex].Score += 1;
                    _board.RemovePiece(skippedRow, skippedCol);

                    // Update the move to the new position
                    move = nextMove;
                }
            }

            // Toggle turn
            _turnController.ToggleTurn();
        }
    }
}