namespace tictactoe
{
    public class Tile //TODO: Large class (file). Move to separate file
    {
        public int X { get; set; } //TODO: Primitive obsession
        public int Y { get; set; } //TODO: Primitive obsession
        public char Symbol { get; set; }
    }

    public class Board //TODO: Large class (file). Move to separate file
    {
        private List<Tile> _plays = new List<Tile>();
        private readonly int _boardSize = 3;
        private readonly char _emptyTileSymbol = ' ';
        public Board()
        {
            InitateEmptyBoard();
        }

        private void InitateEmptyBoard()
        {
            for (int row = 0; row < _boardSize; row++) 
            {
                for (int column = 0; column < _boardSize; column++)
                {
                    _plays.Add(new Tile { X = row, Y = column, Symbol = _emptyTileSymbol});
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y); //TODO: Duplicate code
        }

        //Adds a X to the board //TODO: Comment code smell, bad naming
        public void AddTileAt(char symbol, int x, int y) //Inconsistent order of arguments
        {
            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;  //TODO: Duplicate code
        }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board(); //TODO: Use new shorthand syntax

        public void Play(char symbol, int x, int y) //TODO: Introduce assertion, long method
        {
            //if first move
            if (_lastSymbol == ' ') //Todo: Complicated if statements, and not really related
            {
                //if player is X //TODO: Comment, it's wrong
                if (symbol == 'O')
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
            else if (_board.TileAt(x, y).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        //Decide who lost 
        public char Winner() //TODO: Bad naming, magic numbers all over (row number, column number, empty tile, 
        {   //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.TileAt(0, 0).Symbol != ' ' &&
               _board.TileAt(0, 1).Symbol != ' ' &&
               _board.TileAt(0, 2).Symbol != ' ')
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
            if (_board.TileAt(1, 0).Symbol != ' ' &&
               _board.TileAt(1, 1).Symbol != ' ' &&
               _board.TileAt(1, 2).Symbol != ' ')
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
            if (_board.TileAt(2, 0).Symbol != ' ' &&
               _board.TileAt(2, 1).Symbol != ' ' &&
               _board.TileAt(2, 2).Symbol != ' ')
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

            return ' ';
        }
    }
}
