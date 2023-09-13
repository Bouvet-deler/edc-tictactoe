namespace tictactoe
{

    public enum Symbol
    {
        Empty,
        X,
        O
    }

    public class InvalidMoveException: Exception {
        public InvalidMoveException(string message) : base(message) { }
    }

    public class Game
    {
        
        private Board _board = new (); 
        private Symbol _lastSymbol = Symbol.Empty;
        public void MakeMove(int x, int y, Symbol symbol)
        {
            ValidateMove(x, y, symbol);

            _lastSymbol = symbol;
            _board.UpdateSymbolAt(x, y, symbol);
        }

        private void ValidateMove(int x, int y, Symbol symbol)
        {
            if (IsFirstMove())
            {
                ValidateFirstMove(symbol);
            }

            if (IsSamePlayerAsLastTime(symbol))
            {
                throw new InvalidMoveException("Invalid next player");
            }

            if (IsOccupied(x, y))
            {
                throw new InvalidMoveException("Invalid position");
            }
        }

        private bool IsOccupied(int x, int y)
        {
            return _board.TileAt(x, y).Symbol != Symbol.Empty;
        }

        private bool IsSamePlayerAsLastTime(Symbol symbol)
        {
            return symbol == _lastSymbol;
        }

        private static void ValidateFirstMove(Symbol symbol)
        {
            if (symbol == Symbol.O)
            {
                throw new InvalidMoveException("Invalid first player");
            }
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == Symbol.Empty;
        }

        public Symbol CheckWinner()
        {
            for(int column = 0; column < _board.BoardSize; column++)
            {
                if (CheckColumnNotEmpty(column) && CheckSameSymbolsInColumn(column))
                {
                    return _board.TileAt(column, 0).Symbol;
                }
            }
            
            for (int row = 0; row < _board.BoardSize; row++)
            {
                if (CheckRowNotEmpty(row) && CheckSameSymbolsInRow(row))
                {
                    return _board.TileAt(0, row).Symbol;
                }
            }

            // TODO: should check after diagonal line here

            return Symbol.Empty;
        }

        private bool CheckSameSymbolsInColumn(int column)
        {
            return _board.TileAt(column, 0).Symbol ==
                                _board.TileAt(column, 1).Symbol &&
                                _board.TileAt(column, 2).Symbol ==
                                _board.TileAt(column, 1).Symbol;
        }

        private bool CheckColumnNotEmpty(int column)
        {
            return _board.TileAt(column, 0).Symbol != Symbol.Empty &&
                           _board.TileAt(column, 1).Symbol != Symbol.Empty &&
                           _board.TileAt(column, 2).Symbol != Symbol.Empty;
        }

        private bool CheckSameSymbolsInRow(int row)
        {
            return _board.TileAt(0, row).Symbol ==
                                _board.TileAt(1, row).Symbol &&
                                _board.TileAt(2, row).Symbol ==
                                _board.TileAt(1, row).Symbol;
        }

        private bool CheckRowNotEmpty(int row)
        {
            return _board.TileAt(0, row).Symbol != Symbol.Empty &&
                           _board.TileAt(1, row).Symbol != Symbol.Empty &&
                           _board.TileAt(2, row).Symbol != Symbol.Empty;
        }
    }
}
