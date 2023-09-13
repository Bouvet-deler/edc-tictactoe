namespace tictactoe
{
    public class Board //TODO: Large class (file). Move to separate file
    {
        private List<Tile> _plays = new List<Tile>();

        public Board()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {

            for (int i = 0; i < Constants.BOARDSIZE; i++) 
            {
                for (int j = 0; j < Constants.BOARDSIZE; j++)
                {
                    _plays.Add(new Tile { X = i, Y = j, Symbol = Constants.EMPTYTILE });
                }
            }
        }

        public Tile GetTileAtPosition(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

        public void AddSymbolAtTile(int x, int y, char symbol)
        {
            GetTileAtPosition(x,y).Symbol = symbol;  
        }
    }
}
