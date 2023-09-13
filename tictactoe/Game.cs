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
                    _plays.Add(new Tile { X = i, Y = j, Symbol = ' ' });
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
            var newTile = new Tile //TODO: Dead code
            {
                X = x,
                Y = y,
                Symbol = symbol
            };

            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol; //Duplicate code
        }

        //Adds a X to the board
        public void AddXAt_old(int x, int y) //TODO: Dead code
        {
            var newTile = new Tile
            {
                X = x,
                Y = y,
                Symbol = 'X'
            };

            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = 'X'; //Duplicate code
        }
    }

    public class Game //TODO: Large class (low cohesion), correct data structure?
    {
        private char _lastSymbol = ' '; //TODO: Magic number, and it's everywhere
        private Board _board = new Board();

        public void Play(char symbol, int x, int y) //TODO: Long method, bad and inconsistent naming
        {
            //if first move
            if (_lastSymbol == ' ') //TODO: Readability
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
            else if (_board.TileAt(x, y).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        //Decide who lost //TODO: Comment, and its wrong
        public char Winner() //TODO: Long method, Duplicate code, Complicated if statements, bad name (begin with a verb)
        {   //if the positions in first row are taken
            if (_board.TileAt(0, 0).Symbol != ' ' &&
               _board.TileAt(0, 1).Symbol != ' ' &&
               _board.TileAt(0, 2).Symbol != ' ')
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
            if (_board.TileAt(1, 0).Symbol != ' ' &&
               _board.TileAt(1, 1).Symbol != ' ' &&
               _board.TileAt(1, 2).Symbol != ' ')
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
            if (_board.TileAt(2, 0).Symbol != ' ' &&
               _board.TileAt(2, 1).Symbol != ' ' &&
               _board.TileAt(2, 2).Symbol != ' ')
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

            return ' ';
        }
    }
}
