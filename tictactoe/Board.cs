namespace tictactoe
{
    public class Board
    {
        private List<Tile> _plays = new List<Tile>();

        public Board()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++) //TODO: magic numbers, 0 and 3, empty tile symbol
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile { X = i, Y = j, Symbol = ' ' });
                }
            }
        }

        public Tile GetTileAtPosition(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }


        public Tile GetTileAtPosition(Position position)
        {
            throw new NotImplementedException();
        }


        public void PlayATileAt(int x, int y, char symbol)
        {
            var tile = GetTileAtPosition(x, y);
            tile.Symbol = symbol;
        }
    }
}
