namespace tictactoe
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Mark { get; set; }
    }

    public class Board //TODO: Large class (uncohesive), correct data structure??
    {
        private List<Tile> _board = new List<Tile>(); //TODO: is this the correct data structure to use?

        public Board()
        {
            SetupBoard();
        }

        private void SetupBoard()
        {
            const int DimLength = 3;
            for (int i = 0; i < DimLength; i++)
            {
                for (int j = 0; j < DimLength; j++)
                {
                    _board.Add(new Tile { X = i, Y = j, Mark = Constants.Empty });
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _board.Single(tile => tile.X == x && tile.Y == y);
        }

        public void PlaceMark(char symbol, int x, int y)
        {

            _board.Single(tile => tile.X == x && tile.Y == y).Mark = symbol;
        }


    }


    public class Game //TODO: Large class (low cohesion), correct data structure?
    {
        private char _lastPlayer = Constants.Empty; 
        private Board _board = new Board();

        public void Play(char player, int x, int y) //TODO: Long method, bad and inconsistent naming
        {
            if (player == _lastPlayer || (_lastPlayer == Constants.Empty && player == Constants.Circle))
            {
                throw new Exception("Invalid next player");
            }
          
            else if (_board.TileAt(x, y).Mark != Constants.Empty)
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastPlayer = player;
            _board.PlaceMark(player, x, y);
        }

        //Decide who lost //TODO: Comment, and its wrong
        public char Winner() //TODO: Long method, Duplicate code, Complicated if statements, bad name (begin with a verb)
        {   //if the positions in first row are taken
            if (_board.TileAt(0, 0).Mark != Constants.Empty &&
               _board.TileAt(0, 1).Mark != Constants.Empty &&
               _board.TileAt(0, 2).Mark != Constants.Empty)
            {
                //if first row is full with same symbol.
                if (_board.TileAt(0, 0).Mark ==
                    _board.TileAt(0, 1).Mark &&
                    _board.TileAt(0, 2).Mark ==
                    _board.TileAt(0, 1).Mark)
                {
                    return _board.TileAt(0, 0).Mark;
                }
            }

            //if the positions in first row are taken
            if (_board.TileAt(1, 0).Mark != Constants.Empty &&
               _board.TileAt(1, 1).Mark != Constants.Empty &&
               _board.TileAt(1, 2).Mark != Constants.Empty)
            {
                //if middle row is full with same symbol //TODO: Comment, 
                if (_board.TileAt(1, 0).Mark ==
                    _board.TileAt(1, 1).Mark &&
                    _board.TileAt(1, 2).Mark ==
                    _board.TileAt(1, 1).Mark)
                {
                    return _board.TileAt(1, 0).Mark;
                }
            }

            //if the positions in first row are taken
            if (_board.TileAt(2, 0).Mark != Constants.Empty &&
               _board.TileAt(2, 1).Mark != Constants.Empty &&
               _board.TileAt(2, 2).Mark != Constants.Empty)
            {
                //if middle row is full with same symbol //TODO: Comment, and its wrong
                if (_board.TileAt(2, 0).Mark ==
                    _board.TileAt(2, 1).Mark &&
                    _board.TileAt(2, 2).Mark ==
                    _board.TileAt(2, 1).Mark)
                {
                    return _board.TileAt(2, 0).Mark;
                }
            }

            return Constants.Empty;
        }
    }
}
