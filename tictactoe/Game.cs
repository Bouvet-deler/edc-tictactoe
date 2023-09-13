namespace tictactoe
{
    public class Constants
    {
        public const int BOARDSIZE = 3;
    }
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
        
        
        public Board()
        {
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < Constants.BOARDSIZE; i++) 
            {
                for (int j = 0; j < Constants.BOARDSIZE; j++)
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

    public class Game
    {
        private Tile.TileSymbol _lastSymbol = Tile.TileSymbol.empty; 
        private Board _board = new Board();

        public void Play(Tile.TileSymbol symbol, int x, int y)
        {
            CheckFirstPlayerIsX(symbol, x, y);
            CheckRepeatedPlayer(symbol);
            CheckIfTileEmpty(x, y);
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void CheckIfTileEmpty(int x, int y)
        {
            if (_board.TileAt(x, y).Symbol != Tile.TileSymbol.empty)
            {
                throw new Exception("Invalid position");
            }
        }

        private void CheckRepeatedPlayer(Tile.TileSymbol symbol)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
        }

        private void CheckFirstPlayerIsX(Tile.TileSymbol symbol, int x, int y)
        {
            if (_lastSymbol == Tile.TileSymbol.empty)
            {
                if (symbol == Tile.TileSymbol.O)
                {
                    throw new Exception("Invalid first player");
                }
            }
            
        }

        public Tile.TileSymbol CheckRow(int row)
        {
            if (_board.TileAt(row, 0).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(row, 1).Symbol != Tile.TileSymbol.empty &&
               _board.TileAt(row, 2).Symbol != Tile.TileSymbol.empty)
            {
                if (_board.TileAt(row, 0).Symbol ==
                    _board.TileAt(row, 1).Symbol &&
                    _board.TileAt(row, 2).Symbol ==
                    _board.TileAt(row, 1).Symbol)
                {
                    return _board.TileAt(row, 0).Symbol;
                }
            }
            return Tile.TileSymbol.empty;
        }

        public Tile.TileSymbol CheckWinner() 
        {   
            for (int i = 0; i < Constants.BOARDSIZE; i++)
            {
                Tile.TileSymbol result = CheckRow(i);
                if (result != Tile.TileSymbol.empty)
                    return result;
            }            

            return Tile.TileSymbol.empty;
        }
    }
}
