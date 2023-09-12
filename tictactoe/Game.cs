namespace tictactoe
{
    public class Tile //TODO: Large class (file). Move to separate file
    {
        public int X { get; set; } //TODO: Primitive obsession
        public int Y { get; set; } //TODO: Primitive obsession
        public Symbol Symbol { get; set; }
    }

    public enum Symbol
    {
        Empty,
        X,
        O
    }

    public class Game
    {
        
        private Board _board = new Board(); //TODO: Use new shorthand syntax
        private Symbol _lastSymbol = Symbol.Empty;
        public void Play(Symbol symbol, int x, int y) //TODO: Introduce assertion, long method
        {
            //if first move
            if (_lastSymbol == Symbol.Empty) //Todo: Complicated if statements, and not really related
            {
                //if player is X //TODO: Comment, it's wrong
                if (symbol == Symbol.O)
                {
                    throw new Exception("Invalid first player"); //TODO: Should implement a more specific exception type
                }
            }
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            else if (_board.TileAt(x, y).Symbol != Symbol.Empty)
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
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
