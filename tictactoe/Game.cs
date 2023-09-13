using System.Reflection.Metadata;

namespace tictactoe
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
    }

    public class Board //TODO: Large class (uncohesive), correct data structure??
    {
        private const int BOARD_SIZE = 3;
        public static char EMPTY_TILE = ' ';
        private List<Tile> _plays = new List<Tile>(); //TODO: Bad naming, is this the correct data structure to use?

        public Board()
        {
            InitilizeBoard();
        }

        private void InitilizeBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++) //TODO: Magic number (also on line below)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    _plays.Add(new Tile { X = i, Y = j, Symbol = EMPTY_TILE });
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

        //Adds a X to the board
        public void AddTileAt(char symbol, int x, int y)
        {
            TileAt(x, y).Symbol = symbol; 
        }

    }

    public class Game //TODO: Large class (low cohesion), correct data structure?
    {
        private Board _board = new Board();
        private char _lastSymbol = Board.EMPTY_TILE;


        public void Play(char symbol, int x, int y) //TODO: Long method, bad and inconsistent naming
        {
            //if first move
            if (_lastSymbol == Board.EMPTY_TILE) //TODO: Readability
            {
                //if player is X
                if (symbol == 'O')
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
            else if (_board.TileAt(x, y).Symbol != Board.EMPTY_TILE)
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        //Decide who lost //TODO: Comment, and its wrong
        public char Winner() //TODO: Long method, Duplicate code, Complicated if statements, bad name (begin with a verb)
        {   
            if (IsRowFilled(0))
            {
                if (IsRowFilledWithSameSymbol(0))
                {
                    return _board.TileAt(0, 0).Symbol;
                }
            }

            if (IsRowFilled(1))
            {
                if (IsRowFilledWithSameSymbol(1))
                {
                    return _board.TileAt(1, 0).Symbol;
                }
            }

            if (IsRowFilled(2))
            {
                if (IsRowFilledWithSameSymbol(2))
                {
                    return _board.TileAt(2, 0).Symbol;
                }
            }

            return Board.EMPTY_TILE;
        }

        private bool IsRowFilledWithSameSymbol(int row_number)
        {
            return _board.TileAt(row_number, 0).Symbol ==
                                _board.TileAt(row_number, 1).Symbol &&
                                _board.TileAt(row_number, 2).Symbol ==
                                _board.TileAt(row_number, 1).Symbol;
        }

        private bool IsRowFilled(int row_number)
        {
            return _board.TileAt(row_number, 0).Symbol != Board.EMPTY_TILE &&
                           _board.TileAt(row_number, 1).Symbol != Board.EMPTY_TILE &&
                           _board.TileAt(row_number, 2).Symbol != Board.EMPTY_TILE;
        }
    }
}
