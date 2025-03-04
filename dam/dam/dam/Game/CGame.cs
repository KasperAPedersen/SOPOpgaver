namespace dam;

public class CGame
{
    private readonly IBoard _board;
    private readonly IRender _boardRenderer;
    private readonly IMove _moveValidator;
    private readonly IScoreboard _scoreboard;
    private readonly ITurnController _turnController;
    private readonly IInput _inputHandler;
    private readonly IStatus _status;

    public CGame(
        IBoard board,
        IRender boardRenderer,
        IMove moveValidator,
        IScoreboard scoreboard,
        ITurnController turnController, 
        IInput inputHandler,
        IStatus status
    )
    {
        _board = board;
        _boardRenderer = boardRenderer;
        _moveValidator = moveValidator;
        _scoreboard = scoreboard;
        _turnController = turnController;
        _inputHandler = inputHandler;
        _status = status;
    }

    public void Start()
{
    while (true)
    {
        int playerIndex = _turnController.IsPlayer1Turn ? 0 : 1;

        Console.Clear();
        _boardRenderer.Render();
        _scoreboard.Render();

        // Loop until a valid move is provided
        bool validMove = false;
        while (!validMove)
        {
            // Get user input
            var move = _inputHandler.ParseMove();
            if (move == null)
            {
                _status.ShowError("Invalid input. Please enter a valid square (e.g., A3).");
                Console.ReadKey();
                continue;
            }

            // Validate move coordinates
            if (move.Value.fromRow < 0 || move.Value.fromRow >= _board.BoardSize ||
                move.Value.fromCol < 0 || move.Value.fromCol >= _board.BoardSize ||
                move.Value.toRow < 0 || move.Value.toRow >= _board.BoardSize ||
                move.Value.toCol < 0 || move.Value.toCol >= _board.BoardSize)
            {
                _status.ShowError("Invalid move. Coordinates are out of bounds. Press any key to continue...");
                Console.ReadKey();
                _boardRenderer.ClearSelector(move.Value.fromRow, move.Value.fromCol); // Clear the selected piece
                continue;
            }

            // Check if player is moving their own piece
            var owner = _board.GetSquareOwner(move.Value.fromRow, move.Value.fromCol);
            if ((_turnController.IsPlayer1Turn && owner != Owner.Player1) || (!_turnController.IsPlayer1Turn && owner != Owner.Player2))
            {
                _status.ShowError("You can only move your own piece. Press any key to continue...");
                Console.ReadKey();
                _boardRenderer.ClearSelector(move.Value.fromRow, move.Value.fromCol); // Clear the selected piece
                continue;
            }

            // Check if the destination square is empty
            if (!_board.IsSquareEmpty(move.Value.toRow, move.Value.toCol))
            {
                _status.ShowError("Destination square is not empty. Press any key to continue...");
                Console.ReadKey();
                _boardRenderer.ClearSelector(move.Value.fromRow, move.Value.fromCol); // Clear the selected piece
                continue;
            }

            // Check if the move is a valid one-square move or a valid skip move
            bool isSkipMove = _moveValidator.IsValidSkipMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol, owner.Value);
            if (!_moveValidator.IsOneSquareMove(move.Value.fromRow, move.Value.fromCol, move.Value.toRow, move.Value.toCol) && !isSkipMove)
            {
                _status.ShowError("Invalid move. Press any key to continue...");
                Console.ReadKey();
                _boardRenderer.ClearSelector(move.Value.fromRow, move.Value.fromCol); // Clear the selected piece
                continue;
            }

            // Check if the move is forward
            if (!_turnController.IsForwardMove(move.Value.fromRow, move.Value.toRow, _board.GetPiece(move.Value.fromRow, move.Value.fromCol)))
            {
                _status.ShowError("You can only move forward. Press any key to continue...");
                Console.ReadKey();
                _boardRenderer.ClearSelector(move.Value.fromRow, move.Value.fromCol); // Clear the selected piece
                continue;
            }

            // If all checks pass, the move is valid
            validMove = true;

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

                    // Get user input for the next skip move
                    var nextMove = _inputHandler.ParseMove(move.Value.toRow, move.Value.toCol);
                    while (nextMove == null)
                    {
                        _status.ShowError("Invalid input. Press any key to continue...");
                        Console.ReadKey();
                        _status.ClearStatus();
                        nextMove = _inputHandler.ParseMove(move.Value.toRow, move.Value.toCol);
                    }

                    // Check if the next move is a valid skip move
                    isSkipMove = _moveValidator.IsValidSkipMove(nextMove.Value.fromRow, nextMove.Value.fromCol, nextMove.Value.toRow, nextMove.Value.toCol, owner.Value);
                    while (!isSkipMove)
                    {
                        _status.ShowError("Invalid move. Press any key to continue...");
                        Console.ReadKey();
                        _status.ClearStatus();
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
        }

        // Toggle turn
        _turnController.ToggleTurn();
    }
}
}