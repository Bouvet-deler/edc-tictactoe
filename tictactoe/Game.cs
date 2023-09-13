namespace tictactoe
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileSymbol Symbol { get; set; }
        public enum TileSymbol { X, O, empty }
    }

    public class Board //TODO: Large class (uncohesive), correct data structure??
    {
        private List<Tile> _plays = new List<Tile>(); //TODO: Bad naming, is this the correct data structure to use?
        private const int BOARDSIZE = 3;
        
        public Board()
        {
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < BOARDSIZE; i++) 
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    _plays.Add(new Tile { X = i, Y = j, Symbol = Tile.TileSymbol.empty});
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

        //Adds a X to the board
        public void AddTileAt(Tile.TileSymbol symbol, int x, int y)
        {

            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol; //Duplicate code
        }


    }

    public class Game //TODO: Large class (low cohesion), correct data structure?
    {
        private Tile.TileSymbol _lastSymbol = Tile.TileSymbol.empty; 
        private Board _board = new Board();

        public void Play(Tile.TileSymbol symbol, int x, int y) //TODO: Long method, bad and inconsistent naming
        {
            //if first move
            if (_lastSymbol == Tile.TileSymbol.empty) //TODO: Readability
            {
                //if player is X
                if (symbol == Tile.TileSymbol.O)
                {
                    throw new Exception("Invalid first player");
                }
            }
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            else if (_board.TileAt(x, y).Symbol != Tile.TileSymbol.empty)
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        //Decide who lost //TODO: Comment, and its wrong
        public Tile.TileSymbol Winner() //TODO: Long method, Duplicate code, Complicated if statements, bad name (begin with a verb)
        {   //if the positions in first row are taken
            if (_board.TileAt(0, 0).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(0, 1).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(0, 2).Symbol != Tile.TileSymbol.empty)
            {
                //if first row is full with same symbol.
                if (_board.TileAt(0, 0).Symbol ==
                    _board.TileAt(0, 1).Symbol &&
                    _board.TileAt(0, 2).Symbol ==
                    _board.TileAt(0, 1).Symbol)
                {
                    return _board.TileAt(0, 0).Symbol;
                }
            }

            //if the positions in first row are taken
            if (_board.TileAt(1, 0).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(1, 1).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(1, 2).Symbol != Tile.TileSymbol.empty)
            {
                //if middle row is full with same symbol //TODO: Comment, 
                if (_board.TileAt(1, 0).Symbol ==
                    _board.TileAt(1, 1).Symbol &&
                    _board.TileAt(1, 2).Symbol ==
                    _board.TileAt(1, 1).Symbol)
                {
                    return _board.TileAt(1, 0).Symbol;
                }
            }

            //if the positions in first row are taken
            if (_board.TileAt(2, 0).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(2, 1).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(2, 2).Symbol != Tile.TileSymbol.empty)
            {
                //if middle row is full with same symbol //TODO: Comment, and its wrong
                if (_board.TileAt(2, 0).Symbol ==
                    _board.TileAt(2, 1).Symbol &&
                    _board.TileAt(2, 2).Symbol ==
                    _board.TileAt(2, 1).Symbol)
                {
                    return _board.TileAt(2, 0).Symbol;
                }
            }

            return Tile.TileSymbol.empty;
        }
    }
}
