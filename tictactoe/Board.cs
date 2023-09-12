namespace tictactoe
{
    public class Board //TODO: Large class (file). Move to separate file
    {
        private List<Tile> _plays = new List<Tile>();
        private readonly int _boardSize = 3;

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
                    _plays.Add(new Tile { X = row, Y = column, Symbol = Symbol.Empty});
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y); //TODO: Duplicate code
        }

        //Adds a X to the board //TODO: Comment code smell, bad naming
        public void AddTileAt(Symbol symbol, int x, int y) //Inconsistent order of arguments
        {
            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;  //TODO: Duplicate code
        }
    }
}
