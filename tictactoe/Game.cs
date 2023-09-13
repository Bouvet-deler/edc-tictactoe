namespace tictactoe
{
    public class Constants
    {
        public const int BOARDSIZE = 3;
    }
    public enum TileSymbol { X, O, empty }
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileSymbol Symbol { get; set; }
        
    }

    public class Board 
    {
        private List<Tile> _plays = new List<Tile>(); 
        
        
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
                    _plays.Add(new Tile { X = i, Y = j, Symbol = TileSymbol.empty});
                }
            }
        }

        public Tile GetTileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

  
        public void AddTileAt(TileSymbol symbol, int x, int y)
        {
            GetTileAt(x,y).Symbol = symbol;
        }
    }

    public class Game
    {
        private TileSymbol _lastSymbol = TileSymbol.empty; 
        private Board _board = new Board();

        public void Play(TileSymbol symbol, int x, int y)
        {
            CheckFirstPlayerIsX(symbol, x, y);
            CheckRepeatedPlayer(symbol);
            CheckIfTileEmpty(x, y);
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void CheckIfTileEmpty(int x, int y)
        {
            if (_board.GetTileAt(x, y).Symbol != TileSymbol.empty)
            {
                throw new Exception("Invalid position");
            }
        }

        private void CheckRepeatedPlayer(TileSymbol symbol)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
        }

        private void CheckFirstPlayerIsX(TileSymbol symbol, int x, int y)
        {
            if (_lastSymbol == TileSymbol.empty)
            {
                if (symbol == TileSymbol.O)
                {
                    throw new Exception("Invalid first player");
                }
            }
            
        }

        public TileSymbol CheckRow(int row)
        {
            if (_board.GetTileAt(row, 0).Symbol != TileSymbol.empty &&
               _board.GetTileAt(row, 1).Symbol != TileSymbol.empty &&
               _board.GetTileAt(row, 2).Symbol != TileSymbol.empty)
            {
                if (_board.GetTileAt(row, 0).Symbol ==
                    _board.GetTileAt(row, 1).Symbol &&
                    _board.GetTileAt(row, 2).Symbol ==
                    _board.GetTileAt(row, 1).Symbol)
                {
                    return _board.GetTileAt(row, 0).Symbol;
                }
            }
            return TileSymbol.empty;
        }

        public TileSymbol CheckWinner() 
        {   
            for (int i = 0; i < Constants.BOARDSIZE; i++)
            {
                TileSymbol result = CheckRow(i);
                if (result != TileSymbol.empty)
                    return result;
            }            

            return TileSymbol.empty;
        }
    }
}
