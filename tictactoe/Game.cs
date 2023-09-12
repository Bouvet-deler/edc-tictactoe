namespace tictactoe
{

    public enum Symbol
    {
        Empty,
        X,
        O
    }

    public class Game
    {
        
        private Board _board = new (); 
        private Symbol _lastSymbol = Symbol.Empty;
        public void MakeMove(int x, int y, Symbol symbol)
        {
            ValidateMove(x, y, symbol);

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void ValidateMove(int x, int y, Symbol symbol)
        {
            if (IsFirstMove())
            {
                ValidateFirstMove(symbol);
            }

            //if not first move but player repeated
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }

            //if not first move but play on an already played tile
            if (_board.TileAt(x, y).Symbol != Symbol.Empty)
            {
                throw new Exception("Invalid position");
            }
        }

        private static void ValidateFirstMove(Symbol symbol)
        {
            if (symbol == Symbol.O)
            {
                throw new Exception("Invalid first player"); //TODO: Should implement a more specific exception type
            }
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == Symbol.Empty;
        }

        //Decide who lost 
        public Symbol Winner() //TODO: Bad naming, magic numbers all over (row number, column number, empty tile, 
        {   //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.TileAt(0, 0).Symbol != Symbol.Empty &&
               _board.TileAt(0, 1).Symbol != Symbol.Empty &&
               _board.TileAt(0, 2).Symbol != Symbol.Empty)
            {
                //if first row is full with same symbol
                if (_board.TileAt(0, 0).Symbol ==
                    _board.TileAt(0, 1).Symbol &&
                    _board.TileAt(0, 2).Symbol ==
                    _board.TileAt(0, 1).Symbol)
                {
                    return _board.TileAt(0, 0).Symbol;
                }
            }

            //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.TileAt(1, 0).Symbol != Symbol.Empty &&
               _board.TileAt(1, 1).Symbol != Symbol.Empty &&
               _board.TileAt(1, 2).Symbol != Symbol.Empty)
            {
                //if middle row is full with same symbol
                if (_board.TileAt(1, 0).Symbol ==
                    _board.TileAt(1, 1).Symbol &&
                    _board.TileAt(1, 2).Symbol ==
                    _board.TileAt(1, 1).Symbol)
                {
                    return _board.TileAt(1, 0).Symbol;
                }
            }

            //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.TileAt(2, 0).Symbol != Symbol.Empty &&
               _board.TileAt(2, 1).Symbol != Symbol.Empty &&
               _board.TileAt(2, 2).Symbol != Symbol.Empty)
            {
                //if middle row is full with same symbol
                if (_board.TileAt(2, 0).Symbol ==
                    _board.TileAt(2, 1).Symbol &&
                    _board.TileAt(2, 2).Symbol ==
                    _board.TileAt(2, 1).Symbol)
                {
                    return _board.TileAt(2, 0).Symbol;
                }
            }

            return Symbol.Empty;
        }
    }
}
